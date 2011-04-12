using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Windows.Forms;
using Google.API.Translate;
using System.Collections;
using Utilities;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Reflection;
using System.Resources;
using SQLiteLayer;
using gDesktop.Update.Core;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Web.Security;
using System.Text;
using Media;

namespace gDesktopTranslator
{
    public partial class TranslatorToolMainForm : Form
    {
        public globalKeyboardHook gkh    = new globalKeyboardHook(); //Low-level hook
        KeyboardHook hook                = new KeyboardHook();                   //Hook for Register hot key  

        DateTime time                    = DateTime.Now;
        const long threshold             = 1000; //time for double pressing ctrl+c
        // New point that will be updated by the function with the current coordinates
        Point defPnt = new Point();

        Language from;                   //Language to quick translate from
        Language to;                     //Language to quick translate to
        Language translateFromDef;       //Default "Translate from" Language. reading from parameters
        Language translateToDef;         //Default "Translate to" Language. reading from parameters
                                         //Details: http://code.google.com/p/gdesctop-translator/issues/detail?id=5
        Language intefraceLanguage;      //Language of GUI
        
        bool isMinOnClose;
        bool isMinOnStartUp;
        bool closing = false;
        bool useCache;
        bool updateFinished = true;//To indicate when thread for check updates is finished his work
        Thread oThread;

        public KeyEventHandler keh; 
        
        ResultForm resFrm                 = new ResultForm();
        ErrorListFrom errList             = new ErrorListFrom();
        AboutBox aboutForm                = new AboutBox();
        NewVersionInfo frm;

        PersistenceConnector cacheConnector;
        uint cacheHitCount;
        uint missHitCount;
        public delegate int restartDelegate(String u, int i);

        private AddTextToLearn addTTLForm;
        private TeachWord techForm;
        private ArrayList selectedBefore;

        private String key = "o6806642kbM7c5";

        private LearnWordViaSelectForm learnWordViaSelectForm;

        Language lastTranslatedFrom = 0;//Used for sguggesting better translation
        Language lastTranslatedTo = 0;//Used for sguggesting better translation

        Media.MP3Player mplayer;

        private int ttsRequestCount = 0; //User to track how many tts requests was sent
        private Object lockObject = new Object();

        public TranslatorToolMainForm()
        {
            InitializeComponent();
            //Create media player for playing Text-to-speach files
            mplayer = new MP3Player();

            readAppSettings();

            keh = new KeyEventHandler(gkh_KeyDown);

            //Filling combo boxes with languages
            ICollection<Language> languages = LanguageUtility.translatableCollection;
            foreach (Language lang in languages)
            {
                originalLanguageSelect.Items.Add(lang.ToString());
                destinationLanguageSelect.Items.Add(lang.ToString());
                
                //Selecting default languages 
                if (lang.Equals(translateFromDef))
                    originalLanguageSelect.SelectedIndex = originalLanguageSelect.Items.Count - 1;
                if (lang.Equals(translateToDef))
                    destinationLanguageSelect.SelectedIndex = destinationLanguageSelect.Items.Count - 1;
            }
            
            

            gkh.HookedKeys.Add(Keys.C);
            //gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += keh;

            //Registering global hotkey
            // register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(globalKeyPressed);
            // register the control + alt + o combination as hot key.
            try
            {
                hook.RegisterHotKey(gDesktopTranslator.ModifierKeys.Control | gDesktopTranslator.ModifierKeys.Alt, Keys.O);
            }
            catch (InvalidOperationException ex)
            {
                errList.errorslList.AppendText(DateTime.Now.ToString() + " Can't set global hot key [control + alt + o] " + ex.Message + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine + System.Environment.NewLine + "----------------------------------" + System.Environment.NewLine + ex.Data + System.Environment.NewLine + ex.ToString());
            }

            try
            {
                hook.RegisterHotKey(gDesktopTranslator.ModifierKeys.Control | gDesktopTranslator.ModifierKeys.Alt, Keys.F);
            }
            catch (InvalidOperationException ex)
            {
                errList.errorslList.AppendText(DateTime.Now.ToString() + " Can't set global hot key [control + alt + F] " + ex.Message + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine + System.Environment.NewLine + "----------------------------------" + System.Environment.NewLine + ex.Data + System.Environment.NewLine + ex.ToString());
            }

            InitializeCacheIfNeeded();
            CheckForUpdates();

            
            addTTLForm = new AddTextToLearn(cacheConnector,this);

            techForm = new TeachWord();
            techForm.mainForm = this;

            learnWordViaSelectForm = new LearnWordViaSelectForm();

            InitWordLearning();

            LocalizeAllForms();
        }

