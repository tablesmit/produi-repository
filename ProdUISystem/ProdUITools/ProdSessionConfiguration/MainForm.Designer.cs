namespace ProdSessionConfiguration
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
            this.components = new System.ComponentModel.Container();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NumTimeout = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkErrors = new System.Windows.Forms.CheckBox();
            this.ChkWarn = new System.Windows.Forms.CheckBox();
            this.ChkInfo = new System.Windows.Forms.CheckBox();
            this.ChkProd = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmdOff = new System.Windows.Forms.Button();
            this.CmdDefault = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TsNewSession = new System.Windows.Forms.ToolStripMenuItem();
            this.TsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.TsSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsRecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.TsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.RdoMinimum = new System.Windows.Forms.RadioButton();
            this.RdoMaximum = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CmdMoveUp = new System.Windows.Forms.Button();
            this.TxtLoggerName = new System.Windows.Forms.TextBox();
            this.TxtDllPath = new System.Windows.Forms.TextBox();
            this.CmdAddLogger = new System.Windows.Forms.Button();
            this.TxtDateFormat = new System.Windows.Forms.TextBox();
            this.CmdMoveDown = new System.Windows.Forms.Button();
            this.LstLogEntry = new System.Windows.Forms.CheckedListBox();
            this.LstLoggers = new System.Windows.Forms.ListBox();
            this.CmdBrowse = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PnlLayout = new System.Windows.Forms.Panel();
            this.PnlSessionValues = new System.Windows.Forms.Panel();
            this.GrpLogger = new System.Windows.Forms.GroupBox();
            this.CmdEditLogger = new System.Windows.Forms.Button();
            this.CmdRemoveLogger = new System.Windows.Forms.Button();
            this.PnlLogOptions = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.LvParams = new System.Windows.Forms.ListView();
            this.ClnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TblOutput = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LblMessageExample = new System.Windows.Forms.Label();
            this.LblMethodExample = new System.Windows.Forms.Label();
            this.LblTypeExample = new System.Windows.Forms.Label();
            this.LblTimeExample = new System.Windows.Forms.Label();
            this.CtxId = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtxNewGuid = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.NumTimeout)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.PnlLayout.SuspendLayout();
            this.PnlSessionValues.SuspendLayout();
            this.GrpLogger.SuspendLayout();
            this.PnlLogOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.CtxId.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtName
            // 
            this.TxtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtName.Location = new System.Drawing.Point(90, 41);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(234, 20);
            this.TxtName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.TxtName, "A \"Friendly\" name for this session");
            this.TxtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Session Name";
            // 
            // NumTimeout
            // 
            this.NumTimeout.Location = new System.Drawing.Point(131, 24);
            this.NumTimeout.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumTimeout.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumTimeout.Name = "NumTimeout";
            this.NumTimeout.Size = new System.Drawing.Size(50, 20);
            this.NumTimeout.TabIndex = 0;
            this.toolTip1.SetToolTip(this.NumTimeout, "The length of time (in seconds) to wait for verification");
            this.NumTimeout.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NumTimeout.ValueChanged += new System.EventHandler(this.NumTimeout_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Event Timeout (sec)";
            // 
            // ChkErrors
            // 
            this.ChkErrors.AutoSize = true;
            this.ChkErrors.Location = new System.Drawing.Point(19, 95);
            this.ChkErrors.Name = "ChkErrors";
            this.ChkErrors.Size = new System.Drawing.Size(53, 17);
            this.ChkErrors.TabIndex = 3;
            this.ChkErrors.Tag = "1";
            this.ChkErrors.Text = "Errors";
            this.toolTip1.SetToolTip(this.ChkErrors, "Include all error messages");
            this.ChkErrors.UseVisualStyleBackColor = true;
            this.ChkErrors.CheckedChanged += new System.EventHandler(this.LevelCheckedChanged);
            // 
            // ChkWarn
            // 
            this.ChkWarn.AutoSize = true;
            this.ChkWarn.Location = new System.Drawing.Point(19, 49);
            this.ChkWarn.Name = "ChkWarn";
            this.ChkWarn.Size = new System.Drawing.Size(71, 17);
            this.ChkWarn.TabIndex = 1;
            this.ChkWarn.Tag = "2";
            this.ChkWarn.Text = "Warnings";
            this.toolTip1.SetToolTip(this.ChkWarn, "Include warning messages");
            this.ChkWarn.UseVisualStyleBackColor = true;
            this.ChkWarn.CheckedChanged += new System.EventHandler(this.LevelCheckedChanged);
            // 
            // ChkInfo
            // 
            this.ChkInfo.AutoSize = true;
            this.ChkInfo.Location = new System.Drawing.Point(19, 26);
            this.ChkInfo.Name = "ChkInfo";
            this.ChkInfo.Size = new System.Drawing.Size(86, 17);
            this.ChkInfo.TabIndex = 0;
            this.ChkInfo.Tag = "4";
            this.ChkInfo.Text = "Informational";
            this.toolTip1.SetToolTip(this.ChkInfo, "Include informational messages");
            this.ChkInfo.UseVisualStyleBackColor = true;
            this.ChkInfo.CheckedChanged += new System.EventHandler(this.LevelCheckedChanged);
            // 
            // ChkProd
            // 
            this.ChkProd.AutoSize = true;
            this.ChkProd.Location = new System.Drawing.Point(19, 71);
            this.ChkProd.Name = "ChkProd";
            this.ChkProd.Size = new System.Drawing.Size(53, 17);
            this.ChkProd.TabIndex = 2;
            this.ChkProd.Tag = "8";
            this.ChkProd.Text = "Prods";
            this.toolTip1.SetToolTip(this.ChkProd, "Include all Prods performed by ProdUI");
            this.ChkProd.UseVisualStyleBackColor = true;
            this.ChkProd.CheckedChanged += new System.EventHandler(this.LevelCheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.CmdOff);
            this.groupBox1.Controls.Add(this.CmdDefault);
            this.groupBox1.Controls.Add(this.ChkInfo);
            this.groupBox1.Controls.Add(this.ChkProd);
            this.groupBox1.Controls.Add(this.ChkErrors);
            this.groupBox1.Controls.Add(this.ChkWarn);
            this.groupBox1.Location = new System.Drawing.Point(431, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 135);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logging Level";
            // 
            // CmdOff
            // 
            this.CmdOff.Location = new System.Drawing.Point(111, 70);
            this.CmdOff.Name = "CmdOff";
            this.CmdOff.Size = new System.Drawing.Size(75, 23);
            this.CmdOff.TabIndex = 5;
            this.CmdOff.Text = "Off";
            this.toolTip1.SetToolTip(this.CmdOff, "Turn off all logging");
            this.CmdOff.UseVisualStyleBackColor = true;
            this.CmdOff.Click += new System.EventHandler(this.CmdOff_Click);
            // 
            // CmdDefault
            // 
            this.CmdDefault.Location = new System.Drawing.Point(111, 41);
            this.CmdDefault.Name = "CmdDefault";
            this.CmdDefault.Size = new System.Drawing.Size(75, 23);
            this.CmdDefault.TabIndex = 4;
            this.CmdDefault.Text = "Default";
            this.toolTip1.SetToolTip(this.CmdDefault, "Informational|Prods|Errors");
            this.CmdDefault.UseVisualStyleBackColor = true;
            this.CmdDefault.Click += new System.EventHandler(this.CmdDefault_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsNewSession,
            this.TsOpen,
            this.toolStripMenuItem2,
            this.TsSave,
            this.TsSaveAs,
            this.toolStripMenuItem1,
            this.TsRecentFiles,
            this.toolStripMenuItem3,
            this.TsExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // TsNewSession
            // 
            this.TsNewSession.Name = "TsNewSession";
            this.TsNewSession.Size = new System.Drawing.Size(152, 22);
            this.TsNewSession.Text = "New";
            this.TsNewSession.Click += new System.EventHandler(this.TsNewSession_Click);
            // 
            // TsOpen
            // 
            this.TsOpen.Name = "TsOpen";
            this.TsOpen.Size = new System.Drawing.Size(152, 22);
            this.TsOpen.Text = "Open";
            this.TsOpen.Click += new System.EventHandler(this.TsOpen_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // TsSave
            // 
            this.TsSave.Enabled = false;
            this.TsSave.Name = "TsSave";
            this.TsSave.Size = new System.Drawing.Size(152, 22);
            this.TsSave.Text = "Save";
            this.TsSave.Click += new System.EventHandler(this.TsSave_Click);
            // 
            // TsSaveAs
            // 
            this.TsSaveAs.Enabled = false;
            this.TsSaveAs.Name = "TsSaveAs";
            this.TsSaveAs.Size = new System.Drawing.Size(152, 22);
            this.TsSaveAs.Text = "Save As...";
            this.TsSaveAs.Click += new System.EventHandler(this.TsSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // TsRecentFiles
            // 
            this.TsRecentFiles.Name = "TsRecentFiles";
            this.TsRecentFiles.Size = new System.Drawing.Size(152, 22);
            this.TsRecentFiles.Text = "Recent Files";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // TsExit
            // 
            this.TsExit.Name = "TsExit";
            this.TsExit.Size = new System.Drawing.Size(152, 22);
            this.TsExit.Text = "Exit";
            this.TsExit.Click += new System.EventHandler(this.TsExit_Click);
            // 
            // RdoMinimum
            // 
            this.RdoMinimum.AutoSize = true;
            this.RdoMinimum.Checked = true;
            this.RdoMinimum.Location = new System.Drawing.Point(19, 47);
            this.RdoMinimum.Name = "RdoMinimum";
            this.RdoMinimum.Size = new System.Drawing.Size(107, 17);
            this.RdoMinimum.TabIndex = 0;
            this.RdoMinimum.TabStop = true;
            this.RdoMinimum.Tag = "1";
            this.RdoMinimum.Text = "Minimum (default)";
            this.RdoMinimum.UseVisualStyleBackColor = false;
            this.RdoMinimum.CheckedChanged += new System.EventHandler(this.Verbosity_CheckedChanged);
            // 
            // RdoMaximum
            // 
            this.RdoMaximum.AutoSize = true;
            this.RdoMaximum.Location = new System.Drawing.Point(20, 70);
            this.RdoMaximum.Name = "RdoMaximum";
            this.RdoMaximum.Size = new System.Drawing.Size(41, 17);
            this.RdoMaximum.TabIndex = 1;
            this.RdoMaximum.Tag = "2";
            this.RdoMaximum.Text = "Full";
            this.toolTip1.SetToolTip(this.RdoMaximum, "Includes all items (such as list items in a Listbox)");
            this.RdoMaximum.UseVisualStyleBackColor = true;
            this.RdoMaximum.CheckedChanged += new System.EventHandler(this.Verbosity_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.RdoMinimum);
            this.groupBox3.Controls.Add(this.RdoMaximum);
            this.groupBox3.Location = new System.Drawing.Point(53, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 135);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logging Verbosity";
            this.toolTip1.SetToolTip(this.groupBox3, "Set the amount of information to be logged");
            // 
            // TxtId
            // 
            this.TxtId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TxtId.ContextMenuStrip = this.CtxId;
            this.TxtId.Location = new System.Drawing.Point(90, 6);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(234, 20);
            this.TxtId.TabIndex = 0;
            this.toolTip1.SetToolTip(this.TxtId, "Identifier for this session");
            this.TxtId.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Session Id";
            // 
            // CmdMoveUp
            // 
            this.CmdMoveUp.Image = global::ProdSessionConfiguration.Properties.Resources.UpArrowShort;
            this.CmdMoveUp.Location = new System.Drawing.Point(168, 30);
            this.CmdMoveUp.Name = "CmdMoveUp";
            this.CmdMoveUp.Size = new System.Drawing.Size(24, 24);
            this.CmdMoveUp.TabIndex = 1;
            this.toolTip1.SetToolTip(this.CmdMoveUp, "Move selection up");
            this.CmdMoveUp.UseVisualStyleBackColor = true;
            this.CmdMoveUp.Click += new System.EventHandler(this.CmdMoveUp_Click);
            // 
            // TxtLoggerName
            // 
            this.TxtLoggerName.Location = new System.Drawing.Point(210, 10);
            this.TxtLoggerName.Name = "TxtLoggerName";
            this.TxtLoggerName.Size = new System.Drawing.Size(212, 20);
            this.TxtLoggerName.TabIndex = 0;
            this.toolTip1.SetToolTip(this.TxtLoggerName, "User assigned name for this particular logger");
            this.TxtLoggerName.TextChanged += new System.EventHandler(this.TxtLoggerName_TextChanged);
            // 
            // TxtDllPath
            // 
            this.TxtDllPath.BackColor = System.Drawing.SystemColors.Window;
            this.TxtDllPath.Location = new System.Drawing.Point(210, 35);
            this.TxtDllPath.Name = "TxtDllPath";
            this.TxtDllPath.ReadOnly = true;
            this.TxtDllPath.Size = new System.Drawing.Size(212, 20);
            this.TxtDllPath.TabIndex = 1;
            this.toolTip1.SetToolTip(this.TxtDllPath, "Path to the loggers Dll");
            this.TxtDllPath.TextChanged += new System.EventHandler(this.TxtLoggerName_TextChanged);
            // 
            // CmdAddLogger
            // 
            this.CmdAddLogger.Enabled = false;
            this.CmdAddLogger.Location = new System.Drawing.Point(14, 203);
            this.CmdAddLogger.Name = "CmdAddLogger";
            this.CmdAddLogger.Size = new System.Drawing.Size(68, 23);
            this.CmdAddLogger.TabIndex = 1;
            this.CmdAddLogger.Tag = "new";
            this.CmdAddLogger.Text = "New";
            this.toolTip1.SetToolTip(this.CmdAddLogger, "Create or save a new ProdLogger");
            this.CmdAddLogger.UseVisualStyleBackColor = true;
            this.CmdAddLogger.Click += new System.EventHandler(this.CmdAddLogger_Click);
            // 
            // TxtDateFormat
            // 
            this.TxtDateFormat.Location = new System.Drawing.Point(39, 116);
            this.TxtDateFormat.Name = "TxtDateFormat";
            this.TxtDateFormat.Size = new System.Drawing.Size(120, 20);
            this.TxtDateFormat.TabIndex = 3;
            this.TxtDateFormat.Text = "T";
            this.TxtDateFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.TxtDateFormat, "A string format to be passed to the DateTime structure");
            this.TxtDateFormat.TextChanged += new System.EventHandler(this.TxtDateFormat_TextChanged);
            // 
            // CmdMoveDown
            // 
            this.CmdMoveDown.Image = global::ProdSessionConfiguration.Properties.Resources.DownArrowShort;
            this.CmdMoveDown.Location = new System.Drawing.Point(168, 60);
            this.CmdMoveDown.Name = "CmdMoveDown";
            this.CmdMoveDown.Size = new System.Drawing.Size(24, 24);
            this.CmdMoveDown.TabIndex = 2;
            this.toolTip1.SetToolTip(this.CmdMoveDown, "Move selection down");
            this.CmdMoveDown.UseVisualStyleBackColor = true;
            this.CmdMoveDown.Click += new System.EventHandler(this.CmdMoveDown_Click);
            // 
            // LstLogEntry
            // 
            this.LstLogEntry.CheckOnClick = true;
            this.LstLogEntry.FormattingEnabled = true;
            this.LstLogEntry.Location = new System.Drawing.Point(39, 17);
            this.LstLogEntry.Name = "LstLogEntry";
            this.LstLogEntry.Size = new System.Drawing.Size(120, 79);
            this.LstLogEntry.TabIndex = 0;
            this.toolTip1.SetToolTip(this.LstLogEntry, "Output format for a log entry. Uncheck to disable a category");
            this.LstLogEntry.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.LstLogEntry_ItemCheck);
            // 
            // LstLoggers
            // 
            this.LstLoggers.FormattingEnabled = true;
            this.LstLoggers.Location = new System.Drawing.Point(14, 50);
            this.LstLoggers.Name = "LstLoggers";
            this.LstLoggers.Size = new System.Drawing.Size(156, 147);
            this.LstLoggers.TabIndex = 0;
            this.toolTip1.SetToolTip(this.LstLoggers, "A list of all loggers associated with this session");
            this.LstLoggers.SelectedIndexChanged += new System.EventHandler(this.LstLoggers_SelectedIndexChanged);
            // 
            // CmdBrowse
            // 
            this.CmdBrowse.Location = new System.Drawing.Point(428, 34);
            this.CmdBrowse.Name = "CmdBrowse";
            this.CmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.CmdBrowse.TabIndex = 31;
            this.CmdBrowse.Text = "Browse";
            this.toolTip1.SetToolTip(this.CmdBrowse, "Browse to file that implements a ProdLogger");
            this.CmdBrowse.UseVisualStyleBackColor = true;
            this.CmdBrowse.Click += new System.EventHandler(this.CmdBrowse_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.NumTimeout);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(107, 81);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 59);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Verification Options";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 627);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(936, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TsStatusLabel
            // 
            this.TsStatusLabel.Name = "TsStatusLabel";
            this.TsStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // PnlLayout
            // 
            this.PnlLayout.Controls.Add(this.PnlSessionValues);
            this.PnlLayout.Controls.Add(this.GrpLogger);
            this.PnlLayout.Controls.Add(this.LblMessageExample);
            this.PnlLayout.Controls.Add(this.LblMethodExample);
            this.PnlLayout.Controls.Add(this.LblTypeExample);
            this.PnlLayout.Controls.Add(this.LblTimeExample);
            this.PnlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlLayout.Location = new System.Drawing.Point(0, 24);
            this.PnlLayout.Name = "PnlLayout";
            this.PnlLayout.Size = new System.Drawing.Size(936, 603);
            this.PnlLayout.TabIndex = 22;
            // 
            // PnlSessionValues
            // 
            this.PnlSessionValues.Controls.Add(this.label3);
            this.PnlSessionValues.Controls.Add(this.label1);
            this.PnlSessionValues.Controls.Add(this.groupBox4);
            this.PnlSessionValues.Controls.Add(this.TxtName);
            this.PnlSessionValues.Controls.Add(this.TxtId);
            this.PnlSessionValues.Enabled = false;
            this.PnlSessionValues.Location = new System.Drawing.Point(302, 13);
            this.PnlSessionValues.Name = "PnlSessionValues";
            this.PnlSessionValues.Size = new System.Drawing.Size(333, 181);
            this.PnlSessionValues.TabIndex = 28;
            // 
            // GrpLogger
            // 
            this.GrpLogger.Controls.Add(this.CmdEditLogger);
            this.GrpLogger.Controls.Add(this.CmdRemoveLogger);
            this.GrpLogger.Controls.Add(this.CmdAddLogger);
            this.GrpLogger.Controls.Add(this.PnlLogOptions);
            this.GrpLogger.Controls.Add(this.LstLoggers);
            this.GrpLogger.Controls.Add(this.label8);
            this.GrpLogger.Enabled = false;
            this.GrpLogger.Location = new System.Drawing.Point(46, 200);
            this.GrpLogger.Name = "GrpLogger";
            this.GrpLogger.Size = new System.Drawing.Size(844, 389);
            this.GrpLogger.TabIndex = 27;
            this.GrpLogger.TabStop = false;
            this.GrpLogger.Text = "Session Logger Configuration";
            // 
            // CmdEditLogger
            // 
            this.CmdEditLogger.Enabled = false;
            this.CmdEditLogger.Location = new System.Drawing.Point(102, 203);
            this.CmdEditLogger.Name = "CmdEditLogger";
            this.CmdEditLogger.Size = new System.Drawing.Size(68, 23);
            this.CmdEditLogger.TabIndex = 27;
            this.CmdEditLogger.Text = "Edit";
            this.CmdEditLogger.UseVisualStyleBackColor = true;
            this.CmdEditLogger.Click += new System.EventHandler(this.CmdEditLogger_Click);
            // 
            // CmdRemoveLogger
            // 
            this.CmdRemoveLogger.Enabled = false;
            this.CmdRemoveLogger.Location = new System.Drawing.Point(58, 228);
            this.CmdRemoveLogger.Name = "CmdRemoveLogger";
            this.CmdRemoveLogger.Size = new System.Drawing.Size(68, 23);
            this.CmdRemoveLogger.TabIndex = 26;
            this.CmdRemoveLogger.Text = "Remove";
            this.CmdRemoveLogger.UseVisualStyleBackColor = true;
            this.CmdRemoveLogger.Click += new System.EventHandler(this.CmdRemoveLogger_Click);
            // 
            // PnlLogOptions
            // 
            this.PnlLogOptions.Controls.Add(this.label7);
            this.PnlLogOptions.Controls.Add(this.LvParams);
            this.PnlLogOptions.Controls.Add(this.CmdBrowse);
            this.PnlLogOptions.Controls.Add(this.label5);
            this.PnlLogOptions.Controls.Add(this.TxtDllPath);
            this.PnlLogOptions.Controls.Add(this.label4);
            this.PnlLogOptions.Controls.Add(this.tableLayoutPanel1);
            this.PnlLogOptions.Controls.Add(this.TblOutput);
            this.PnlLogOptions.Controls.Add(this.groupBox3);
            this.PnlLogOptions.Controls.Add(this.TxtLoggerName);
            this.PnlLogOptions.Controls.Add(this.groupBox1);
            this.PnlLogOptions.Controls.Add(this.groupBox2);
            this.PnlLogOptions.Enabled = false;
            this.PnlLogOptions.Location = new System.Drawing.Point(195, 12);
            this.PnlLogOptions.Name = "PnlLogOptions";
            this.PnlLogOptions.Size = new System.Drawing.Size(633, 371);
            this.PnlLogOptions.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(124, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Logger Parameters";
            // 
            // LvParams
            // 
            this.LvParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClnName,
            this.ClnValue});
            this.LvParams.Location = new System.Drawing.Point(127, 270);
            this.LvParams.Name = "LvParams";
            this.LvParams.Size = new System.Drawing.Size(384, 97);
            this.LvParams.TabIndex = 28;
            this.LvParams.UseCompatibleStateImageBehavior = false;
            this.LvParams.View = System.Windows.Forms.View.Details;
            // 
            // ClnName
            // 
            this.ClnName.Text = "Parameter";
            this.ClnName.Width = 102;
            // 
            // ClnValue
            // 
            this.ClnValue.Text = "Value";
            this.ClnValue.Width = 274;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Logger Path";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Name";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Location = new System.Drawing.Point(278, 216);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // TblOutput
            // 
            this.TblOutput.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TblOutput.AutoSize = true;
            this.TblOutput.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TblOutput.ColumnCount = 4;
            this.TblOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TblOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TblOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TblOutput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TblOutput.Location = new System.Drawing.Point(278, 216);
            this.TblOutput.Name = "TblOutput";
            this.TblOutput.RowCount = 1;
            this.TblOutput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TblOutput.Size = new System.Drawing.Size(0, 0);
            this.TblOutput.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TxtDateFormat);
            this.groupBox2.Controls.Add(this.CmdMoveUp);
            this.groupBox2.Controls.Add(this.CmdMoveDown);
            this.groupBox2.Controls.Add(this.LstLogEntry);
            this.groupBox2.Location = new System.Drawing.Point(217, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 142);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log Entry Format";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Date Format";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Loaded Loggers";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LblMessageExample
            // 
            this.LblMessageExample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblMessageExample.AutoSize = true;
            this.LblMessageExample.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMessageExample.Location = new System.Drawing.Point(757, 58);
            this.LblMessageExample.Name = "LblMessageExample";
            this.LblMessageExample.Size = new System.Drawing.Size(176, 18);
            this.LblMessageExample.TabIndex = 25;
            this.LblMessageExample.Tag = "Message Text";
            this.LblMessageExample.Text = "Button click verified";
            this.LblMessageExample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblMessageExample.Visible = false;
            // 
            // LblMethodExample
            // 
            this.LblMethodExample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblMethodExample.AutoSize = true;
            this.LblMethodExample.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMethodExample.Location = new System.Drawing.Point(780, 76);
            this.LblMethodExample.Name = "LblMethodExample";
            this.LblMethodExample.Size = new System.Drawing.Size(120, 18);
            this.LblMethodExample.TabIndex = 24;
            this.LblMethodExample.Tag = "Calling Function";
            this.LblMethodExample.Text = "*Method=Click*";
            this.LblMethodExample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblMethodExample.Visible = false;
            // 
            // LblTypeExample
            // 
            this.LblTypeExample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblTypeExample.AutoSize = true;
            this.LblTypeExample.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTypeExample.Location = new System.Drawing.Point(815, 40);
            this.LblTypeExample.Name = "LblTypeExample";
            this.LblTypeExample.Size = new System.Drawing.Size(56, 18);
            this.LblTypeExample.TabIndex = 23;
            this.LblTypeExample.Tag = "Message Level";
            this.LblTypeExample.Text = "*Prod*";
            this.LblTypeExample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTypeExample.Visible = false;
            // 
            // LblTimeExample
            // 
            this.LblTimeExample.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblTimeExample.AutoSize = true;
            this.LblTimeExample.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTimeExample.Location = new System.Drawing.Point(780, 19);
            this.LblTimeExample.Name = "LblTimeExample";
            this.LblTimeExample.Size = new System.Drawing.Size(120, 18);
            this.LblTimeExample.TabIndex = 22;
            this.LblTimeExample.Tag = "LogTime";
            this.LblTimeExample.Text = "[10:12:32 AM]:";
            this.LblTimeExample.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblTimeExample.Visible = false;
            // 
            // CtxId
            // 
            this.CtxId.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtxNewGuid});
            this.CtxId.Name = "CtxId";
            this.CtxId.Size = new System.Drawing.Size(131, 26);
            // 
            // CtxNewGuid
            // 
            this.CtxNewGuid.Name = "CtxNewGuid";
            this.CtxNewGuid.Size = new System.Drawing.Size(130, 22);
            this.CtxNewGuid.Text = "New Guid";
            this.CtxNewGuid.Click += new System.EventHandler(this.CtxNewGuid_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 649);
            this.Controls.Add(this.PnlLayout);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ProdSession Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumTimeout)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.PnlLayout.ResumeLayout(false);
            this.PnlLayout.PerformLayout();
            this.PnlSessionValues.ResumeLayout(false);
            this.PnlSessionValues.PerformLayout();
            this.GrpLogger.ResumeLayout(false);
            this.GrpLogger.PerformLayout();
            this.PnlLogOptions.ResumeLayout(false);
            this.PnlLogOptions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.CtxId.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkErrors;
        private System.Windows.Forms.CheckBox ChkWarn;
        private System.Windows.Forms.CheckBox ChkInfo;
        private System.Windows.Forms.CheckBox ChkProd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CmdOff;
        private System.Windows.Forms.Button CmdDefault;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TsOpen;
        private System.Windows.Forms.ToolStripMenuItem TsSave;
        private System.Windows.Forms.ToolStripMenuItem TsSaveAs;
        private System.Windows.Forms.ToolStripMenuItem TsExit;
        private System.Windows.Forms.RadioButton RdoMinimum;
        private System.Windows.Forms.RadioButton RdoMaximum;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripMenuItem TsNewSession;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TsStatusLabel;
        private System.Windows.Forms.Panel PnlLayout;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button CmdAddLogger;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox LstLoggers;
        private System.Windows.Forms.Panel PnlLogOptions;
        private System.Windows.Forms.Button CmdMoveUp;
        private System.Windows.Forms.Button CmdMoveDown;
        private System.Windows.Forms.CheckedListBox LstLogEntry;
        private System.Windows.Forms.Label LblMessageExample;
        private System.Windows.Forms.Label LblMethodExample;
        private System.Windows.Forms.Label LblTypeExample;
        private System.Windows.Forms.Label LblTimeExample;
        private System.Windows.Forms.TableLayoutPanel TblOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtLoggerName;
        private System.Windows.Forms.GroupBox GrpLogger;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDllPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDateFormat;
        private System.Windows.Forms.Panel PnlSessionValues;
        private System.Windows.Forms.Button CmdBrowse;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button CmdRemoveLogger;
        private System.Windows.Forms.Button CmdEditLogger;
        private System.Windows.Forms.ListView LvParams;
        private System.Windows.Forms.ColumnHeader ClnName;
        private System.Windows.Forms.ColumnHeader ClnValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem TsRecentFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ContextMenuStrip CtxId;
        private System.Windows.Forms.ToolStripMenuItem CtxNewGuid;
    }
}

