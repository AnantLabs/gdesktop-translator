using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SQLiteLayer;

namespace gDesktopTranslator
{
    public partial class TeachWord : Form
    {
        public TeachWord()
        {
            InitializeComponent();
        }

        public LeardWordRecord record;
        
        public TranslatorToolMainForm mainForm;

        private void TeachWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        public void Positionate()
        {
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            this.Top = screenHeight - this.Height;
            this.Left = screenWidth - this.Width;
        }

        public void visualize()
        {
            wordEdit.Text = record.word;
            translationEdit.Text = record.translation;
            label1.Focus();
            wordEdit.Select(0, 0);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            mainForm.getNextRecord();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        public long getRecordId()
        {
            long l = record.id;
            return l;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            mainForm.markWordAsLearned(record.id);
            this.nextButton_Click(sender, e);
        }
    }
}