        private void CheckForUpdates()
        {
            //This method checks for application updates
            //Check maked in separate thread
            if (!Properties.Settings.Default.checkForUpdates)
                return;

            if (!updateFinished)
                return;
            try
            {
                updateFinished = false;
                UpdateUtility updutil = new UpdateUtility(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
                IWebProxy proxy = CunstructProxy();
                ThreadedUpdatesCheck updateCheck = new ThreadedUpdatesCheck(proxy, updutil, this);

                // Create the thread object, passing in the Alpha.Beta method
                // via a ThreadStart delegate. This does not start the thread.
                oThread = new Thread(new ThreadStart(updateCheck.CheckForUpdates));

                // Start the thread
                oThread.Start();
                
            }
            catch (Exception ex)
            {
                errList.errorslList.AppendText(DateTime.Now.ToString() + " Error occured when try to check for updates " + ex.Message + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine + System.Environment.NewLine + "----------------------------------" + System.Environment.NewLine + ex.Data + System.Environment.NewLine + ex.ToString());
            }
        }

        private IWebProxy CunstructProxy()
        {
            if (!Properties.Settings.Default.ifUserProxy)
                return null;
            IWebProxy proxy = new WebProxy(Properties.Settings.Default.ProxyAdress);
            proxy.Credentials = new NetworkCredential(Properties.Settings.Default.ProxyUserName,
                                                      Encoding.Unicode.GetString(Convert.FromBase64String(Properties.Settings.Default.ProxyPassword)),
                                                      Properties.Settings.Default.ProxyDomain);

            return proxy;
        }

        private void InitializeCacheIfNeeded()
        {
            //[Implementing Issue 3: Add caching possibilities for this programm]
            //http://code.google.com/p/gdesctop-translator/issues/detail?id=3
            //20/03/2010
            try
            {
                //if (useCache)
                cacheConnector = new PersistenceConnector(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
                //else
                //    cacheConnector = null;
            }
            catch (Exception ex)
            {
                cacheConnector = null;
                logException(ex);
                useCache = false;
            }
        }

        public void logException(Exception ex)
        {
            errList.errorslList.AppendText(DateTime.Now.ToString() + " " + ex.Message + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine + System.Environment.NewLine + "----------------------------------" + System.Environment.NewLine + ex.Data + System.Environment.NewLine + ex.ToString());
            MessageBox.Show("An Exception occured." + System.Environment.NewLine + "For details open Error List from: File->Translations Error List", Application.ProductName);
        }
        
        private void readAppSettings()
        {
            from = (Language) Enum.Parse(typeof(Language),Properties.Settings.Default.QuickTranslateFromLanguage,false);
            to   = (Language) Enum.Parse(typeof(Language), Properties.Settings.Default.QuickTranslateToLanguage, false);
            intefraceLanguage = (Language)Enum.Parse(typeof(Language), Properties.Settings.Default.InterfaceLanguage, false);

            translateFromDef = (Language)Enum.Parse(typeof(Language), Properties.Settings.Default.defaultLangFrom, false);
            translateToDef = (Language)Enum.Parse(typeof(Language), Properties.Settings.Default.dafaultlangTo, false);

            isMinOnClose = Properties.Settings.Default.minToTrayOnClose;
            isMinOnStartUp = Properties.Settings.Default.minToTrayAtStart;
            useCache = Properties.Settings.Default.useCache;
            mplayer.VolumeAll = Properties.Settings.Default.SoundVolume;
        }

        //Processed key input from low level hook
        public void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            //We need Ctrl+C combination
            if (!ifControlPressed())
                return;
            DateTime buf = time;
            time = DateTime.Now;
            //Check if pressed twice quickly
            
            
            if ((time - buf).TotalMilliseconds < threshold)
            {
                String source = GetTextFromClipboard().Trim();
                if (source.Length == 0)
                    return;
                String result = source;
                try
                {
                    result = CachedTranslateRequest(source, from, to);
                    addTTLForm.Hide();
                    GetCursorPos(ref defPnt);
                    resFrm.resultEdit.Text = result;
                    resFrm.source = source;
                    resFrm.addForm = addTTLForm;
                    resFrm.Show();
                    resFrm.Location = defPnt;
                    resFrm.hideFormTimer.Enabled = false;
                    resFrm.hideFormTimer.Enabled = true;
                }
                catch (TranslateException ex)
                {
                    logException(ex);
                }
            }
        }

        private string CachedTranslateRequest(string source, Language from, Language to)
        {
            String result = source;

            if (useCache)
                result = cacheConnector.get(source, LanguageUtility.GetLanguageCode(from), LanguageUtility.GetLanguageCode(to));
            if (result.Equals(source) || !useCache) //Cache not contain translation
            {
                String translation = Translator.Translate(source, from, to,
                                        Properties.Settings.Default.ifUserProxy,
                                        Properties.Settings.Default.ProxyUserName,
                                        Encoding.Unicode.GetString(Convert.FromBase64String(Properties.Settings.Default.ProxyPassword)),
                                        Properties.Settings.Default.ProxyAdress,
                                        Properties.Settings.Default.ProxyDomain);

                Properties.Settings.Default.TotalTranslateCount++;
                totalCtn.Text = Properties.Settings.Default.TotalTranslateCount.ToString();
                //Properties.Settings.Default.Save();

                if (useCache && !translation.Equals(source))
                {
                    cacheConnector.put(source, LanguageUtility.GetLanguageCode(from), LanguageUtility.GetLanguageCode(to), translation);
                    missHitCount++;
                }

                lastTranslatedFrom = from;
                lastTranslatedTo = to;

                return translation;
            }
            else
            {
                cacheHitCount++;
                return result;
            }
        }

        private void tanslateBtn_Click(object sender, EventArgs e)
        {
            translateToBox.Clear();
            Translator.Timeout = Int32.MaxValue;
            statusLabel.Text = "Status: idle";
            String source = translateFromBox.Text.Trim();
            if (source.Length == 0)
                return;
            
            statusLabel.Text = "Status: translating...";
            Application.DoEvents();
            Language srcLng = (Language)   Enum.Parse(typeof(Language),originalLanguageSelect.Text,false);
            Language destLng = (Language)   Enum.Parse(typeof(Language),destinationLanguageSelect.Text,false);
            String result;
            for (int i = 0; i < translateFromBox.Lines.Length; ++i)
            {
                source = translateFromBox.Lines[i].Trim();
                result = source;

                if (source.Length > 0)
                {
                    try
                    {
                        result = CachedTranslateRequest(source, srcLng, destLng);
                    }
                    catch (TranslateException ex)
                    {
                        logException(ex);
                    }
                }
                //MessageBox.Show(result);
                translateToBox.AppendText(result+System.Environment.NewLine);
            }
            destinationLanguageSelect_TextChanged(null, null);
            statusLabel.Text = "Status: idle...";
        }

        private void detectLanguageBtn_Click(object sender, EventArgs e)
        {
            
            String source = translateFromBox.Text.Trim();
            if (source.Length == 0)
                return;

            statusLabel.Text = "Status: detecting language...";
            Application.DoEvents();
            bool isReliable;
            double confidence;
            Language result = Language.Unknown; ;
            try
            {
                result = Translator.Detect(source, out isReliable, out confidence,
                                                    Properties.Settings.Default.ifUserProxy,
                                                    Properties.Settings.Default.ProxyUserName,
                                                    Encoding.Unicode.GetString(Convert.FromBase64String(Properties.Settings.Default.ProxyPassword)),
                                                    Properties.Settings.Default.ProxyAdress,
                                                    Properties.Settings.Default.ProxyDomain);
            }
            catch (TranslateException ex)
            {
                logException(ex);
            }
            detectedLanguageLabel.Text = result.ToString();
            statusLabel.Text = "Status: idle";
        }

        /// <summary>
        /// Get Text in ClipBoard
        /// </summary>
        /// <returns>text in ClipBoard, 
        /// empty String if no text is in it</returns>
        /// <example>
        /// string text = ClipBoardHelper.GetText();
        /// </example>
        public static string GetTextFromClipboard()
        {
            IDataObject dataObj = Clipboard.GetDataObject();

            if (!dataObj.GetDataPresent(DataFormats.Text))
                return "";

            return dataObj.GetData(DataFormats.Text).ToString();

        }

        private void TranslatorToolMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //gkh.unhook();
            //Properties.Settings.Default.Save();
            //MessageBox.Show(oThread.ThreadState.ToString() + " " + System.Threading.ThreadState.Running.ToString());
            if (isMinOnClose && !closing)
            {
                e.Cancel = true;
                Hide();
                return;
            }
            else if (oThread != null /*&& oThread.ThreadState == System.Threading.ThreadState.Running*/)
            {
                oThread.Join();
            }
            Properties.Settings.Default.defaultLangFrom = originalLanguageSelect.Text;
            Properties.Settings.Default.dafaultlangTo = destinationLanguageSelect.Text;
            Properties.Settings.Default.Save();

            mplayer.Close();
        }

