namespace DialogTest
{
    partial class Form1
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
            this.CmdOFD = new System.Windows.Forms.Button();
            this.CmdMbox = new System.Windows.Forms.Button();
            this.CmdFontDialog = new System.Windows.Forms.Button();
            this.CmdFolderBrowser = new System.Windows.Forms.Button();
            this.CmdSFD = new System.Windows.Forms.Button();
            this.CmdColorDialog = new System.Windows.Forms.Button();
            this.CmdPrintDialog = new System.Windows.Forms.Button();
            this.CmdPageSetupDialog = new System.Windows.Forms.Button();
            this.CmdPrintPreview = new System.Windows.Forms.Button();
            this.TxtAnyText = new System.Windows.Forms.TextBox();
            this.CmdChild = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmdOFD
            // 
            this.CmdOFD.Location = new System.Drawing.Point(80, 23);
            this.CmdOFD.Name = "CmdOFD";
            this.CmdOFD.Size = new System.Drawing.Size(85, 23);
            this.CmdOFD.TabIndex = 0;
            this.CmdOFD.Text = "Open File";
            this.CmdOFD.UseVisualStyleBackColor = true;
            this.CmdOFD.Click += new System.EventHandler(this.CmdOFD_Click);
            // 
            // CmdMbox
            // 
            this.CmdMbox.Location = new System.Drawing.Point(80, 77);
            this.CmdMbox.Name = "CmdMbox";
            this.CmdMbox.Size = new System.Drawing.Size(85, 23);
            this.CmdMbox.TabIndex = 1;
            this.CmdMbox.Text = "MessageBox";
            this.CmdMbox.UseVisualStyleBackColor = true;
            this.CmdMbox.Click += new System.EventHandler(this.CmdMbox_Click);
            // 
            // CmdFontDialog
            // 
            this.CmdFontDialog.Location = new System.Drawing.Point(195, 77);
            this.CmdFontDialog.Name = "CmdFontDialog";
            this.CmdFontDialog.Size = new System.Drawing.Size(85, 23);
            this.CmdFontDialog.TabIndex = 2;
            this.CmdFontDialog.Text = "Font";
            this.CmdFontDialog.UseVisualStyleBackColor = true;
            this.CmdFontDialog.Click += new System.EventHandler(this.CmdFontDialog_Click);
            // 
            // CmdFolderBrowser
            // 
            this.CmdFolderBrowser.Location = new System.Drawing.Point(310, 23);
            this.CmdFolderBrowser.Name = "CmdFolderBrowser";
            this.CmdFolderBrowser.Size = new System.Drawing.Size(85, 23);
            this.CmdFolderBrowser.TabIndex = 3;
            this.CmdFolderBrowser.Text = "Folder Browser";
            this.CmdFolderBrowser.UseVisualStyleBackColor = true;
            // 
            // CmdSFD
            // 
            this.CmdSFD.Location = new System.Drawing.Point(195, 23);
            this.CmdSFD.Name = "CmdSFD";
            this.CmdSFD.Size = new System.Drawing.Size(85, 23);
            this.CmdSFD.TabIndex = 4;
            this.CmdSFD.Text = "Save File";
            this.CmdSFD.UseVisualStyleBackColor = true;
            this.CmdSFD.Click += new System.EventHandler(this.CmdSFD_Click);
            // 
            // CmdColorDialog
            // 
            this.CmdColorDialog.Location = new System.Drawing.Point(310, 77);
            this.CmdColorDialog.Name = "CmdColorDialog";
            this.CmdColorDialog.Size = new System.Drawing.Size(85, 23);
            this.CmdColorDialog.TabIndex = 5;
            this.CmdColorDialog.Text = "Color Picker";
            this.CmdColorDialog.UseVisualStyleBackColor = true;
            this.CmdColorDialog.Click += new System.EventHandler(this.CmdColorDialog_Click);
            // 
            // CmdPrintDialog
            // 
            this.CmdPrintDialog.Location = new System.Drawing.Point(80, 129);
            this.CmdPrintDialog.Name = "CmdPrintDialog";
            this.CmdPrintDialog.Size = new System.Drawing.Size(85, 23);
            this.CmdPrintDialog.TabIndex = 6;
            this.CmdPrintDialog.Text = "Print Dialog";
            this.CmdPrintDialog.UseVisualStyleBackColor = true;
            this.CmdPrintDialog.Click += new System.EventHandler(this.CmdPrintDialog_Click);
            // 
            // CmdPageSetupDialog
            // 
            this.CmdPageSetupDialog.Location = new System.Drawing.Point(195, 129);
            this.CmdPageSetupDialog.Name = "CmdPageSetupDialog";
            this.CmdPageSetupDialog.Size = new System.Drawing.Size(85, 23);
            this.CmdPageSetupDialog.TabIndex = 7;
            this.CmdPageSetupDialog.Text = "Page Setup";
            this.CmdPageSetupDialog.UseVisualStyleBackColor = true;
            this.CmdPageSetupDialog.Click += new System.EventHandler(this.CmdPageSetupDialog_Click);
            // 
            // CmdPrintPreview
            // 
            this.CmdPrintPreview.Location = new System.Drawing.Point(310, 129);
            this.CmdPrintPreview.Name = "CmdPrintPreview";
            this.CmdPrintPreview.Size = new System.Drawing.Size(85, 23);
            this.CmdPrintPreview.TabIndex = 8;
            this.CmdPrintPreview.Text = "Print Preview";
            this.CmdPrintPreview.UseVisualStyleBackColor = true;
            this.CmdPrintPreview.Click += new System.EventHandler(this.CmdPrintPreview_Click);
            // 
            // TxtAnyText
            // 
            this.TxtAnyText.Location = new System.Drawing.Point(80, 229);
            this.TxtAnyText.Name = "TxtAnyText";
            this.TxtAnyText.Size = new System.Drawing.Size(322, 20);
            this.TxtAnyText.TabIndex = 9;
            // 
            // CmdChild
            // 
            this.CmdChild.Location = new System.Drawing.Point(195, 185);
            this.CmdChild.Name = "CmdChild";
            this.CmdChild.Size = new System.Drawing.Size(75, 23);
            this.CmdChild.TabIndex = 10;
            this.CmdChild.Text = "Child";
            this.CmdChild.UseVisualStyleBackColor = true;
            this.CmdChild.Click += new System.EventHandler(this.CmdChild_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 265);
            this.Controls.Add(this.CmdChild);
            this.Controls.Add(this.TxtAnyText);
            this.Controls.Add(this.CmdPrintPreview);
            this.Controls.Add(this.CmdPageSetupDialog);
            this.Controls.Add(this.CmdPrintDialog);
            this.Controls.Add(this.CmdColorDialog);
            this.Controls.Add(this.CmdSFD);
            this.Controls.Add(this.CmdFolderBrowser);
            this.Controls.Add(this.CmdFontDialog);
            this.Controls.Add(this.CmdMbox);
            this.Controls.Add(this.CmdOFD);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdOFD;
        private System.Windows.Forms.Button CmdMbox;
        private System.Windows.Forms.Button CmdFontDialog;
        private System.Windows.Forms.Button CmdFolderBrowser;
        private System.Windows.Forms.Button CmdSFD;
        private System.Windows.Forms.Button CmdColorDialog;
        private System.Windows.Forms.Button CmdPrintDialog;
        private System.Windows.Forms.Button CmdPageSetupDialog;
        private System.Windows.Forms.Button CmdPrintPreview;
        private System.Windows.Forms.TextBox TxtAnyText;
        private System.Windows.Forms.Button CmdChild;
    }
}

