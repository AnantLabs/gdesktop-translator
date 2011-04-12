using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gDesktop.Update.Core
{
    public partial class UpdateStatusForm : Form
    {
        public bool canceled = false;

        public UpdateStatusForm()
        {
            InitializeComponent();
            canceled = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            canceled = true;
        }
    }
}
