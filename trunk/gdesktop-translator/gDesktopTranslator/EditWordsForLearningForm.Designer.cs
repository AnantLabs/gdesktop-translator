namespace gDesktopTranslator
{
    partial class EditWordsForLearningForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditWordsForLearningForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.removeRowBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteAllBtn = new System.Windows.Forms.ToolStripButton();
            this.learnAgain = new System.Windows.Forms.ToolStripButton();
            this.wordsGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.translation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.learned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.learnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleDescription = null;
            this.toolStrip1.AccessibleName = null;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackgroundImage = null;
            this.toolStrip1.Font = null;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeRowBtn,
            this.deleteAllBtn,
            this.learnAgain});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // removeRowBtn
            // 
            this.removeRowBtn.AccessibleDescription = null;
            this.removeRowBtn.AccessibleName = null;
            resources.ApplyResources(this.removeRowBtn, "removeRowBtn");
            this.removeRowBtn.BackgroundImage = null;
            this.removeRowBtn.Name = "removeRowBtn";
            this.removeRowBtn.Click += new System.EventHandler(this.removeRowBtn_Click);
            // 
            // deleteAllBtn
            // 
            this.deleteAllBtn.AccessibleDescription = null;
            this.deleteAllBtn.AccessibleName = null;
            resources.ApplyResources(this.deleteAllBtn, "deleteAllBtn");
            this.deleteAllBtn.BackgroundImage = null;
            this.deleteAllBtn.Name = "deleteAllBtn";
            this.deleteAllBtn.Click += new System.EventHandler(this.deleteAllBtn_Click);
            // 
            // learnAgain
            // 
            this.learnAgain.AccessibleDescription = null;
            this.learnAgain.AccessibleName = null;
            resources.ApplyResources(this.learnAgain, "learnAgain");
            this.learnAgain.BackgroundImage = null;
            this.learnAgain.Name = "learnAgain";
            this.learnAgain.Click += new System.EventHandler(this.learnAgain_Click);
            // 
            // wordsGridView
            // 
            this.wordsGridView.AccessibleDescription = null;
            this.wordsGridView.AccessibleName = null;
            this.wordsGridView.AllowUserToAddRows = false;
            this.wordsGridView.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.wordsGridView, "wordsGridView");
            this.wordsGridView.BackgroundImage = null;
            this.wordsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wordsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.word,
            this.translation,
            this.learned,
            this.learnCount});
            this.wordsGridView.Font = null;
            this.wordsGridView.Name = "wordsGridView";
            this.wordsGridView.ReadOnly = true;
            this.wordsGridView.ShowEditingIcon = false;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // word
            // 
            this.word.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.word, "word");
            this.word.Name = "word";
            this.word.ReadOnly = true;
            // 
            // translation
            // 
            this.translation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.translation, "translation");
            this.translation.Name = "translation";
            this.translation.ReadOnly = true;
            // 
            // learned
            // 
            this.learned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            resources.ApplyResources(this.learned, "learned");
            this.learned.Name = "learned";
            this.learned.ReadOnly = true;
            // 
            // learnCount
            // 
            this.learnCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            resources.ApplyResources(this.learnCount, "learnCount");
            this.learnCount.Name = "learnCount";
            this.learnCount.ReadOnly = true;
            // 
            // EditWordsForLearningForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.wordsGridView);
            this.Controls.Add(this.toolStrip1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.Name = "EditWordsForLearningForm";
            this.ShowInTaskbar = false;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton removeRowBtn;
        private System.Windows.Forms.ToolStripButton deleteAllBtn;
        private System.Windows.Forms.ToolStripButton learnAgain;
        public System.Windows.Forms.DataGridView wordsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn word;
        private System.Windows.Forms.DataGridViewTextBoxColumn translation;
        private System.Windows.Forms.DataGridViewTextBoxColumn learned;
        private System.Windows.Forms.DataGridViewTextBoxColumn learnCount;
    }
}