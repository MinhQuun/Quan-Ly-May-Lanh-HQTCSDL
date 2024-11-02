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
    public partial class frm_NhanVienKhoHang : Form
    {
        private string currentUser;
        public frm_NhanVienKhoHang()
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

            btn_HoaDonNhap.MouseEnter += button_MouseEnter;
            btn_HoaDonNhap.MouseLeave += button_MouseLeave;

            btn_HoaDonXuat.MouseEnter += button_MouseEnter;
            btn_HoaDonXuat.MouseLeave += button_MouseLeave;

            btn_DashBoard.PerformClick();
        }

        private void HideAllUserControls()
        {
            nvkH_DashBoard1.Visible = false;
            nvkH_HoaDonNhap1.Visible = false;
            nvkH_HoaDonXuat1.Visible = false;
        }

        private void btn_DashBoard_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            nvkH_DashBoard1.Visible = true;
            nvkH_DashBoard1.BringToFront();
        }

        private void btn_HoaDonNhap_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            nvkH_HoaDonNhap1.Visible = true;
            nvkH_HoaDonNhap1.BringToFront();
        }

        private void btn_HoaDonXuat_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            nvkH_HoaDonXuat1.Visible = true;
            nvkH_HoaDonXuat1.BringToFront();
        }

    }
}