        public static bool ifControlPressed()
        {
            return GetAsyncKeyState(Keys.RControlKey) || GetAsyncKeyState(Keys.LControlKey);
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            closing = true;
            this.Close();
        }

        private void translationsErrorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errList.errorslList.SelectionStart = 0;
            errList.errorslList.SelectionLength = 0;
            errList.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutForm.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sForm = new SettingsForm();
            sForm.readSettings();
            //Filling combo boxes with languages
            ICollection<Language> languages = LanguageUtility.translatableCollection;
            foreach (Language lang in languages)
            {
                sForm.comboBoxTranslateFrom.Items.Add(lang.ToString());
                sForm.comboBoxTranslateTo.Items.Add(lang.ToString());
            }

            localizeForm(sForm, getCurrentCulture());
            sForm.ShowDialog();
            readAppSettings();
            InitializeCacheIfNeeded();
            InitWordLearning();
        }

        private void InitWordLearning()
        {
            learningTimer.Enabled = Properties.Settings.Default.LearningEnabled;
            learnWordsToolStripMenuItem.Checked = Properties.Settings.Default.LearningEnabled;
            learningTimer.Interval = (int)Properties.Settings.Default.LearnIntervalInMinutes * 60 * 1000; //In milliseconds
        }

        private void TranslatorToolMainForm_Shown(object sender, EventArgs e)
        {
            if (isMinOnStartUp)
                Hide();
        }

