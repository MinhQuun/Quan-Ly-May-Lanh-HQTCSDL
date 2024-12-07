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
    public partial class UC_User : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        string currentUser = "";
        public UC_User()
        {
            cn = db.conn;
            InitializeComponent();
        }
        public string ID
        {
            set { currentUser = value; }
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
        private void txt_Search_Enter(object sender, EventArgs e)
        {
            if (txt_Search.Text == "Search.......")
            {
                txt_Search.Text = ""; // Xóa chữ "Search" khi người dùng bấm vào
                txt_Search.ForeColor = Color.Black; // Đổi màu chữ sang màu bình thường
                txt_Search.Font = new Font(txt_Search.Font.FontFamily, 14, FontStyle.Regular);
            }
        }

        private void txt_Search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Search.Text))
            {
                txt_Search.Text = "Search......."; // Đặt lại chữ "Search" khi không có nội dung
                txt_Search.ForeColor = Color.Gray; // Đổi màu chữ sang màu nhạt
                txt_Search.Font = new Font(txt_Search.Font.FontFamily, 14, FontStyle.Italic);
            }
        }
        private void UC_User_Load(object sender, EventArgs e)
        {
            btn_SignUp.MouseEnter += button_MouseEnter;
            btn_SignUp.MouseLeave += button_MouseLeave;

            btn_Delete.MouseEnter += button_MouseEnter;
            btn_Delete.MouseLeave += button_MouseLeave;

            btn_Update.MouseEnter += button_MouseEnter;
            btn_Update.MouseLeave += button_MouseLeave;

            btn_Reload.MouseEnter += button_MouseEnter;
            btn_Reload.MouseLeave += button_MouseLeave;

            // Thiết lập placeholder mặc định cho TextBox
            txt_Search.Text = "Search.......";
            txt_Search.ForeColor = Color.Gray;
            txt_Search.Font = new Font(txt_Search.Font.FontFamily, 14, FontStyle.Italic);

            // Gắn sự kiện Enter và Leave cho TextBox
            txt_Search.Enter += txt_Search_Enter;
            txt_Search.Leave += txt_Search_Leave;

            Load_DataGridView();

            if (dgv_ViewUser.Columns.Count > 0)
            {
                dgv_ViewUser.Columns["MAND"].HeaderText = "Mã Người Dùng";
                dgv_ViewUser.Columns["TEN"].HeaderText = "Tên";
                dgv_ViewUser.Columns["NGAYSINH"].HeaderText = "Ngày Sinh";
                dgv_ViewUser.Columns["SODIENTHOAI"].HeaderText = "Số Điện Thoại";
                dgv_ViewUser.Columns["USERNAME"].HeaderText = "UserName";
                dgv_ViewUser.Columns["MATKHAU"].HeaderText = "Mật Khẩu";
                dgv_ViewUser.Columns["MAQUYEN"].HeaderText = "Mã Quyền";

                // Đặt chế độ tự điều chỉnh và chiều rộng tối thiểu cho cột "Mã Nhà Cung Cấp"
                //dgv_ViewSupplier.Columns["MANCC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgv_ViewSupplier.Columns["MANCC"].MinimumWidth = 120; // Đặt chiều rộng tối thiểu cho cột "Mã Nhà Cung Cấp"
            }

            // Tùy chỉnh DataGridView
            dgv_ViewUser.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dgv_ViewUser.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv_ViewUser.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_ViewUser.EnableHeadersVisualStyles = false;

            dgv_ViewUser.DefaultCellStyle.Font = new Font("Arial", 11);
            dgv_ViewUser.DefaultCellStyle.BackColor = Color.White;
            dgv_ViewUser.DefaultCellStyle.ForeColor = Color.Black;
            dgv_ViewUser.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv_ViewUser.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv_ViewUser.GridColor = Color.DarkGray; // Đặt màu cho đường kẻ
            dgv_ViewUser.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical; // Thêm đường kẻ dọc cho các cột

            foreach (DataGridViewColumn column in dgv_ViewUser.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa dữ liệu
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
                column.DefaultCellStyle.Padding = new Padding(5); // Thêm khoảng cách bên trong các ô
            }

            dgv_ViewUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_ViewUser.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;

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
        private void Load_DataGridView()
        {
            try
            {
                string query = "Admin_GetAllUsers";
                DataTable dt = db.getDataTable(query, "NGUOIDUNG");

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv_ViewUser.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu người dùng để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_ViewUser.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Quản lý người dùng
        //Thêm người dùng
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
            // Kiểm tra nếu ngày sinh không được trong tương lai
            if (dob > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được là ngày trong tương lai.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra độ dài số điện thoại
            if (sdt.Length > 10)
            {
                MessageBox.Show("Số điện thoại không được vượt quá 10 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(user_name) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(pass) || cbo_VaiTroNguoiDung.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    pic_AddUser.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "yes.png");
                }
                else
                {
                    pic_AddUser.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "no.png");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra tên người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Xóa người dùng
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu ô tìm kiếm trống
            if (string.IsNullOrWhiteSpace(txt_Search.Text) || txt_Search.Text == "Search.......")
            {
                // Nếu trống, tải lại tất cả dữ liệu từ cơ sở dữ liệu
                Load_DataGridView();
            }
            else
            {
                // Câu truy vấn SQL với cú pháp đúng
                string query = "Admin_SearchUserByUsername";

                // Tạo parameter với giá trị tìm kiếm từ txt_Search
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@username", "%" + txt_Search.Text.Trim() + "%")
                };

                try
                {
                    // Sử dụng DBConnect để lấy dữ liệu và cập nhật DataGridView
                    DataTable dt = db.getDataTable(query, "NGUOIDUNG", parameters);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dgv_ViewUser.DataSource = dt; // Gán kết quả cho DataGridView
                    }
                    else
                    {
                        dgv_ViewUser.DataSource = null; // Xóa dữ liệu nếu không tìm thấy
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        string userName;

        private void dgv_ViewUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Kiểm tra chỉ số hàng hợp lệ
                {
                    userName = dgv_ViewUser.Rows[e.RowIndex].Cells["USERNAME"].Value.ToString(); // Sử dụng tên cột "USERNAME" để lấy giá trị
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa thông tin!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (currentUser != userName)
                {
                    try
                    {
                        string query = "Admin_DeleteUserByUsername";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", userName);

                        db.openConnect(); // Mở kết nối đến cơ sở dữ liệu
                        cmd.ExecuteNonQuery(); // Thực thi câu lệnh xóa
                        db.closeConnect(); // Đóng kết nối sau khi xóa

                        MessageBox.Show("Đã xóa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //UC_ViewUser_Load(this, null);
                        // Tải lại DataGridView sau khi xóa
                        Load_DataGridView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn không thể xóa tài khoản hiện tại đang đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UC_User_Load(this, null);
        }



        //Sửa người dùng
        private void dgv_ViewUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv_ViewUser.Rows[e.RowIndex];

                    Load_Combobox_VaiTroNguoiDung();

                    cbo_VaiTroNguoiDung.SelectedValue = row.Cells["MAQUYEN"].Value.ToString();
                    txt_Ten.Text = row.Cells["TEN"].Value.ToString();
                    dt_NS.Value = Convert.ToDateTime(row.Cells["NGAYSINH"].Value);
                    txt_SDT.Text = row.Cells["SODIENTHOAI"].Value.ToString();
                    txt_UserName.Text = row.Cells["USERNAME"].Value.ToString();
                    txt_MK.Text = row.Cells["MATKHAU"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu hợp lệ
                if (string.IsNullOrWhiteSpace(txt_Ten.Text) ||
                    string.IsNullOrWhiteSpace(txt_UserName.Text) ||
                    string.IsNullOrWhiteSpace(txt_MK.Text) ||
                    cbo_VaiTroNguoiDung.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin người dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy giá trị từ các TextBox và ComboBox
                string ten = txt_Ten.Text;
                DateTime ngaySinh = dt_NS.Value;
                string sdt = txt_SDT.Text;
                string userName = txt_UserName.Text;
                string matKhau = txt_MK.Text;
                string maQuyen = cbo_VaiTroNguoiDung.SelectedValue.ToString();

                // Thực hiện cập nhật qua Stored Procedure
                SqlCommand cmd = new SqlCommand("Admin_UpdateUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số vào thủ tục
                cmd.Parameters.AddWithValue("@TEN", ten);
                cmd.Parameters.AddWithValue("@NGAYSINH", ngaySinh);
                cmd.Parameters.AddWithValue("@SODIENTHOAI", sdt);
                cmd.Parameters.AddWithValue("@USERNAME", userName);
                cmd.Parameters.AddWithValue("@MATKHAU", matKhau);
                cmd.Parameters.AddWithValue("@MAQUYEN", maQuyen);

                // Mở kết nối, thực thi câu lệnh, và đóng kết nối
                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect(); // Mở kết nối nếu chưa mở
                }
                cmd.ExecuteNonQuery(); // Thực thi lệnh thêm
                db.closeConnect(); // Đóng kết nối

                // Thông báo thành công và tải lại DataGridView
                MessageBox.Show("Cập nhật thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DataGridView();  // Cập nhật lại danh sách người dùng
                ClearAll();           // Xóa dữ liệu trên giao diện
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
