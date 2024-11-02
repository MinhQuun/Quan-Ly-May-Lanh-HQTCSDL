using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using May_Lanh_Library;

namespace QuanLyCuaHangMayLanh.Admin
{
    public partial class UC_AddUser : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public UC_AddUser()
        {
            cn = db.conn;
            InitializeComponent();
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

        private void UC_AddUser_Load(object sender, EventArgs e)
        {
            btn_SignUp.MouseEnter += button_MouseEnter;
            btn_SignUp.MouseLeave += button_MouseLeave;

            btn_Reload.MouseEnter += button_MouseEnter;
            btn_Reload.MouseLeave += button_MouseLeave;

            Load_Combobox_VaiTroNguoiDung();
            
        }
        public void Load_Combobox_VaiTroNguoiDung()
        {
            try
            {
                DataTable dtQuyen = db.getDataTable("Admin_GetAllRoles", "QUYEN");

                // Gán dữ liệu cho ComboBox
                cbo_VaiTroNguoiDung.DataSource = dtQuyen;
                cbo_VaiTroNguoiDung.DisplayMember = "TENQUYEN";   // Hiển thị tên 
                cbo_VaiTroNguoiDung.ValueMember = "MAQUYEN";      // Giá trị là mã 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_SignUp_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu Vai Trò Người Dùng chưa được chọn
            if (cbo_VaiTroNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò người dùng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string role = cbo_VaiTroNguoiDung.SelectedValue.ToString();
            string name = txt_Ten.Text;
            DateTime dob = dt_NS.Value;
            string sdt = txt_SDT.Text;
            string user_name = txt_UserName.Text.Trim();
            string pass = txt_MK.Text;

            // Kiểm tra độ dài số điện thoại
            if (sdt.Length > 10)
            {
                MessageBox.Show("Số điện thoại không được vượt quá 10 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Kiểm tra nếu tên đăng nhập đã tồn tại
                SqlParameter[] checkParameters = { new SqlParameter("@username", user_name) };
                int count = db.getCount("Admin_CheckUsernameExists", checkParameters);

                if (count > 0)
                {
                    MessageBox.Show("UserName đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm người dùng mới bằng Stored Procedure `sp_AddUser`
                SqlParameter[] insertParameters = {
                    new SqlParameter("@TEN", name),
                    new SqlParameter("@NGAYSINH", dob),
                    new SqlParameter("@SODIENTHOAI", sdt),
                    new SqlParameter("@USERNAME", user_name),
                    new SqlParameter("@MATKHAU", pass),
                    new SqlParameter("@MAQUYEN", role)
                };

                db.openConnect();
                SqlCommand cmd = new SqlCommand("Admin_InsertNguoiDung", db.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(insertParameters);
                cmd.ExecuteNonQuery();
                db.closeConnect();

                MessageBox.Show("Đăng ký người dùng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thêm được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        public void ClearAll()
        {
            txt_Ten.Clear();
            dt_NS.ResetText();
            txt_SDT.Clear();
            txt_UserName.Clear();
            txt_MK.Clear();
            cbo_VaiTroNguoiDung.SelectedIndex = -1;
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
            SqlParameter[] parameters = { new SqlParameter("@username", txt_UserName.Text.Trim()) };

            try
            {
                int count = db.getCount("Admin_CheckUsernameExists", parameters);
                if (count == 0)
                {
                    pic_AddUser.ImageLocation = @"E:\MinhQuun\HUIT - 2022\Nam 3\HK5\He Quan Tri Co So Du Lieu\Project\Icon\yes.png";
                }
                else
                {
                    pic_AddUser.ImageLocation = @"E:\MinhQuun\HUIT - 2022\Nam 3\HK5\He Quan Tri Co So Du Lieu\Project\Icon\no.png";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra tên người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
