
namespace LineDeleter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.ProgressB = new System.Windows.Forms.ProgressBar();
            this.displayT = new System.Windows.Forms.Label();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MatchFormatting = new MetroFramework.Controls.MetroCheckBox();
            this.RemoveEmptyRows = new MetroFramework.Controls.MetroCheckBox();
            this.OutPutFolderB = new MetroFramework.Controls.MetroButton();
            this.outputI = new MetroFramework.Controls.MetroTextBox();
            this.CapitalizationIsSacredI = new MetroFramework.Controls.MetroCheckBox();
            this.wholeCellOnlyI = new MetroFramework.Controls.MetroCheckBox();
            this.OpenInputStringB = new MetroFramework.Controls.MetroButton();
            this.SelectInputStringB = new MetroFramework.Controls.MetroButton();
            this.inputStringsI = new MetroFramework.Controls.MetroTextBox();
            this.protectI = new MetroFramework.Controls.MetroCheckBox();
            this.openCsvAfterI = new MetroFramework.Controls.MetroCheckBox();
            this.maxLines = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.doNotI = new MetroFramework.Controls.MetroRadioButton();
            this.doContainsI = new MetroFramework.Controls.MetroRadioButton();
            this.logToFileI = new MetroFramework.Controls.MetroCheckBox();
            this.logToUII = new MetroFramework.Controls.MetroCheckBox();
            this.openInputB = new MetroFramework.Controls.MetroButton();
            this.loadInputB = new MetroFramework.Controls.MetroButton();
            this.inputI = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RemoveEmptyRowsButton = new MetroFramework.Controls.MetroButton();
            this.startB = new MetroFramework.Controls.MetroButton();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.DebugT = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel3.Controls.Add(this.ProgressB);
            this.panel3.Controls.Add(this.displayT);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(20, 557);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(941, 57);
            this.panel3.TabIndex = 15;
            // 
            // ProgressB
            // 
            this.ProgressB.Location = new System.Drawing.Point(4, 35);
            this.ProgressB.Name = "ProgressB";
            this.ProgressB.Size = new System.Drawing.Size(933, 14);
            this.ProgressB.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressB.TabIndex = 4;
            // 
            // displayT
            // 
            this.displayT.AutoSize = true;
            this.displayT.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayT.ForeColor = System.Drawing.Color.Black;
            this.displayT.Location = new System.Drawing.Point(22, 10);
            this.displayT.Name = "displayT";
            this.displayT.Size = new System.Drawing.Size(0, 16);
            this.displayT.TabIndex = 2;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Controls.Add(this.metroTabPage2);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(941, 497);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Orange;
            this.metroTabControl1.TabIndex = 16;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabControl1.UseSelectable = true;
            this.metroTabControl1.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.metroTabPage1.Controls.Add(this.panel2);
            this.metroTabPage1.Controls.Add(this.panel1);
            this.metroTabPage1.ForeColor = System.Drawing.Color.Black;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 0;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(933, 452);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Options";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.MatchFormatting);
            this.panel2.Controls.Add(this.RemoveEmptyRows);
            this.panel2.Controls.Add(this.OutPutFolderB);
            this.panel2.Controls.Add(this.outputI);
            this.panel2.Controls.Add(this.CapitalizationIsSacredI);
            this.panel2.Controls.Add(this.wholeCellOnlyI);
            this.panel2.Controls.Add(this.OpenInputStringB);
            this.panel2.Controls.Add(this.SelectInputStringB);
            this.panel2.Controls.Add(this.inputStringsI);
            this.panel2.Controls.Add(this.protectI);
            this.panel2.Controls.Add(this.openCsvAfterI);
            this.panel2.Controls.Add(this.maxLines);
            this.panel2.Controls.Add(this.metroLabel2);
            this.panel2.Controls.Add(this.doNotI);
            this.panel2.Controls.Add(this.doContainsI);
            this.panel2.Controls.Add(this.logToFileI);
            this.panel2.Controls.Add(this.logToUII);
            this.panel2.Controls.Add(this.openInputB);
            this.panel2.Controls.Add(this.loadInputB);
            this.panel2.Controls.Add(this.inputI);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(763, 452);
            this.panel2.TabIndex = 14;
            // 
            // MatchFormatting
            // 
            this.MatchFormatting.AutoSize = true;
            this.MatchFormatting.Location = new System.Drawing.Point(233, 341);
            this.MatchFormatting.Name = "MatchFormatting";
            this.MatchFormatting.Size = new System.Drawing.Size(119, 15);
            this.MatchFormatting.Style = MetroFramework.MetroColorStyle.Orange;
            this.MatchFormatting.TabIndex = 45;
            this.MatchFormatting.Text = "Match Formatting";
            this.MatchFormatting.UseSelectable = true;
            // 
            // RemoveEmptyRows
            // 
            this.RemoveEmptyRows.AutoSize = true;
            this.RemoveEmptyRows.Location = new System.Drawing.Point(396, 277);
            this.RemoveEmptyRows.Name = "RemoveEmptyRows";
            this.RemoveEmptyRows.Size = new System.Drawing.Size(134, 15);
            this.RemoveEmptyRows.Style = MetroFramework.MetroColorStyle.Orange;
            this.RemoveEmptyRows.TabIndex = 43;
            this.RemoveEmptyRows.Text = "Remove Empty Rows";
            this.RemoveEmptyRows.UseSelectable = true;
            // 
            // OutPutFolderB
            // 
            this.OutPutFolderB.Location = new System.Drawing.Point(463, 92);
            this.OutPutFolderB.Name = "OutPutFolderB";
            this.OutPutFolderB.Size = new System.Drawing.Size(111, 23);
            this.OutPutFolderB.Style = MetroFramework.MetroColorStyle.Orange;
            this.OutPutFolderB.TabIndex = 42;
            this.OutPutFolderB.Text = "Select output folder";
            this.OutPutFolderB.UseSelectable = true;
            this.OutPutFolderB.UseStyleColors = true;
            this.OutPutFolderB.Click += new System.EventHandler(this.loadOutputB_Click);
            // 
            // outputI
            // 
            // 
            // 
            // 
            this.outputI.CustomButton.Image = null;
            this.outputI.CustomButton.Location = new System.Drawing.Point(340, 1);
            this.outputI.CustomButton.Name = "";
            this.outputI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.outputI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.outputI.CustomButton.TabIndex = 1;
            this.outputI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.outputI.CustomButton.UseSelectable = true;
            this.outputI.CustomButton.Visible = false;
            this.outputI.Lines = new string[0];
            this.outputI.Location = new System.Drawing.Point(32, 92);
            this.outputI.MaxLength = 32767;
            this.outputI.Name = "outputI";
            this.outputI.PasswordChar = '\0';
            this.outputI.ReadOnly = true;
            this.outputI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.outputI.SelectedText = "";
            this.outputI.SelectionLength = 0;
            this.outputI.SelectionStart = 0;
            this.outputI.ShortcutsEnabled = true;
            this.outputI.Size = new System.Drawing.Size(362, 23);
            this.outputI.Style = MetroFramework.MetroColorStyle.Orange;
            this.outputI.TabIndex = 41;
            this.outputI.UseSelectable = true;
            this.outputI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.outputI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CapitalizationIsSacredI
            // 
            this.CapitalizationIsSacredI.AutoSize = true;
            this.CapitalizationIsSacredI.Location = new System.Drawing.Point(233, 309);
            this.CapitalizationIsSacredI.Name = "CapitalizationIsSacredI";
            this.CapitalizationIsSacredI.Size = new System.Drawing.Size(151, 15);
            this.CapitalizationIsSacredI.Style = MetroFramework.MetroColorStyle.Orange;
            this.CapitalizationIsSacredI.TabIndex = 40;
            this.CapitalizationIsSacredI.Text = "Capitalization is sacred ?";
            this.CapitalizationIsSacredI.UseSelectable = true;
            // 
            // wholeCellOnlyI
            // 
            this.wholeCellOnlyI.AutoSize = true;
            this.wholeCellOnlyI.Location = new System.Drawing.Point(233, 277);
            this.wholeCellOnlyI.Name = "wholeCellOnlyI";
            this.wholeCellOnlyI.Size = new System.Drawing.Size(114, 15);
            this.wholeCellOnlyI.Style = MetroFramework.MetroColorStyle.Orange;
            this.wholeCellOnlyI.TabIndex = 39;
            this.wholeCellOnlyI.Text = "Whole cells only?";
            this.wholeCellOnlyI.UseSelectable = true;
            // 
            // OpenInputStringB
            // 
            this.OpenInputStringB.Location = new System.Drawing.Point(618, 52);
            this.OpenInputStringB.Name = "OpenInputStringB";
            this.OpenInputStringB.Size = new System.Drawing.Size(111, 23);
            this.OpenInputStringB.Style = MetroFramework.MetroColorStyle.Orange;
            this.OpenInputStringB.TabIndex = 38;
            this.OpenInputStringB.Text = "Open input strings File";
            this.OpenInputStringB.UseSelectable = true;
            this.OpenInputStringB.UseStyleColors = true;
            this.OpenInputStringB.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // SelectInputStringB
            // 
            this.SelectInputStringB.Location = new System.Drawing.Point(463, 52);
            this.SelectInputStringB.Name = "SelectInputStringB";
            this.SelectInputStringB.Size = new System.Drawing.Size(136, 23);
            this.SelectInputStringB.Style = MetroFramework.MetroColorStyle.Orange;
            this.SelectInputStringB.TabIndex = 37;
            this.SelectInputStringB.Text = "Select input strings File";
            this.SelectInputStringB.UseSelectable = true;
            this.SelectInputStringB.UseStyleColors = true;
            this.SelectInputStringB.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // inputStringsI
            // 
            // 
            // 
            // 
            this.inputStringsI.CustomButton.Image = null;
            this.inputStringsI.CustomButton.Location = new System.Drawing.Point(340, 1);
            this.inputStringsI.CustomButton.Name = "";
            this.inputStringsI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.inputStringsI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputStringsI.CustomButton.TabIndex = 1;
            this.inputStringsI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputStringsI.CustomButton.UseSelectable = true;
            this.inputStringsI.CustomButton.Visible = false;
            this.inputStringsI.Lines = new string[0];
            this.inputStringsI.Location = new System.Drawing.Point(32, 52);
            this.inputStringsI.MaxLength = 32767;
            this.inputStringsI.Name = "inputStringsI";
            this.inputStringsI.PasswordChar = '\0';
            this.inputStringsI.ReadOnly = true;
            this.inputStringsI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputStringsI.SelectedText = "";
            this.inputStringsI.SelectionLength = 0;
            this.inputStringsI.SelectionStart = 0;
            this.inputStringsI.ShortcutsEnabled = true;
            this.inputStringsI.Size = new System.Drawing.Size(362, 23);
            this.inputStringsI.Style = MetroFramework.MetroColorStyle.Orange;
            this.inputStringsI.TabIndex = 36;
            this.inputStringsI.UseSelectable = true;
            this.inputStringsI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputStringsI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // protectI
            // 
            this.protectI.AutoSize = true;
            this.protectI.Location = new System.Drawing.Point(32, 277);
            this.protectI.Name = "protectI";
            this.protectI.Size = new System.Drawing.Size(125, 15);
            this.protectI.Style = MetroFramework.MetroColorStyle.Orange;
            this.protectI.TabIndex = 35;
            this.protectI.Text = "Protect the headers";
            this.protectI.UseSelectable = true;
            // 
            // openCsvAfterI
            // 
            this.openCsvAfterI.AutoSize = true;
            this.openCsvAfterI.Location = new System.Drawing.Point(32, 309);
            this.openCsvAfterI.Name = "openCsvAfterI";
            this.openCsvAfterI.Size = new System.Drawing.Size(153, 15);
            this.openCsvAfterI.Style = MetroFramework.MetroColorStyle.Orange;
            this.openCsvAfterI.TabIndex = 34;
            this.openCsvAfterI.Text = "Open output when done";
            this.openCsvAfterI.UseSelectable = true;
            // 
            // maxLines
            // 
            // 
            // 
            // 
            this.maxLines.CustomButton.Image = null;
            this.maxLines.CustomButton.Location = new System.Drawing.Point(104, 1);
            this.maxLines.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.maxLines.CustomButton.Name = "";
            this.maxLines.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.maxLines.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.maxLines.CustomButton.TabIndex = 1;
            this.maxLines.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.maxLines.CustomButton.UseSelectable = true;
            this.maxLines.CustomButton.Visible = false;
            this.maxLines.Lines = new string[] {
        "450000"};
            this.maxLines.Location = new System.Drawing.Point(183, 228);
            this.maxLines.Margin = new System.Windows.Forms.Padding(2);
            this.maxLines.MaxLength = 32767;
            this.maxLines.Name = "maxLines";
            this.maxLines.PasswordChar = '\0';
            this.maxLines.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.maxLines.SelectedText = "";
            this.maxLines.SelectionLength = 0;
            this.maxLines.SelectionStart = 0;
            this.maxLines.ShortcutsEnabled = true;
            this.maxLines.Size = new System.Drawing.Size(126, 23);
            this.maxLines.TabIndex = 33;
            this.maxLines.Text = "450000";
            this.maxLines.UseSelectable = true;
            this.maxLines.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.maxLines.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(32, 228);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(128, 19);
            this.metroLabel2.TabIndex = 32;
            this.metroLabel2.Text = "Max lines per sheet :";
            // 
            // doNotI
            // 
            this.doNotI.AutoSize = true;
            this.doNotI.Location = new System.Drawing.Point(26, 193);
            this.doNotI.Margin = new System.Windows.Forms.Padding(2);
            this.doNotI.Name = "doNotI";
            this.doNotI.Size = new System.Drawing.Size(321, 15);
            this.doNotI.TabIndex = 31;
            this.doNotI.Text = "Remove Rows that do not Contains the following values ";
            this.doNotI.UseSelectable = true;
            // 
            // doContainsI
            // 
            this.doContainsI.AutoSize = true;
            this.doContainsI.Checked = true;
            this.doContainsI.Location = new System.Drawing.Point(26, 156);
            this.doContainsI.Margin = new System.Windows.Forms.Padding(2);
            this.doContainsI.Name = "doContainsI";
            this.doContainsI.Size = new System.Drawing.Size(283, 15);
            this.doContainsI.TabIndex = 30;
            this.doContainsI.TabStop = true;
            this.doContainsI.Text = "Remove Rows that Contains the following values ";
            this.doContainsI.UseSelectable = true;
            // 
            // logToFileI
            // 
            this.logToFileI.AutoSize = true;
            this.logToFileI.Location = new System.Drawing.Point(32, 374);
            this.logToFileI.Name = "logToFileI";
            this.logToFileI.Size = new System.Drawing.Size(79, 15);
            this.logToFileI.Style = MetroFramework.MetroColorStyle.Orange;
            this.logToFileI.TabIndex = 27;
            this.logToFileI.Text = "Log To File";
            this.logToFileI.UseSelectable = true;
            // 
            // logToUII
            // 
            this.logToUII.AutoSize = true;
            this.logToUII.Location = new System.Drawing.Point(32, 341);
            this.logToUII.Name = "logToUII";
            this.logToUII.Size = new System.Drawing.Size(72, 15);
            this.logToUII.Style = MetroFramework.MetroColorStyle.Orange;
            this.logToUII.TabIndex = 26;
            this.logToUII.Text = "Log To UI";
            this.logToUII.UseSelectable = true;
            // 
            // openInputB
            // 
            this.openInputB.Location = new System.Drawing.Point(618, 15);
            this.openInputB.Name = "openInputB";
            this.openInputB.Size = new System.Drawing.Size(111, 23);
            this.openInputB.Style = MetroFramework.MetroColorStyle.Orange;
            this.openInputB.TabIndex = 24;
            this.openInputB.Text = "Open File to Alter";
            this.openInputB.UseSelectable = true;
            this.openInputB.UseStyleColors = true;
            this.openInputB.Click += new System.EventHandler(this.openInputB_Click_1);
            // 
            // loadInputB
            // 
            this.loadInputB.Location = new System.Drawing.Point(463, 15);
            this.loadInputB.Name = "loadInputB";
            this.loadInputB.Size = new System.Drawing.Size(136, 23);
            this.loadInputB.Style = MetroFramework.MetroColorStyle.Orange;
            this.loadInputB.TabIndex = 22;
            this.loadInputB.Text = "Select input folder";
            this.loadInputB.UseSelectable = true;
            this.loadInputB.UseStyleColors = true;
            this.loadInputB.Click += new System.EventHandler(this.loadInputB_Click_1);
            // 
            // inputI
            // 
            // 
            // 
            // 
            this.inputI.CustomButton.Image = null;
            this.inputI.CustomButton.Location = new System.Drawing.Point(340, 1);
            this.inputI.CustomButton.Name = "";
            this.inputI.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.inputI.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.inputI.CustomButton.TabIndex = 1;
            this.inputI.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.inputI.CustomButton.UseSelectable = true;
            this.inputI.CustomButton.Visible = false;
            this.inputI.Lines = new string[0];
            this.inputI.Location = new System.Drawing.Point(32, 15);
            this.inputI.MaxLength = 32767;
            this.inputI.Name = "inputI";
            this.inputI.PasswordChar = '\0';
            this.inputI.ReadOnly = true;
            this.inputI.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.inputI.SelectedText = "";
            this.inputI.SelectionLength = 0;
            this.inputI.SelectionStart = 0;
            this.inputI.ShortcutsEnabled = true;
            this.inputI.Size = new System.Drawing.Size(362, 23);
            this.inputI.Style = MetroFramework.MetroColorStyle.Orange;
            this.inputI.TabIndex = 20;
            this.inputI.UseSelectable = true;
            this.inputI.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.inputI.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.RemoveEmptyRowsButton);
            this.panel1.Controls.Add(this.startB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(763, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 452);
            this.panel1.TabIndex = 6;
            // 
            // RemoveEmptyRowsButton
            // 
            this.RemoveEmptyRowsButton.Location = new System.Drawing.Point(6, 15);
            this.RemoveEmptyRowsButton.Name = "RemoveEmptyRowsButton";
            this.RemoveEmptyRowsButton.Size = new System.Drawing.Size(161, 43);
            this.RemoveEmptyRowsButton.Style = MetroFramework.MetroColorStyle.Orange;
            this.RemoveEmptyRowsButton.TabIndex = 24;
            this.RemoveEmptyRowsButton.Text = "Remove Empty Rows";
            this.RemoveEmptyRowsButton.UseSelectable = true;
            this.RemoveEmptyRowsButton.UseStyleColors = true;
            this.RemoveEmptyRowsButton.Visible = false;
            this.RemoveEmptyRowsButton.Click += new System.EventHandler(this.RemoveEmptyRowsButton_Click);
            // 
            // startB
            // 
            this.startB.Location = new System.Drawing.Point(6, 395);
            this.startB.Name = "startB";
            this.startB.Size = new System.Drawing.Size(161, 43);
            this.startB.Style = MetroFramework.MetroColorStyle.Orange;
            this.startB.TabIndex = 23;
            this.startB.Text = "Start";
            this.startB.UseSelectable = true;
            this.startB.UseStyleColors = true;
            this.startB.Click += new System.EventHandler(this.startB_Click_1);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.metroPanel2);
            this.metroTabPage2.HorizontalScrollbarBarColor = false;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 0;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 41);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(933, 452);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Logs";
            this.metroTabPage2.VerticalScrollbarBarColor = false;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 0;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.DebugT);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(933, 452);
            this.metroPanel2.TabIndex = 2;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // DebugT
            // 
            this.DebugT.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DebugT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DebugT.Cursor = System.Windows.Forms.Cursors.Default;
            this.DebugT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugT.Location = new System.Drawing.Point(0, 0);
            this.DebugT.Margin = new System.Windows.Forms.Padding(4);
            this.DebugT.Name = "DebugT";
            this.DebugT.ReadOnly = true;
            this.DebugT.Size = new System.Drawing.Size(933, 452);
            this.DebugT.TabIndex = 1;
            this.DebugT.Text = "";
            this.DebugT.WordWrap = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::LineDeleter.Properties.Resources.clipart196740;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(20, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 634);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "         LineDeleter 1.17";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ProgressBar ProgressB;
        private System.Windows.Forms.Label displayT;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        internal System.Windows.Forms.RichTextBox DebugT;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTextBox inputI;
        private MetroFramework.Controls.MetroButton loadInputB;
        private MetroFramework.Controls.MetroButton openInputB;
        private MetroFramework.Controls.MetroButton startB;
        private MetroFramework.Controls.MetroCheckBox logToUII;
        private MetroFramework.Controls.MetroCheckBox logToFileI;
        private MetroFramework.Controls.MetroRadioButton doNotI;
        private MetroFramework.Controls.MetroRadioButton doContainsI;
        private MetroFramework.Controls.MetroTextBox maxLines;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroCheckBox openCsvAfterI;
        private MetroFramework.Controls.MetroCheckBox protectI;
        private MetroFramework.Controls.MetroButton OpenInputStringB;
        private MetroFramework.Controls.MetroButton SelectInputStringB;
        private MetroFramework.Controls.MetroTextBox inputStringsI;
        private MetroFramework.Controls.MetroCheckBox CapitalizationIsSacredI;
        private MetroFramework.Controls.MetroCheckBox wholeCellOnlyI;
        private MetroFramework.Controls.MetroButton RemoveEmptyRowsButton;
        private MetroFramework.Controls.MetroButton OutPutFolderB;
        private MetroFramework.Controls.MetroTextBox outputI;
        private MetroFramework.Controls.MetroCheckBox RemoveEmptyRows;
        private MetroFramework.Controls.MetroCheckBox MatchFormatting;
    }
}

