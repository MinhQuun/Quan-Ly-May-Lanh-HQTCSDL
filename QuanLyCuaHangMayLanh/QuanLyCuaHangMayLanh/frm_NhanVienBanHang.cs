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
    public partial class frm_NhanVienBanHang : Form
    {
        private string currentUser;
        public frm_NhanVienBanHang()
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

        private void frm_NhanVienKhoHang_Load(object sender, EventArgs e)
        {
            lbl_UserName.Text = currentUser;

            btn_DashBoard.MouseEnter += button_MouseEnter;
            btn_DashBoard.MouseLeave += button_MouseLeave;

            btn_Product.MouseEnter += button_MouseEnter;
            btn_Product.MouseLeave += button_MouseLeave;

            btn_BanHang.MouseEnter += button_MouseEnter;
            btn_BanHang.MouseLeave += button_MouseLeave;

            btn_DashBoard.PerformClick();
        }

        private void HideAllUserControls()
        {
            nvkH_DashBoard1.Visible = false;
            nvbH_XemKhoSanPham1.Visible = false;
            uC_BanHang1.Visible = false;
        }

        private void btn_DashBoard_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            nvkH_DashBoard1.Visible = true;
            nvkH_DashBoard1.BringToFront();
        }

        private void btn_Product_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            nvbH_XemKhoSanPham1.Visible = true;
            nvbH_XemKhoSanPham1.BringToFront();
        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uC_BanHang1.Visible = true;
            uC_BanHang1.BringToFront();
        }

    }
}
