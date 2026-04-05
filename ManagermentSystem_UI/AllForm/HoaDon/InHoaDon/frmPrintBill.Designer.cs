namespace SuperProjectQ
{
    partial class frmPrintBill
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
            this.rpInHoaDon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpInHoaDon
            // 
            this.rpInHoaDon.Location = new System.Drawing.Point(9, 13);
            this.rpInHoaDon.Margin = new System.Windows.Forms.Padding(0);
            this.rpInHoaDon.Name = "rpInHoaDon";
            this.rpInHoaDon.ServerReport.BearerToken = null;
            this.rpInHoaDon.ShowBackButton = false;
            this.rpInHoaDon.ShowFindControls = false;
            this.rpInHoaDon.ShowStopButton = false;
            this.rpInHoaDon.Size = new System.Drawing.Size(440, 683);
            this.rpInHoaDon.TabIndex = 0;
            // 
            // frmPrintBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 705);
            this.Controls.Add(this.rpInHoaDon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPrintBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PrintBill";
            this.Load += new System.EventHandler(this.PrintBill_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpInHoaDon;
    }
}