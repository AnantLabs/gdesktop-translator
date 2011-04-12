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
    public partial class AddTextToLearn : Form
    {
        PersistenceConnector cacheConnector;
        TranslatorToolMainForm mainForm;
        public AddTextToLearn(PersistenceConnector cc, TranslatorToolMainForm mainForm)
        {
            InitializeComponent();
            this.cacheConnector = cc;
            this.mainForm = mainForm;
        }

        public void PrepareAdd(String word, String translation, Form parentForm, bool ifClose)
        {
            if (ifClose)
                parentForm.Close();
            this.textToLearn.Text = word;
            this.translation.Text = translation;
            this.ShowDialog();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textToLearn.Text.Trim().Length == 0 || translation.Text.Trim().Length == 0 || categoryBox.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Please, input all parameters", "Error");
                    return;
                }
                cacheConnector.addTextToLearn(textToLearn.Text, translation.Text, categoryBox.Text);
                ClearFormData();
                Close();
            }
            catch (Exception ex)
            {
                mainForm.logException(ex);
            }
        }

        private void ClearFormData()
        {
            textToLearn.Clear();
            translation.Clear();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddTextToLearn_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClearFormData();
            e.Cancel = true;
            Hide();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void viewListBtn_Click(object sender, EventArgs e)
        {
            mainForm.viewWordsForLearningToolStripMenuItem_Click(sender, e);
        }
    }
}
