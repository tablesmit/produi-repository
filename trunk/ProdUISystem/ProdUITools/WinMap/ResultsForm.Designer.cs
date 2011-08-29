namespace WinMap
{
    partial class ResultsForm
    {

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LvResults = new System.Windows.Forms.ListView();
            this.ClnCheckPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnOrigVal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnNewVal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LblWindowScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LvResults
            // 
            this.LvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClnCheckPoint,
            this.ClnOrigVal,
            this.ClnNewVal,
            this.ClnResult});
            this.LvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvResults.Location = new System.Drawing.Point(0, 36);
            this.LvResults.Name = "LvResults";
            this.LvResults.Size = new System.Drawing.Size(414, 534);
            this.LvResults.TabIndex = 0;
            this.LvResults.UseCompatibleStateImageBehavior = false;
            this.LvResults.View = System.Windows.Forms.View.Details;
            // 
            // ClnCheckPoint
            // 
            this.ClnCheckPoint.Text = "CheckPoint";
            this.ClnCheckPoint.Width = 116;
            // 
            // ClnOrigVal
            // 
            this.ClnOrigVal.Text = "Original Value";
            this.ClnOrigVal.Width = 102;
            // 
            // ClnNewVal
            // 
            this.ClnNewVal.Text = "Scanned Value";
            this.ClnNewVal.Width = 104;
            // 
            // ClnResult
            // 
            this.ClnResult.Text = "Pass";
            // 
            // LblWindowScore
            // 
            this.LblWindowScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblWindowScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblWindowScore.Location = new System.Drawing.Point(0, 0);
            this.LblWindowScore.Name = "LblWindowScore";
            this.LblWindowScore.Size = new System.Drawing.Size(414, 36);
            this.LblWindowScore.TabIndex = 1;
            this.LblWindowScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 570);
            this.Controls.Add(this.LvResults);
            this.Controls.Add(this.LblWindowScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Results";
            this.Load += new System.EventHandler(this.ResultsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView LvResults;
        private System.Windows.Forms.ColumnHeader ClnOrigVal;
        private System.Windows.Forms.ColumnHeader ClnNewVal;
        private System.Windows.Forms.ColumnHeader ClnCheckPoint;
        private System.Windows.Forms.Label LblWindowScore;
        private System.Windows.Forms.ColumnHeader ClnResult;
    }
}