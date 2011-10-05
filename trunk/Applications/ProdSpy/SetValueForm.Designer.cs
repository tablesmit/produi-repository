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
            this.LblPrompt = new System.Windows.Forms.Label();
            this.PnlOptions = new System.Windows.Forms.Panel();
            this.RdoInconclusive = new System.Windows.Forms.RadioButton();
            this.RdoNegative = new System.Windows.Forms.RadioButton();
            this.RdoAffirm = new System.Windows.Forms.RadioButton();
            this.CmdOk = new System.Windows.Forms.Button();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.PnlOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtValue
            // 
            this.TxtValue.Location = new System.Drawing.Point(84, 26);
            this.TxtValue.Name = "TxtValue";
            this.TxtValue.Size = new System.Drawing.Size(226, 20);
            this.TxtValue.TabIndex = 0;
            // 
            // LblPrompt
            // 
            this.LblPrompt.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblPrompt.Location = new System.Drawing.Point(0, 0);
            this.LblPrompt.Name = "LblPrompt";
            this.LblPrompt.Size = new System.Drawing.Size(394, 23);
            this.LblPrompt.TabIndex = 1;
            this.LblPrompt.Text = "label1";
            this.LblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlOptions
            // 
            this.PnlOptions.Controls.Add(this.RdoInconclusive);
            this.PnlOptions.Controls.Add(this.RdoNegative);
            this.PnlOptions.Controls.Add(this.RdoAffirm);
            this.PnlOptions.Location = new System.Drawing.Point(84, 48);
            this.PnlOptions.Name = "PnlOptions";
            this.PnlOptions.Size = new System.Drawing.Size(226, 24);
            this.PnlOptions.TabIndex = 2;
            this.PnlOptions.Visible = false;
            // 
            // RdoInconclusive
            // 
            this.RdoInconclusive.AutoSize = true;
            this.RdoInconclusive.Location = new System.Drawing.Point(135, 4);
            this.RdoInconclusive.Name = "RdoInconclusive";
            this.RdoInconclusive.Size = new System.Drawing.Size(89, 17);
            this.RdoInconclusive.TabIndex = 2;
            this.RdoInconclusive.TabStop = true;
            this.RdoInconclusive.Text = "Indeterminate";
            this.RdoInconclusive.UseVisualStyleBackColor = true;
            this.RdoInconclusive.CheckedChanged += new System.EventHandler(this.RdoInconclusive_CheckedChanged);
            // 
            // RdoNegative
            // 
            this.RdoNegative.AutoSize = true;
            this.RdoNegative.Location = new System.Drawing.Point(68, 4);
            this.RdoNegative.Name = "RdoNegative";
            this.RdoNegative.Size = new System.Drawing.Size(39, 17);
            this.RdoNegative.TabIndex = 1;
            this.RdoNegative.TabStop = true;
            this.RdoNegative.Text = "Off";
            this.RdoNegative.UseVisualStyleBackColor = true;
            this.RdoNegative.CheckedChanged += new System.EventHandler(this.RdoNegative_CheckedChanged);
            // 
            // RdoAffirm
            // 
            this.RdoAffirm.AutoSize = true;
            this.RdoAffirm.Location = new System.Drawing.Point(4, 4);
            this.RdoAffirm.Name = "RdoAffirm";
            this.RdoAffirm.Size = new System.Drawing.Size(39, 17);
            this.RdoAffirm.TabIndex = 0;
            this.RdoAffirm.TabStop = true;
            this.RdoAffirm.Text = "On";
            this.RdoAffirm.UseVisualStyleBackColor = true;
            this.RdoAffirm.CheckedChanged += new System.EventHandler(this.RdoAffirm_CheckedChanged);
            // 
            // CmdOk
            // 
            this.CmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CmdOk.Location = new System.Drawing.Point(125, 111);
            this.CmdOk.Name = "CmdOk";
            this.CmdOk.Size = new System.Drawing.Size(75, 23);
            this.CmdOk.TabIndex = 3;
            this.CmdOk.Text = "Ok";
            this.CmdOk.UseVisualStyleBackColor = true;
            this.CmdOk.Click += new System.EventHandler(this.CmdOk_Click);
            // 
            // CmdCancel
            // 
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.Location = new System.Drawing.Point(214, 111);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel.TabIndex = 4;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            // 
            // SetValueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 147);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdOk);
            this.Controls.Add(this.PnlOptions);
            this.Controls.Add(this.LblPrompt);
            this.Controls.Add(this.TxtValue);
            this.Name = "SetValueForm";
            this.Text = "Set Value";
            this.Load += new System.EventHandler(this.SetValueForm_Load);
            this.PnlOptions.ResumeLayout(false);
            this.PnlOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtValue;
        private System.Windows.Forms.Label LblPrompt;
        private System.Windows.Forms.Panel PnlOptions;
        private System.Windows.Forms.RadioButton RdoInconclusive;
        private System.Windows.Forms.RadioButton RdoNegative;
        private System.Windows.Forms.RadioButton RdoAffirm;
        private System.Windows.Forms.Button CmdOk;
        private System.Windows.Forms.Button CmdCancel;
    }
}