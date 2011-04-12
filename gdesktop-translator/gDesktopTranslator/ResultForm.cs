using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SQLiteLayer;

namespace gDesktopTranslator
{
    public partial class ResultForm : Form
    {
        public String source;
        public AddTextToLearn addForm;
        public ResultForm()
        {
            InitializeComponent();
        }

        private void ResultForm_Shown(object sender, EventArgs e)
        {
            //for (int i = 0; i < 15; ++i)
            //    Thread.Sleep(100);

            //this.Hide();
        }

        private void ResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            hideFormTimer.Enabled = false;
            Hide();
        }

        private void hideFormTimer_Tick(object sender, EventArgs e)
        {
            hideFormTimer.Enabled = false;
            this.Hide();
        }

        private void resultEdit_Click(object sender, EventArgs e)
        {
            hideFormTimer.Enabled = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (resultEdit.SelectedText.Length == 0)
                resultEdit.SelectAll();
            resultEdit.Copy();
        }

        private void learnThisBtn_Click(object sender, EventArgs e)
        {
            //addForm.Visible = false;
            //addForm.Hide();
            addForm.PrepareAdd(source, resultEdit.Text,this,true);    
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void suggestTranslation_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    String rawText = translateFromBox.Text.Trim();
            //    String original;
            //    if (Translator.RequestedWithDict)
            //    {
            //        String txt = translateToBox.Text.Trim();
            //        int comaIdx = txt.IndexOf(',');
            //        if (comaIdx > 0)
            //            original = txt.Substring(0, comaIdx);
            //        else
            //            original = txt;
            //    }
            //    else
            //        original = translateToBox.Text.Trim();

            //    if (original.Length == 0 || rawText.Length == 0)
            //        return;

            //    if (lastTranslatedFrom == Language.Unknown || lastTranslatedTo == Language.Unknown)
            //        return;

            //    SuggestBetterTranslationForm form = new SuggestBetterTranslationForm();
            //    localizeForm(form, getCurrentCulture());
            //    form.suggestTextBox.Text = original;
            //    DialogResult result = form.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        statusLabel.Text = "Status: suggesting better translation...";
            //        Application.DoEvents();
            //        String suggestion = form.suggestTextBox.Text;

            //        Language srcLng = (Language)Enum.Parse(typeof(Language), originalLanguageSelect.Text, false);
            //        Language destLng = (Language)Enum.Parse(typeof(Language), destinationLanguageSelect.Text, false);

            //        bool res = Translator.SuggestBetterTranslation(rawText, original, suggestion, lastTranslatedFrom, lastTranslatedTo, CunstructProxy());

            //        statusLabel.Text = "Status: Suggestion done. Idle...";
            //        Application.DoEvents();
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logException(ex);
            //    statusLabel.Text = "Status: idle...";
            //    Application.DoEvents();
            //    return;
            //}
        }

    }
}
