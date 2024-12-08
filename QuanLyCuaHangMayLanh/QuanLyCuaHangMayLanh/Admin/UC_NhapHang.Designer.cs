namespace QuanLyCuaHangMayLanh.Admin
{
    partial class UC_NhapHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbo_SP = new System.Windows.Forms.ComboBox();
            this.cbo_NV = new System.Windows.Forms.ComboBox();
            this.txt_TongTien = new System.Windows.Forms.TextBox();
            this.lbl_TongTien = new System.Windows.Forms.Label();
            this.lbl_SP = new System.Windows.Forms.Label();
            this.dt_NgayNhap = new System.Windows.Forms.DateTimePicker();
            this.txt_DonGiaNhap = new System.Windows.Forms.TextBox();
            this.cbo_MaNCC = new System.Windows.Forms.ComboBox();
            this.lbl_MaNCC = new System.Windows.Forms.Label();
            this.lbl_DonGiaBan = new System.Windows.Forms.Label();
            this.lbl_NgayNhap = new System.Windows.Forms.Label();
            this.txt_SL = new System.Windows.Forms.TextBox();
            this.txt_MaHDN = new System.Windows.Forms.TextBox();
            this.lbl_SoLuong = new System.Windows.Forms.Label();
            this.lbl_NV = new System.Windows.Forms.Label();
            this.lbl_MaHDN = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_HoaDonNhap = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_AddHDN = new System.Windows.Forms.PictureBox();
            this.btn_InHoaDon = new System.Windows.Forms.Button();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_AddHDN = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDonNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_AddHDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbo_SP
            // 
            this.cbo_SP.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbo_SP.ForeColor = System.Drawing.Color.Black;
            this.cbo_SP.FormattingEnabled = true;
            this.cbo_SP.Location = new System.Drawing.Point(865, 165);
            this.cbo_SP.Name = "cbo_SP";
            this.cbo_SP.Size = new System.Drawing.Size(541, 39);
            this.cbo_SP.TabIndex = 107;
            this.cbo_SP.SelectedIndexChanged += new System.EventHandler(this.cbo_SP_SelectedIndexChanged);
            // 
            // cbo_NV
            // 
            this.cbo_NV.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbo_NV.ForeColor = System.Drawing.Color.Black;
            this.cbo_NV.FormattingEnabled = true;
            this.cbo_NV.Location = new System.Drawing.Point(104, 165);
            this.cbo_NV.Name = "cbo_NV";
            this.cbo_NV.Size = new System.Drawing.Size(369, 39);
            this.cbo_NV.TabIndex = 106;
            // 
            // txt_TongTien
            // 
            this.txt_TongTien.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_TongTien.ForeColor = System.Drawing.Color.Black;
            this.txt_TongTien.Location = new System.Drawing.Point(862, 578);
            this.txt_TongTien.Multiline = true;
            this.txt_TongTien.Name = "txt_TongTien";
            this.txt_TongTien.ReadOnly = true;
            this.txt_TongTien.Size = new System.Drawing.Size(369, 48);
            this.txt_TongTien.TabIndex = 105;
            // 
            // lbl_TongTien
            // 
            this.lbl_TongTien.AutoSize = true;
            this.lbl_TongTien.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TongTien.Location = new System.Drawing.Point(858, 508);
            this.lbl_TongTien.Name = "lbl_TongTien";
            this.lbl_TongTien.Size = new System.Drawing.Size(162, 39);
            this.lbl_TongTien.TabIndex = 104;
            this.lbl_TongTien.Text = "Tổng Tiền";
            // 
            // lbl_SP
            // 
            this.lbl_SP.AutoSize = true;
            this.lbl_SP.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SP.Location = new System.Drawing.Point(855, 100);
            this.lbl_SP.Name = "lbl_SP";
            this.lbl_SP.Size = new System.Drawing.Size(170, 39);
            this.lbl_SP.TabIndex = 103;
            this.lbl_SP.Text = "Sản Phẩm";
            // 
            // dt_NgayNhap
            // 
            this.dt_NgayNhap.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.dt_NgayNhap.Location = new System.Drawing.Point(104, 466);
            this.dt_NgayNhap.Name = "dt_NgayNhap";
            this.dt_NgayNhap.Size = new System.Drawing.Size(400, 39);
            this.dt_NgayNhap.TabIndex = 102;
            // 
            // txt_DonGiaNhap
            // 
            this.txt_DonGiaNhap.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_DonGiaNhap.ForeColor = System.Drawing.Color.Black;
            this.txt_DonGiaNhap.Location = new System.Drawing.Point(862, 444);
            this.txt_DonGiaNhap.Multiline = true;
            this.txt_DonGiaNhap.Name = "txt_DonGiaNhap";
            this.txt_DonGiaNhap.Size = new System.Drawing.Size(369, 48);
            this.txt_DonGiaNhap.TabIndex = 101;
            // 
            // cbo_MaNCC
            // 
            this.cbo_MaNCC.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbo_MaNCC.ForeColor = System.Drawing.Color.Black;
            this.cbo_MaNCC.FormattingEnabled = true;
            this.cbo_MaNCC.Location = new System.Drawing.Point(107, 309);
            this.cbo_MaNCC.Name = "cbo_MaNCC";
            this.cbo_MaNCC.Size = new System.Drawing.Size(369, 39);
            this.cbo_MaNCC.TabIndex = 100;
            this.cbo_MaNCC.SelectedIndexChanged += new System.EventHandler(this.cbo_MaNCC_SelectedIndexChanged);
            // 
            // lbl_MaNCC
            // 
            this.lbl_MaNCC.AutoSize = true;
            this.lbl_MaNCC.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaNCC.Location = new System.Drawing.Point(100, 262);
            this.lbl_MaNCC.Name = "lbl_MaNCC";
            this.lbl_MaNCC.Size = new System.Drawing.Size(317, 39);
            this.lbl_MaNCC.TabIndex = 99;
            this.lbl_MaNCC.Text = "Mã Nhà Cung Cấp";
            // 
            // lbl_DonGiaBan
            // 
            this.lbl_DonGiaBan.AutoSize = true;
            this.lbl_DonGiaBan.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DonGiaBan.Location = new System.Drawing.Point(858, 378);
            this.lbl_DonGiaBan.Name = "lbl_DonGiaBan";
            this.lbl_DonGiaBan.Size = new System.Drawing.Size(242, 39);
            this.lbl_DonGiaBan.TabIndex = 98;
            this.lbl_DonGiaBan.Text = "Đơn Giá Nhập";
            // 
            // lbl_NgayNhap
            // 
            this.lbl_NgayNhap.AutoSize = true;
            this.lbl_NgayNhap.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgayNhap.Location = new System.Drawing.Point(100, 405);
            this.lbl_NgayNhap.Name = "lbl_NgayNhap";
            this.lbl_NgayNhap.Size = new System.Drawing.Size(198, 39);
            this.lbl_NgayNhap.TabIndex = 97;
            this.lbl_NgayNhap.Text = "Ngày Nhập";
            // 
            // txt_SL
            // 
            this.txt_SL.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_SL.ForeColor = System.Drawing.Color.Black;
            this.txt_SL.Location = new System.Drawing.Point(862, 309);
            this.txt_SL.Multiline = true;
            this.txt_SL.Name = "txt_SL";
            this.txt_SL.Size = new System.Drawing.Size(369, 48);
            this.txt_SL.TabIndex = 96;
            // 
            // txt_MaHDN
            // 
            this.txt_MaHDN.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_MaHDN.ForeColor = System.Drawing.Color.Black;
            this.txt_MaHDN.Location = new System.Drawing.Point(550, 156);
            this.txt_MaHDN.Multiline = true;
            this.txt_MaHDN.Name = "txt_MaHDN";
            this.txt_MaHDN.Size = new System.Drawing.Size(110, 48);
            this.txt_MaHDN.TabIndex = 94;
            this.txt_MaHDN.TextChanged += new System.EventHandler(this.txt_MaHDN_TextChanged);
            // 
            // lbl_SoLuong
            // 
            this.lbl_SoLuong.AutoSize = true;
            this.lbl_SoLuong.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SoLuong.Location = new System.Drawing.Point(858, 239);
            this.lbl_SoLuong.Name = "lbl_SoLuong";
            this.lbl_SoLuong.Size = new System.Drawing.Size(157, 39);
            this.lbl_SoLuong.TabIndex = 93;
            this.lbl_SoLuong.Text = "Số Lượng";
            // 
            // lbl_NV
            // 
            this.lbl_NV.AutoSize = true;
            this.lbl_NV.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NV.Location = new System.Drawing.Point(100, 100);
            this.lbl_NV.Name = "lbl_NV";
            this.lbl_NV.Size = new System.Drawing.Size(184, 39);
            this.lbl_NV.TabIndex = 92;
            this.lbl_NV.Text = "Nhân Viên";
            // 
            // lbl_MaHDN
            // 
            this.lbl_MaHDN.AutoSize = true;
            this.lbl_MaHDN.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaHDN.Location = new System.Drawing.Point(441, 100);
            this.lbl_MaHDN.Name = "lbl_MaHDN";
            this.lbl_MaHDN.Size = new System.Drawing.Size(310, 39);
            this.lbl_MaHDN.TabIndex = 91;
            this.lbl_MaHDN.Text = "Mã Hóa Đơn Nhập";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.panel1.Location = new System.Drawing.Point(757, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 440);
            this.panel1.TabIndex = 90;
            // 
            // txt_Search
            // 
            this.txt_Search.ForeColor = System.Drawing.Color.White;
            this.txt_Search.Location = new System.Drawing.Point(1377, 67);
            this.txt_Search.Multiline = true;
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(268, 44);
            this.txt_Search.TabIndex = 89;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1371, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 33);
            this.label2.TabIndex = 88;
            this.label2.Text = "Mã hóa đơn";
            // 
            // dgv_HoaDonNhap
            // 
            this.dgv_HoaDonNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgv_HoaDonNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HoaDonNhap.GridColor = System.Drawing.Color.White;
            this.dgv_HoaDonNhap.Location = new System.Drawing.Point(3, 638);
            this.dgv_HoaDonNhap.Name = "dgv_HoaDonNhap";
            this.dgv_HoaDonNhap.RowHeadersWidth = 51;
            this.dgv_HoaDonNhap.RowTemplate.Height = 24;
            this.dgv_HoaDonNhap.Size = new System.Drawing.Size(1654, 370);
            this.dgv_HoaDonNhap.TabIndex = 87;
            this.dgv_HoaDonNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_HoaDonNhap_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 44);
            this.label1.TabIndex = 80;
            this.label1.Text = "Nhập Hàng";
            // 
            // pic_AddHDN
            // 
            this.pic_AddHDN.Location = new System.Drawing.Point(677, 156);
            this.pic_AddHDN.Name = "pic_AddHDN";
            this.pic_AddHDN.Size = new System.Drawing.Size(74, 48);
            this.pic_AddHDN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_AddHDN.TabIndex = 95;
            this.pic_AddHDN.TabStop = false;
            // 
            // btn_InHoaDon
            // 
            this.btn_InHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_InHoaDon.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InHoaDon.ForeColor = System.Drawing.Color.White;
            this.btn_InHoaDon.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.icons8_print_30;
            this.btn_InHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_InHoaDon.Location = new System.Drawing.Point(1262, 1025);
            this.btn_InHoaDon.Name = "btn_InHoaDon";
            this.btn_InHoaDon.Size = new System.Drawing.Size(171, 49);
            this.btn_InHoaDon.TabIndex = 86;
            this.btn_InHoaDon.Text = "In hóa đơn";
            this.btn_InHoaDon.UseVisualStyleBackColor = false;
            this.btn_InHoaDon.Click += new System.EventHandler(this.btn_InHoaDon_Click);
            // 
            // btn_Reload
            // 
            this.btn_Reload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_Reload.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reload.ForeColor = System.Drawing.Color.White;
            this.btn_Reload.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.reset;
            this.btn_Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reload.Location = new System.Drawing.Point(1484, 1025);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(171, 49);
            this.btn_Reload.TabIndex = 85;
            this.btn_Reload.Text = "Tải lại";
            this.btn_Reload.UseVisualStyleBackColor = false;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_AddHDN
            // 
            this.btn_AddHDN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_AddHDN.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddHDN.ForeColor = System.Drawing.Color.White;
            this.btn_AddHDN.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.add;
            this.btn_AddHDN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddHDN.Location = new System.Drawing.Point(1040, 1025);
            this.btn_AddHDN.Name = "btn_AddHDN";
            this.btn_AddHDN.Size = new System.Drawing.Size(171, 49);
            this.btn_AddHDN.TabIndex = 84;
            this.btn_AddHDN.Text = "Nhập hàng";
            this.btn_AddHDN.UseVisualStyleBackColor = false;
            this.btn_AddHDN.Click += new System.EventHandler(this.btn_AddHDN_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.White;
            this.btn_Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.sync__1_1;
            this.btn_Update.Location = new System.Drawing.Point(320, 11);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(55, 51);
            this.btn_Update.TabIndex = 81;
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.sync;
            this.pictureBox1.Location = new System.Drawing.Point(297, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 82;
            this.pictureBox1.TabStop = false;
            // 
            // UC_NhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbo_SP);
            this.Controls.Add(this.cbo_NV);
            this.Controls.Add(this.txt_TongTien);
            this.Controls.Add(this.lbl_TongTien);
            this.Controls.Add(this.lbl_SP);
            this.Controls.Add(this.dt_NgayNhap);
            this.Controls.Add(this.txt_DonGiaNhap);
            this.Controls.Add(this.cbo_MaNCC);
            this.Controls.Add(this.lbl_MaNCC);
            this.Controls.Add(this.lbl_DonGiaBan);
            this.Controls.Add(this.lbl_NgayNhap);
            this.Controls.Add(this.txt_SL);
            this.Controls.Add(this.pic_AddHDN);
            this.Controls.Add(this.txt_MaHDN);
            this.Controls.Add(this.lbl_SoLuong);
            this.Controls.Add(this.lbl_NV);
            this.Controls.Add(this.lbl_MaHDN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_HoaDonNhap);
            this.Controls.Add(this.btn_InHoaDon);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.btn_AddHDN);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "UC_NhapHang";
            this.Size = new System.Drawing.Size(1667, 1102);
            this.Load += new System.EventHandler(this.UC_NhapHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDonNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_AddHDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_SP;
        private System.Windows.Forms.ComboBox cbo_NV;
        private System.Windows.Forms.TextBox txt_TongTien;
        private System.Windows.Forms.Label lbl_TongTien;
        private System.Windows.Forms.Label lbl_SP;
        private System.Windows.Forms.DateTimePicker dt_NgayNhap;
        private System.Windows.Forms.TextBox txt_DonGiaNhap;
        private System.Windows.Forms.ComboBox cbo_MaNCC;
        private System.Windows.Forms.Label lbl_MaNCC;
        private System.Windows.Forms.Label lbl_DonGiaBan;
        private System.Windows.Forms.Label lbl_NgayNhap;
        private System.Windows.Forms.TextBox txt_SL;
        private System.Windows.Forms.PictureBox pic_AddHDN;
        private System.Windows.Forms.TextBox txt_MaHDN;
        private System.Windows.Forms.Label lbl_SoLuong;
        private System.Windows.Forms.Label lbl_NV;
        private System.Windows.Forms.Label lbl_MaHDN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_HoaDonNhap;
        private System.Windows.Forms.Button btn_InHoaDon;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.Button btn_AddHDN;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
