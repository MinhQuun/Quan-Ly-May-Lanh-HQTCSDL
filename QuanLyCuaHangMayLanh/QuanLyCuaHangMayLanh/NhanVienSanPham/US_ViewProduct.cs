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

namespace QuanLyCuaHangMayLanh.User
{
    public partial class US_ViewProduct : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public US_ViewProduct()
        {
            cn = db.conn;
            InitializeComponent();
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

        private void US_ViewProduct_Load(object sender, EventArgs e)
        {
            // Thiết lập placeholder mặc định cho TextBox
            txt_Search.Text = "Search.......";
            txt_Search.ForeColor = Color.Gray;
            txt_Search.Font = new Font(txt_Search.Font.FontFamily, 14, FontStyle.Italic);

            // Gắn sự kiện Enter và Leave cho TextBox
            txt_Search.Enter += txt_Search_Enter;
            txt_Search.Leave += txt_Search_Leave;

            Load_DataGridView();

            if (dgv_ViewProduct.Columns.Count > 0)
            {
                dgv_ViewProduct.Columns["MASANPHAM"].HeaderText = "Mã Sản Phẩm";
                dgv_ViewProduct.Columns["TENSANPHAM"].HeaderText = "Tên Sản Phẩm";
                dgv_ViewProduct.Columns["SOLUONG"].HeaderText = "Số Lượng";
                dgv_ViewProduct.Columns["DONGIANHAP"].HeaderText = "Đơn Giá Nhập";
                dgv_ViewProduct.Columns["DONGIABAN"].HeaderText = "Đơn Giá Bán";
                dgv_ViewProduct.Columns["MANCC"].HeaderText = "Mã Nhà Cung Cấp";

                // Đặt chế độ tự điều chỉnh và chiều rộng tối thiểu cho cột "Mã Sản Phẩm"
                dgv_ViewProduct.Columns["MASANPHAM"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv_ViewProduct.Columns["MASANPHAM"].MinimumWidth = 120; // Đặt chiều rộng tối thiểu cho cột "Mã Sản Phẩm"
            }

            // Tùy chỉnh DataGridView
            dgv_ViewProduct.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dgv_ViewProduct.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv_ViewProduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_ViewProduct.EnableHeadersVisualStyles = false;

            dgv_ViewProduct.DefaultCellStyle.Font = new Font("Arial", 11);
            dgv_ViewProduct.DefaultCellStyle.BackColor = Color.White;
            dgv_ViewProduct.DefaultCellStyle.ForeColor = Color.Black;
            dgv_ViewProduct.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv_ViewProduct.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv_ViewProduct.GridColor = Color.DarkGray; // Đặt màu cho đường kẻ
            dgv_ViewProduct.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical; // Thêm đường kẻ dọc cho các cột

            foreach (DataGridViewColumn column in dgv_ViewProduct.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa dữ liệu
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
                column.DefaultCellStyle.Padding = new Padding(5); // Thêm khoảng cách bên trong các ô
            }

            dgv_ViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_ViewProduct.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
        }
        private void Load_DataGridView()
        {
            try
            {
                string query = "NVSP_GetAllProducts";
                DataTable dt = db.getDataTable(query, "SANPHAM");

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv_ViewProduct.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_ViewProduct.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu ô tìm kiếm trống hoặc giá trị mặc định "Search......."
            if (string.IsNullOrWhiteSpace(txt_Search.Text) || txt_Search.Text == "Search.......")
            {
                // Nếu trống, tải lại tất cả dữ liệu từ cơ sở dữ liệu
                Load_DataGridView();
            }
            else
            {
                // Câu truy vấn SQL với cú pháp đúng
                string query = "NVSP_SearchProductByName";

                // Tạo parameter với giá trị tìm kiếm từ txt_Search
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@tensp", "%" + txt_Search.Text.Trim() + "%")
                };

                try
                {
                    // Sử dụng DBConnect để lấy dữ liệu và cập nhật DataGridView
                    DataTable dt = db.getDataTable(query, "SANPHAM", parameters);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dgv_ViewProduct.DataSource = dt; // Gán kết quả cho DataGridView
                    }
                    else
                    {
                        dgv_ViewProduct.DataSource = null; // Xóa dữ liệu nếu không tìm thấy
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        string TenSP;

        private void dgv_ViewProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Kiểm tra chỉ số hàng hợp lệ
                {
                    TenSP = dgv_ViewProduct.Rows[e.RowIndex].Cells["TENSANPHAM"].Value.ToString(); // Sử dụng tên cột "TENSANPHAM" để lấy giá trị
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn tên sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TenSP))
            {
                MessageBox.Show("Vui lòng chọn tên sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm không?", "Xóa thông tin!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Gọi stored procedure để xóa sản phẩm
                    SqlCommand cmd = new SqlCommand("NVSP_DeleteProductByName", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tensp", TenSP);

                    db.openConnect(); // Mở kết nối đến cơ sở dữ liệu
                    cmd.ExecuteNonQuery(); // Thực thi stored procedure
                    db.closeConnect(); // Đóng kết nối

                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại DataGridView sau khi xóa
                    Load_DataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {
            US_ViewProduct_Load(this, null);
        }

    }
}
