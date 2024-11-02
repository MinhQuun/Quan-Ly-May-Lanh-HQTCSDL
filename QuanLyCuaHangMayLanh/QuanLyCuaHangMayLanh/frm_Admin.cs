using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMayLanh
{
    public partial class frm_Admin : Form
    {
        string user = "";
        public frm_Admin()
        {
            InitializeComponent();
        }
        public string ID
        {
            get { return user.ToString(); }
        }
        public frm_Admin(string userName)
        {
            InitializeComponent();
            lbl_UserName.Text = userName;
            user = userName; ////
            uC_ViewUser1.ID = ID;
            uC_Profile1.ID = ID;
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            frm_Login login = new frm_Login();
            login.Show();
            this.Hide();
        }
        private Color originalColor;

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Lưu lại màu nền ban đầu để khôi phục khi rời chuột
                originalColor = button.BackColor;
                // Đổi màu nền của nút thành màu trắng khi di chuột vào
                button.BackColor = Color.White;
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                // Khôi phục màu nền ban đầu khi chuột rời khỏi
                button.BackColor = originalColor;
            }
        }

        private void frm_Admin_Load(object sender, EventArgs e)
        {
            btn_DashBoard.MouseEnter += button_MouseEnter;
            btn_DashBoard.MouseLeave += button_MouseLeave;

            btn_AddUser.MouseEnter += button_MouseEnter;
            btn_AddUser.MouseLeave += button_MouseLeave;

            btn_ViewUser.MouseEnter += button_MouseEnter;
            btn_ViewUser.MouseLeave += button_MouseLeave;

            btn_Profile.MouseEnter += button_MouseEnter;
            btn_Profile.MouseLeave += button_MouseLeave;

            btn_LogOut.MouseEnter += button_MouseEnter;
            btn_LogOut.MouseLeave += button_MouseLeave;


            HideAllUserControls();

            btn_DashBoard.PerformClick(); //Hiển thị DashBoard khi đăng nhập

        }
        private void HideAllUserControls()
        {
            uC_DashBoard1.Visible = false;
            uC_AddUser1.Visible = false;
            uC_ViewUser1.Visible = false;
            uC_Profile1.Visible = false;
        }

        private void btn_DashBoard_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_DashBoard1.Visible = true;
            uC_DashBoard1.BringToFront();
        }

        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_AddUser1.Visible = true;
            uC_AddUser1.BringToFront();
        }

        private void lbl_UserName_Click(object sender, EventArgs e)
        {

        }

        private void btn_ViewUser_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_ViewUser1.Visible = true;
            uC_ViewUser1.BringToFront();
        }

        private void btn_Profile_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_Profile1.Visible = true;
            uC_Profile1.BringToFront();
        }
        
        

        
    }
}
