using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace gDesktop.Update.Core
{
    public class UpdateData
    {
        public String version;
        public String infoURL;
        public ArrayList newOptions ;
        public ArrayList fileToDownload ;

        public UpdateData()
        {
            newOptions = new ArrayList();
            fileToDownload = new ArrayList();
        }
    }
}
