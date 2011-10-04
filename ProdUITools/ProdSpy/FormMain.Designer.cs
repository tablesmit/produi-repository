using System.Security.Permissions;

namespace ProdSpy
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.LblBegin = new System.Windows.Forms.Label();
            this.LblCap = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TsCoords = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsPin = new System.Windows.Forms.ToolStripButton();
            this.TsGraph = new System.Windows.Forms.ToolStripButton();
            this.TsHighlight = new System.Windows.Forms.ToolStripButton();
            this.TsInteractions = new System.Windows.Forms.ToolStripDropDownButton();
            this.TsOptions = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PropControls = new System.Windows.Forms.PropertyGrid();
            this.PropApplication = new System.Windows.Forms.PropertyGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.LstSupportedPatterns = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LstSupportedProperties = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.RtbCode = new System.Windows.Forms.RichTextBox();
            this.CtxRtb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtxCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GraphSplitter = new System.Windows.Forms.SplitContainer();
            this.TvGraph = new System.Windows.Forms.TreeView();
            this.CtxTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CtxExportIds = new System.Windows.Forms.ToolStripMenuItem();
            this.CtxTextReport = new System.Windows.Forms.ToolStripMenuItem();
            this.CtxExcelReport = new System.Windows.Forms.ToolStripMenuItem();
            this.CtxHTMLReport = new System.Windows.Forms.ToolStripMenuItem();
            this.CtxHighlight = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.RtbTip = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.CtxRtb.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphSplitter)).BeginInit();
            this.GraphSplitter.Panel1.SuspendLayout();
            this.GraphSplitter.Panel2.SuspendLayout();
            this.GraphSplitter.SuspendLayout();
            this.CtxTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblBegin
            // 
            resources.ApplyResources(this.LblBegin, "LblBegin");
            this.LblBegin.Name = "LblBegin";
            // 
            // LblCap
            // 
            resources.ApplyResources(this.LblCap, "LblCap");
            this.LblCap.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblCap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblCap.Name = "LblCap";
            this.LblCap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LblCap_MouseDown);
            this.LblCap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LblCap_MouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.TsCoords});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // TsCoords
            // 
            this.TsCoords.Name = "TsCoords";
            resources.ApplyResources(this.TsCoords, "TsCoords");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsPin,
            this.TsGraph,
            this.TsHighlight,
            this.TsInteractions,
            this.TsOptions});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // TsPin
            // 
            resources.ApplyResources(this.TsPin, "TsPin");
            this.TsPin.CheckOnClick = true;
            this.TsPin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsPin.Name = "TsPin";
            this.TsPin.Click += new System.EventHandler(this.TsPin_Click);
            // 
            // TsGraph
            // 
            resources.ApplyResources(this.TsGraph, "TsGraph");
            this.TsGraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsGraph.Name = "TsGraph";
            this.TsGraph.Click += new System.EventHandler(this.TsGraph_Click);
            // 
            // TsHighlight
            // 
            resources.ApplyResources(this.TsHighlight, "TsHighlight");
            this.TsHighlight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsHighlight.Name = "TsHighlight";
            this.TsHighlight.Click += new System.EventHandler(this.TsHighlight_Click);
            // 
            // TsInteractions
            // 
            resources.ApplyResources(this.TsInteractions, "TsInteractions");
            this.TsInteractions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsInteractions.Name = "TsInteractions";
            // 
            // TsOptions
            // 
            this.TsOptions.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.TsOptions, "TsOptions");
            this.TsOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsOptions.Name = "TsOptions";
            this.TsOptions.Click += new System.EventHandler(this.TsOptions_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PropControls);
            this.tabPage1.Controls.Add(this.PropApplication);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PropControls
            // 
            resources.ApplyResources(this.PropControls, "PropControls");
            this.PropControls.Name = "PropControls";
            this.PropControls.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.PropControls.ToolbarVisible = false;
            this.PropControls.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // PropApplication
            // 
            resources.ApplyResources(this.PropApplication, "PropApplication");
            this.PropApplication.Name = "PropApplication";
            this.PropApplication.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.PropApplication.TabStop = false;
            this.PropApplication.ToolbarVisible = false;
            this.PropApplication.ViewForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.LstSupportedPatterns);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LstSupportedProperties);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            // 
            // LstSupportedPatterns
            // 
            resources.ApplyResources(this.LstSupportedPatterns, "LstSupportedPatterns");
            this.LstSupportedPatterns.FormattingEnabled = true;
            this.LstSupportedPatterns.Name = "LstSupportedPatterns";
            this.LstSupportedPatterns.Sorted = true;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // LstSupportedProperties
            // 
            resources.ApplyResources(this.LstSupportedProperties, "LstSupportedProperties");
            this.LstSupportedProperties.FormattingEnabled = true;
            this.LstSupportedProperties.Name = "LstSupportedProperties";
            this.LstSupportedProperties.Sorted = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RtbCode);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // RtbCode
            // 
            this.RtbCode.BackColor = System.Drawing.SystemColors.Window;
            this.RtbCode.ContextMenuStrip = this.CtxRtb;
            resources.ApplyResources(this.RtbCode, "RtbCode");
            this.RtbCode.Name = "RtbCode";
            this.RtbCode.ReadOnly = true;
            this.RtbCode.SelectionChanged += new System.EventHandler(this.RtbCode_SelectionChanged);
            // 
            // CtxRtb
            // 
            this.CtxRtb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtxCopy});
            this.CtxRtb.Name = "CtxRtb";
            resources.ApplyResources(this.CtxRtb, "CtxRtb");
            // 
            // CtxCopy
            // 
            resources.ApplyResources(this.CtxCopy, "CtxCopy");
            this.CtxCopy.Name = "CtxCopy";
            this.CtxCopy.Click += new System.EventHandler(this.CtxCopy_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblBegin);
            this.panel1.Controls.Add(this.LblCap);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // GraphSplitter
            // 
            resources.ApplyResources(this.GraphSplitter, "GraphSplitter");
            this.GraphSplitter.Name = "GraphSplitter";
            // 
            // GraphSplitter.Panel1
            // 
            this.GraphSplitter.Panel1.Controls.Add(this.TvGraph);
            this.GraphSplitter.Panel1.Controls.Add(this.RtbTip);
            this.GraphSplitter.Panel1Collapsed = true;
            // 
            // GraphSplitter.Panel2
            // 
            this.GraphSplitter.Panel2.Controls.Add(this.tabControl1);
            // 
            // TvGraph
            // 
            this.TvGraph.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TvGraph.ContextMenuStrip = this.CtxTree;
            resources.ApplyResources(this.TvGraph, "TvGraph");
            this.TvGraph.HideSelection = false;
            this.TvGraph.ImageList = this.imageList1;
            this.TvGraph.Name = "TvGraph";
            this.TvGraph.ShowNodeToolTips = true;
            this.TvGraph.ShowPlusMinus = false;
            this.TvGraph.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvGraph_AfterSelect);
            // 
            // CtxTree
            // 
            this.CtxTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtxExportIds,
            this.CtxHighlight});
            this.CtxTree.Name = "CtxTree";
            resources.ApplyResources(this.CtxTree, "CtxTree");
            // 
            // CtxExportIds
            // 
            this.CtxExportIds.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CtxTextReport,
            this.CtxExcelReport,
            this.CtxHTMLReport});
            this.CtxExportIds.Name = "CtxExportIds";
            resources.ApplyResources(this.CtxExportIds, "CtxExportIds");
            // 
            // CtxTextReport
            // 
            this.CtxTextReport.Name = "CtxTextReport";
            resources.ApplyResources(this.CtxTextReport, "CtxTextReport");
            // 
            // CtxExcelReport
            // 
            this.CtxExcelReport.Name = "CtxExcelReport";
            resources.ApplyResources(this.CtxExcelReport, "CtxExcelReport");
            // 
            // CtxHTMLReport
            // 
            this.CtxHTMLReport.Name = "CtxHTMLReport";
            resources.ApplyResources(this.CtxHTMLReport, "CtxHTMLReport");
            // 
            // CtxHighlight
            // 
            this.CtxHighlight.Name = "CtxHighlight";
            resources.ApplyResources(this.CtxHighlight, "CtxHighlight");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "GoToNextHS.png");
            this.imageList1.Images.SetKeyName(1, "RecordHS.png");
            this.imageList1.Images.SetKeyName(2, "StopHS.png");
            // 
            // RtbTip
            // 
            this.RtbTip.AutoWordSelection = true;
            this.RtbTip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RtbTip.ContextMenuStrip = this.CtxRtb;
            resources.ApplyResources(this.RtbTip, "RtbTip");
            this.RtbTip.Name = "RtbTip";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GraphSplitter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.CtxRtb.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.GraphSplitter.Panel1.ResumeLayout(false);
            this.GraphSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GraphSplitter)).EndInit();
            this.GraphSplitter.ResumeLayout(false);
            this.CtxTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblBegin;
        private System.Windows.Forms.Label LblCap;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TsCoords;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsGraph;
        private System.Windows.Forms.ToolStripButton TsPin;
        private System.Windows.Forms.ToolStripButton TsOptions;
        private System.Windows.Forms.ToolStripButton TsHighlight;
        private System.Windows.Forms.ToolStripDropDownButton TsInteractions;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PropertyGrid PropControls;
        private System.Windows.Forms.PropertyGrid PropApplication;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox LstSupportedPatterns;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox LstSupportedProperties;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer GraphSplitter;
        private System.Windows.Forms.TreeView TvGraph;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip CtxRtb;
        private System.Windows.Forms.ToolStripMenuItem CtxCopy;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip CtxTree;
        private System.Windows.Forms.ToolStripMenuItem CtxExportIds;
        private System.Windows.Forms.ToolStripMenuItem CtxTextReport;
        private System.Windows.Forms.ToolStripMenuItem CtxExcelReport;
        private System.Windows.Forms.ToolStripMenuItem CtxHTMLReport;
        private System.Windows.Forms.ToolStripMenuItem CtxHighlight;
        private System.Windows.Forms.RichTextBox RtbTip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox RtbCode;
    }
}

