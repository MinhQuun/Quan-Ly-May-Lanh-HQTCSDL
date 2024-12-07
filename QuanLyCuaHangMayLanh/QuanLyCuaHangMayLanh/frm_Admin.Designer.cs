namespace QuanLyCuaHangMayLanh
{
    partial class frm_Admin
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
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.lbl_TitleAdmin = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_NhapHang1 = new QuanLyCuaHangMayLanh.Admin.UC_NhapHang();
            this.uC_Product1 = new QuanLyCuaHangMayLanh.Admin.UC_Product();
            this.uC_Supplier1 = new QuanLyCuaHangMayLanh.Admin.UC_Supplier();
            this.uC_User1 = new QuanLyCuaHangMayLanh.Admin.UC_User();
            this.uC_DashBoard1 = new QuanLyCuaHangMayLanh.Admin.UC_DashBoard();
            this.btn_NhapHang = new System.Windows.Forms.Button();
            this.btn_BanHang = new System.Windows.Forms.Button();
            this.btn_Product = new System.Windows.Forms.Button();
            this.btn_Supplier = new System.Windows.Forms.Button();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.btn_User = new System.Windows.Forms.Button();
            this.btn_DashBoard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btn_NhapHang);
            this.panel1.Controls.Add(this.btn_BanHang);
            this.panel1.Controls.Add(this.btn_Product);
            this.panel1.Controls.Add(this.btn_Supplier);
            this.panel1.Controls.Add(this.lbl_UserName);
            this.panel1.Controls.Add(this.btn_LogOut);
            this.panel1.Controls.Add(this.btn_User);
            this.panel1.Controls.Add(this.btn_DashBoard);
            this.panel1.Controls.Add(this.lbl_TitleAdmin);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 1010);
            this.panel1.TabIndex = 0;
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_UserName.ForeColor = System.Drawing.Color.Gold;
            this.lbl_UserName.Location = new System.Drawing.Point(0, 791);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(250, 59);
            this.lbl_UserName.TabIndex = 7;
            this.lbl_UserName.Text = "Admin";
            this.lbl_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_TitleAdmin
            // 
            this.lbl_TitleAdmin.AutoSize = true;
            this.lbl_TitleAdmin.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_TitleAdmin.ForeColor = System.Drawing.Color.White;
            this.lbl_TitleAdmin.Location = new System.Drawing.Point(53, 196);
            this.lbl_TitleAdmin.Name = "lbl_TitleAdmin";
            this.lbl_TitleAdmin.Size = new System.Drawing.Size(131, 49);
            this.lbl_TitleAdmin.TabIndex = 1;
            this.lbl_TitleAdmin.Text = "Admin";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.uC_NhapHang1);
            this.panel2.Controls.Add(this.uC_Product1);
            this.panel2.Controls.Add(this.uC_Supplier1);
            this.panel2.Controls.Add(this.uC_User1);
            this.panel2.Controls.Add(this.uC_DashBoard1);
            this.panel2.Location = new System.Drawing.Point(259, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2223, 1598);
            this.panel2.TabIndex = 1;
            // 
            // uC_NhapHang1
            // 
            this.uC_NhapHang1.Location = new System.Drawing.Point(-3, -2);
            this.uC_NhapHang1.Name = "uC_NhapHang1";
            this.uC_NhapHang1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_NhapHang1.TabIndex = 4;
            // 
            // uC_Product1
            // 
            this.uC_Product1.Location = new System.Drawing.Point(-3, 0);
            this.uC_Product1.Name = "uC_Product1";
            this.uC_Product1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_Product1.TabIndex = 3;
            // 
            // uC_Supplier1
            // 
            this.uC_Supplier1.Location = new System.Drawing.Point(-3, -2);
            this.uC_Supplier1.Name = "uC_Supplier1";
            this.uC_Supplier1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_Supplier1.TabIndex = 2;
            // 
            // uC_User1
            // 
            this.uC_User1.Location = new System.Drawing.Point(3, 0);
            this.uC_User1.Name = "uC_User1";
            this.uC_User1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_User1.TabIndex = 1;
            // 
            // uC_DashBoard1
            // 
            this.uC_DashBoard1.Location = new System.Drawing.Point(0, 3);
            this.uC_DashBoard1.Name = "uC_DashBoard1";
            this.uC_DashBoard1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_DashBoard1.TabIndex = 0;
            // 
            // btn_NhapHang
            // 
            this.btn_NhapHang.BackColor = System.Drawing.Color.White;
            this.btn_NhapHang.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NhapHang.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.icons8_import_goods_30;
            this.btn_NhapHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_NhapHang.Location = new System.Drawing.Point(0, 572);
            this.btn_NhapHang.Name = "btn_NhapHang";
            this.btn_NhapHang.Size = new System.Drawing.Size(250, 42);
            this.btn_NhapHang.TabIndex = 11;
            this.btn_NhapHang.Text = "Nhập Hàng";
            this.btn_NhapHang.UseVisualStyleBackColor = false;
            this.btn_NhapHang.Click += new System.EventHandler(this.btn_NhapHang_Click);
            // 
            // btn_BanHang
            // 
            this.btn_BanHang.BackColor = System.Drawing.Color.White;
            this.btn_BanHang.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BanHang.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.icons8_import_goods_30__1_;
            this.btn_BanHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BanHang.Location = new System.Drawing.Point(0, 646);
            this.btn_BanHang.Name = "btn_BanHang";
            this.btn_BanHang.Size = new System.Drawing.Size(250, 42);
            this.btn_BanHang.TabIndex = 10;
            this.btn_BanHang.Text = "Bán Hàng";
            this.btn_BanHang.UseVisualStyleBackColor = false;
            // 
            // btn_Product
            // 
            this.btn_Product.BackColor = System.Drawing.Color.White;
            this.btn_Product.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Product.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.icons8_air_conditioner_30;
            this.btn_Product.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Product.Location = new System.Drawing.Point(3, 498);
            this.btn_Product.Name = "btn_Product";
            this.btn_Product.Size = new System.Drawing.Size(250, 42);
            this.btn_Product.TabIndex = 9;
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
            this.btn_Supplier.Location = new System.Drawing.Point(3, 424);
            this.btn_Supplier.Name = "btn_Supplier";
            this.btn_Supplier.Size = new System.Drawing.Size(250, 42);
            this.btn_Supplier.TabIndex = 8;
            this.btn_Supplier.Text = "Nhà Cung Cấp";
            this.btn_Supplier.UseVisualStyleBackColor = false;
            this.btn_Supplier.Click += new System.EventHandler(this.btn_Supplier_Click);
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.BackColor = System.Drawing.Color.White;
            this.btn_LogOut.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LogOut.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.log_out;
            this.btn_LogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LogOut.Location = new System.Drawing.Point(0, 720);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(250, 42);
            this.btn_LogOut.TabIndex = 6;
            this.btn_LogOut.Text = "Đăng Xuất";
            this.btn_LogOut.UseVisualStyleBackColor = false;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // btn_User
            // 
            this.btn_User.BackColor = System.Drawing.Color.White;
            this.btn_User.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_User.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.profile;
            this.btn_User.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_User.Location = new System.Drawing.Point(0, 350);
            this.btn_User.Name = "btn_User";
            this.btn_User.Size = new System.Drawing.Size(250, 42);
            this.btn_User.TabIndex = 5;
            this.btn_User.Text = "Người Dùng";
            this.btn_User.UseVisualStyleBackColor = false;
            this.btn_User.Click += new System.EventHandler(this.btn_User_Click);
            // 
            // btn_DashBoard
            // 
            this.btn_DashBoard.BackColor = System.Drawing.Color.White;
            this.btn_DashBoard.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DashBoard.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.dashboard1;
            this.btn_DashBoard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DashBoard.Location = new System.Drawing.Point(0, 276);
            this.btn_DashBoard.Name = "btn_DashBoard";
            this.btn_DashBoard.Size = new System.Drawing.Size(250, 42);
            this.btn_DashBoard.TabIndex = 2;
            this.btn_DashBoard.Text = "DashBoard";
            this.btn_DashBoard.UseVisualStyleBackColor = false;
            this.btn_DashBoard.Click += new System.EventHandler(this.btn_DashBoard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.admin3;
            this.pictureBox1.Location = new System.Drawing.Point(24, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frm_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Admin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.Button btn_User;
        private System.Windows.Forms.Button btn_DashBoard;
        private System.Windows.Forms.Label lbl_TitleAdmin;
        private System.Windows.Forms.Panel panel2;
        private Admin.UC_DashBoard uC_DashBoard1;
        private Admin.UC_User uC_User1;
        private System.Windows.Forms.Button btn_Product;
        private System.Windows.Forms.Button btn_Supplier;
        private Admin.UC_Supplier uC_Supplier1;
        private Admin.UC_Product uC_Product1;
        private System.Windows.Forms.Button btn_NhapHang;
        private System.Windows.Forms.Button btn_BanHang;
        private Admin.UC_NhapHang uC_NhapHang1;
    }
}