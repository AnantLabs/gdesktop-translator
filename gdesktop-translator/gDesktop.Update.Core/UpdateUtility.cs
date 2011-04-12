using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Threading;
using System.Diagnostics;

namespace gDesktop.Update.Core
{
    public class UpdateUtility
    {
        public const string updateInfoFile = "http://bytes.org.ua/gDesktopTranslatorUpdates/update.xml";
        private string localUpdateInfoFile;
        private string parentPath;
        private static System.Net.WebClient webClient = new System.Net.WebClient();
        private static System.Net.IWebProxy webProxy;
        private String updatePath;
        private String currentVersion = "0.4";
        private String updateFolder = "UpdateData";
        public UpdateData updateData = null;
        public delegate DialogResult ShowDialogDelegate();
        UpdateStatusForm usf;
        public delegate void SetTextCallback(String a);
        public delegate void IncValueDelegator();
        public String batFile;
        public bool ifUpdate;

        public UpdateUtility(String aPath)
        {
            updatePath = Path.Combine(aPath, updateFolder);
            parentPath = aPath;
            localUpdateInfoFile = Path.Combine(updateFolder, "update.txt");
            ifUpdate = false;
        }

        public void setProxy(IWebProxy prx)
        {
            webProxy = prx;
        }

        public bool isNeedUpdate()
        {
            if (updateData == null)
                checkForUpdates();

            if (currentVersion.Equals(updateData.version))
                return false;
            return true;
        }
        
        public UpdateData checkForUpdates()
        {
            //prepareProxy();
            prepareUpdateFolder();
            String contents = DownloadWebPage(updateInfoFile);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(new StringReader(contents));

            UpdateData updData = new UpdateData();

            System.Xml.XmlNodeList NodeList = xmlDoc.GetElementsByTagName("current"); // Create a list of the nodes in the xml file //
            updData.version = NodeList[0].InnerText.Trim();

            NodeList = xmlDoc.GetElementsByTagName("details");
            updData.infoURL = NodeList[0].InnerText.Trim();

            NodeList = xmlDoc.GetElementsByTagName("option");
            for (int i = 0; i < NodeList.Count; ++i)
            {
                updData.newOptions.Add(NodeList[i].InnerText.Trim());
            }

            NodeList = xmlDoc.GetElementsByTagName("file");
            for (int i = 0; i < NodeList.Count; ++i)
            {
                updData.fileToDownload.Add(NodeList[i].InnerText.Trim());
            }

            updateData = updData; 

            return updData;
        }

        private void prepareUpdateFolder()
        {

            if (!Directory.Exists(updatePath))
                Directory.CreateDirectory(updateFolder);
        }

        private void prepareProxy()
        {
            webClient.Proxy = webProxy;
        }

        /// <summary>
        /// Returns the content of a given web adress as string.
        /// </summary>
        /// <param name="Url">URL of the webpage</param>
        /// <returns>Website content</returns>
        private string DownloadWebPage(string Url)
        {
            // Open a connection
            HttpWebRequest WebRequestObject = (HttpWebRequest)HttpWebRequest.Create(Url);

            // You can also specify additional header values like 
            // the user agent or the referer:
            WebRequestObject.UserAgent = ".NET Framework/2.0";
            WebRequestObject.Proxy = webProxy;

            // Request response:
            WebResponse Response = WebRequestObject.GetResponse();

            // Open data stream:
            Stream WebStream = Response.GetResponseStream();

            // Create reader object:
            StreamReader Reader = new StreamReader(WebStream);

            // Read the entire stream content:
            string PageContent = Reader.ReadToEnd();

            // Cleanup
            Reader.Close();
            WebStream.Close();
            Response.Close();

            return PageContent;
        }

        public void downloadFilesForUpdate()
        {
            usf = new UpdateStatusForm();
            usf.progressBar.Maximum = updateData.fileToDownload.Count;
            usf.progressBar.Step = 1;
            usf.progressBar.Minimum = 0;
            usf.progressBar.Value = 0;
            prepareProxy();
            Thread oThread = new Thread(new ThreadStart(DownloadFiles));

            // Start the thread
            oThread.Start();

            usf.ShowDialog();
        }

