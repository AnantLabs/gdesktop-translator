using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gDesktopTranslator
{
    public partial class ErrorListFrom : Form
    {
        public ErrorListFrom()
        {
            InitializeComponent();
        }

        private void copyToClipboard_Click(object sender, EventArgs e)
        {
            errorslList.SelectAll();
            errorslList.Copy();
        }

        private void sendToAuthor_Click(object sender, EventArgs e)
        {
            if (errorslList.Text.Trim().Length > 0)
                System.Diagnostics.Process.Start("mailto:admin@bytes.org.ua?subject=Errors in gDesktopTranslator&body="+errorslList.Text);
        }

        private void closeWindow_Click(object sender, EventArgs e)
        {
            //We don't want tthat form was disposed!
            //Just hide it
            this.Hide();
        }

        private void ErrorListFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            //We don't want tthat form was disposed!
            e.Cancel = true;
            Hide();
        }
    }
}
