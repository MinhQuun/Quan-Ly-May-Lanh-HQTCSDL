using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using May_Lanh_Library;
using System.Data.SqlClient;


namespace QuanLyCuaHangMayLanh.Admin
{
    public partial class UC_Profile : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public UC_Profile()
        {
            cn = db.conn;
            InitializeComponent();
        }
        public string ID
        {
            set { lbl_UserName.Text = value; }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            string ten = txt_Ten.Text;
            DateTime dob = dt_NS.Value;
            string sdt = txt_SDT.Text;
            string mk = txt_MK.Text;
            string username = lbl_UserName.Text; // Lấy username của người dùng hiện tại

            try
            {
                string query = "Admin_UpdateUser";

                SqlCommand cmdUpdate = new SqlCommand(query, db.conn);
                cmdUpdate.CommandType = CommandType.StoredProcedure; // Đặt kiểu là StoredProcedure
                cmdUpdate.Parameters.AddWithValue("@TEN", ten);
                cmdUpdate.Parameters.AddWithValue("@NGAYSINH", dob.ToString("yyyy-MM-dd"));
                cmdUpdate.Parameters.AddWithValue("@SODIENTHOAI", sdt);
                cmdUpdate.Parameters.AddWithValue("@MATKHAU", mk);
                cmdUpdate.Parameters.AddWithValue("@USERNAME", username);

                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect(); // Mở kết nối nếu chưa mở
                }
                cmdUpdate.ExecuteNonQuery(); // Thực thi lệnh thêm
                db.closeConnect(); // Đóng kết nối

                MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_Profile_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbl_UserName.Text))
            {
                MessageBox.Show("Không thể tải thông tin người dùng vì chưa có thông tin đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                // Tạo câu truy vấn để lấy thông tin người dùng
                string query = "Admin_GetUserByUsername";

                // Tạo parameter với giá trị tìm kiếm từ `currentUser` hoặc `txt_UserName` (đây là giá trị tài khoản hiện tại đang đăng nhập)
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", lbl_UserName.Text)
                };

                // Sử dụng `getDataTable` để lấy dữ liệu từ database
                DataTable dt = db.getDataTable(query, "NGUOIDUNG", parameters);

                // Kiểm tra nếu có dữ liệu và gán giá trị lên các TextBox
                if (dt != null && dt.Rows.Count > 0)
                {
                    txt_Ten.Text = dt.Rows[0]["TEN"].ToString();
                    DateTime ngaySinh;
                    if (DateTime.TryParse(dt.Rows[0]["NGAYSINH"].ToString(), out ngaySinh))
                    {
                        dt_NS.Value = ngaySinh; // Sử dụng DateTimePicker để hiển thị ngày sinh
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu ngày sinh không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    txt_SDT.Text = dt.Rows[0]["SODIENTHOAI"].ToString();
                    txt_MK.Text = dt.Rows[0]["MATKHAU"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            txt_Ten.Clear();
            dt_NS.Value = DateTime.Today;
            txt_SDT.Clear();
            txt_MK.Clear();
        }
        
    }
}
