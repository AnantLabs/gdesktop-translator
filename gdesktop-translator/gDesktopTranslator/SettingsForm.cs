using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Google.API.Translate;
using Microsoft.Win32;

namespace gDesktopTranslator
{
    public partial class SettingsForm : Form
    {
        //To work with registry
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        //bool canClose = false; //Details see http://code.google.com/p/gdesctop-translator/issues/detail?id=4

        
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //canClose = true;
            Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (userProxyCheck.Checked && proxyAddressEdit.Text.Trim().Length == 0)
            {
                MessageBox.Show("Fill proxy address","Error");
                return;
            }

            Properties.Settings.Default.minToTrayOnClose = minToTrayOnCloseCheck.Checked;
            Properties.Settings.Default.minToTrayAtStart = minToTrayAtStartCheck.Checked;
            Properties.Settings.Default.QuickTranslateFromLanguage = comboBoxTranslateFrom.Text;
            Properties.Settings.Default.QuickTranslateToLanguage = comboBoxTranslateTo.Text;

            Properties.Settings.Default.ifUserProxy = userProxyCheck.Checked;
            Properties.Settings.Default.ProxyUserName = proxyUserName.Text;
            Properties.Settings.Default.ProxyPassword = Convert.ToBase64String(Encoding.Unicode.GetBytes(proxyUserPassword.Text));
            Properties.Settings.Default.ProxyDomain = proxyUserDomain.Text;
            Properties.Settings.Default.ProxyAdress = proxyAddressEdit.Text;
            Properties.Settings.Default.useCache = useCacheBox.Checked;
            Properties.Settings.Default.checkForUpdates = checkForUpdates.Checked;
            Properties.Settings.Default.LearningEnabled = learningEnabledCheck.Checked;
            Properties.Settings.Default.LearnIntervalInMinutes = (long) runInterval.Value;
            Properties.Settings.Default.MarkASLearnderAfterShownTimes = (long)markAsLearnedAfter.Value;

            if (runAtStartupCheck.Checked)
            {
                if (!ifProgramStartsUp())
                    rkApp.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
            }
            else
            {
                if (ifProgramStartsUp())
                    rkApp.DeleteValue(Application.ProductName);
            }

            Properties.Settings.Default.SoundVolume = (short) soundVolume.Value;
            //canClose = true;
            Close();
        }

        public void readSettings()
        {
            //Reading app settings
            minToTrayAtStartCheck.Checked = Properties.Settings.Default.minToTrayAtStart;
            minToTrayOnCloseCheck.Checked = Properties.Settings.Default.minToTrayOnClose;
            String lngFrom = Properties.Settings.Default.QuickTranslateFromLanguage;
            String lngTo = Properties.Settings.Default.QuickTranslateToLanguage;

            //Select languages from app settings in combo boxes
            for (int i = 0; i < comboBoxTranslateFrom.Items.Count; ++i)
            {
                if (comboBoxTranslateFrom.Items[i].Equals(lngFrom))
                {
                    comboBoxTranslateFrom.SelectedIndex = i;
                    break;
                }
            }
            //Select languages from app settings in combo boxes
            for (int i = 0; i < comboBoxTranslateTo.Items.Count; ++i)
            {
                if (comboBoxTranslateTo.Items[i].Equals(lngTo))
                {
                    comboBoxTranslateTo.SelectedIndex = i;
                    break;
                }
            }
            runAtStartupCheck.Checked = ifProgramStartsUp();

            userProxyCheck.Checked = Properties.Settings.Default.ifUserProxy;
            proxyUserName.Text = Properties.Settings.Default.ProxyUserName;
            proxyUserPassword.Text = Encoding.Unicode.GetString(Convert.FromBase64String(Properties.Settings.Default.ProxyPassword));
            proxyUserDomain.Text = Properties.Settings.Default.ProxyDomain;
            proxyAddressEdit.Text = Properties.Settings.Default.ProxyAdress;
            useCacheBox.Checked = Properties.Settings.Default.useCache;
            checkForUpdates.Checked = Properties.Settings.Default.checkForUpdates;
            learningEnabledCheck.Checked = Properties.Settings.Default.LearningEnabled;
            runInterval.Value = Properties.Settings.Default.LearnIntervalInMinutes;
            markAsLearnedAfter.Value = Properties.Settings.Default.MarkASLearnderAfterShownTimes;

            soundVolume.Value = Properties.Settings.Default.SoundVolume;
        }

        //Check if app already starts up with system
        public bool ifProgramStartsUp()
        {
            Object val = rkApp.GetValue(Application.ProductName);
            if (val == null)
                return false;
            return true;
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            readSettings();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!canClose)
            //    e.Cancel = true;
        }
    }
}
