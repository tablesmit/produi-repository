namespace WindowCracker
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
            this.CmdCrawl = new System.Windows.Forms.Button();
            this.TvWindowList = new System.Windows.Forms.TreeView();
            this.CmdBrowse = new System.Windows.Forms.Button();
            this.TxtOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CmdCrawl
            // 
            this.CmdCrawl.Enabled = false;
            this.CmdCrawl.Location = new System.Drawing.Point(217, 212);
            this.CmdCrawl.Name = "CmdCrawl";
            this.CmdCrawl.Size = new System.Drawing.Size(98, 23);
            this.CmdCrawl.TabIndex = 0;
            this.CmdCrawl.Text = "Crawl Window";
            this.CmdCrawl.UseVisualStyleBackColor = true;
            this.CmdCrawl.Click += new System.EventHandler(this.CmdCrawl_Click);
            // 
            // TvWindowList
            // 
            this.TvWindowList.Dock = System.Windows.Forms.DockStyle.Left;
            this.TvWindowList.HideSelection = false;
            this.TvWindowList.Location = new System.Drawing.Point(0, 0);
            this.TvWindowList.Name = "TvWindowList";
            this.TvWindowList.Size = new System.Drawing.Size(158, 247);
            this.TvWindowList.TabIndex = 1;
            this.TvWindowList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvWindowList_AfterSelect);
            // 
            // CmdBrowse
            // 
            this.CmdBrowse.Location = new System.Drawing.Point(229, 53);
            this.CmdBrowse.Name = "CmdBrowse";
            this.CmdBrowse.Size = new System.Drawing.Size(75, 23);
            this.CmdBrowse.TabIndex = 3;
            this.CmdBrowse.Text = "Browse";
            this.CmdBrowse.UseVisualStyleBackColor = true;
            this.CmdBrowse.Click += new System.EventHandler(this.CmdBrowse_Click);
            // 
            // TxtOutput
            // 
            this.TxtOutput.Location = new System.Drawing.Point(180, 27);
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.Size = new System.Drawing.Size(172, 20);
            this.TxtOutput.TabIndex = 4;
            this.TxtOutput.TextChanged += new System.EventHandler(this.TxtOutput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Output File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 247);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtOutput);
            this.Controls.Add(this.CmdBrowse);
            this.Controls.Add(this.TvWindowList);
            this.Controls.Add(this.CmdCrawl);
            this.Name = "MainForm";
            this.Text = "Window Cracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdCrawl;
        private System.Windows.Forms.TreeView TvWindowList;
        private System.Windows.Forms.Button CmdBrowse;
        private System.Windows.Forms.TextBox TxtOutput;
        private System.Windows.Forms.Label label1;
    }
}

