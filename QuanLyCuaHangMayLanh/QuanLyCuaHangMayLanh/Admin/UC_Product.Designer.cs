namespace QuanLyCuaHangMayLanh.Admin
{
    partial class UC_Product
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
            this.dgv_ViewProduct = new System.Windows.Forms.DataGridView();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.txt_SL = new System.Windows.Forms.TextBox();
            this.txt_TenSP = new System.Windows.Forms.TextBox();
            this.pic_AddProduct = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_DonGiaBan = new System.Windows.Forms.TextBox();
            this.txt_DonGiaNhap = new System.Windows.Forms.TextBox();
            this.txt_MaSP = new System.Windows.Forms.TextBox();
            this.cbo_MaNCC = new System.Windows.Forms.ComboBox();
            this.lbl_MaNCC = new System.Windows.Forms.Label();
            this.lbl_DonGiaBan = new System.Windows.Forms.Label();
            this.lbl_DonGiaNhap = new System.Windows.Forms.Label();
            this.lbl_SoLuong = new System.Windows.Forms.Label();
            this.lbl_TenSP = new System.Windows.Forms.Label();
            this.lbl_MaSP = new System.Windows.Forms.Label();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_AddProduct = new System.Windows.Forms.Button();
            this.btn_UpdateProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_AddProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_ViewProduct
            // 
            this.dgv_ViewProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ViewProduct.GridColor = System.Drawing.Color.White;
            this.dgv_ViewProduct.Location = new System.Drawing.Point(0, 521);
            this.dgv_ViewProduct.Name = "dgv_ViewProduct";
            this.dgv_ViewProduct.RowHeadersWidth = 51;
            this.dgv_ViewProduct.RowTemplate.Height = 24;
            this.dgv_ViewProduct.Size = new System.Drawing.Size(1654, 486);
            this.dgv_ViewProduct.TabIndex = 21;
            this.dgv_ViewProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ViewProduct_CellClick);
            this.dgv_ViewProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ViewProduct_CellContentClick);
            // 
            // txt_Search
            // 
            this.txt_Search.ForeColor = System.Drawing.Color.White;
            this.txt_Search.Location = new System.Drawing.Point(1206, 68);
            this.txt_Search.Multiline = true;
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(268, 44);
            this.txt_Search.TabIndex = 20;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1200, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 33);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tên sản phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 39);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sản Phẩm";
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.White;
            this.btn_Update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.sync__1_1;
            this.btn_Update.Location = new System.Drawing.Point(274, 12);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(55, 51);
            this.btn_Update.TabIndex = 17;
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.sync;
            this.pictureBox1.Location = new System.Drawing.Point(251, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 79);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Red;
            this.btn_Delete.Font = new System.Drawing.Font("Century", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.delete;
            this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.Location = new System.Drawing.Point(990, 1013);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(162, 54);
            this.btn_Delete.TabIndex = 22;
            this.btn_Delete.Text = "Xóa";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // txt_SL
            // 
            this.txt_SL.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_SL.ForeColor = System.Drawing.Color.Black;
            this.txt_SL.Location = new System.Drawing.Point(89, 311);
            this.txt_SL.Multiline = true;
            this.txt_SL.Name = "txt_SL";
            this.txt_SL.Size = new System.Drawing.Size(369, 48);
            this.txt_SL.TabIndex = 49;
            // 
            // txt_TenSP
            // 
            this.txt_TenSP.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_TenSP.ForeColor = System.Drawing.Color.Black;
            this.txt_TenSP.Location = new System.Drawing.Point(89, 171);
            this.txt_TenSP.Multiline = true;
            this.txt_TenSP.Name = "txt_TenSP";
            this.txt_TenSP.Size = new System.Drawing.Size(369, 48);
            this.txt_TenSP.TabIndex = 48;
            // 
            // pic_AddProduct
            // 
            this.pic_AddProduct.Location = new System.Drawing.Point(520, 170);
            this.pic_AddProduct.Name = "pic_AddProduct";
            this.pic_AddProduct.Size = new System.Drawing.Size(74, 48);
            this.pic_AddProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_AddProduct.TabIndex = 47;
            this.pic_AddProduct.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.panel1.Location = new System.Drawing.Point(600, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 400);
            this.panel1.TabIndex = 46;
            // 
            // txt_DonGiaBan
            // 
            this.txt_DonGiaBan.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_DonGiaBan.ForeColor = System.Drawing.Color.Black;
            this.txt_DonGiaBan.Location = new System.Drawing.Point(713, 311);
            this.txt_DonGiaBan.Multiline = true;
            this.txt_DonGiaBan.Name = "txt_DonGiaBan";
            this.txt_DonGiaBan.Size = new System.Drawing.Size(369, 48);
            this.txt_DonGiaBan.TabIndex = 45;
            // 
            // txt_DonGiaNhap
            // 
            this.txt_DonGiaNhap.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_DonGiaNhap.ForeColor = System.Drawing.Color.Black;
            this.txt_DonGiaNhap.Location = new System.Drawing.Point(713, 171);
            this.txt_DonGiaNhap.Multiline = true;
            this.txt_DonGiaNhap.Name = "txt_DonGiaNhap";
            this.txt_DonGiaNhap.Size = new System.Drawing.Size(369, 48);
            this.txt_DonGiaNhap.TabIndex = 44;
            // 
            // txt_MaSP
            // 
            this.txt_MaSP.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_MaSP.ForeColor = System.Drawing.Color.Black;
            this.txt_MaSP.Location = new System.Drawing.Point(475, 170);
            this.txt_MaSP.Multiline = true;
            this.txt_MaSP.Name = "txt_MaSP";
            this.txt_MaSP.Size = new System.Drawing.Size(39, 48);
            this.txt_MaSP.TabIndex = 43;
            this.txt_MaSP.TextChanged += new System.EventHandler(this.txt_MaSP_TextChanged);
            // 
            // cbo_MaNCC
            // 
            this.cbo_MaNCC.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbo_MaNCC.ForeColor = System.Drawing.Color.Black;
            this.cbo_MaNCC.FormattingEnabled = true;
            this.cbo_MaNCC.Location = new System.Drawing.Point(716, 451);
            this.cbo_MaNCC.Name = "cbo_MaNCC";
            this.cbo_MaNCC.Size = new System.Drawing.Size(369, 39);
            this.cbo_MaNCC.TabIndex = 42;
            // 
            // lbl_MaNCC
            // 
            this.lbl_MaNCC.AutoSize = true;
            this.lbl_MaNCC.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaNCC.Location = new System.Drawing.Point(709, 385);
            this.lbl_MaNCC.Name = "lbl_MaNCC";
            this.lbl_MaNCC.Size = new System.Drawing.Size(317, 39);
            this.lbl_MaNCC.TabIndex = 41;
            this.lbl_MaNCC.Text = "Mã Nhà Cung Cấp";
            // 
            // lbl_DonGiaBan
            // 
            this.lbl_DonGiaBan.AutoSize = true;
            this.lbl_DonGiaBan.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DonGiaBan.Location = new System.Drawing.Point(709, 245);
            this.lbl_DonGiaBan.Name = "lbl_DonGiaBan";
            this.lbl_DonGiaBan.Size = new System.Drawing.Size(218, 39);
            this.lbl_DonGiaBan.TabIndex = 40;
            this.lbl_DonGiaBan.Text = "Đơn Giá Bán";
            // 
            // lbl_DonGiaNhap
            // 
            this.lbl_DonGiaNhap.AutoSize = true;
            this.lbl_DonGiaNhap.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DonGiaNhap.Location = new System.Drawing.Point(706, 105);
            this.lbl_DonGiaNhap.Name = "lbl_DonGiaNhap";
            this.lbl_DonGiaNhap.Size = new System.Drawing.Size(242, 39);
            this.lbl_DonGiaNhap.TabIndex = 39;
            this.lbl_DonGiaNhap.Text = "Đơn Giá Nhập";
            // 
            // lbl_SoLuong
            // 
            this.lbl_SoLuong.AutoSize = true;
            this.lbl_SoLuong.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SoLuong.Location = new System.Drawing.Point(91, 245);
            this.lbl_SoLuong.Name = "lbl_SoLuong";
            this.lbl_SoLuong.Size = new System.Drawing.Size(157, 39);
            this.lbl_SoLuong.TabIndex = 38;
            this.lbl_SoLuong.Text = "Số Lượng";
            // 
            // lbl_TenSP
            // 
            this.lbl_TenSP.AutoSize = true;
            this.lbl_TenSP.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenSP.Location = new System.Drawing.Point(82, 105);
            this.lbl_TenSP.Name = "lbl_TenSP";
            this.lbl_TenSP.Size = new System.Drawing.Size(234, 39);
            this.lbl_TenSP.TabIndex = 37;
            this.lbl_TenSP.Text = "Tên Sản Phẩm";
            // 
            // lbl_MaSP
            // 
            this.lbl_MaSP.AutoSize = true;
            this.lbl_MaSP.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaSP.Location = new System.Drawing.Point(363, 105);
            this.lbl_MaSP.Name = "lbl_MaSP";
            this.lbl_MaSP.Size = new System.Drawing.Size(231, 39);
            this.lbl_MaSP.TabIndex = 36;
            this.lbl_MaSP.Text = "Mã Sản Phẩm";
            // 
            // btn_Reload
            // 
            this.btn_Reload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_Reload.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reload.ForeColor = System.Drawing.Color.White;
            this.btn_Reload.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.reset;
            this.btn_Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reload.Location = new System.Drawing.Point(1411, 1013);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(171, 49);
            this.btn_Reload.TabIndex = 51;
            this.btn_Reload.Text = "Tải lại";
            this.btn_Reload.UseVisualStyleBackColor = false;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_AddProduct
            // 
            this.btn_AddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_AddProduct.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddProduct.ForeColor = System.Drawing.Color.White;
            this.btn_AddProduct.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.add;
            this.btn_AddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddProduct.Location = new System.Drawing.Point(775, 1018);
            this.btn_AddProduct.Name = "btn_AddProduct";
            this.btn_AddProduct.Size = new System.Drawing.Size(171, 49);
            this.btn_AddProduct.TabIndex = 50;
            this.btn_AddProduct.Text = "Thêm";
            this.btn_AddProduct.UseVisualStyleBackColor = false;
            this.btn_AddProduct.Click += new System.EventHandler(this.btn_AddProduct_Click);
            // 
            // btn_UpdateProduct
            // 
            this.btn_UpdateProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_UpdateProduct.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UpdateProduct.ForeColor = System.Drawing.Color.White;
            this.btn_UpdateProduct.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.updated;
            this.btn_UpdateProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_UpdateProduct.Location = new System.Drawing.Point(1196, 1013);
            this.btn_UpdateProduct.Name = "btn_UpdateProduct";
            this.btn_UpdateProduct.Size = new System.Drawing.Size(171, 49);
            this.btn_UpdateProduct.TabIndex = 54;
            this.btn_UpdateProduct.Text = "Cập nhật";
            this.btn_UpdateProduct.UseVisualStyleBackColor = false;
            this.btn_UpdateProduct.Click += new System.EventHandler(this.btn_UpdateProduct_Click);
            // 
            // UC_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_UpdateProduct);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.btn_AddProduct);
            this.Controls.Add(this.txt_SL);
            this.Controls.Add(this.txt_TenSP);
            this.Controls.Add(this.pic_AddProduct);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_DonGiaBan);
            this.Controls.Add(this.txt_DonGiaNhap);
            this.Controls.Add(this.txt_MaSP);
            this.Controls.Add(this.cbo_MaNCC);
            this.Controls.Add(this.lbl_MaNCC);
            this.Controls.Add(this.lbl_DonGiaBan);
            this.Controls.Add(this.lbl_DonGiaNhap);
            this.Controls.Add(this.lbl_SoLuong);
            this.Controls.Add(this.lbl_TenSP);
            this.Controls.Add(this.lbl_MaSP);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.dgv_ViewProduct);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "UC_Product";
            this.Size = new System.Drawing.Size(1667, 1102);
            this.Load += new System.EventHandler(this.UC_Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_AddProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_ViewProduct;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.TextBox txt_SL;
        private System.Windows.Forms.TextBox txt_TenSP;
        private System.Windows.Forms.PictureBox pic_AddProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_DonGiaBan;
        private System.Windows.Forms.TextBox txt_DonGiaNhap;
        private System.Windows.Forms.TextBox txt_MaSP;
        private System.Windows.Forms.ComboBox cbo_MaNCC;
        private System.Windows.Forms.Label lbl_MaNCC;
        private System.Windows.Forms.Label lbl_DonGiaBan;
        private System.Windows.Forms.Label lbl_DonGiaNhap;
        private System.Windows.Forms.Label lbl_SoLuong;
        private System.Windows.Forms.Label lbl_TenSP;
        private System.Windows.Forms.Label lbl_MaSP;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.Button btn_AddProduct;
        private System.Windows.Forms.Button btn_UpdateProduct;
    }
}
