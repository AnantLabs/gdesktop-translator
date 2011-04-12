using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gDesktopTranslator
{
    public partial class EditWordsForLearningForm : Form
    {
        public TranslatorToolMainForm mainForm;
        public EditWordsForLearningForm()
        {
            InitializeComponent();
        }

        private void deleteAllBtn_Click(object sender, EventArgs e)
        {
            mainForm.deleteAllLearningRecords();
            mainForm.refreshWordsGrid(this);
        }

        private void removeRowBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (wordsGridView.SelectedCells == null || wordsGridView.Rows.Count == 0)
                    return;
                for (int counter = 0; counter < (wordsGridView.SelectedCells.Count); counter++)
                {
                    mainForm.deleteLearnRecord(Convert.ToInt64(wordsGridView.Rows[wordsGridView.SelectedCells[counter].RowIndex].Cells["id"].Value));
                }
                mainForm.refreshWordsGrid(this);
            }
            catch (Exception ex)
            {
                mainForm.logException(ex);
            }
        }

        private void learnAgain_Click(object sender, EventArgs e)
        {
            try
            {
                if (wordsGridView.SelectedCells == null || wordsGridView.Rows.Count == 0)
                    return;
                for (int counter = 0; counter < (wordsGridView.SelectedCells.Count); counter++)
                {
                    mainForm.markToLearn(Convert.ToInt64(wordsGridView.Rows[wordsGridView.SelectedCells[counter].RowIndex].Cells["id"].Value));
                }
                mainForm.refreshWordsGrid(this);
            }
            catch (Exception ex)
            {
                mainForm.logException(ex);
            }
        }
    }
}
