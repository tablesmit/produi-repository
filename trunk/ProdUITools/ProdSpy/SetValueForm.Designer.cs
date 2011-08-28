namespace ProdSpy
{
    partial class SetValueForm
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
            this.TxtValue = new System.Windows.Forms.TextBox();
            this.CmdOk = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.TxtPrompt = new System.Windows.Forms.TextBox();
            this.PnlParams = new System.Windows.Forms.Panel();
            this.PnlParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(65, 6);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(175, 20);
            this.TxtValue.TabIndex = 1;
            // 
            // CmdOk
            // 
            this.CmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CmdOk.Location = new System.Drawing.Point(74, 61);
            this.CmdOk.Name = "CmdOk";
            this.CmdOk.Size = new System.Drawing.Size(75, 23);
            this.CmdOk.TabIndex = 3;
            this.CmdOk.Text = "OK";
            this.CmdOk.UseVisualStyleBackColor = true;
            this.CmdOk.Click += new System.EventHandler(this.CmdOk_Click);
            // 
            // CmdCancel
            // 
            this.CmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.Location = new System.Drawing.Point(155, 61);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel.TabIndex = 4;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            // 
            // TxtPrompt
            // 
            this.TxtPrompt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPrompt.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtPrompt.Location = new System.Drawing.Point(0, 0);
            this.TxtPrompt.Multiline = true;
            this.TxtPrompt.Name = "TxtPrompt";
            this.TxtPrompt.ReadOnly = true;
            this.TxtPrompt.Size = new System.Drawing.Size(304, 19);
            this.TxtPrompt.TabIndex = 5;
            this.TxtPrompt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PnlParams
            // 
            this.PnlParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlParams.Controls.Add(this.TxtValue);
            this.PnlParams.Location = new System.Drawing.Point(0, 23);
            this.PnlParams.Name = "PnlParams";
            this.PnlParams.Size = new System.Drawing.Size(304, 32);
            this.PnlParams.TabIndex = 6;
            // 
            // SetValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 96);
            this.Controls.Add(this.PnlParams);
            this.Controls.Add(this.TxtPrompt);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(310, 146);
            this.Name = "SetValueForm";
            this.Text = "Set Value";
            this.Load += new System.EventHandler(this.SetValue_Load);
            this.PnlParams.ResumeLayout(false);
            this.PnlParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Button CmdOk;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.TextBox TxtPrompt;
        private System.Windows.Forms.Panel PnlParams;
    }
}