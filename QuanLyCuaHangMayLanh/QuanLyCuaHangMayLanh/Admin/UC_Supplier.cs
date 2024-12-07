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
    public partial class UC_Supplier : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        string currentUser = "";

        public UC_Supplier()
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

        private void UC_Supplier_Load(object sender, EventArgs e)
        {
            btn_AddSupplier.MouseEnter += button_MouseEnter;
            btn_AddSupplier.MouseLeave += button_MouseLeave;

            btn_Delete.MouseEnter += button_MouseEnter;
            btn_Delete.MouseLeave += button_MouseLeave;

            btn_UpdateSupplier.MouseEnter += button_MouseEnter;
            btn_UpdateSupplier.MouseLeave += button_MouseLeave;

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

            if (dgv_ViewSupplier.Columns.Count > 0)
            {
                dgv_ViewSupplier.Columns["MANCC"].HeaderText = "Mã Nhà Cung Cấp";
                dgv_ViewSupplier.Columns["TENNCC"].HeaderText = "Tên Nhà Cung Cấp";
                dgv_ViewSupplier.Columns["DIACHI"].HeaderText = "Địa Chỉ";

                // Đặt chế độ tự điều chỉnh và chiều rộng tối thiểu cho cột "Mã Nhà Cung Cấp"
                dgv_ViewSupplier.Columns["MANCC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv_ViewSupplier.Columns["MANCC"].MinimumWidth = 120; // Đặt chiều rộng tối thiểu cho cột "Mã Nhà Cung Cấp"
            }

            // Tùy chỉnh DataGridView
            dgv_ViewSupplier.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dgv_ViewSupplier.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv_ViewSupplier.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_ViewSupplier.EnableHeadersVisualStyles = false;

            dgv_ViewSupplier.DefaultCellStyle.Font = new Font("Arial", 11);
            dgv_ViewSupplier.DefaultCellStyle.BackColor = Color.White;
            dgv_ViewSupplier.DefaultCellStyle.ForeColor = Color.Black;
            dgv_ViewSupplier.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv_ViewSupplier.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv_ViewSupplier.GridColor = Color.DarkGray; // Đặt màu cho đường kẻ
            dgv_ViewSupplier.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical; // Thêm đường kẻ dọc cho các cột

            foreach (DataGridViewColumn column in dgv_ViewSupplier.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa dữ liệu
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
                column.DefaultCellStyle.Padding = new Padding(5); // Thêm khoảng cách bên trong các ô
            }

            dgv_ViewSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_ViewSupplier.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
        }
        private void Load_DataGridView()
        {
            try
            {
                string query = "NVSP_GetAllSuppliers";
                DataTable dt = db.getDataTable(query, "NHACUNGCAP");

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv_ViewSupplier.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu nhà cung cấp để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_ViewSupplier.DataSource = null;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Thêm nhà cung cấp
        private void btn_AddSupplier_Click(object sender, EventArgs e)
        {
            string ma = txt_MaNCC.Text;
            string ten = txt_TenNCC.Text;
            string dc = txt_DiaChi.Text;
            if (string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(dc))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                // Sử dụng getCount để kiểm tra sự tồn tại của mã nhà cung cấp
                SqlParameter[] checkParams = { new SqlParameter("@MANCC", ma) };
                int count = db.getCount("NVSP_CheckSupplierExistence", checkParams);

                if (count > 0)
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Gọi thủ tục lưu trữ để thêm nhà cung cấp
                SqlParameter[] insertParameters =
                {
                    new SqlParameter("@MANCC", ma),
                    new SqlParameter("@TENNCC", ten),
                    new SqlParameter("@DIACHI", dc)
                };
                db.openConnect();
                SqlCommand cmd = new SqlCommand("NVSP_AddSupplier", db.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(insertParameters);
                cmd.ExecuteNonQuery();
                db.closeConnect();


                MessageBox.Show("Thêm nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll(); // Làm trống các trường nhập liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thêm được: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClearAll()
        {
            txt_MaNCC.Clear();
            txt_TenNCC.Clear();
            txt_DiaChi.Clear();

        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txt_MaNCC_TextChanged(object sender, EventArgs e)
        {
            string ma = txt_MaNCC.Text;

            try
            {
                // Kiểm tra sự tồn tại của mã nhà cung cấp
                SqlParameter[] checkParams = { new SqlParameter("@MANCC", ma) };
                int count = db.getCount("NVSP_CheckSupplierExistence", checkParams);

                // Cập nhật hình ảnh dựa trên kết quả
                if (count == 0)
                {
                    pic_AddSupplier.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "yes.png");
                }
                else
                {
                    pic_AddSupplier.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "no.png");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xóa nhà cung cấp
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
                string query = "NVSP_SearchSupplierByName";

                // Tạo parameter với giá trị tìm kiếm từ txt_Search
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@tenncc", txt_Search.Text.Trim())
                };

                try
                {
                    // Sử dụng DBConnect để lấy dữ liệu và cập nhật DataGridView
                    DataTable dt = db.getDataTable(query, "NHACUNGCAP", parameters);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dgv_ViewSupplier.DataSource = dt; // Gán kết quả cho DataGridView

                    }
                    else
                    {
                        dgv_ViewSupplier.DataSource = null; // Xóa dữ liệu nếu không tìm thấy
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }      
        }

        string TenNCC;

        private void dgv_ViewSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Kiểm tra chỉ số hàng hợp lệ
                {
                    TenNCC = dgv_ViewSupplier.Rows[e.RowIndex].Cells["TENNCC"].Value.ToString(); // Sử dụng tên cột "TENNCC" để lấy giá trị
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn tên tên cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TenNCC))
            {
                MessageBox.Show("Vui lòng chọn tên nhà cung cấp cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp không?", "Xóa thông tin!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Gọi stored procedure để xóa nhà cung cấp và các sản phẩm liên quan
                    SqlCommand cmd = new SqlCommand("NVSP_DeleteSupplierByName", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tenncc", TenNCC);

                    db.openConnect(); // Mở kết nối đến cơ sở dữ liệu
                    cmd.ExecuteNonQuery(); // Thực thi stored procedure
                    db.closeConnect(); // Đóng kết nối

                    MessageBox.Show("Đã xóa nhà cung cấp và các sản phẩm liên quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại DataGridView sau khi xóa
                    Load_DataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UC_Supplier_Load(this, null);
        }

        
        //Sửa nhà cung cấp
        private void dgv_ViewSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgv_ViewSupplier.Rows[e.RowIndex];

                txt_MaNCC.Text = row.Cells["MANCC"].Value.ToString();
                txt_TenNCC.Text = row.Cells["TENNCC"].Value.ToString();
                txt_DiaChi.Text = row.Cells["DIACHI"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_UpdateSupplier_Click(object sender, EventArgs e)
        {
            string ma = txt_MaNCC.Text;
            string ten = txt_TenNCC.Text;
            string dc = txt_DiaChi.Text;
            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(ma) || string.IsNullOrEmpty(dc))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "NVSP_UpdateSupplier";
                SqlCommand cmdUpdate = new SqlCommand(query, db.conn);
                cmdUpdate.CommandType = CommandType.StoredProcedure; // Đặt kiểu là StoredProcedure

                cmdUpdate.Parameters.AddWithValue("@MANCC", ma);
                cmdUpdate.Parameters.AddWithValue("@TENNCC", ten);
                cmdUpdate.Parameters.AddWithValue("@DIACHI", dc);

                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect(); // Mở kết nối nếu chưa mở
                }
                cmdUpdate.ExecuteNonQuery(); // Thực thi lệnh thêm
                db.closeConnect(); // Đóng kết nối

                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