        private void DownloadFiles() 
        {
            System.Threading.Thread.Sleep(1000);
            FileInfo f = null;
            StreamWriter w = null;

            try
            {
                batFile = Path.Combine(parentPath, "update.bat");
                f = new FileInfo(batFile);
                w = f.CreateText();
                w.WriteLine("ping 127.0.0.1 -n 1 > nul"); //for timeout

                for (int i = 0; i < updateData.fileToDownload.Count; ++i)
                {
                    String fileName = Path.GetFileName((String)updateData.fileToDownload[i]);
                    ThreadProcSafeText( "Downloading " + fileName);

                    String tmpFileName = Path.Combine(updatePath, fileName);
                    webClient.DownloadFile((String)updateData.fileToDownload[i], tmpFileName);
                    w.WriteLine("copy \""+tmpFileName+"\" \""+parentPath+"\"");
                    w.WriteLine("del \"" + tmpFileName + "\" /Q");

                    ThreadProcSafeIncValue(); //Safe call for usf.progressBar.Value++;
                    Application.DoEvents();
                    if (usf.canceled)
                    {
                        //ThreadProcSafeCloseForm();
                        return;
                    }
                }

                //w.WriteLine("del \""+updatePath+"\" * /Q");
                //w.WriteLine("\"" + Path.Combine(parentPath, "gDesktopTranslator.exe") + "\"");
                w.WriteLine("exit");
                ifUpdate = true;
            }
            finally
            {
                ThreadProcSafeCloseForm();
                if (w != null) w.Close();
            }
        }

        


        #region ThreadSafeOperation
        // If the calling thread is different from the thread that
        // created the TextBox control, this method passes in the
        // the SetText method to the SetTextCallback delegate and 
        // passes in the delegate to the Invoke method.
        private void ThreadProcSafeText(String text)
        {
            // Check if this method is running on a different thread
            // than the thread that created the control.
            if (usf.fileNameLabel.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                SetTextCallback d = new SetTextCallback(SetText);
                usf.Invoke(d, new object[] { text });
            }
            else
            {
                // It's on the same thread, no need for Invoke
                usf.fileNameLabel.Text = text ;
            }
        }
        
        // This method is passed in to the SetTextCallBack delegate
        // to set the Text property of textBox1.
        private void SetText(string text)
        {
            usf.fileNameLabel.Text = text;
        }

        // If the calling thread is different from the thread that
        // created the TextBox control, this method passes in the
        // the SetText method to the SetTextCallback delegate and 
        // passes in the delegate to the Invoke method.
        private void ThreadProcSafeIncValue()
        {
            // Check if this method is running on a different thread
            // than the thread that created the control.
            if (usf.progressBar.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                IncValueDelegator d = new IncValueDelegator(IncValue);
                usf.Invoke(d, null);
            }
            else
            {
                // It's on the same thread, no need for Invoke
                usf.progressBar.Value++;
            }
        }

        // This method is passed in to the SetTextCallBack delegate
        // to set the Text property of textBox1.
        private void IncValue()
        {
            usf.progressBar.Value++;
        }

        // If the calling thread is different from the thread that
        // created the TextBox control, this method passes in the
        // the SetText method to the SetTextCallback delegate and 
        // passes in the delegate to the Invoke method.
        private void ThreadProcSafeCloseForm()
        {
            // Check if this method is running on a different thread
            // than the thread that created the control.
            if (usf.InvokeRequired)
            {
                // It's on a different thread, so use Invoke.
                IncValueDelegator d = new IncValueDelegator(CloseForm);
                usf.Invoke(d, null);
            }
            else
            {
                // It's on the same thread, no need for Invoke
                usf.Close();
            }
        }

        // This method is passed in to the SetTextCallBack delegate
        // to set the Text property of textBox1.
        private void CloseForm()
        {
            usf.Close();
        }
        #endregion

    }

}
