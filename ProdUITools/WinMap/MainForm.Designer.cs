namespace WinMap
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TvWindowList = new System.Windows.Forms.TreeView();
            this.CtxTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtxMapWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.CtxCompare = new System.Windows.Forms.ToolStripMenuItem();
            this.LvControls = new System.Windows.Forms.ListView();
            this.ClnCustom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnAutomationId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnControlType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnClassName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnHelpText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnAcceleratorKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnAccessKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnLabeledBy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnControlTreePosition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnItemType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CtxListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxAssignName = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LoadProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.TsLoadedForm = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsSortOrder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsOpenMap = new System.Windows.Forms.ToolStripButton();
            this.TsSaveWindow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsGetWindows = new System.Windows.Forms.ToolStripButton();
            this.TsCrawl = new System.Windows.Forms.ToolStripButton();
            this.TsCompare = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CtxTreeView.SuspendLayout();
            this.CtxListView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TvWindowList
            // 
            this.TvWindowList.ContextMenuStrip = this.CtxTreeView;
            this.TvWindowList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TvWindowList.HideSelection = false;
            this.TvWindowList.Location = new System.Drawing.Point(0, 0);
            this.TvWindowList.Name = "TvWindowList";
            this.TvWindowList.Size = new System.Drawing.Size(239, 587);
            this.TvWindowList.TabIndex = 1;
            this.TvWindowList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvWindowList_AfterSelect);
            this.TvWindowList.DoubleClick += new System.EventHandler(this.TsCrawl_Click);
            // 
            // CtxTreeView
            // 
            this.CtxTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtxMapWindow,
            this.CtxCompare});
            this.CtxTreeView.Name = "CtxTreeView";
            this.CtxTreeView.Size = new System.Drawing.Size(147, 48);
            // 
            // CtxMapWindow
            // 
            this.CtxMapWindow.Enabled = false;
            this.CtxMapWindow.Name = "CtxMapWindow";
            this.CtxMapWindow.Size = new System.Drawing.Size(146, 22);
            this.CtxMapWindow.Text = "Map Window";
            this.CtxMapWindow.ToolTipText = "Map the currently selected window";
            this.CtxMapWindow.Click += new System.EventHandler(this.TsCrawl_Click);
            // 
            // CtxCompare
            // 
            this.CtxCompare.Enabled = false;
            this.CtxCompare.Name = "CtxCompare";
            this.CtxCompare.Size = new System.Drawing.Size(146, 22);
            this.CtxCompare.Text = "Compare";
            this.CtxCompare.ToolTipText = "Compare the loaded window with a previously saved map file";
            this.CtxCompare.Click += new System.EventHandler(this.TsCompare_Click);
            // 
            // LvControls
            // 
            this.LvControls.AllowColumnReorder = true;
            this.LvControls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClnCustom,
            this.ClnAutomationId,
            this.ClnName,
            this.ClnControlType,
            this.ClnClassName,
            this.ClnHelpText,
            this.ClnAcceleratorKey,
            this.ClnAccessKey,
            this.ClnLabeledBy,
            this.ClnControlTreePosition,
            this.ClnItemType});
            this.LvControls.ContextMenuStrip = this.CtxListView;
            this.LvControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvControls.FullRowSelect = true;
            this.LvControls.GridLines = true;
            this.LvControls.Location = new System.Drawing.Point(0, 0);
            this.LvControls.Name = "LvControls";
            this.LvControls.ShowGroups = false;
            this.LvControls.Size = new System.Drawing.Size(794, 565);
            this.LvControls.TabIndex = 5;
            this.LvControls.UseCompatibleStateImageBehavior = false;
            this.LvControls.View = System.Windows.Forms.View.Details;
            this.LvControls.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LvControls_ColumnClick);
            this.LvControls.SelectedIndexChanged += new System.EventHandler(this.LvControls_SelectedIndexChanged);
            // 
            // ClnCustom
            // 
            this.ClnCustom.Text = "Custom Name";
            // 
            // ClnAutomationId
            // 
            this.ClnAutomationId.Text = "Automation Id";
            this.ClnAutomationId.Width = 80;
            // 
            // ClnName
            // 
            this.ClnName.Text = "Name";
            this.ClnName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ClnControlType
            // 
            this.ClnControlType.Text = "Control Type";
            this.ClnControlType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClnControlType.Width = 90;
            // 
            // ClnClassName
            // 
            this.ClnClassName.Text = "Class Name";
            this.ClnClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClnClassName.Width = 80;
            // 
            // ClnHelpText
            // 
            this.ClnHelpText.Text = "Help Text";
            this.ClnHelpText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClnHelpText.Width = 70;
            // 
            // ClnAcceleratorKey
            // 
            this.ClnAcceleratorKey.Text = "Accelerator Key";
            this.ClnAcceleratorKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClnAcceleratorKey.Width = 100;
            // 
            // ClnAccessKey
            // 
            this.ClnAccessKey.Text = "Access Key";
            this.ClnAccessKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClnAccessKey.Width = 80;
            // 
            // ClnLabeledBy
            // 
            this.ClnLabeledBy.Text = "Labeled By";
            this.ClnLabeledBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClnLabeledBy.Width = 70;
            // 
            // ClnControlTreePosition
            // 
            this.ClnControlTreePosition.Text = "Tree Position";
            this.ClnControlTreePosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClnControlTreePosition.Width = 80;
            // 
            // ClnItemType
            // 
            this.ClnItemType.Text = "Item Type";
            this.ClnItemType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ClnItemType.Width = 80;
            // 
            // CtxListView
            // 
            this.CtxListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxAssignName});
            this.CtxListView.Name = "CtxListView";
            this.CtxListView.Size = new System.Drawing.Size(147, 26);
            // 
            // ctxAssignName
            // 
            this.ctxAssignName.Enabled = false;
            this.ctxAssignName.Name = "ctxAssignName";
            this.ctxAssignName.Size = new System.Drawing.Size(146, 22);
            this.ctxAssignName.Text = "Assign Name";
            this.ctxAssignName.ToolTipText = "Assign a custom identifier to a control.";
            this.ctxAssignName.Click += new System.EventHandler(this.ctxAssignName_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 36);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TvWindowList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LvControls);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1037, 587);
            this.splitContainer1.SplitterDistance = 239;
            this.splitContainer1.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadProgress,
            this.TsLoadedForm,
            this.TsSortOrder});
            this.statusStrip1.Location = new System.Drawing.Point(0, 565);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(794, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LoadProgress
            // 
            this.LoadProgress.Enabled = false;
            this.LoadProgress.Name = "LoadProgress";
            this.LoadProgress.Size = new System.Drawing.Size(100, 16);
            this.LoadProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.LoadProgress.Visible = false;
            // 
            // TsLoadedForm
            // 
            this.TsLoadedForm.Name = "TsLoadedForm";
            this.TsLoadedForm.Size = new System.Drawing.Size(0, 17);
            // 
            // TsSortOrder
            // 
            this.TsSortOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TsSortOrder.Name = "TsSortOrder";
            this.TsSortOrder.Size = new System.Drawing.Size(0, 17);
            this.TsSortOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsOpenMap,
            this.TsSaveWindow,
            this.toolStripSeparator1,
            this.TsGetWindows,
            this.toolStripSeparator2,
            this.TsCrawl,
            this.TsCompare});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1037, 36);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TsOpenMap
            // 
            this.TsOpenMap.Image = global::WinMap.Properties.Resources.OpenFile;
            this.TsOpenMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsOpenMap.Name = "TsOpenMap";
            this.TsOpenMap.Size = new System.Drawing.Size(60, 33);
            this.TsOpenMap.Text = "Open Map";
            this.TsOpenMap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsOpenMap.ToolTipText = "Open an exsisting map file";
            this.TsOpenMap.Click += new System.EventHandler(this.TsOpenMap_Click);
            // 
            // TsSaveWindow
            // 
            this.TsSaveWindow.Enabled = false;
            this.TsSaveWindow.Image = global::WinMap.Properties.Resources.saveHS;
            this.TsSaveWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsSaveWindow.Name = "TsSaveWindow";
            this.TsSaveWindow.Size = new System.Drawing.Size(58, 33);
            this.TsSaveWindow.Text = "Save Map";
            this.TsSaveWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsSaveWindow.ToolTipText = "Save the currently loaded window as a map file";
            this.TsSaveWindow.Click += new System.EventHandler(this.TsSaveWindow_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // TsGetWindows
            // 
            this.TsGetWindows.Image = global::WinMap.Properties.Resources.WindowsHS;
            this.TsGetWindows.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TsGetWindows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsGetWindows.Name = "TsGetWindows";
            this.TsGetWindows.Size = new System.Drawing.Size(74, 33);
            this.TsGetWindows.Text = "Get Windows";
            this.TsGetWindows.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsGetWindows.ToolTipText = "Get a list of all visible windows";
            this.TsGetWindows.Click += new System.EventHandler(this.TsGetWindows_Click);
            // 
            // TsCrawl
            // 
            this.TsCrawl.Enabled = false;
            this.TsCrawl.Image = global::WinMap.Properties.Resources.HtmlBalanceBracesHS;
            this.TsCrawl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsCrawl.Name = "TsCrawl";
            this.TsCrawl.Size = new System.Drawing.Size(72, 33);
            this.TsCrawl.Text = "Map Window";
            this.TsCrawl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsCrawl.ToolTipText = "Map the currently selected window";
            this.TsCrawl.Click += new System.EventHandler(this.TsCrawl_Click);
            // 
            // TsCompare
            // 
            this.TsCompare.Enabled = false;
            this.TsCompare.Image = global::WinMap.Properties.Resources.compareversionsHS;
            this.TsCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsCompare.Name = "TsCompare";
            this.TsCompare.Size = new System.Drawing.Size(54, 33);
            this.TsCompare.Text = "Compare";
            this.TsCompare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TsCompare.ToolTipText = "Compare the loaded window with a previously saved map file";
            this.TsCompare.Click += new System.EventHandler(this.TsCompare_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 36);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 623);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.Text = "WinMap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.CtxTreeView.ResumeLayout(false);
            this.CtxListView.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView TvWindowList;
        private System.Windows.Forms.ListView LvControls;
        private System.Windows.Forms.ColumnHeader ClnClassName;
        private System.Windows.Forms.ColumnHeader ClnControlType;
        private System.Windows.Forms.ColumnHeader ClnHelpText;
        private System.Windows.Forms.ColumnHeader ClnAcceleratorKey;
        private System.Windows.Forms.ColumnHeader ClnAccessKey;
        private System.Windows.Forms.ColumnHeader ClnLabeledBy;
        private System.Windows.Forms.ColumnHeader ClnControlTreePosition;
        private System.Windows.Forms.ColumnHeader ClnAutomationId;
        private System.Windows.Forms.ColumnHeader ClnName;
        private System.Windows.Forms.ColumnHeader ClnItemType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsSaveWindow;
        private System.Windows.Forms.ToolStripButton TsCompare;
        private System.Windows.Forms.ToolStripButton TsGetWindows;
        private System.Windows.Forms.ToolStripButton TsOpenMap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TsCrawl;
        private System.Windows.Forms.ContextMenuStrip CtxListView;
        private System.Windows.Forms.ToolStripMenuItem ctxAssignName;
        private System.Windows.Forms.ColumnHeader ClnCustom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar LoadProgress;
        private System.Windows.Forms.ToolStripStatusLabel TsLoadedForm;
        private System.Windows.Forms.ContextMenuStrip CtxTreeView;
        private System.Windows.Forms.ToolStripMenuItem CtxMapWindow;
        private System.Windows.Forms.ToolStripMenuItem CtxCompare;
        private System.Windows.Forms.ToolStripStatusLabel TsSortOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

