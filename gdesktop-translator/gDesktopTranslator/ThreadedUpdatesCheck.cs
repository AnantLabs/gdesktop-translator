using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using gDesktop.Update.Core;
using System.Windows.Forms;

namespace gDesktopTranslator
{
    class ThreadedUpdatesCheck
    {
        IWebProxy proxy;
        UpdateUtility util;
        TranslatorToolMainForm mainForm;
        public delegate void CallbackDelegate(UpdateUtility u);

        public ThreadedUpdatesCheck(IWebProxy p, UpdateUtility u,TranslatorToolMainForm frm)
        {
            proxy = p;
            util = u;
            mainForm = frm;
        }

        public void CheckForUpdates()
        {
            try
            {
                CallbackDelegate callbackDelegate = new CallbackDelegate(mainForm.UpdateNeeded);
                System.Threading.Thread.Sleep(3000);
                if (util.isNeedUpdate())
                {
                    object[] param = new object[1];
                    param[0] = util;
                    mainForm.BeginInvoke(callbackDelegate, param);

                }
            }
            catch (Exception ex)
            {
                mainForm.statusLabel.Text = "Status: Exception occured during checking for updates";
                System.Threading.Thread.CurrentThread.Abort();
            }
        }
    }
}
