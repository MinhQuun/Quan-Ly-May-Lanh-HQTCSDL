namespace QuanLyCuaHangMayLanh
{
    partial class frm_Login
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
            this.btn_Reload = new System.Windows.Forms.Button();
            this.btn_SignIn = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.lbl_Login = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbl_Error);
            this.panel1.Controls.Add(this.btn_Reload);
            this.panel1.Controls.Add(this.btn_SignIn);
            this.panel1.Controls.Add(this.txt_Password);
            this.panel1.Controls.Add(this.txt_UserName);
            this.panel1.Controls.Add(this.lbl_Login);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Location = new System.Drawing.Point(406, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 550);
            this.panel1.TabIndex = 0;
            // 
            // btn_Reload
            // 
            this.btn_Reload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_Reload.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reload.ForeColor = System.Drawing.Color.White;
            this.btn_Reload.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.reset;
            this.btn_Reload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reload.Location = new System.Drawing.Point(872, 344);
            this.btn_Reload.Name = "btn_Reload";
            this.btn_Reload.Size = new System.Drawing.Size(171, 49);
            this.btn_Reload.TabIndex = 17;
            this.btn_Reload.Text = "Tải lại";
            this.btn_Reload.UseVisualStyleBackColor = false;
            // 
            // btn_SignIn
            // 
            this.btn_SignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(225)))));
            this.btn_SignIn.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SignIn.ForeColor = System.Drawing.Color.White;
            this.btn_SignIn.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.add_friend;
            this.btn_SignIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SignIn.Location = new System.Drawing.Point(628, 344);
            this.btn_SignIn.Name = "btn_SignIn";
            this.btn_SignIn.Size = new System.Drawing.Size(171, 49);
            this.btn_SignIn.TabIndex = 16;
            this.btn_SignIn.Text = "Đăng nhập";
            this.btn_SignIn.UseVisualStyleBackColor = false;
            this.btn_SignIn.Click += new System.EventHandler(this.btn_SignIn_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.ForeColor = System.Drawing.Color.Black;
            this.txt_Password.Location = new System.Drawing.Point(628, 248);
            this.txt_Password.Multiline = true;
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.Size = new System.Drawing.Size(415, 67);
            this.txt_Password.TabIndex = 4;
            // 
            // txt_UserName
            // 
            this.txt_UserName.ForeColor = System.Drawing.Color.Black;
            this.txt_UserName.Location = new System.Drawing.Point(628, 135);
            this.txt_UserName.Multiline = true;
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(415, 67);
            this.txt_UserName.TabIndex = 3;
            this.txt_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Login
            // 
            this.lbl_Login.AutoSize = true;
            this.lbl_Login.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Login.Location = new System.Drawing.Point(770, 48);
            this.lbl_Login.Name = "lbl_Login";
            this.lbl_Login.Size = new System.Drawing.Size(91, 41);
            this.lbl_Login.TabIndex = 2;
            this.lbl_Login.Text = "Login";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.air_conditioner;
            this.pictureBox1.Location = new System.Drawing.Point(20, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(482, 442);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.cancel_50px;
            this.btn_Close.Location = new System.Drawing.Point(3, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 60);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // lbl_Error
            // 
            this.lbl_Error.AutoSize = true;
            this.lbl_Error.Location = new System.Drawing.Point(665, 459);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(0, 17);
            this.lbl_Error.TabIndex = 18;
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1848, 761);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label lbl_Login;
        private System.Windows.Forms.Button btn_Reload;
        private System.Windows.Forms.Button btn_SignIn;
        private System.Windows.Forms.Label lbl_Error;
    }
}

