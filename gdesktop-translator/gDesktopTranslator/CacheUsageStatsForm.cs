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
    public partial class CacheUsageStatsForm : Form
    {
        public CacheUsageStatsForm()
        {
            InitializeComponent();
        }

        PersistenceConnector cacheConnector;

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void clearCache_Click(object sender, EventArgs e)
        {
            if (cacheConnector != null)
            {
                cacheConnector.clear();
                recordsinCache.Text = "0";
            }
        }

        public void ShowDialogEx(PersistenceConnector pc)
        {
            cacheConnector = pc;
            ShowDialog();
        }

        private void CacheUsageStatsForm_Load(object sender, EventArgs e)
        {
            
        }

        private void deleteOldDRecordsBtn_Click(object sender, EventArgs e)
        {
            cacheConnector.deleteoldRecords();
        }
    }
}
