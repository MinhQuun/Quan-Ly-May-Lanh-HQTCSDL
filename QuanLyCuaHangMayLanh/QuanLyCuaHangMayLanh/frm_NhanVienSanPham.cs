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
    public partial class frm_NhanVienSanPham : Form
    {
        private string currentUser;
        public frm_NhanVienSanPham()
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

            btn_AddSupplier.MouseEnter += button_MouseEnter;
            btn_AddSupplier.MouseLeave += button_MouseLeave;

            btn_AddProduct.MouseEnter += button_MouseEnter;
            btn_AddProduct.MouseLeave += button_MouseLeave;

            btn_ViewProduct.MouseEnter += button_MouseEnter;
            btn_ViewProduct.MouseLeave += button_MouseLeave;

            btn_LogOut.MouseEnter += button_MouseEnter;
            btn_LogOut.MouseLeave += button_MouseLeave;

            HideAllUserControls();

            btn_DashBoard.PerformClick();
        }
        private void HideAllUserControls()
        {
            uS_DashBoard1.Visible = false;
            uS_AddSupplier1.Visible = false;
            uS_ViewSupplier1.Visible = false;
            uS_AddProduct1.Visible = false;
            uS_ViewProduct1.Visible = false;
            uS_UpdateProduct1.Visible = false;
        }

        private void btn_DashBoard_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uS_DashBoard1.Visible = true;
            uS_DashBoard1.BringToFront();
        }

        private void btn_AddSupplier_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uS_AddSupplier1.Visible = true;
            uS_AddSupplier1.BringToFront();
            
        }

        private void btn_ViewSupplier_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uS_ViewSupplier1.Visible = true;
            uS_ViewSupplier1.BringToFront();
        }

        private void btn_UpdateSupplier_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uS_UpdateSupplier1.Visible = true;
            uS_UpdateSupplier1.BringToFront();
        }

        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uS_AddProduct1.Visible = true;
            uS_AddProduct1.BringToFront();
        }

        private void btn_ViewProduct_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uS_ViewProduct1.Visible = true;
            uS_ViewProduct1.BringToFront();
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            HideAllUserControls();
            uS_UpdateProduct1.Visible = true;
            uS_UpdateProduct1.BringToFront();
        }

       

    }
}