        private void TranslatorToolMainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
                Hide();
        }

        private void globalKeyPressed(object sender, EventArgs e)
        {
            KeyPressedEventArgs  kpa =(KeyPressedEventArgs) e;
            if (kpa.Key == Keys.O)
                notifyIcon_DoubleClick(sender, e);
            else if (kpa.Key == Keys.F)
                searchTextFromClipboardInToolStripMenuItem_Click(sender,e);
        }
        
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Activate();
            translateFromBox.Focus();
            translateFromBox.SelectAll();
        }

        private void TranslatorToolMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //gkh.unhook();
            Properties.Settings.Default.Save();
        }

        private void LocalizeAllForms()
        {
            CultureInfo cultInfo = getCurrentCulture();
            
            localizeForm(this, cultInfo);
            localizeForm(errList, cultInfo);
            localizeForm(aboutForm, cultInfo);
            localizeForm(addTTLForm, cultInfo);
            localizeForm(techForm, cultInfo);
            localizeForm(learnWordViaSelectForm, cultInfo);
            localizeForm(resFrm, cultInfo);
            

            if (Properties.Settings.Default.InterfaceLanguage == Language.English.ToString())
            {
                englishToolStripMenuItem.Checked = true;
                ukrainianToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = false;
            }
            else if (Properties.Settings.Default.InterfaceLanguage == Language.Ukranian.ToString())
            {
                englishToolStripMenuItem.Checked = false;
                ukrainianToolStripMenuItem.Checked = true;
                russianToolStripMenuItem.Checked = false;
            }
            else if (Properties.Settings.Default.InterfaceLanguage == Language.Russian.ToString())
            {
                englishToolStripMenuItem.Checked = false;
                ukrainianToolStripMenuItem.Checked = false;
                russianToolStripMenuItem.Checked = true;
            }
            totalCtn.Text = Properties.Settings.Default.TotalTranslateCount.ToString();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.InterfaceLanguage = Language.English.ToString();
            readAppSettings();
            LocalizeAllForms();
        }

        private void ukrainianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.InterfaceLanguage = Language.Ukranian.ToString();
            readAppSettings();
            LocalizeAllForms();
        }

        public void localizeForm(Form someForm, CultureInfo cultureInfo)  
        {
            Type someFormType = someForm.GetType();  
            ResourceManager res = new ResourceManager(someFormType);  
  
            //зададим список свойств объектов, которые будем извлекать из файла ресурсов  
            string[] properties = { "Text", "Location" };  
  
            foreach (string propertyName in properties)  
            {  
                //выбор всех свойств класса формы, извлечение из файла ресурсов значения, и их установка  
                foreach (FieldInfo fieldInfo in someFormType.GetFields(BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance))  
                {  
                    PropertyInfo propertyInfo = fieldInfo.FieldType.GetProperty(propertyName);  
                    if (propertyInfo == null)  
                        continue;  
                    object objProperty = res.GetObject(fieldInfo.Name + '.' + propertyInfo.Name, cultureInfo);  
                    if (objProperty == null) continue;  
                    object field = fieldInfo.GetValue(someForm);  
                    if (field != null)  
                        propertyInfo.SetValue(field, objProperty, null);  
                }  
                //код для установки свойств самих форм  
                PropertyInfo propertyInfo1 = someFormType.GetProperty(propertyName);  
                if (propertyInfo1 == null)  
                    continue;  
                object objProperty1 = res.GetObject("$this." + propertyInfo1.Name, cultureInfo);  
                if (objProperty1 == null) continue;  
                propertyInfo1.SetValue(someForm, objProperty1, null);  
            }  
        }

        private void swapButton_Click(object sender, EventArgs e)
        {
            String original = originalLanguageSelect.Text;
            String destination = destinationLanguageSelect.Text;
            int idx = originalLanguageSelect.FindStringExact(original);
            destinationLanguageSelect.SelectedIndex = idx;

            idx = destinationLanguageSelect.FindStringExact(destination);
            originalLanguageSelect.SelectedIndex = idx;

            //Swap original and result text as well
            //String tmp = translateFromBox.Text;
            //translateFromBox.Text = translateToBox.Text;
            //translateToBox.Text = tmp;
        }

        private void copyResultToClipboard_Click(object sender, EventArgs e)
        {
            if (translateToBox.SelectedText.Length == 0)
                translateToBox.SelectAll();
            //Not to copy format of Rich BOx Element
            Clipboard.SetText(translateToBox.SelectedText, TextDataFormat.UnicodeText);
            //translateToBox.Copy();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            translateFromBox.Text = GetTextFromClipboard().Trim();
        }

        private void pasteAndTranslate_Click(object sender, EventArgs e)
        {
            pasteButton_Click(sender,e);
            tanslateBtn_Click(sender, e);
        }

        private void originalLanguageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.defaultLangFrom = originalLanguageSelect.Text;
        }

        private void destinationLanguageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.dafaultlangTo = destinationLanguageSelect.Text;
        }

        [DllImport("user32.dll")]
        static extern bool GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        // We need to use unmanaged code
        [DllImport("user32.dll")]

        // GetCursorPos() makes everything possible
        static extern bool GetCursorPos(ref Point lpPoint);

        private void cacheStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CacheUsageStatsForm cacheStatsFrm = new CacheUsageStatsForm();
            if (cacheConnector != null)
                cacheStatsFrm.cacheServerVersion.Text = cacheConnector.getServerVersion();
            else
                cacheStatsFrm.cacheServerVersion.Text = "(None)";
            if (useCache)
                cacheStatsFrm.cacheInUse.Text = "Yes";
            else
                cacheStatsFrm.cacheInUse.Text = "No";

            cacheStatsFrm.cacheHits.Text = cacheHitCount.ToString();
            cacheStatsFrm.cacheMisses.Text = missHitCount.ToString();
            localizeForm(cacheStatsFrm, getCurrentCulture());
            if (!useCache)
            {
                cacheStatsFrm.clearCache.Enabled = false;
                cacheStatsFrm.deleteOldDRecordsBtn.Enabled = false;
                cacheStatsFrm.recordsinCache.Text = "Unknown";
                cacheStatsFrm.cacheSizeLabel.Text = "Unknown";
            }
            else
            {
                cacheStatsFrm.clearCache.Enabled = true;
                cacheStatsFrm.deleteOldDRecordsBtn.Enabled = true;
                cacheStatsFrm.recordsinCache.Text = cacheConnector.cacheRecordsCount().ToString();
                cacheStatsFrm.cacheSizeLabel.Text = cacheConnector.getCacheSizeInKB();
            }

            cacheStatsFrm.ShowDialogEx(cacheConnector);
        }

        private CultureInfo getCurrentCulture()
        {
            CultureInfo cultInfo;
            if (intefraceLanguage.Equals(Language.English))
            {
                cultInfo = new CultureInfo("en");
            }
            else if (intefraceLanguage.Equals(Language.Ukranian))
            {
               cultInfo = new CultureInfo("uk-UA");
            }
            else
               cultInfo = new CultureInfo("ru-RU");
            return cultInfo;
        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            translateFromBox.Clear();
            translateToBox.Clear();
            translateFromBox.Focus();
        }

        private void searchTextFromClipboardInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String text = GetTextFromClipboard().Trim();
            if (text.Length > 0 && text.Length <= 200)
                System.Diagnostics.Process.Start("http://www.google.com/#q=" + HttpUtility.UrlEncode(text));
        }

        public void UpdateNeeded(UpdateUtility u)
        {
            if (frm != null)
                return;
            updateInfoStatusLabel.Text ="New version avaliable " + u.updateData.version;
            updateFinished = true;
            frm = new NewVersionInfo();
            frm.versionInfoGB.Text = "What's new in version " + u.updateData.version;
            for (int i = 0; i < u.updateData.newOptions.Count; ++i)
            {
                frm.optionsList.AppendText(u.updateData.newOptions[i].ToString() + System.Environment.NewLine);
            }
            frm.optionsList.SelectionStart = 0;
            frm.optionsList.SelectionLength = 0;
            frm.linkLabel.Text = u.updateData.infoURL;
            
            if (DialogResult.Yes ==frm.ShowDialog() )
            {
                System.Diagnostics.Process.Start(u.updateData.infoURL);
                //try
                //{
                //    u.downloadFilesForUpdate();
                //    if (u.ifUpdate)
                //    {
                //        //Clipboard.SetText(Path.GetDirectoryName(Application.ExecutablePath));
                //        String path = Path.GetDirectoryName(Application.ExecutablePath);
                //        //MessageBox.Show(Path.Combine(path, "gDesktop.Update.Util.exe"));
                //        System.Diagnostics.Process.Start(Path.Combine(path, "gDesktop.Update.Util.exe"));
                //        ExitMenuItem_Click(this,null);                        
                //    }
                //}
                //catch (Exception ex)
                //{
                //    logException(ex);
                //    frm = null;
                //}
            }
            frm = null;
            updateFinished = true;
        }

        public void NoNeedUpdate()
        {
            updateFinished = true;
            updateInfoStatusLabel.Text = "You have a latest version.";
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        private void TranslatorToolMainForm_Load(object sender, EventArgs e)
        {

        }

        private void languageHistoryBtn_Click(object sender, EventArgs e)
        {
            GetCursorPos(ref defPnt);
            langHistoryMenuStrip.Show(defPnt.X,defPnt.Y);
        }

        private void destinationLanguageSelect_TextChanged(object sender, EventArgs e)
        {
            String menuItem = originalLanguageSelect.Text+" -> "+ destinationLanguageSelect.Text;
            for (int i = 0; i < langHistoryMenuStrip.Items.Count; ++i)
            {
                if (menuItem.Equals(langHistoryMenuStrip.Items[i].Text))
                    return;
            }
            langHistoryMenuStrip.Items.Add(menuItem, null, new System.EventHandler(this.applyLang_Click));
        }

        private void applyLang_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string[] langs = item.Text.Split(new Char[] { '-', '>'});
            int idx = originalLanguageSelect.FindStringExact(langs[0].Trim());
            originalLanguageSelect.SelectedIndex = idx;
            idx = destinationLanguageSelect.FindStringExact(langs[2].Trim());
            destinationLanguageSelect.SelectedIndex = idx;
        }

        private void applyInputLanguage()
        {

            if (LanguageUtility.s_InputLanguage.ContainsKey((Language)Enum.Parse(typeof(Language), originalLanguageSelect.Text, false)))
            {
                for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; ++i)
                    if (InputLanguage.InstalledInputLanguages[i].Culture.EnglishName.Equals(LanguageUtility.s_InputLanguage[(Language)Enum.Parse(typeof(Language), originalLanguageSelect.Text, false)]))
                    {
                        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                        return;
                    }
            }
        }

        private void originalLanguageSelect_TextChanged(object sender, EventArgs e)
        {
            applyInputLanguage();    
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addTTLForm.ShowDialog();
        }

        private void learningTimer_Tick(object sender, EventArgs e)
        {
            //When time to learn words - shows form with words for learning
            try //Catch all exceptions
            {
                //Hide forms before next learning session
                learnWordViaSelectForm.Hide();
                techForm.Hide();

                //Decide what method should we use
                //Generate random number from 0 to 1
                //if 1 - then via select
                //if 0 - then simple window with text and translation
                
                Random rnd = new Random();
                int variant = rnd.Next(2);

                //But if we have less than 6 words to learn, that always will be used simple window (variant = 0)
                long wordCount = cacheConnector.getCountWordsForLearning();
                if (wordCount < Properties.Settings.Default.LearnViaSelectThreshold)
                    variant = 0;

                if (variant == 1)
                    LearnWordsViaSelect_Start(null, null);
                else
                {
                    selectedBefore = new ArrayList();
                    int result = getNextRecord();
                    if (result == -1 || result == -2)
                        return;
                    techForm.Show();
                    techForm.Positionate();
                    techForm.label1.Focus();
                }
            }
            catch (Exception ex)
            {
                logException(ex);
            }
        }
        public int getNextRecord()
        {
            if (techForm.getRecordId() != -1)
                cacheConnector.increaseLearnCount(techForm.getRecordId());
            //if (techForm.record.learnCount >= Properties.Settings.Default.MarkASLearnderAfterShownTimes)
            //    cacheConnector.markAsLearned(techForm.getRecordId());
            if (selectedBefore.Count >= Properties.Settings.Default.WordsPerSession)
            {
                techForm.Hide();
                return -2;
            }
            LeardWordRecord record = cacheConnector.getNextRecordForLearning(selectedBefore);
            if (record.id == -1)
            {
                techForm.Hide();
                return -1;
            }
            techForm.record = record;
            techForm.visualize();
            selectedBefore.Add(record.id);
            return 0;
        }

        public void markWordAsLearned(long id)
        {
            try
            {
                cacheConnector.markAsLearned(id);
            }
            catch (Exception ex)
            {
                logException(ex);
            }
        }

        public void markToLearn(long id)
        {
            try
            {
                cacheConnector.markToLearn(id);
            }
            catch (Exception ex)
            {
                logException(ex);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        public void viewWordsForLearningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EditWordsForLearningForm form = new EditWordsForLearningForm();
                localizeForm(form, getCurrentCulture());
                refreshWordsGrid(form);
                form.mainForm = this;
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                logException(ex);
                return;
            }
        }
        public void deleteAllLearningRecords()
        {
            try
            {
                cacheConnector.deleteAllLearningRecords();
            }
            catch (Exception ex)
            {
                logException(ex);
            }
        }

        public void deleteLearnRecord(long id)
        {
            try
            {
                cacheConnector.deleteRowForLearning(id);
            }
            catch (Exception ex)
            {
                logException(ex);
            }
        }

        public void refreshWordsGrid(EditWordsForLearningForm form)
        {
            form.wordsGridView.Rows.Clear();
            SQLiteDataReader dr = cacheConnector.getLearnRecords();
            while (dr.Read())
            {
                String val = "";
                if (dr.GetInt64(3) == 0) //Word learnded
                    val = " No";
                else
                    val = "Yes";
                form.wordsGridView.Rows.Add(new object[] { dr.GetInt64(0), dr.GetString(1), dr.GetString(2), val, dr.GetInt64(4) });
            }
        }

        private void learnWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LearningEnabled = !learnWordsToolStripMenuItem.Checked;
            learnWordsToolStripMenuItem.Checked = !learnWordsToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            InitWordLearning();
        }

        private void learnThisBtn_Click(object sender, EventArgs e)
        {
            if (translateFromBox.Text.Trim().Length == 0 || translateToBox.Text.Trim().Length == 0)
            {
                return;
            }
            addTTLForm.PrepareAdd(translateFromBox.Text, translateToBox.Text, this, false); 
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.InterfaceLanguage = Language.Russian.ToString();
            readAppSettings();
            LocalizeAllForms();
        }

        private void LearnWordsViaSelect_Start(object sender, EventArgs e)
        {
            try
            {
                selectedBefore = new ArrayList();
                int result = getNextRecordForSelect();
                if (result == -1 || result == -2)
                    return;
                

                learnWordViaSelectForm.Show();
                learnWordViaSelectForm.Positionate();
                //techForm.label1.Focus();
            }
            catch (Exception ex)
            {
                logException(ex);
            }
        }

        public int getNextRecordForSelect()
        {
            if (selectedBefore.Count >= Properties.Settings.Default.WordsPerSession)
            {
                selectedBefore.Clear();
                learnWordViaSelectForm.Hide();
                return -2;
            }
            if (learnWordViaSelectForm.getRecordId() != -1)
                cacheConnector.increaseLearnCount(learnWordViaSelectForm.getRecordId());
            //if (techForm.record.learnCount >= Properties.Settings.Default.MarkASLearnderAfterShownTimes)
            //    cacheConnector.markAsLearned(techForm.getRecordId());
            if (selectedBefore.Count >= Properties.Settings.Default.WordsPerSession)
            {
                techForm.Hide();
                return -2;
            }

            ArrayList optionsIdx = new ArrayList();
            LeardWordRecord[] opts = new LeardWordRecord[4];
            ArrayList selectedOptions = new ArrayList();
            //ArrayList options = new ArrayList(4);

            Random rnd = new Random();
            
            int  index = 0;
            //selectedBefore.Clear();

            for (int i = 0; optionsIdx.Count < 4; ++i )
            {
                index = rnd.Next(4);
                if (!optionsIdx.Contains(index))
                {
                    optionsIdx.Add(index);

                    LeardWordRecord record;

                    if (i == 0)
                    {
                        record = cacheConnector.getNextRecordForLearning(selectedBefore);
                        learnWordViaSelectForm.correctOption = index;
                        selectedBefore.Add(record.id);
                    }
                    else
                        record = cacheConnector.getNextRecordForLearning(selectedOptions);
                     
                    if (record.id == -1)
                    {
                        learnWordViaSelectForm.Hide();
                        return -1;
                    }
                    opts[index] = record;
                    //learnWordViaSelectForm.record = record;
                    selectedOptions.Add(record.id);
                }
            }
            learnWordViaSelectForm.options = new ArrayList(opts);            

            //Getting Answers
            //LeardWordRecord record1 = cacheConnector.getNextRecordForLearning(selectedBefore);
            //if (record.id == -1)
            //{
            //    learnWordViaSelectForm.Hide();
            //    return -1;
            //}
            //learnWordViaSelectForm.record1 = record1; 

            //LeardWordRecord record2 = cacheConnector.getNextRecordForLearning(selectedBefore);
            //if (record.id == -1)
            //{
            //    learnWordViaSelectForm.Hide();
            //    return -1;
            //}
            //learnWordViaSelectForm.record2 = record2;

            //LeardWordRecord record3 = cacheConnector.getNextRecordForLearning(selectedBefore);
            //if (record.id == -1)
            //{
            //    learnWordViaSelectForm.Hide();
            //    return -1;
            //}
            //learnWordViaSelectForm.record3 = record3;

            learnWordViaSelectForm.mainForm = this;
            
            learnWordViaSelectForm.visualize();
            
            
            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Language srcLng = (Language)Enum.Parse(typeof(Language), originalLanguageSelect.Text, false);
            Language destLng = (Language)Enum.Parse(typeof(Language), destinationLanguageSelect.Text, false);
            String result = Translator.TranslateWithDictInfo("test", srcLng, destLng,  Properties.Settings.Default.ifUserProxy,
                                        Properties.Settings.Default.ProxyUserName,
                                        Encoding.Unicode.GetString(Convert.FromBase64String(Properties.Settings.Default.ProxyPassword)),
                                        Properties.Settings.Default.ProxyAdress,
                                        Properties.Settings.Default.ProxyDomain);
            translateToBox.Text = result;
            //MessageBox.Show(result);
        }

        private void toolStripDropDownButton1_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                String rawText = translateFromBox.Text.Trim();
                String original;
                if (Translator.RequestedWithDict)
                {
                    String txt = translateToBox.Text.Trim();
                    int comaIdx = txt.IndexOf(',');
                    if (comaIdx > 0)
                        original = txt.Substring(0, comaIdx);
                    else
                        original = txt;
                }
                else
                    original = translateToBox.Text.Trim();
                
                if (original.Length == 0 || rawText.Length == 0)
                    return;

                if (lastTranslatedFrom == Language.Unknown || lastTranslatedTo == Language.Unknown)
                    return;

                SuggestBetterTranslationForm form = new SuggestBetterTranslationForm();
                localizeForm(form, getCurrentCulture());
                form.suggestTextBox.Text = original;
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    statusLabel.Text = "Status: suggesting better translation...";
                    Application.DoEvents();
                    String suggestion = form.suggestTextBox.Text;

                    Language srcLng = (Language)Enum.Parse(typeof(Language), originalLanguageSelect.Text, false);
                    Language destLng = (Language)Enum.Parse(typeof(Language), destinationLanguageSelect.Text, false);

                    bool res = Translator.SuggestBetterTranslation(rawText, original, suggestion,lastTranslatedFrom,lastTranslatedTo, CunstructProxy());

                    statusLabel.Text = "Status: Suggestion done. Idle...";
                    Application.DoEvents();
                    return;
                }
            }
            catch (Exception ex)
            {
                logException(ex);
                statusLabel.Text = "Status: idle...";
                Application.DoEvents();
                return;
            }
        }

        private void hideWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void TranslatorToolMainForm_Activated(object sender, EventArgs e)
        {
            //translateFromBox.SelectAll();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (translateToBox.Text.Trim().Length == 0 || translateToBox.Text.Trim().Length > Translator.MAX_TTS_LENGTH)
            {
                errList.errorslList.AppendText(DateTime.Now.ToString() + " " + "Text to speech is too long or empty" + System.Environment.NewLine);
                return;
            }
            Language destLng = (Language)Enum.Parse(typeof(Language), destinationLanguageSelect.Text, false);
            incrementRequestCounter();
            ttsFailedLabel.Visible = false;
            Translator.getSpeechFile(translateToBox.Text.Trim(), LanguageUtility.GetLanguageCode(destLng), CunstructProxy(), new DownloadMp3Completed(job_Downloaded), new DownloadMp3Failed(job_Failed));
        }

        private void job_Downloaded(string text, string fileName)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    decrementRequestCounter();
                    mplayer.Open(fileName);
                    mplayer.VolumeAll = Properties.Settings.Default.SoundVolume;
                    mplayer.Play();
                });
            }
            catch (Exception ex)
            {
                String error = DateTime.Now.ToString() + " " + ex.Message + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine + System.Environment.NewLine + "----------------------------------" + System.Environment.NewLine + ex.Data + System.Environment.NewLine + ex.ToString();

                this.Invoke((MethodInvoker)delegate
                {
                    errList.errorslList.AppendText(error); // runs on UI thread
                });
            }
        }

        private void job_Failed(string text, string fileName, Exception ex)
        {
            //This will be called when download failed
            //logException(ex);
            String error = DateTime.Now.ToString() + " " + ex.Message + System.Environment.NewLine + ex.StackTrace + System.Environment.NewLine + System.Environment.NewLine + "----------------------------------" + System.Environment.NewLine + ex.Data + System.Environment.NewLine + ex.ToString();
            
            this.Invoke((MethodInvoker)delegate
            {
                ttsFailedLabel.Visible = true;
                decrementRequestCounter();
                errList.errorslList.AppendText(error); // runs on UI thread
            });

        }

        private void translateToBox_TextChanged(object sender, EventArgs e)
        {
            //If Text is allowed to be spoken by Google - then aenable button
            if (translateToBox.Text.Trim().Length > 0 && translateToBox.Text.Trim().Length < Translator.MAX_TTS_LENGTH)
            {
                btnListen.Enabled = true;
            }else{
                btnListen.Enabled = false;
            }
        }

        public void incrementRequestCounter()
        {
            lock (lockObject)
            {
                btnIndicator.Visible = true;
                ttsRequestCount++;
            }
        }

        public int getRequestCounter()
        {
            lock (lockObject)
            {
                return ttsRequestCount;
            }
        }

        public void decrementRequestCounter()
        {
            lock (lockObject)
            {
                if (ttsRequestCount == 1)
                {
                    btnIndicator.Visible = false;
                    ttsRequestCount--;
                }
                else if (ttsRequestCount < 0) ttsRequestCount = 0;
                else ttsRequestCount--;
            }
        }

    }
}
