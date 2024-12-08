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
    public partial class frm_NhanVienNhapHang : Form
    {
        private string currentUser;
        public frm_NhanVienNhapHang()
        {
            InitializeComponent();
        }
        public string UserName
        {
            set { currentUser = value; }
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

        private void frm_NhanVien_Load(object sender, EventArgs e)
        {
            lbl_UserName.Text = currentUser;

            btn_DashBoard.MouseEnter += button_MouseEnter;
            btn_DashBoard.MouseLeave += button_MouseLeave;

            btn_Supplier.MouseEnter += button_MouseEnter;
            btn_Supplier.MouseLeave += button_MouseLeave;

            btn_Product.MouseEnter += button_MouseEnter;
            btn_Product.MouseLeave += button_MouseLeave;

            btn_NhapHang.MouseEnter += button_MouseEnter;
            btn_NhapHang.MouseLeave += button_MouseLeave;

            btn_LogOut.MouseEnter += button_MouseEnter;
            btn_LogOut.MouseLeave += button_MouseLeave;

            HideAllUserControls();

            btn_DashBoard.PerformClick();
        }
        private void HideAllUserControls()
        {
            nvnH_DashBoard1.Visible = false;
            uC_Supplier1.Visible = false;
            uC_Product1.Visible = false;
            uC_NhapHang1.Visible = false;
        }

        private void btn_DashBoard_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            nvnH_DashBoard1.Visible = true;
            nvnH_DashBoard1.BringToFront();
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
