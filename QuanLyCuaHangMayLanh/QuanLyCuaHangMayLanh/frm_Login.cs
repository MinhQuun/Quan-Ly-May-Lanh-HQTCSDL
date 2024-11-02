using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using May_Lanh_Library;
using System.Data.SqlClient;

namespace QuanLyCuaHangMayLanh
{
    public partial class frm_Login : Form
    {
        DBConnect db = new DBConnect();
        //DataSet ds;
        public frm_Login()
        {
            InitializeComponent();
            SetPlaceholder(txt_UserName, "UserName");
            SetPlaceholder(txt_Password, "Password");
        }
        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            // Đặt văn bản mặc định (placeholder) và màu chữ ban đầu
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            // Đặt kích thước và loại phông chữ
            textBox.Font = new Font("Arial", 14, FontStyle.Italic); // Phông chữ Arial, cỡ chữ 14, kiểu chữ nghiêng cho placeholder

            // Căn chỉnh văn bản ở giữa theo chiều ngang
            textBox.TextAlign = HorizontalAlignment.Center;

            // Sử dụng multiline để căn chỉnh dọc (tùy chọn nếu cần thiết)
            textBox.Multiline = true;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black; // Màu chữ bình thường
                    textBox.Font = new Font("Arial", 14, FontStyle.Regular); // Phông chữ Arial, cỡ chữ 14, kiểu chữ thường
                    textBox.TextAlign = HorizontalAlignment.Left;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray; // Màu chữ nhạt để người dùng biết đây là placeholder
                    textBox.Font = new Font("Arial", 14, FontStyle.Italic); // Phông chữ Arial, cỡ chữ 14, kiểu chữ nghiêng cho placeholder
                }
            };
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btn_SignIn_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Kiểm tra nếu không có tài khoản nào trong bảng NGUOIDUNG
                int count = db.getCount("Login_CountUser");

                // Nếu không có tài khoản nào, cho phép đăng nhập với thông tin mặc định
                if (count == 0)
                {
                    if (txt_UserName.Text == "root" && txt_Password.Text == "root")
                    {
                        frm_Admin admin = new frm_Admin();
                        admin.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }

                // Bước 2: Sử dụng Stored Procedure để kiểm tra thông tin đăng nhập
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", txt_UserName.Text),
                    new SqlParameter("@password", txt_Password.Text)
                };

                DataTable dt = db.getDataTable("Login_GetUserRole", "NGUOIDUNG", parameters);

                // Bước 3: Kiểm tra kết quả truy vấn và xử lý vai trò
                if (dt.Rows.Count > 0)
                {
                    string role = dt.Rows[0]["MAQUYEN"].ToString();

                    if (role == "Q1") // Vai trò Admin
                    {
                        frm_Admin admin = new frm_Admin(txt_UserName.Text);
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "Q2") // Vai trò Nhân Viên Sản Phẩm
                    {
                        frm_NhanVienSanPham nv = new frm_NhanVienSanPham();
                        nv.UserName = txt_UserName.Text;
                        nv.Show();
                        this.Hide();
                    }
                    else if (role == "Q3") // Vai trò Nhân Viên Kho Hàng
                    {
                        frm_NhanVienKhoHang nvkh = new frm_NhanVienKhoHang();
                        nvkh.UserName = txt_UserName.Text;
                        nvkh.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Role not recognized.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username or password", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
