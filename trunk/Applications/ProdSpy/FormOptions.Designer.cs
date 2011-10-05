namespace ProdSpy
{
    partial class FormOptions
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
            this.ChkShowFocus = new System.Windows.Forms.CheckBox();
            this.CmdSave = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.ChkAutoHighlightFocus = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkTreeNodeHighlight = new System.Windows.Forms.CheckBox();
            this.ChkUpdateFromNode = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ChkExpandedGraph = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChkShowFocus
            // 
            this.ChkShowFocus.AutoSize = true;
            this.ChkShowFocus.Location = new System.Drawing.Point(22, 31);
            this.ChkShowFocus.Name = "ChkShowFocus";
            this.ChkShowFocus.Size = new System.Drawing.Size(125, 17);
            this.ChkShowFocus.TabIndex = 0;
            this.ChkShowFocus.Text = "Show Focus Graphic";
            this.ChkShowFocus.UseVisualStyleBackColor = true;
            // 
            // CmdSave
            // 
            this.CmdSave.Location = new System.Drawing.Point(125, 159);
            this.CmdSave.Name = "CmdSave";
            this.CmdSave.Size = new System.Drawing.Size(75, 23);
            this.CmdSave.TabIndex = 1;
            this.CmdSave.Text = "Save";
            this.CmdSave.UseVisualStyleBackColor = true;
            this.CmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // CmdCancel
            // 
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.Location = new System.Drawing.Point(213, 159);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel.TabIndex = 2;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // ChkAutoHighlightFocus
            // 
            this.ChkAutoHighlightFocus.AutoSize = true;
            this.ChkAutoHighlightFocus.Location = new System.Drawing.Point(22, 55);
            this.ChkAutoHighlightFocus.Name = "ChkAutoHighlightFocus";
            this.ChkAutoHighlightFocus.Size = new System.Drawing.Size(124, 17);
            this.ChkAutoHighlightFocus.TabIndex = 3;
            this.ChkAutoHighlightFocus.Text = "Auto Highlight Focus";
            this.toolTip1.SetToolTip(this.ChkAutoHighlightFocus, "Shows highlight box on focused control after mouse release");
            this.ChkAutoHighlightFocus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkAutoHighlightFocus);
            this.groupBox1.Controls.Add(this.ChkShowFocus);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Analyzer";
            // 
            // ChkTreeNodeHighlight
            // 
            this.ChkTreeNodeHighlight.AutoSize = true;
            this.ChkTreeNodeHighlight.Location = new System.Drawing.Point(6, 54);
            this.ChkTreeNodeHighlight.Name = "ChkTreeNodeHighlight";
            this.ChkTreeNodeHighlight.Size = new System.Drawing.Size(135, 17);
            this.ChkTreeNodeHighlight.TabIndex = 5;
            this.ChkTreeNodeHighlight.Text = "Highlight focused node";
            this.toolTip1.SetToolTip(this.ChkTreeNodeHighlight, "Check to enable the corrospoinding control to be highlighted");
            this.ChkTreeNodeHighlight.UseVisualStyleBackColor = true;
            // 
            // ChkUpdateFromNode
            // 
            this.ChkUpdateFromNode.AutoSize = true;
            this.ChkUpdateFromNode.Checked = true;
            this.ChkUpdateFromNode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkUpdateFromNode.Location = new System.Drawing.Point(6, 31);
            this.ChkUpdateFromNode.Name = "ChkUpdateFromNode";
            this.ChkUpdateFromNode.Size = new System.Drawing.Size(142, 17);
            this.ChkUpdateFromNode.TabIndex = 6;
            this.ChkUpdateFromNode.Text = "Update on node change";
            this.toolTip1.SetToolTip(this.ChkUpdateFromNode, "Check to update the analysis portion on node switch");
            this.ChkUpdateFromNode.UseVisualStyleBackColor = true;
            // 
            // ChkExpandedGraph
            // 
            this.ChkExpandedGraph.AutoSize = true;
            this.ChkExpandedGraph.Location = new System.Drawing.Point(6, 78);
            this.ChkExpandedGraph.Name = "ChkExpandedGraph";
            this.ChkExpandedGraph.Size = new System.Drawing.Size(94, 17);
            this.ChkExpandedGraph.TabIndex = 8;
            this.ChkExpandedGraph.Text = "Expand Graph";
            this.toolTip1.SetToolTip(this.ChkExpandedGraph, "Check to have the control graph expanded on startup");
            this.ChkExpandedGraph.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkExpandedGraph);
            this.groupBox2.Controls.Add(this.ChkTreeNodeHighlight);
            this.groupBox2.Controls.Add(this.ChkUpdateFromNode);
            this.groupBox2.Location = new System.Drawing.Point(210, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(170, 109);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graph Options";
            // 
            // FormOptions
            // 
            this.AcceptButton = this.CmdSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CmdCancel;
            this.ClientSize = new System.Drawing.Size(412, 199);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ChkShowFocus;
        private System.Windows.Forms.Button CmdSave;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.CheckBox ChkAutoHighlightFocus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ChkTreeNodeHighlight;
        private System.Windows.Forms.CheckBox ChkUpdateFromNode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ChkExpandedGraph;
    }
}