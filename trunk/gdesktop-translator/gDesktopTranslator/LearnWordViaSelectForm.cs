using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SQLiteLayer;

namespace gDesktopTranslator
{
    public partial class LearnWordViaSelectForm : Form
    {
        //public LeardWordRecord record;

        //public LeardWordRecord record1;//answers
        //public LeardWordRecord record2;
        //public LeardWordRecord record3;
        //public LeardWordRecord record4;

        public int correctOption;
        public ArrayList options;

        public TranslatorToolMainForm mainForm;
        
        public LearnWordViaSelectForm()
        {
            InitializeComponent();
        }

        private void LearnWordViaSelectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MarkAsLearnedBtn_Click(object sender, EventArgs e)
        {
            LeardWordRecord record = (LeardWordRecord)options[correctOption];
            mainForm.markWordAsLearned(record.id);
            this.NextBtn_Click(sender, e);
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            mainForm.getNextRecordForSelect();
        }

        public void Positionate()
        {
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            this.Top = screenHeight - this.Height;
            this.Left = screenWidth - this.Width;
        }

        public long getRecordId()
        {
            if (options == null)
                return -1;
            LeardWordRecord record = (LeardWordRecord)options[correctOption];
            long l = record.id;
            return l;
        }

        internal void visualize()
        {
            LeardWordRecord record = (LeardWordRecord)options[correctOption];
            textToLearnEdit.Text = record.word;

            record = (LeardWordRecord)options[0];
            variant1Btn.Text = record.translation;
            variant1Btn.ToolTipText = record.translation;

            record = (LeardWordRecord)options[1];
            variant2Btn.Text = record.translation;
            variant2Btn.ToolTipText = record.translation;

            record = (LeardWordRecord)options[2];
            variant3Btn.Text = record.translation;
            variant3Btn.ToolTipText = record.translation;

            record = (LeardWordRecord)options[3];
            variant4Btn.Text = record.translation;
            variant4Btn.ToolTipText = record.translation;

            this.variant1Btn.BackColor = System.Drawing.SystemColors.Control;
            this.variant2Btn.BackColor = System.Drawing.SystemColors.Control;
            this.variant3Btn.BackColor = System.Drawing.SystemColors.Control;
            this.variant4Btn.BackColor = System.Drawing.SystemColors.Control;

            this.variant1Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.variant2Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.variant3Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.variant4Btn.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        private void variant1Btn_Click(object sender, EventArgs e)
        {
            //Unified method to check results

            //Sender always must be ToolStripButton
            ToolStripButton button = (ToolStripButton)sender;
            int idx = Int32.Parse(button.Tag.ToString());
            //Every button for variant contain Tag with it's index
            //if index==correctoption, than user selected right word
            if (idx == correctOption)
            {
                this.NextBtn_Click(sender, e);
            }
            else
            {
                button.BackColor = System.Drawing.Color.Red;
                button.ForeColor = System.Drawing.Color.White;
            }

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ansversToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
