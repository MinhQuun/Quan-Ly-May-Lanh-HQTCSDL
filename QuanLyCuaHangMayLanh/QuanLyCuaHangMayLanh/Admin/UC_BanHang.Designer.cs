namespace QuanLyCuaHangMayLanh.Admin
{
    partial class UC_BanHang
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
            this.txt_DonGiaBan = new System.Windows.Forms.TextBox();
            this.cbo_KH = new System.Windows.Forms.ComboBox();
            this.lbl_KH = new System.Windows.Forms.Label();
            this.lbl_DonGiaBan = new System.Windows.Forms.Label();
            this.txt_SL = new System.Windows.Forms.TextBox();
            this.lbl_SoLuong = new System.Windows.Forms.Label();
            this.lbl_NV = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_HoaDonXuat = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_BanHang = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_InHoaDon = new System.Windows.Forms.Button();
            this.dt_NgayXuat = new System.Windows.Forms.DateTimePicker();
            this.lbl_Ngãyuat = new System.Windows.Forms.Label();
            this.lbl_MaHDX = new System.Windows.Forms.Label();
            this.pic_AddHDX = new System.Windows.Forms.PictureBox();
            this.txt_MaHDX = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDonXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_AddHDX)).BeginInit();
            this.SuspendLayout();
            // 
            // cbo_SP
            // 
            this.cbo_SP.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbo_SP.ForeColor = System.Drawing.Color.Black;
            this.cbo_SP.FormattingEnabled = true;
            this.cbo_SP.Location = new System.Drawing.Point(852, 195);
            this.cbo_SP.Name = "cbo_SP";
            this.cbo_SP.Size = new System.Drawing.Size(541, 39);
            this.cbo_SP.TabIndex = 135;
            this.cbo_SP.SelectedIndexChanged += new System.EventHandler(this.cbo_SP_SelectedIndexChanged);
            // 
            // cbo_NV
            // 
            this.cbo_NV.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbo_NV.ForeColor = System.Drawing.Color.Black;
            this.cbo_NV.FormattingEnabled = true;
            this.cbo_NV.Location = new System.Drawing.Point(106, 195);
            this.cbo_NV.Name = "cbo_NV";
            this.cbo_NV.Size = new System.Drawing.Size(369, 39);
            this.cbo_NV.TabIndex = 134;
            // 
            // txt_TongTien
            // 
            this.txt_TongTien.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_TongTien.ForeColor = System.Drawing.Color.Black;
            this.txt_TongTien.Location = new System.Drawing.Point(849, 608);
            this.txt_TongTien.Multiline = true;
            this.txt_TongTien.Name = "txt_TongTien";
            this.txt_TongTien.ReadOnly = true;
            this.txt_TongTien.Size = new System.Drawing.Size(369, 48);
            this.txt_TongTien.TabIndex = 133;
            // 
            // lbl_TongTien
            // 
            this.lbl_TongTien.AutoSize = true;
            this.lbl_TongTien.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TongTien.Location = new System.Drawing.Point(845, 538);
            this.lbl_TongTien.Name = "lbl_TongTien";
            this.lbl_TongTien.Size = new System.Drawing.Size(162, 39);
            this.lbl_TongTien.TabIndex = 132;
            this.lbl_TongTien.Text = "Tổng Tiền";
            // 
            // lbl_SP
            // 
            this.lbl_SP.AutoSize = true;
            this.lbl_SP.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SP.Location = new System.Drawing.Point(842, 130);
            this.lbl_SP.Name = "lbl_SP";
            this.lbl_SP.Size = new System.Drawing.Size(170, 39);
            this.lbl_SP.TabIndex = 131;
            this.lbl_SP.Text = "Sản Phẩm";
            // 
            // txt_DonGiaBan
            // 
            this.txt_DonGiaBan.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_DonGiaBan.ForeColor = System.Drawing.Color.Black;
            this.txt_DonGiaBan.Location = new System.Drawing.Point(849, 474);
            this.txt_DonGiaBan.Multiline = true;
            this.txt_DonGiaBan.Name = "txt_DonGiaBan";
            this.txt_DonGiaBan.Size = new System.Drawing.Size(369, 48);
            this.txt_DonGiaBan.TabIndex = 129;
            // 
            // cbo_KH
            // 
            this.cbo_KH.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbo_KH.ForeColor = System.Drawing.Color.Black;
            this.cbo_KH.FormattingEnabled = true;
            this.cbo_KH.Location = new System.Drawing.Point(106, 339);
            this.cbo_KH.Name = "cbo_KH";
            this.cbo_KH.Size = new System.Drawing.Size(369, 39);
            this.cbo_KH.TabIndex = 128;
            // 
            // lbl_KH
            // 
            this.lbl_KH.AutoSize = true;
            this.lbl_KH.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_KH.Location = new System.Drawing.Point(99, 288);
            this.lbl_KH.Name = "lbl_KH";
            this.lbl_KH.Size = new System.Drawing.Size(215, 39);
            this.lbl_KH.TabIndex = 127;
            this.lbl_KH.Text = "Khách Hàng";
            // 
            // lbl_DonGiaBan
            // 
            this.lbl_DonGiaBan.AutoSize = true;
            this.lbl_DonGiaBan.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DonGiaBan.Location = new System.Drawing.Point(845, 408);
            this.lbl_DonGiaBan.Name = "lbl_DonGiaBan";
            this.lbl_DonGiaBan.Size = new System.Drawing.Size(218, 39);
            this.lbl_DonGiaBan.TabIndex = 126;
            this.lbl_DonGiaBan.Text = "Đơn Giá Bán";
            // 
            // txt_SL
            // 
            this.txt_SL.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_SL.ForeColor = System.Drawing.Color.Black;
            this.txt_SL.Location = new System.Drawing.Point(849, 339);
            this.txt_SL.Multiline = true;
            this.txt_SL.Name = "txt_SL";
            this.txt_SL.Size = new System.Drawing.Size(369, 48);
            this.txt_SL.TabIndex = 124;
            // 
            // lbl_SoLuong
            // 
            this.lbl_SoLuong.AutoSize = true;
            this.lbl_SoLuong.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SoLuong.Location = new System.Drawing.Point(845, 269);
            this.lbl_SoLuong.Name = "lbl_SoLuong";
            this.lbl_SoLuong.Size = new System.Drawing.Size(157, 39);
            this.lbl_SoLuong.TabIndex = 121;
            this.lbl_SoLuong.Text = "Số Lượng";
            // 
            // lbl_NV
            // 
            this.lbl_NV.AutoSize = true;
            this.lbl_NV.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NV.Location = new System.Drawing.Point(99, 142);
            this.lbl_NV.Name = "lbl_NV";
            this.lbl_NV.Size = new System.Drawing.Size(184, 39);
            this.lbl_NV.TabIndex = 120;
            this.lbl_NV.Text = "Nhân Viên";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.panel1.Location = new System.Drawing.Point(744, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 440);
            this.panel1.TabIndex = 118;
            // 
            // txt_Search
            // 
            this.txt_Search.ForeColor = System.Drawing.Color.White;
            this.txt_Search.Location = new System.Drawing.Point(1371, 69);
            this.txt_Search.Multiline = true;
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(268, 44);
            this.txt_Search.TabIndex = 117;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1365, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 33);
            this.label2.TabIndex = 116;
            this.label2.Text = "Mã hóa đơn";
            // 
            // dgv_HoaDonXuat
            // 
            this.dgv_HoaDonXuat.BackgroundColor = System.Drawing.Color.White;
            this.dgv_HoaDonXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HoaDonXuat.GridColor = System.Drawing.Color.White;
            this.dgv_HoaDonXuat.Location = new System.Drawing.Point(6, 682);
            this.dgv_HoaDonXuat.Name = "dgv_HoaDonXuat";
            this.dgv_HoaDonXuat.RowHeadersWidth = 51;
            this.dgv_HoaDonXuat.RowTemplate.Height = 24;
            this.dgv_HoaDonXuat.Size = new System.Drawing.Size(1654, 298);
            this.dgv_HoaDonXuat.TabIndex = 115;
            this.dgv_HoaDonXuat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_HoaDonXuat_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 44);
            this.label1.TabIndex = 108;
            this.label1.Text = "Bán Hàng";
            // 
            // btn_Reload
            // 
            this.btn_Reload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_Reload.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reload.ForeColor = System.Drawing.Color.White;
            this.btn_Reload.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.reset;
            this.btn_Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reload.Location = new System.Drawing.Point(1477, 1017);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(171, 49);
            this.btn_Reload.TabIndex = 113;
            this.btn_Reload.Text = "Tải lại";
            this.btn_Reload.UseVisualStyleBackColor = false;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_BanHang
            // 
            this.btn_BanHang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_BanHang.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BanHang.ForeColor = System.Drawing.Color.White;
            this.btn_BanHang.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.add;
            this.btn_BanHang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BanHang.Location = new System.Drawing.Point(1033, 1017);
            this.btn_BanHang.Name = "btn_BanHang";
            this.btn_BanHang.Size = new System.Drawing.Size(171, 49);
            this.btn_BanHang.TabIndex = 112;
            this.btn_BanHang.Text = "Bán Hàng";
            this.btn_BanHang.UseVisualStyleBackColor = false;
            this.btn_BanHang.Click += new System.EventHandler(this.btn_BanHang_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.White;
            this.btn_Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.sync__1_1;
            this.btn_Update.Location = new System.Drawing.Point(320, 16);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(55, 51);
            this.btn_Update.TabIndex = 109;
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.sync;
            this.pictureBox1.Location = new System.Drawing.Point(297, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 110;
            this.pictureBox1.TabStop = false;
            // 
            // btn_InHoaDon
            // 
            this.btn_InHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_InHoaDon.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InHoaDon.ForeColor = System.Drawing.Color.White;
            this.btn_InHoaDon.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.icons8_print_30;
            this.btn_InHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_InHoaDon.Location = new System.Drawing.Point(1248, 1017);
            this.btn_InHoaDon.Name = "btn_InHoaDon";
            this.btn_InHoaDon.Size = new System.Drawing.Size(171, 49);
            this.btn_InHoaDon.TabIndex = 136;
            this.btn_InHoaDon.Text = "In hóa đơn";
            this.btn_InHoaDon.UseVisualStyleBackColor = false;
            // 
            // dt_NgayXuat
            // 
            this.dt_NgayXuat.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.dt_NgayXuat.Location = new System.Drawing.Point(106, 483);
            this.dt_NgayXuat.Name = "dt_NgayXuat";
            this.dt_NgayXuat.Size = new System.Drawing.Size(400, 39);
            this.dt_NgayXuat.TabIndex = 130;
            // 
            // lbl_Ngãyuat
            // 
            this.lbl_Ngãyuat.AutoSize = true;
            this.lbl_Ngãyuat.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ngãyuat.Location = new System.Drawing.Point(99, 427);
            this.lbl_Ngãyuat.Name = "lbl_Ngãyuat";
            this.lbl_Ngãyuat.Size = new System.Drawing.Size(184, 39);
            this.lbl_Ngãyuat.TabIndex = 125;
            this.lbl_Ngãyuat.Text = "Ngày Xuất";
            // 
            // lbl_MaHDX
            // 
            this.lbl_MaHDX.AutoSize = true;
            this.lbl_MaHDX.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaHDX.Location = new System.Drawing.Point(442, 130);
            this.lbl_MaHDX.Name = "lbl_MaHDX";
            this.lbl_MaHDX.Size = new System.Drawing.Size(296, 39);
            this.lbl_MaHDX.TabIndex = 119;
            this.lbl_MaHDX.Text = "Mã Hóa Đơn Xuất";
            // 
            // pic_AddHDX
            // 
            this.pic_AddHDX.Location = new System.Drawing.Point(664, 186);
            this.pic_AddHDX.Name = "pic_AddHDX";
            this.pic_AddHDX.Size = new System.Drawing.Size(74, 48);
            this.pic_AddHDX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_AddHDX.TabIndex = 123;
            this.pic_AddHDX.TabStop = false;
            // 
            // txt_MaHDX
            // 
            this.txt_MaHDX.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_MaHDX.ForeColor = System.Drawing.Color.Black;
            this.txt_MaHDX.Location = new System.Drawing.Point(506, 186);
            this.txt_MaHDX.Multiline = true;
            this.txt_MaHDX.Name = "txt_MaHDX";
            this.txt_MaHDX.Size = new System.Drawing.Size(140, 48);
            this.txt_MaHDX.TabIndex = 122;
            this.txt_MaHDX.TextChanged += new System.EventHandler(this.txt_MaHDX_TextChanged);
            // 
            // UC_BanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_InHoaDon);
            this.Controls.Add(this.cbo_SP);
            this.Controls.Add(this.cbo_NV);
            this.Controls.Add(this.txt_TongTien);
            this.Controls.Add(this.lbl_TongTien);
            this.Controls.Add(this.lbl_SP);
            this.Controls.Add(this.dt_NgayXuat);
            this.Controls.Add(this.txt_DonGiaBan);
            this.Controls.Add(this.cbo_KH);
            this.Controls.Add(this.lbl_KH);
            this.Controls.Add(this.lbl_DonGiaBan);
            this.Controls.Add(this.lbl_Ngãyuat);
            this.Controls.Add(this.txt_SL);
            this.Controls.Add(this.pic_AddHDX);
            this.Controls.Add(this.txt_MaHDX);
            this.Controls.Add(this.lbl_SoLuong);
            this.Controls.Add(this.lbl_NV);
            this.Controls.Add(this.lbl_MaHDX);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_HoaDonXuat);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.btn_BanHang);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "UC_BanHang";
            this.Size = new System.Drawing.Size(1667, 1102);
            this.Load += new System.EventHandler(this.UC_BanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoaDonXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_AddHDX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_SP;
        private System.Windows.Forms.ComboBox cbo_NV;
        private System.Windows.Forms.TextBox txt_TongTien;
        private System.Windows.Forms.Label lbl_TongTien;
        private System.Windows.Forms.Label lbl_SP;
        private System.Windows.Forms.TextBox txt_DonGiaBan;
        private System.Windows.Forms.ComboBox cbo_KH;
        private System.Windows.Forms.Label lbl_KH;
        private System.Windows.Forms.Label lbl_DonGiaBan;
        private System.Windows.Forms.TextBox txt_SL;
        private System.Windows.Forms.Label lbl_SoLuong;
        private System.Windows.Forms.Label lbl_NV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_HoaDonXuat;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.Button btn_BanHang;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_InHoaDon;
        private System.Windows.Forms.DateTimePicker dt_NgayXuat;
        private System.Windows.Forms.Label lbl_Ngãyuat;
        private System.Windows.Forms.Label lbl_MaHDX;
        private System.Windows.Forms.PictureBox pic_AddHDX;
        private System.Windows.Forms.TextBox txt_MaHDX;
    }
}
