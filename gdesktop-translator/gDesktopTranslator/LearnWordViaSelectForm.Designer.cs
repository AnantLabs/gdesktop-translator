namespace gDesktopTranslator
{
    partial class LearnWordViaSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LearnWordViaSelectForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textToLearnEdit = new System.Windows.Forms.RichTextBox();
            this.ansversToolStrip = new System.Windows.Forms.ToolStrip();
            this.variant1Btn = new System.Windows.Forms.ToolStripButton();
            this.variant2Btn = new System.Windows.Forms.ToolStripButton();
            this.variant3Btn = new System.Windows.Forms.ToolStripButton();
            this.variant4Btn = new System.Windows.Forms.ToolStripButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.NextBtn = new System.Windows.Forms.ToolStripButton();
            this.MarkAsLearnedBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ansversToolStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textToLearnEdit);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ansversToolStrip);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            // 
            // textToLearnEdit
            // 
            this.textToLearnEdit.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.textToLearnEdit, "textToLearnEdit");
            this.textToLearnEdit.Name = "textToLearnEdit";
            this.textToLearnEdit.ReadOnly = true;
            // 
            // ansversToolStrip
            // 
            resources.ApplyResources(this.ansversToolStrip, "ansversToolStrip");
            this.ansversToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ansversToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.variant1Btn,
            this.variant2Btn,
            this.variant3Btn,
            this.variant4Btn});
            this.ansversToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.ansversToolStrip.MaximumSize = new System.Drawing.Size(350, 89);
            this.ansversToolStrip.MinimumSize = new System.Drawing.Size(217, 89);
            this.ansversToolStrip.Name = "ansversToolStrip";
            this.ansversToolStrip.ShowItemToolTips = false;
            this.ansversToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ansversToolStrip_ItemClicked);
            // 
            // variant1Btn
            // 
            this.variant1Btn.BackColor = System.Drawing.SystemColors.Control;
            this.variant1Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.variant1Btn, "variant1Btn");
            this.variant1Btn.Name = "variant1Btn";
            this.variant1Btn.Tag = "0";
            this.variant1Btn.Click += new System.EventHandler(this.variant1Btn_Click);
            // 
            // variant2Btn
            // 
            this.variant2Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.variant2Btn, "variant2Btn");
            this.variant2Btn.Name = "variant2Btn";
            this.variant2Btn.Tag = "1";
            this.variant2Btn.Click += new System.EventHandler(this.variant1Btn_Click);
            // 
            // variant3Btn
            // 
            this.variant3Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.variant3Btn, "variant3Btn");
            this.variant3Btn.Name = "variant3Btn";
            this.variant3Btn.Tag = "2";
            this.variant3Btn.Click += new System.EventHandler(this.variant1Btn_Click);
            // 
            // variant4Btn
            // 
            this.variant4Btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.variant4Btn, "variant4Btn");
            this.variant4Btn.Name = "variant4Btn";
            this.variant4Btn.Tag = "3";
            this.variant4Btn.Click += new System.EventHandler(this.variant1Btn_Click);
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NextBtn,
            this.MarkAsLearnedBtn,
            this.toolStripButton3});
            this.toolStrip.Name = "toolStrip";
            // 
            // NextBtn
            // 
            resources.ApplyResources(this.NextBtn, "NextBtn");
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // MarkAsLearnedBtn
            // 
            resources.ApplyResources(this.MarkAsLearnedBtn, "MarkAsLearnedBtn");
            this.MarkAsLearnedBtn.Name = "MarkAsLearnedBtn";
            this.MarkAsLearnedBtn.Click += new System.EventHandler(this.MarkAsLearnedBtn_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.Image = global::gDesktopTranslator.Properties.Resources.button_cancel;
            resources.ApplyResources(this.toolStripButton3, "toolStripButton3");
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // LearnWordViaSelectForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LearnWordViaSelectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LearnWordViaSelectForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ansversToolStrip.ResumeLayout(false);
            this.ansversToolStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox textToLearnEdit;
        private System.Windows.Forms.ToolStripButton NextBtn;
        public System.Windows.Forms.ToolStrip ansversToolStrip;
        public System.Windows.Forms.ToolStripButton variant1Btn;
        public System.Windows.Forms.ToolStripButton variant2Btn;
        public System.Windows.Forms.ToolStripButton variant3Btn;
        public System.Windows.Forms.ToolStripButton variant4Btn;
        private System.Windows.Forms.ToolStripButton MarkAsLearnedBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}