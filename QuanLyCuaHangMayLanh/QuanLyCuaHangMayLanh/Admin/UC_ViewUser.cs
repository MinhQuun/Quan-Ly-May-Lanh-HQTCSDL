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
    public partial class UC_ViewUser : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        string currentUser = "";
        
        public UC_ViewUser()
        {
            cn = db.conn;
            InitializeComponent();
        }
        public string ID
        {
            set { currentUser = value; }
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


        private void UC_ViewUser_Load(object sender, EventArgs e)
        {
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

            // Ẩn cột mật khẩu
            //if (dgv_ViewUser.Columns.Contains("MATKHAU"))
            //{
            //    dgv_ViewUser.Columns["MATKHAU"].Visible = false;
            //}
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

        private void txt_Search_TextChanged(object sender, EventArgs e)
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
            UC_ViewUser_Load(this, null);
        }


    }
}
