using Utilities;

namespace gDesktopTranslator
{
    partial class TranslatorToolMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranslatorToolMainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.translateFromBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.clearAllToolBtn = new System.Windows.Forms.ToolStripButton();
            this.copyResultToolBtn = new System.Windows.Forms.ToolStripButton();
            this.pasteTextTBtn = new System.Windows.Forms.ToolStripButton();
            this.pasteAndTranslateBtn = new System.Windows.Forms.ToolStripButton();
            this.detectedLanguageLabel = new System.Windows.Forms.ToolStripLabel();
            this.detectLanguageToolBtn = new System.Windows.Forms.ToolStripButton();
            this.originalLanguageSelect = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.destinationLanguageSelect = new System.Windows.Forms.ToolStripComboBox();
            this.languageHistoryBtn = new System.Windows.Forms.ToolStripButton();
            this.swapButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.learnThisBtn = new System.Windows.Forms.ToolStripButton();
            this.translateToBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translationsErrorListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ukrainianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteTextFromClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteAndTranslateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swapLanguagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.additionalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTextFromClipboardInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewWordsForLearningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cacheStatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.updateInfoStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalCtn = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorStatusMessages = new System.Windows.Forms.ToolStripStatusLabel();
            this.suggestBetterTranslation = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnListen = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnIndicator = new System.Windows.Forms.ToolStripDropDownButton();
            this.ttsFailedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.sysTrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.learnWordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.langHistoryMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.learningTimer = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.sysTrayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.translateFromBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.translateToBox, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // translateFromBox
            // 
            resources.ApplyResources(this.translateFromBox, "translateFromBox");
            this.translateFromBox.Name = "translateFromBox";
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllToolBtn,
            this.copyResultToolBtn,
            this.pasteTextTBtn,
            this.pasteAndTranslateBtn,
            this.detectedLanguageLabel,
            this.detectLanguageToolBtn,
            this.originalLanguageSelect,
            this.toolStripLabel1,
            this.destinationLanguageSelect,
            this.languageHistoryBtn,
            this.swapButton,
            this.toolStripButton1,
            this.learnThisBtn});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // clearAllToolBtn
            // 
            this.clearAllToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearAllToolBtn.Image = global::gDesktopTranslator.Properties.Resources._new;
            resources.ApplyResources(this.clearAllToolBtn, "clearAllToolBtn");
            this.clearAllToolBtn.Name = "clearAllToolBtn";
            this.clearAllToolBtn.Click += new System.EventHandler(this.clearAllBtn_Click);
            // 
            // copyResultToolBtn
            // 
            this.copyResultToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.copyResultToolBtn.Image = global::gDesktopTranslator.Properties.Resources.copy;
            resources.ApplyResources(this.copyResultToolBtn, "copyResultToolBtn");
            this.copyResultToolBtn.Name = "copyResultToolBtn";
            this.copyResultToolBtn.Click += new System.EventHandler(this.copyResultToClipboard_Click);
            // 
            // pasteTextTBtn
            // 
            this.pasteTextTBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteTextTBtn.Image = global::gDesktopTranslator.Properties.Resources.paste;
            resources.ApplyResources(this.pasteTextTBtn, "pasteTextTBtn");
            this.pasteTextTBtn.Name = "pasteTextTBtn";
            this.pasteTextTBtn.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // pasteAndTranslateBtn
            // 
            this.pasteAndTranslateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pasteAndTranslateBtn.Image = global::gDesktopTranslator.Properties.Resources.clipboard_paste_01;
            resources.ApplyResources(this.pasteAndTranslateBtn, "pasteAndTranslateBtn");
            this.pasteAndTranslateBtn.Name = "pasteAndTranslateBtn";
            this.pasteAndTranslateBtn.Click += new System.EventHandler(this.pasteAndTranslate_Click);
            // 
            // detectedLanguageLabel
            // 
            this.detectedLanguageLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.detectedLanguageLabel.Name = "detectedLanguageLabel";
            resources.ApplyResources(this.detectedLanguageLabel, "detectedLanguageLabel");
            // 
            // detectLanguageToolBtn
            // 
            this.detectLanguageToolBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.detectLanguageToolBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.detectLanguageToolBtn.Image = global::gDesktopTranslator.Properties.Resources.onebit_21;
            resources.ApplyResources(this.detectLanguageToolBtn, "detectLanguageToolBtn");
            this.detectLanguageToolBtn.Name = "detectLanguageToolBtn";
            this.detectLanguageToolBtn.Click += new System.EventHandler(this.detectLanguageBtn_Click);
            // 
            // originalLanguageSelect
            // 
            this.originalLanguageSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.originalLanguageSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.originalLanguageSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originalLanguageSelect.Name = "originalLanguageSelect";
            resources.ApplyResources(this.originalLanguageSelect, "originalLanguageSelect");
            this.originalLanguageSelect.SelectedIndexChanged += new System.EventHandler(this.originalLanguageSelect_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // destinationLanguageSelect
            // 
            this.destinationLanguageSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.destinationLanguageSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.destinationLanguageSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destinationLanguageSelect.Name = "destinationLanguageSelect";
            resources.ApplyResources(this.destinationLanguageSelect, "destinationLanguageSelect");
            // 
            // languageHistoryBtn
            // 
            this.languageHistoryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.languageHistoryBtn, "languageHistoryBtn");
            this.languageHistoryBtn.Name = "languageHistoryBtn";
            this.languageHistoryBtn.Click += new System.EventHandler(this.languageHistoryBtn_Click);
            // 
            // swapButton
            // 
            this.swapButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.swapButton.Image = global::gDesktopTranslator.Properties.Resources.reload;
            resources.ApplyResources(this.swapButton, "swapButton");
            this.swapButton.Name = "swapButton";
            this.swapButton.Click += new System.EventHandler(this.swapButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::gDesktopTranslator.Properties.Resources.google;
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.tanslateBtn_Click);
            // 
            // learnThisBtn
            // 
            this.learnThisBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.learnThisBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.learnThisBtn.Image = global::gDesktopTranslator.Properties.Resources.emblem_library;
            resources.ApplyResources(this.learnThisBtn, "learnThisBtn");
            this.learnThisBtn.Name = "learnThisBtn";
            this.learnThisBtn.Click += new System.EventHandler(this.learnThisBtn_Click);
            // 
            // translateToBox
            // 
            resources.ApplyResources(this.translateToBox, "translateToBox");
            this.translateToBox.Name = "translateToBox";
            this.translateToBox.TextChanged += new System.EventHandler(this.translateToBox_TextChanged);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.translationToolStripMenuItem,
            this.additionalToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translationsErrorListToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.toolStripMenuItem1,
            this.hideWindowToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // translationsErrorListToolStripMenuItem
            // 
            this.translationsErrorListToolStripMenuItem.Name = "translationsErrorListToolStripMenuItem";
            resources.ApplyResources(this.translationsErrorListToolStripMenuItem, "translationsErrorListToolStripMenuItem");
            this.translationsErrorListToolStripMenuItem.Click += new System.EventHandler(this.translationsErrorListToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // hideWindowToolStripMenuItem
            // 
            this.hideWindowToolStripMenuItem.Name = "hideWindowToolStripMenuItem";
            resources.ApplyResources(this.hideWindowToolStripMenuItem, "hideWindowToolStripMenuItem");
            this.hideWindowToolStripMenuItem.Click += new System.EventHandler(this.hideWindowToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.ukrainianToolStripMenuItem,
            this.russianToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // ukrainianToolStripMenuItem
            // 
            this.ukrainianToolStripMenuItem.Name = "ukrainianToolStripMenuItem";
            resources.ApplyResources(this.ukrainianToolStripMenuItem, "ukrainianToolStripMenuItem");
            this.ukrainianToolStripMenuItem.Click += new System.EventHandler(this.ukrainianToolStripMenuItem_Click);
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            resources.ApplyResources(this.russianToolStripMenuItem, "russianToolStripMenuItem");
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.russianToolStripMenuItem_Click);
            // 
            // translationToolStripMenuItem
            // 
            this.translationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.translateToolStripMenuItem,
            this.detectLanguageToolStripMenuItem,
            this.pasteTextFromClipboardToolStripMenuItem,
            this.pasteAndTranslateToolStripMenuItem,
            this.clearAllToolStripMenuItem,
            this.swapLanguagesToolStripMenuItem});
            this.translationToolStripMenuItem.Name = "translationToolStripMenuItem";
            resources.ApplyResources(this.translationToolStripMenuItem, "translationToolStripMenuItem");
            // 
            // translateToolStripMenuItem
            // 
            this.translateToolStripMenuItem.Name = "translateToolStripMenuItem";
            resources.ApplyResources(this.translateToolStripMenuItem, "translateToolStripMenuItem");
            this.translateToolStripMenuItem.Click += new System.EventHandler(this.tanslateBtn_Click);
            // 
            // detectLanguageToolStripMenuItem
            // 
            this.detectLanguageToolStripMenuItem.Name = "detectLanguageToolStripMenuItem";
            resources.ApplyResources(this.detectLanguageToolStripMenuItem, "detectLanguageToolStripMenuItem");
            this.detectLanguageToolStripMenuItem.Click += new System.EventHandler(this.detectLanguageBtn_Click);
            // 
            // pasteTextFromClipboardToolStripMenuItem
            // 
            this.pasteTextFromClipboardToolStripMenuItem.Name = "pasteTextFromClipboardToolStripMenuItem";
            resources.ApplyResources(this.pasteTextFromClipboardToolStripMenuItem, "pasteTextFromClipboardToolStripMenuItem");
            this.pasteTextFromClipboardToolStripMenuItem.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // pasteAndTranslateToolStripMenuItem
            // 
            this.pasteAndTranslateToolStripMenuItem.Name = "pasteAndTranslateToolStripMenuItem";
            resources.ApplyResources(this.pasteAndTranslateToolStripMenuItem, "pasteAndTranslateToolStripMenuItem");
            this.pasteAndTranslateToolStripMenuItem.Click += new System.EventHandler(this.pasteAndTranslate_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            resources.ApplyResources(this.clearAllToolStripMenuItem, "clearAllToolStripMenuItem");
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllBtn_Click);
            // 
            // swapLanguagesToolStripMenuItem
            // 
            this.swapLanguagesToolStripMenuItem.Name = "swapLanguagesToolStripMenuItem";
            resources.ApplyResources(this.swapLanguagesToolStripMenuItem, "swapLanguagesToolStripMenuItem");
            this.swapLanguagesToolStripMenuItem.Click += new System.EventHandler(this.swapButton_Click);
            // 
            // additionalToolStripMenuItem
            // 
            this.additionalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchTextFromClipboardInToolStripMenuItem,
            this.addToolStripMenuItem,
            this.viewWordsForLearningToolStripMenuItem});
            this.additionalToolStripMenuItem.Name = "additionalToolStripMenuItem";
            resources.ApplyResources(this.additionalToolStripMenuItem, "additionalToolStripMenuItem");
            // 
            // searchTextFromClipboardInToolStripMenuItem
            // 
            resources.ApplyResources(this.searchTextFromClipboardInToolStripMenuItem, "searchTextFromClipboardInToolStripMenuItem");
            this.searchTextFromClipboardInToolStripMenuItem.Name = "searchTextFromClipboardInToolStripMenuItem";
            this.searchTextFromClipboardInToolStripMenuItem.Click += new System.EventHandler(this.searchTextFromClipboardInToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // viewWordsForLearningToolStripMenuItem
            // 
            resources.ApplyResources(this.viewWordsForLearningToolStripMenuItem, "viewWordsForLearningToolStripMenuItem");
            this.viewWordsForLearningToolStripMenuItem.Name = "viewWordsForLearningToolStripMenuItem";
            this.viewWordsForLearningToolStripMenuItem.Click += new System.EventHandler(this.viewWordsForLearningToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.cacheStatisticsToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cacheStatisticsToolStripMenuItem
            // 
            this.cacheStatisticsToolStripMenuItem.Name = "cacheStatisticsToolStripMenuItem";
            resources.ApplyResources(this.cacheStatisticsToolStripMenuItem, "cacheStatisticsToolStripMenuItem");
            this.cacheStatisticsToolStripMenuItem.Click += new System.EventHandler(this.cacheStatisticsToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            resources.ApplyResources(this.checkForUpdatesToolStripMenuItem, "checkForUpdatesToolStripMenuItem");
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowItemReorder = true;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.updateInfoStatusLabel,
            this.toolStripStatusLabel1,
            this.totalCtn,
            this.errorStatusMessages,
            this.suggestBetterTranslation,
            this.btnListen,
            this.btnIndicator,
            this.ttsFailedLabel});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            resources.ApplyResources(this.statusLabel, "statusLabel");
            // 
            // updateInfoStatusLabel
            // 
            this.updateInfoStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.updateInfoStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.updateInfoStatusLabel.Name = "updateInfoStatusLabel";
            resources.ApplyResources(this.updateInfoStatusLabel, "updateInfoStatusLabel");
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // totalCtn
            // 
            this.totalCtn.Name = "totalCtn";
            resources.ApplyResources(this.totalCtn, "totalCtn");
            // 
            // errorStatusMessages
            // 
            this.errorStatusMessages.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.errorStatusMessages.Name = "errorStatusMessages";
            resources.ApplyResources(this.errorStatusMessages, "errorStatusMessages");
            // 
            // suggestBetterTranslation
            // 
            this.suggestBetterTranslation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.suggestBetterTranslation.Image = global::gDesktopTranslator.Properties.Resources.addSuggestion;
            resources.ApplyResources(this.suggestBetterTranslation, "suggestBetterTranslation");
            this.suggestBetterTranslation.Name = "suggestBetterTranslation";
            this.suggestBetterTranslation.ShowDropDownArrow = false;
            this.suggestBetterTranslation.Click += new System.EventHandler(this.toolStripDropDownButton1_ButtonClick);
            // 
            // btnListen
            // 
            resources.ApplyResources(this.btnListen, "btnListen");
            this.btnListen.Image = global::gDesktopTranslator.Properties.Resources.sound_sh_2_;
            this.btnListen.Name = "btnListen";
            this.btnListen.ShowDropDownArrow = false;
            this.btnListen.Click += new System.EventHandler(this.btnListen_Click);
            // 
            // btnIndicator
            // 
            this.btnIndicator.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIndicator.Image = global::gDesktopTranslator.Properties.Resources.ajax_loader1;
            resources.ApplyResources(this.btnIndicator, "btnIndicator");
            this.btnIndicator.Name = "btnIndicator";
            this.btnIndicator.ShowDropDownArrow = false;
            // 
            // ttsFailedLabel
            // 
            this.ttsFailedLabel.BackColor = System.Drawing.Color.OrangeRed;
            this.ttsFailedLabel.Name = "ttsFailedLabel";
            resources.ApplyResources(this.ttsFailedLabel, "ttsFailedLabel");
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.sysTrayContextMenu;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // sysTrayContextMenu
            // 
            this.sysTrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.learnWordsToolStripMenuItem,
            this.showWindowToolStripMenuItem,
            this.ExitMenuItem});
            this.sysTrayContextMenu.Name = "sysTrayContextMenu";
            resources.ApplyResources(this.sysTrayContextMenu, "sysTrayContextMenu");
            // 
            // learnWordsToolStripMenuItem
            // 
            resources.ApplyResources(this.learnWordsToolStripMenuItem, "learnWordsToolStripMenuItem");
            this.learnWordsToolStripMenuItem.Name = "learnWordsToolStripMenuItem";
            this.learnWordsToolStripMenuItem.Click += new System.EventHandler(this.learnWordsToolStripMenuItem_Click);
            // 
            // showWindowToolStripMenuItem
            // 
            this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            resources.ApplyResources(this.showWindowToolStripMenuItem, "showWindowToolStripMenuItem");
            this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            resources.ApplyResources(this.ExitMenuItem, "ExitMenuItem");
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // langHistoryMenuStrip
            // 
            this.langHistoryMenuStrip.Name = "langHistoryMenuStrip";
            resources.ApplyResources(this.langHistoryMenuStrip, "langHistoryMenuStrip");
            // 
            // learningTimer
            // 
            this.learningTimer.Tick += new System.EventHandler(this.learningTimer_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "new.png");
            // 
            // TranslatorToolMainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.label1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TranslatorToolMainForm";
            this.Load += new System.EventHandler(this.TranslatorToolMainForm_Load);
            this.Shown += new System.EventHandler(this.TranslatorToolMainForm_Shown);
            this.Activated += new System.EventHandler(this.TranslatorToolMainForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TranslatorToolMainForm_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TranslatorToolMainForm_FormClosing);
            this.Resize += new System.EventHandler(this.TranslatorToolMainForm_Resize);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.sysTrayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip sysTrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translationsErrorListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ukrainianToolStripMenuItem;
        private System.Windows.Forms.RichTextBox translateFromBox;
        private System.Windows.Forms.RichTextBox translateToBox;
        private System.Windows.Forms.ToolStripMenuItem translationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detectLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cacheStatisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteTextFromClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteAndTranslateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem additionalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchTextFromClipboardInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel updateInfoStatusLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton copyResultToolBtn;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripButton clearAllToolBtn;
        private System.Windows.Forms.ToolStripButton pasteTextTBtn;
        private System.Windows.Forms.ToolStripButton pasteAndTranslateBtn;
        private System.Windows.Forms.ToolStripButton detectLanguageToolBtn;
        private System.Windows.Forms.ToolStripLabel detectedLanguageLabel;
        private System.Windows.Forms.ToolStripComboBox originalLanguageSelect;
        private System.Windows.Forms.ToolStripComboBox destinationLanguageSelect;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton swapButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel totalCtn;
        private System.Windows.Forms.ToolStripButton languageHistoryBtn;
        private System.Windows.Forms.ContextMenuStrip langHistoryMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.Timer learningTimer;
        private System.Windows.Forms.ToolStripMenuItem viewWordsForLearningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem learnWordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swapLanguagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton learnThisBtn;
        private System.Windows.Forms.ToolStripStatusLabel errorStatusMessages;
        public System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton btnListen;
        private System.Windows.Forms.ToolStripDropDownButton suggestBetterTranslation;
        private System.Windows.Forms.ToolStripDropDownButton btnIndicator;
        private System.Windows.Forms.ToolStripStatusLabel ttsFailedLabel;

    }
}

