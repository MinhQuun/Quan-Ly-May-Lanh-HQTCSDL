
namespace QuanLyCuaHangMayLanh
{
    partial class frmHoaDonXuat
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
            this.crvHoaDonXuat = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvHoaDonXuat
            // 
            this.crvHoaDonXuat.ActiveViewIndex = -1;
            this.crvHoaDonXuat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvHoaDonXuat.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvHoaDonXuat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvHoaDonXuat.Location = new System.Drawing.Point(0, 0);
            this.crvHoaDonXuat.Name = "crvHoaDonXuat";
            this.crvHoaDonXuat.Size = new System.Drawing.Size(800, 450);
            this.crvHoaDonXuat.TabIndex = 0;
            // 
            // frmHoaDonXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvHoaDonXuat);
            this.Name = "frmHoaDonXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHoaDonXuat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crvHoaDonXuat;
    }
}