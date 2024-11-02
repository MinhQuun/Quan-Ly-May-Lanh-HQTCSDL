namespace QuanLyCuaHangMayLanh.User
{
    partial class US_AddSupplier
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.txt_TenNCC = new System.Windows.Forms.TextBox();
            this.txt_MaNCC = new System.Windows.Forms.TextBox();
            this.lbl_DiaChi = new System.Windows.Forms.Label();
            this.lbl_TenNCC = new System.Windows.Forms.Label();
            this.lbl_MaNCC = new System.Windows.Forms.Label();
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_AddSupplier = new System.Windows.Forms.Button();
            this.pic_AddSupplier = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_AddSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Supplier";
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_DiaChi.ForeColor = System.Drawing.Color.Black;
            this.txt_DiaChi.Location = new System.Drawing.Point(178, 526);
            this.txt_DiaChi.Multiline = true;
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(369, 48);
            this.txt_DiaChi.TabIndex = 18;
            // 
            // txt_TenNCC
            // 
            this.txt_TenNCC.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_TenNCC.ForeColor = System.Drawing.Color.Black;
            this.txt_TenNCC.Location = new System.Drawing.Point(175, 372);
            this.txt_TenNCC.Multiline = true;
            this.txt_TenNCC.Name = "txt_TenNCC";
            this.txt_TenNCC.Size = new System.Drawing.Size(369, 48);
            this.txt_TenNCC.TabIndex = 17;
            // 
            // txt_MaNCC
            // 
            this.txt_MaNCC.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_MaNCC.ForeColor = System.Drawing.Color.Black;
            this.txt_MaNCC.Location = new System.Drawing.Point(178, 218);
            this.txt_MaNCC.Multiline = true;
            this.txt_MaNCC.Name = "txt_MaNCC";
            this.txt_MaNCC.Size = new System.Drawing.Size(369, 48);
            this.txt_MaNCC.TabIndex = 16;
            this.txt_MaNCC.TextChanged += new System.EventHandler(this.txt_MaNCC_TextChanged);
            // 
            // lbl_DiaChi
            // 
            this.lbl_DiaChi.AutoSize = true;
            this.lbl_DiaChi.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DiaChi.Location = new System.Drawing.Point(174, 453);
            this.lbl_DiaChi.Name = "lbl_DiaChi";
            this.lbl_DiaChi.Size = new System.Drawing.Size(135, 39);
            this.lbl_DiaChi.TabIndex = 15;
            this.lbl_DiaChi.Text = "Địa Chỉ";
            // 
            // lbl_TenNCC
            // 
            this.lbl_TenNCC.AutoSize = true;
            this.lbl_TenNCC.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenNCC.Location = new System.Drawing.Point(171, 299);
            this.lbl_TenNCC.Name = "lbl_TenNCC";
            this.lbl_TenNCC.Size = new System.Drawing.Size(320, 39);
            this.lbl_TenNCC.TabIndex = 14;
            this.lbl_TenNCC.Text = "Tên Nhà Cung Cấp";
            // 
            // lbl_MaNCC
            // 
            this.lbl_MaNCC.AutoSize = true;
            this.lbl_MaNCC.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaNCC.Location = new System.Drawing.Point(174, 145);
            this.lbl_MaNCC.Name = "lbl_MaNCC";
            this.lbl_MaNCC.Size = new System.Drawing.Size(317, 39);
            this.lbl_MaNCC.TabIndex = 13;
            this.lbl_MaNCC.Text = "Mã Nhà Cung Cấp";
            // 
            // btn_Reload
            // 
            this.btn_Reload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_Reload.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reload.ForeColor = System.Drawing.Color.White;
            this.btn_Reload.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.reset;
            this.btn_Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reload.Location = new System.Drawing.Point(379, 624);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(171, 49);
            this.btn_Reload.TabIndex = 20;
            this.btn_Reload.Text = "Tải lại";
            this.btn_Reload.UseVisualStyleBackColor = false;
            this.btn_Reload.Click += new System.EventHandler(this.btn_Reload_Click);
            // 
            // btn_AddSupplier
            // 
            this.btn_AddSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_AddSupplier.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddSupplier.ForeColor = System.Drawing.Color.White;
            this.btn_AddSupplier.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.add;
            this.btn_AddSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddSupplier.Location = new System.Drawing.Point(181, 624);
            this.btn_AddSupplier.Name = "btn_AddSupplier";
            this.btn_AddSupplier.Size = new System.Drawing.Size(171, 49);
            this.btn_AddSupplier.TabIndex = 19;
            this.btn_AddSupplier.Text = "Thêm";
            this.btn_AddSupplier.UseVisualStyleBackColor = false;
            this.btn_AddSupplier.Click += new System.EventHandler(this.btn_AddSupplier_Click);
            // 
            // pic_AddSupplier
            // 
            this.pic_AddSupplier.Location = new System.Drawing.Point(581, 218);
            this.pic_AddSupplier.Name = "pic_AddSupplier";
            this.pic_AddSupplier.Size = new System.Drawing.Size(74, 48);
            this.pic_AddSupplier.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_AddSupplier.TabIndex = 21;
            this.pic_AddSupplier.TabStop = false;
            // 
            // US_AddSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pic_AddSupplier);
            this.Controls.Add(this.btn_Reload);
            this.Controls.Add(this.btn_AddSupplier);
            this.Controls.Add(this.txt_DiaChi);
            this.Controls.Add(this.txt_TenNCC);
            this.Controls.Add(this.txt_MaNCC);
            this.Controls.Add(this.lbl_DiaChi);
            this.Controls.Add(this.lbl_TenNCC);
            this.Controls.Add(this.lbl_MaNCC);
            this.Controls.Add(this.label1);
            this.Name = "US_AddSupplier";
            this.Size = new System.Drawing.Size(1667, 1102);
            this.Load += new System.EventHandler(this.US_AddSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_AddSupplier)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.TextBox txt_TenNCC;
        private System.Windows.Forms.TextBox txt_MaNCC;
        private System.Windows.Forms.Label lbl_DiaChi;
        private System.Windows.Forms.Label lbl_TenNCC;
        private System.Windows.Forms.Label lbl_MaNCC;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.Button btn_AddSupplier;
        private System.Windows.Forms.PictureBox pic_AddSupplier;
    }
}
