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
            this.uC_ViewUser1 = new QuanLyCuaHangMayLanh.Admin.UC_ViewUser();
            this.uC_AddUser1 = new QuanLyCuaHangMayLanh.Admin.UC_AddUser();
            this.uC_DashBoard1 = new QuanLyCuaHangMayLanh.Admin.UC_DashBoard();
            this.uC_Profile1 = new QuanLyCuaHangMayLanh.Admin.UC_Profile();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.btn_Profile = new System.Windows.Forms.Button();
            this.btn_ViewUser = new System.Windows.Forms.Button();
            this.btn_AddUser = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.lbl_UserName);
            this.panel1.Controls.Add(this.btn_LogOut);
            this.panel1.Controls.Add(this.btn_Profile);
            this.panel1.Controls.Add(this.btn_ViewUser);
            this.panel1.Controls.Add(this.btn_AddUser);
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
            this.lbl_UserName.Location = new System.Drawing.Point(0, 689);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(250, 59);
            this.lbl_UserName.TabIndex = 7;
            this.lbl_UserName.Text = "Admin";
            this.lbl_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_UserName.Click += new System.EventHandler(this.lbl_UserName_Click);
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
            this.panel2.Controls.Add(this.uC_ViewUser1);
            this.panel2.Controls.Add(this.uC_AddUser1);
            this.panel2.Controls.Add(this.uC_DashBoard1);
            this.panel2.Location = new System.Drawing.Point(259, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2223, 1598);
            this.panel2.TabIndex = 1;
            // 
            // uC_ViewUser1
            // 
            this.uC_ViewUser1.Location = new System.Drawing.Point(3, 3);
            this.uC_ViewUser1.Name = "uC_ViewUser1";
            this.uC_ViewUser1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_ViewUser1.TabIndex = 2;
            // 
            // uC_AddUser1
            // 
            this.uC_AddUser1.Location = new System.Drawing.Point(3, 3);
            this.uC_AddUser1.Name = "uC_AddUser1";
            this.uC_AddUser1.Size = new System.Drawing.Size(1806, 1152);
            this.uC_AddUser1.TabIndex = 1;
            // 
            // uC_DashBoard1
            // 
            this.uC_DashBoard1.Location = new System.Drawing.Point(0, 3);
            this.uC_DashBoard1.Name = "uC_DashBoard1";
            this.uC_DashBoard1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_DashBoard1.TabIndex = 0;
            // 
            // uC_Profile1
            // 
            this.uC_Profile1.Location = new System.Drawing.Point(259, 0);
            this.uC_Profile1.Name = "uC_Profile1";
            this.uC_Profile1.Size = new System.Drawing.Size(1667, 1102);
            this.uC_Profile1.TabIndex = 3;
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.BackColor = System.Drawing.Color.White;
            this.btn_LogOut.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LogOut.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.log_out;
            this.btn_LogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LogOut.Location = new System.Drawing.Point(0, 580);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(250, 42);
            this.btn_LogOut.TabIndex = 6;
            this.btn_LogOut.Text = "Log Out";
            this.btn_LogOut.UseVisualStyleBackColor = false;
            this.btn_LogOut.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // btn_Profile
            // 
            this.btn_Profile.BackColor = System.Drawing.Color.White;
            this.btn_Profile.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Profile.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.profile;
            this.btn_Profile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Profile.Location = new System.Drawing.Point(0, 504);
            this.btn_Profile.Name = "btn_Profile";
            this.btn_Profile.Size = new System.Drawing.Size(250, 42);
            this.btn_Profile.TabIndex = 5;
            this.btn_Profile.Text = "Profile";
            this.btn_Profile.UseVisualStyleBackColor = false;
            this.btn_Profile.Click += new System.EventHandler(this.btn_Profile_Click);
            // 
            // btn_ViewUser
            // 
            this.btn_ViewUser.BackColor = System.Drawing.Color.White;
            this.btn_ViewUser.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ViewUser.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.viewUser;
            this.btn_ViewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ViewUser.Location = new System.Drawing.Point(0, 428);
            this.btn_ViewUser.Name = "btn_ViewUser";
            this.btn_ViewUser.Size = new System.Drawing.Size(250, 42);
            this.btn_ViewUser.TabIndex = 4;
            this.btn_ViewUser.Text = "View User";
            this.btn_ViewUser.UseVisualStyleBackColor = false;
            this.btn_ViewUser.Click += new System.EventHandler(this.btn_ViewUser_Click);
            // 
            // btn_AddUser
            // 
            this.btn_AddUser.BackColor = System.Drawing.Color.White;
            this.btn_AddUser.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddUser.Image = global::QuanLyCuaHangMayLanh.Properties.Resources.add_user;
            this.btn_AddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddUser.Location = new System.Drawing.Point(0, 352);
            this.btn_AddUser.Name = "btn_AddUser";
            this.btn_AddUser.Size = new System.Drawing.Size(250, 42);
            this.btn_AddUser.TabIndex = 3;
            this.btn_AddUser.Text = "Add User";
            this.btn_AddUser.UseVisualStyleBackColor = false;
            this.btn_AddUser.Click += new System.EventHandler(this.btn_AddUser_Click);
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
            this.Controls.Add(this.uC_Profile1);
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
        private System.Windows.Forms.Button btn_Profile;
        private System.Windows.Forms.Button btn_ViewUser;
        private System.Windows.Forms.Button btn_AddUser;
        private System.Windows.Forms.Button btn_DashBoard;
        private System.Windows.Forms.Label lbl_TitleAdmin;
        private System.Windows.Forms.Panel panel2;
        private Admin.UC_DashBoard uC_DashBoard1;
        private Admin.UC_AddUser uC_AddUser1;
        private Admin.UC_ViewUser uC_ViewUser1;
        private Admin.UC_Profile uC_Profile1;
    }
}