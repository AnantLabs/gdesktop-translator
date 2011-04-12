namespace gDesktopTranslator
{
    partial class ResultForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
            this.resultEdit = new System.Windows.Forms.RichTextBox();
            this.hideFormTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.learnThisBtn = new System.Windows.Forms.ToolStripButton();
            this.suggestTranslation = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // resultEdit
            // 
            this.resultEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.resultEdit, "resultEdit");
            this.resultEdit.Name = "resultEdit";
            this.resultEdit.ReadOnly = true;
            this.resultEdit.Click += new System.EventHandler(this.resultEdit_Click);
            // 
            // hideFormTimer
            // 
            this.hideFormTimer.Interval = 3000;
            this.hideFormTimer.Tick += new System.EventHandler(this.hideFormTimer_Tick);
            // 
            // toolStrip
            // 
            this.toolStrip.AllowMerge = false;
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3,
            this.learnThisBtn,
            this.suggestTranslation});
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // learnThisBtn
            // 
            resources.ApplyResources(this.learnThisBtn, "learnThisBtn");
            this.learnThisBtn.Name = "learnThisBtn";
            this.learnThisBtn.Click += new System.EventHandler(this.learnThisBtn_Click);
            // 
            // suggestTranslation
            // 
            this.suggestTranslation.Image = global::gDesktopTranslator.Properties.Resources.addSuggestion;
            resources.ApplyResources(this.suggestTranslation, "suggestTranslation");
            this.suggestTranslation.Name = "suggestTranslation";
            this.suggestTranslation.Click += new System.EventHandler(this.suggestTranslation_Click);
            // 
            // ResultForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.resultEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.ResultForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultForm_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox resultEdit;
        public System.Windows.Forms.Timer hideFormTimer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton learnThisBtn;
        private System.Windows.Forms.ToolStripButton suggestTranslation;



    }
}