namespace gDesktopTranslator
{
    partial class NewVersionInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewVersionInfo));
            this.versionInfoGB = new System.Windows.Forms.GroupBox();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.optionsList = new System.Windows.Forms.TextBox();
            this.yesButton = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.versionInfoGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionInfoGB
            // 
            this.versionInfoGB.AccessibleDescription = null;
            this.versionInfoGB.AccessibleName = null;
            resources.ApplyResources(this.versionInfoGB, "versionInfoGB");
            this.versionInfoGB.BackgroundImage = null;
            this.versionInfoGB.Controls.Add(this.linkLabel);
            this.versionInfoGB.Controls.Add(this.optionsList);
            this.versionInfoGB.Font = null;
            this.versionInfoGB.Name = "versionInfoGB";
            this.versionInfoGB.TabStop = false;
            // 
            // linkLabel
            // 
            this.linkLabel.AccessibleDescription = null;
            this.linkLabel.AccessibleName = null;
            resources.ApplyResources(this.linkLabel, "linkLabel");
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.TabStop = true;
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // optionsList
            // 
            this.optionsList.AccessibleDescription = null;
            this.optionsList.AccessibleName = null;
            resources.ApplyResources(this.optionsList, "optionsList");
            this.optionsList.BackgroundImage = null;
            this.optionsList.Font = null;
            this.optionsList.Name = "optionsList";
            this.optionsList.ReadOnly = true;
            // 
            // yesButton
            // 
            this.yesButton.AccessibleDescription = null;
            this.yesButton.AccessibleName = null;
            resources.ApplyResources(this.yesButton, "yesButton");
            this.yesButton.BackgroundImage = null;
            this.yesButton.Font = null;
            this.yesButton.Name = "yesButton";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.AccessibleDescription = null;
            this.cancelBtn.AccessibleName = null;
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.BackgroundImage = null;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Font = null;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            // 
            // NewVersionInfo
            // 
            this.AcceptButton = this.yesButton;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.cancelBtn;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.versionInfoGB);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewVersionInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.versionInfoGB.ResumeLayout(false);
            this.versionInfoGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button cancelBtn;
        public System.Windows.Forms.TextBox optionsList;
        public System.Windows.Forms.GroupBox versionInfoGB;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.LinkLabel linkLabel;
    }
}