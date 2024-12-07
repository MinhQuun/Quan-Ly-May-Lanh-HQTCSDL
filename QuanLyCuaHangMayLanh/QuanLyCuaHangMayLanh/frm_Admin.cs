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
            //uC_ViewUser1.ID = ID;
            //uC_Profile1.ID = ID;
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

            btn_User.MouseEnter += button_MouseEnter;
            btn_User.MouseLeave += button_MouseLeave;

            btn_Product.MouseEnter += button_MouseEnter;
            btn_Product.MouseLeave += button_MouseLeave;

            btn_Supplier.MouseEnter += button_MouseEnter;
            btn_Supplier.MouseLeave += button_MouseLeave;

            btn_LogOut.MouseEnter += button_MouseEnter;
            btn_LogOut.MouseLeave += button_MouseLeave;


            HideAllUserControls();

            btn_DashBoard.PerformClick(); //Hiển thị DashBoard khi đăng nhập

        }
        private void HideAllUserControls()
        {
            uC_DashBoard1.Visible = false;
            uC_User1.Visible = false;
            uC_Supplier1.Visible = false;
            uC_Product1.Visible = false;
            uC_NhapHang1.Visible = false;
        }

        private void btn_DashBoard_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_DashBoard1.Visible = true;
            uC_DashBoard1.BringToFront();
        }

        private void btn_User_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_User1.Visible = true;
            uC_User1.BringToFront();
        }

        private void btn_Supplier_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_Supplier1.Visible = true;
            uC_Supplier1.BringToFront();
        }

        private void btn_Product_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_Product1.Visible = true;
            uC_Product1.BringToFront();
        }

        private void btn_NhapHang_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_NhapHang1.Visible = true;
            uC_NhapHang1.BringToFront();
        }

        
    }
}
