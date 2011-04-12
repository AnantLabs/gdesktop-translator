namespace gDesktopTranslator
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTranslateTo = new System.Windows.Forms.ComboBox();
            this.labelTranslateFrom = new System.Windows.Forms.Label();
            this.comboBoxTranslateFrom = new System.Windows.Forms.ComboBox();
            this.runAtStartupCheck = new System.Windows.Forms.CheckBox();
            this.minToTrayAtStartCheck = new System.Windows.Forms.CheckBox();
            this.minToTrayOnCloseCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.generalSettingsPage = new System.Windows.Forms.TabPage();
            this.ProxyPage = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.proxyUserPassword = new System.Windows.Forms.TextBox();
            this.proxyUserDomain = new System.Windows.Forms.TextBox();
            this.proxyUserName = new System.Windows.Forms.TextBox();
            this.ProxyAddress = new System.Windows.Forms.Label();
            this.proxyAddressEdit = new System.Windows.Forms.TextBox();
            this.userProxyCheck = new System.Windows.Forms.CheckBox();
            this.listenTextProps = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.soundVolume = new System.Windows.Forms.TrackBar();
            this.cachingPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.markAsLearnedAfter = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.learningEnabledCheck = new System.Windows.Forms.CheckBox();
            this.runInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkForUpdates = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.useCacheBox = new System.Windows.Forms.CheckBox();
            this.groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.generalSettingsPage.SuspendLayout();
            this.ProxyPage.SuspendLayout();
            this.listenTextProps.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundVolume)).BeginInit();
            this.cachingPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markAsLearnedAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runInterval)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.comboBoxTranslateTo);
            this.groupBox.Controls.Add(this.labelTranslateFrom);
            this.groupBox.Controls.Add(this.comboBoxTranslateFrom);
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBoxTranslateTo
            // 
            this.comboBoxTranslateTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTranslateTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTranslateTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTranslateTo.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxTranslateTo, "comboBoxTranslateTo");
            this.comboBoxTranslateTo.Name = "comboBoxTranslateTo";
            // 
            // labelTranslateFrom
            // 
            resources.ApplyResources(this.labelTranslateFrom, "labelTranslateFrom");
            this.labelTranslateFrom.Name = "labelTranslateFrom";
            // 
            // comboBoxTranslateFrom
            // 
            this.comboBoxTranslateFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxTranslateFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTranslateFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxTranslateFrom, "comboBoxTranslateFrom");
            this.comboBoxTranslateFrom.FormattingEnabled = true;
            this.comboBoxTranslateFrom.Name = "comboBoxTranslateFrom";
            // 
            // runAtStartupCheck
            // 
            resources.ApplyResources(this.runAtStartupCheck, "runAtStartupCheck");
            this.runAtStartupCheck.Checked = true;
            this.runAtStartupCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.runAtStartupCheck.Name = "runAtStartupCheck";
            this.runAtStartupCheck.UseVisualStyleBackColor = true;
            // 
            // minToTrayAtStartCheck
            // 
            resources.ApplyResources(this.minToTrayAtStartCheck, "minToTrayAtStartCheck");
            this.minToTrayAtStartCheck.Checked = true;
            this.minToTrayAtStartCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minToTrayAtStartCheck.Name = "minToTrayAtStartCheck";
            this.minToTrayAtStartCheck.UseVisualStyleBackColor = true;
            // 
            // minToTrayOnCloseCheck
            // 
            resources.ApplyResources(this.minToTrayOnCloseCheck, "minToTrayOnCloseCheck");
            this.minToTrayOnCloseCheck.Checked = true;
            this.minToTrayOnCloseCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.minToTrayOnCloseCheck.Name = "minToTrayOnCloseCheck";
            this.minToTrayOnCloseCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.minToTrayOnCloseCheck);
            this.groupBox1.Controls.Add(this.minToTrayAtStartCheck);
            this.groupBox1.Controls.Add(this.runAtStartupCheck);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // okBtn
            // 
            this.okBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.okBtn, "okBtn");
            this.okBtn.Name = "okBtn";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.cancelBtn, "cancelBtn");
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generalSettingsPage);
            this.tabControl.Controls.Add(this.ProxyPage);
            this.tabControl.Controls.Add(this.listenTextProps);
            this.tabControl.Controls.Add(this.cachingPage);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // generalSettingsPage
            // 
            this.generalSettingsPage.Controls.Add(this.groupBox1);
            this.generalSettingsPage.Controls.Add(this.groupBox);
            resources.ApplyResources(this.generalSettingsPage, "generalSettingsPage");
            this.generalSettingsPage.Name = "generalSettingsPage";
            this.generalSettingsPage.UseVisualStyleBackColor = true;
            // 
            // ProxyPage
            // 
            this.ProxyPage.Controls.Add(this.label5);
            this.ProxyPage.Controls.Add(this.label4);
            this.ProxyPage.Controls.Add(this.label3);
            this.ProxyPage.Controls.Add(this.label2);
            this.ProxyPage.Controls.Add(this.proxyUserPassword);
            this.ProxyPage.Controls.Add(this.proxyUserDomain);
            this.ProxyPage.Controls.Add(this.proxyUserName);
            this.ProxyPage.Controls.Add(this.ProxyAddress);
            this.ProxyPage.Controls.Add(this.proxyAddressEdit);
            this.ProxyPage.Controls.Add(this.userProxyCheck);
            resources.ApplyResources(this.ProxyPage, "ProxyPage");
            this.ProxyPage.Name = "ProxyPage";
            this.ProxyPage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // proxyUserPassword
            // 
            resources.ApplyResources(this.proxyUserPassword, "proxyUserPassword");
            this.proxyUserPassword.Name = "proxyUserPassword";
            this.proxyUserPassword.UseSystemPasswordChar = true;
            // 
            // proxyUserDomain
            // 
            resources.ApplyResources(this.proxyUserDomain, "proxyUserDomain");
            this.proxyUserDomain.Name = "proxyUserDomain";
            // 
            // proxyUserName
            // 
            resources.ApplyResources(this.proxyUserName, "proxyUserName");
            this.proxyUserName.Name = "proxyUserName";
            // 
            // ProxyAddress
            // 
            resources.ApplyResources(this.ProxyAddress, "ProxyAddress");
            this.ProxyAddress.Name = "ProxyAddress";
            // 
            // proxyAddressEdit
            // 
            resources.ApplyResources(this.proxyAddressEdit, "proxyAddressEdit");
            this.proxyAddressEdit.Name = "proxyAddressEdit";
            // 
            // userProxyCheck
            // 
            resources.ApplyResources(this.userProxyCheck, "userProxyCheck");
            this.userProxyCheck.Name = "userProxyCheck";
            this.userProxyCheck.UseVisualStyleBackColor = true;
            // 
            // listenTextProps
            // 
            this.listenTextProps.Controls.Add(this.groupBox5);
            resources.ApplyResources(this.listenTextProps, "listenTextProps");
            this.listenTextProps.Name = "listenTextProps";
            this.listenTextProps.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.soundVolume);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // soundVolume
            // 
            resources.ApplyResources(this.soundVolume, "soundVolume");
            this.soundVolume.Maximum = 1000;
            this.soundVolume.Name = "soundVolume";
            this.soundVolume.TickFrequency = 100;
            this.soundVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // cachingPage
            // 
            this.cachingPage.Controls.Add(this.groupBox4);
            this.cachingPage.Controls.Add(this.groupBox3);
            this.cachingPage.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.cachingPage, "cachingPage");
            this.cachingPage.Name = "cachingPage";
            this.cachingPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.markAsLearnedAfter);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.learningEnabledCheck);
            this.groupBox4.Controls.Add(this.runInterval);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // markAsLearnedAfter
            // 
            resources.ApplyResources(this.markAsLearnedAfter, "markAsLearnedAfter");
            this.markAsLearnedAfter.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.markAsLearnedAfter.Name = "markAsLearnedAfter";
            this.markAsLearnedAfter.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // learningEnabledCheck
            // 
            resources.ApplyResources(this.learningEnabledCheck, "learningEnabledCheck");
            this.learningEnabledCheck.Name = "learningEnabledCheck";
            this.learningEnabledCheck.UseVisualStyleBackColor = true;
            // 
            // runInterval
            // 
            resources.ApplyResources(this.runInterval, "runInterval");
            this.runInterval.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.runInterval.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.runInterval.Name = "runInterval";
            this.runInterval.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkForUpdates);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // checkForUpdates
            // 
            resources.ApplyResources(this.checkForUpdates, "checkForUpdates");
            this.checkForUpdates.Name = "checkForUpdates";
            this.checkForUpdates.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.useCacheBox);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // useCacheBox
            // 
            resources.ApplyResources(this.useCacheBox, "useCacheBox");
            this.useCacheBox.Name = "useCacheBox";
            this.useCacheBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okBtn;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.generalSettingsPage.ResumeLayout(false);
            this.ProxyPage.ResumeLayout(false);
            this.ProxyPage.PerformLayout();
            this.listenTextProps.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundVolume)).EndInit();
            this.cachingPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markAsLearnedAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runInterval)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label labelTranslateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox runAtStartupCheck;
        private System.Windows.Forms.CheckBox minToTrayAtStartCheck;
        private System.Windows.Forms.CheckBox minToTrayOnCloseCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        public System.Windows.Forms.ComboBox comboBoxTranslateFrom;
        public System.Windows.Forms.ComboBox comboBoxTranslateTo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generalSettingsPage;
        private System.Windows.Forms.TabPage ProxyPage;
        private System.Windows.Forms.CheckBox userProxyCheck;
        private System.Windows.Forms.Label ProxyAddress;
        private System.Windows.Forms.TextBox proxyUserPassword;
        private System.Windows.Forms.TextBox proxyUserDomain;
        private System.Windows.Forms.TextBox proxyUserName;
        private System.Windows.Forms.TextBox proxyAddressEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage cachingPage;
        private System.Windows.Forms.CheckBox useCacheBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkForUpdates;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox learningEnabledCheck;
        private System.Windows.Forms.NumericUpDown runInterval;
        private System.Windows.Forms.NumericUpDown markAsLearnedAfter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage listenTextProps;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TrackBar soundVolume;
    }
}