namespace QuanLyCuaHangMayLanh
{
    partial class frm_NhanVienNhapHang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_NhapHang = new System.Windows.Forms.Button();
            this.btn_Product = new System.Windows.Forms.Button();
            this.btn_Supplier = new System.Windows.Forms.Button();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.btn_DashBoard = new System.Windows.Forms.Button();
            this.lbl_TitleEmployee = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nvnH_DashBoard1 = new QuanLyCuaHangMayLanh.NhanVienNhapHang.NVNH_DashBoard();
            this.uC_Supplier1 = new QuanLyCuaHangMayLanh.Admin.UC_Supplier();
            this.uC_Product1 = new QuanLyCuaHangMayLanh.Admin.UC_Product();
            this.uC_NhapHang1 = new QuanLyCuaHangMayLanh.Admin.UC_NhapHang();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.panel1.Controls.Add(this.btn_NhapHang);
            this.panel1.Controls.Add(this.btn_Product);
            this.panel1.Controls.Add(this.btn_Supplier);
            this.panel1.Controls.Add(this.lbl_UserName);
            this.panel1.Controls.Add(this.btn_LogOut);
            this.panel1.Controls.Add(this.btn_DashBoard);
            this.panel1.Controls.Add(this.lbl_TitleEmployee);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 1055);
            this.panel1.TabIndex = 1;
            // 
            // btn_NhapHang
            // 
            this.btn_NhapHang.BackColor = System.Drawing.Color.White;
            this.btn_NhapHang.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NhapHang.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.icons8_import_goods_30;
            this.btn_NhapHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NhapHang.Location = new System.Drawing.Point(0, 578);
            this.btn_NhapHang.Name = "btn_NhapHang";
            this.btn_NhapHang.Size = new System.Drawing.Size(250, 42);
            this.btn_NhapHang.TabIndex = 14;
            this.btn_NhapHang.Text = "Nhập Hàng";
            this.btn_NhapHang.UseVisualStyleBackColor = false;
            this.btn_NhapHang.Click += new System.EventHandler(this.btn_NhapHang_Click);
            // 
            // btn_Product
            // 
            this.btn_Product.BackColor = System.Drawing.Color.White;
            this.btn_Product.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Product.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.icons8_air_conditioner_30;
            this.btn_Product.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Product.Location = new System.Drawing.Point(3, 478);
            this.btn_Product.Name = "btn_Product";
            this.btn_Product.Size = new System.Drawing.Size(250, 42);
            this.btn_Product.TabIndex = 13;
            this.btn_Product.Text = "Sản Phẩm";
            this.btn_Product.UseVisualStyleBackColor = false;
            this.btn_Product.Click += new System.EventHandler(this.btn_Product_Click);
            // 
            // btn_Supplier
            // 
            this.btn_Supplier.BackColor = System.Drawing.Color.White;
            this.btn_Supplier.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Supplier.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.icons8_supplies_128;
            this.btn_Supplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Supplier.Location = new System.Drawing.Point(3, 378);
            this.btn_Supplier.Name = "btn_Supplier";
            this.btn_Supplier.Size = new System.Drawing.Size(250, 42);
            this.btn_Supplier.TabIndex = 12;
            this.btn_Supplier.Text = "Nhà Cung Cấp";
            this.btn_Supplier.UseVisualStyleBackColor = false;
            this.btn_Supplier.Click += new System.EventHandler(this.btn_Supplier_Click);
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_UserName.ForeColor = System.Drawing.Color.Gold;
            this.lbl_UserName.Location = new System.Drawing.Point(0, 778);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(250, 59);
            this.lbl_UserName.TabIndex = 7;
            this.lbl_UserName.Text = "Admin";
            this.lbl_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.BackColor = System.Drawing.Color.White;
            this.btn_LogOut.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LogOut.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.log_out;
            this.btn_LogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LogOut.Location = new System.Drawing.Point(0, 678);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(250, 42);
            this.btn_LogOut.TabIndex = 6;
            this.btn_LogOut.Text = "Đăng Xuất";
            this.btn_LogOut.UseVisualStyleBackColor = false;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // btn_DashBoard
            // 
            this.btn_DashBoard.BackColor = System.Drawing.Color.White;
            this.btn_DashBoard.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DashBoard.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.dashboard1;
            this.btn_DashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DashBoard.Location = new System.Drawing.Point(0, 278);
            this.btn_DashBoard.Name = "btn_DashBoard";
            this.btn_DashBoard.Size = new System.Drawing.Size(250, 42);
            this.btn_DashBoard.TabIndex = 2;
            this.btn_DashBoard.Text = "DashBoard";
            this.btn_DashBoard.UseVisualStyleBackColor = false;
            this.btn_DashBoard.Click += new System.EventHandler(this.btn_DashBoard_Click);
            // 
            // lbl_TitleEmployee
            // 
            this.lbl_TitleEmployee.AutoSize = true;
            this.lbl_TitleEmployee.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_TitleEmployee.ForeColor = System.Drawing.Color.White;
            this.lbl_TitleEmployee.Location = new System.Drawing.Point(22, 198);
            this.lbl_TitleEmployee.Name = "lbl_TitleEmployee";
            this.lbl_TitleEmployee.Size = new System.Drawing.Size(187, 49);
            this.lbl_TitleEmployee.TabIndex = 1;
            this.lbl_TitleEmployee.Text = "Employee";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.Air_Conditioning_free_icons_designed_by_Smashicons;
            this.pictureBox1.Location = new System.Drawing.Point(24, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // nvnH_DashBoard1
            // 
            this.nvnH_DashBoard1.Location = new System.Drawing.Point(259, 0);
            this.nvnH_DashBoard1.Name = "nvnH_DashBoard1";
            this.nvnH_DashBoard1.Size = new System.Drawing.Size(1667, 1102);
            this.nvnH_DashBoard1.TabIndex = 2;
            // 
            // uC_Supplier1
            // 
            this.uC_Supplier1.Location = new System.Drawing.Point(256, 0);
            this.uC_Supplier1.Name = "uC_Supplier1";
            this.uC_Supplier1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_Supplier1.TabIndex = 3;
            // 
            // uC_Product1
            // 
            this.uC_Product1.Location = new System.Drawing.Point(256, 0);
            this.uC_Product1.Name = "uC_Product1";
            this.uC_Product1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_Product1.TabIndex = 4;
            // 
            // uC_NhapHang1
            // 
            this.uC_NhapHang1.Location = new System.Drawing.Point(256, 0);
            this.uC_NhapHang1.Name = "uC_NhapHang1";
            this.uC_NhapHang1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_NhapHang1.TabIndex = 5;
            // 
            // frm_NhanVienNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1788, 1055);
            this.Controls.Add(this.uC_NhapHang1);
            this.Controls.Add(this.uC_Product1);
            this.Controls.Add(this.uC_Supplier1);
            this.Controls.Add(this.nvnH_DashBoard1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_NhanVienNhapHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_NhanVien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.Button btn_DashBoard;
        private System.Windows.Forms.Label lbl_TitleEmployee;
        private System.Windows.Forms.PictureBox pictureBox1;
        //private User.US_DashBoard uS_DashBoard1;
        private System.Windows.Forms.Button btn_NhapHang;
        private System.Windows.Forms.Button btn_Product;
        private System.Windows.Forms.Button btn_Supplier;
        private NhanVienNhapHang.NVNH_DashBoard nvnH_DashBoard1;
        private Admin.UC_Supplier uC_Supplier1;
        private Admin.UC_Product uC_Product1;
        private Admin.UC_NhapHang uC_NhapHang1;
    }
}