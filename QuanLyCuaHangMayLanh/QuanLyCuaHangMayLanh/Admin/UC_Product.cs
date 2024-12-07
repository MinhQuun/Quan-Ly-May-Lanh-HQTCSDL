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
    public partial class UC_Product : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public UC_Product()
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
        private void UC_Product_Load(object sender, EventArgs e)
        {
            txt_SL.Text = "0";  // Đặt mặc định giá trị cho TextBox là 0
            // Khi nhấn vào dòng dữ liệu, vô hiệu hóa ô Số Lượng
            txt_SL.Enabled = false; // Vô hiệu hóa TextBox Số Lượng

            btn_AddProduct.MouseEnter += button_MouseEnter;
            btn_AddProduct.MouseLeave += button_MouseLeave;

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

            Load_Combobox_MaNCC();
        }
        public void Load_Combobox_MaNCC()
        {

            try
            {
                DataTable dtNCC = db.getDataTable("NVSP_GetAllSuppliers", "NHACUNGCAP");

                // Gán dữ liệu cho ComboBox
                cbo_MaNCC.DataSource = dtNCC;
                //cbo_MaNCC.DisplayMember = "TENNCC";    // Giá trị hiển thị mã
                cbo_MaNCC.ValueMember = "MANCC";     // Giá trị là tên
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

        //Thêm sản phẩm 
        private void btn_AddProduct_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các trường nhập liệu có trống
            if (string.IsNullOrEmpty(txt_MaSP.Text) || string.IsNullOrEmpty(txt_TenSP.Text) ||
                string.IsNullOrEmpty(txt_SL.Text) || string.IsNullOrEmpty(txt_DonGiaNhap.Text) ||
                string.IsNullOrEmpty(txt_DonGiaBan.Text) || cbo_MaNCC.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Lấy Mã Nhà Cung Cấp từ combobox
            string maNCC = cbo_MaNCC.SelectedValue.ToString();
            SqlParameter[] checkParams = { new SqlParameter("@MANCC", maNCC) };
            int count = db.getCount("NVSP_CheckSupplierExistence", checkParams);

            if (count == 0) // Không tồn tại mã nhà cung cấp trong CSDL
            {
                MessageBox.Show("Mã nhà cung cấp không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            // Lấy dữ liệu từ các textbox và combobox
            string maSP = txt_MaSP.Text.Trim();
            string tenSP = txt_TenSP.Text.Trim();
            decimal donGiaNhap, donGiaBan;

            // Đặt mặc định số lượng là 0 nếu người dùng không nhập giá trị
            int soLuong = 0;  // Số lượng mặc định = 0
            if (!string.IsNullOrWhiteSpace(txt_SL.Text))
            {
                soLuong = Convert.ToInt32(txt_SL.Text);  // Lấy giá trị nhập từ TextBox
            }

            // Kiểm tra giá trị hợp lệ của Đơn Giá Nhập
            if (!decimal.TryParse(txt_DonGiaNhap.Text.Trim(), out donGiaNhap) || donGiaNhap < 0)
            {
                MessageBox.Show("Đơn giá nhập phải là một số không âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra giá trị hợp lệ của Đơn Giá Bán
            if (!decimal.TryParse(txt_DonGiaBan.Text.Trim(), out donGiaBan) || donGiaBan < 0)
            {
                MessageBox.Show("Đơn giá bán phải là một số không âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Chuỗi truy vấn để thêm sản phẩm vào cơ sở dữ liệu
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MASP", maSP),
                    new SqlParameter("@TENSP", tenSP),
                    new SqlParameter("@DONGIANHAP", donGiaNhap),
                    new SqlParameter("@DONGIABAN", donGiaBan),
                    new SqlParameter("@MANCC", maNCC)
                };

                // Mở kết nối và thực thi câu lệnh thêm
                db.openConnect();
                SqlCommand cmd = new SqlCommand("NVSP_AddProduct", db.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
                db.closeConnect();

                MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa dữ liệu trong các ô nhập liệu
                ClearAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClearAll()
        {
            txt_MaSP.Clear();
            txt_TenSP.Clear();
            txt_SL.Text = "0";  // Đặt mặc định là 0
            txt_DonGiaNhap.Clear();
            txt_DonGiaBan.Clear();
            cbo_MaNCC.SelectedIndex = -1;
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txt_MaSP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MASP", txt_MaSP.Text)
                };
                int count = db.getCount("NVSP_CheckProductExistence", parameters);

                if (count == 0)
                {
                    pic_AddProduct.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "yes.png");
                }
                else
                {
                    pic_AddProduct.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "no.png");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UC_Product_Load(this, null);
        }

        //Xóa sản phẩm
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

        //Sửa sản phẩm
        private void dgv_ViewProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgv_ViewProduct.Rows[e.RowIndex];

                Load_Combobox_MaNCC();

                cbo_MaNCC.SelectedValue = row.Cells["MANCC"].Value.ToString();
                txt_MaSP.Text = row.Cells["MASANPHAM"].Value.ToString();
                txt_TenSP.Text = row.Cells["TENSANPHAM"].Value.ToString();
                txt_SL.Text = row.Cells["SOLUONG"].Value.ToString();
                txt_DonGiaNhap.Text = row.Cells["DONGIANHAP"].Value.ToString();
                txt_DonGiaBan.Text = row.Cells["DONGIABAN"].Value.ToString();
                // Khi nhấn vào dòng dữ liệu, vô hiệu hóa ô Số Lượng
                txt_SL.Enabled = false; // Vô hiệu hóa TextBox Số Lượng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            string maSP = txt_MaSP.Text;
            string tenSP = txt_TenSP.Text;
            decimal donGiaNhap, donGiaBan;
            string maNCC = cbo_MaNCC.Text;

            // Đặt mặc định số lượng là 0 nếu không có giá trị nhập
            int soLuong = 0;  // Số lượng mặc định là 0
            if (!string.IsNullOrWhiteSpace(txt_SL.Text))
            {
                soLuong = Convert.ToInt32(txt_SL.Text);  // Lấy giá trị nhập từ TextBox
            }

            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP) || string.IsNullOrEmpty(maNCC) ||
                !int.TryParse(txt_SL.Text, out soLuong) ||
                !decimal.TryParse(txt_DonGiaNhap.Text, out donGiaNhap) ||
                !decimal.TryParse(txt_DonGiaBan.Text, out donGiaBan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng thông tin sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = "NVSP_UpdateProduct";
                SqlCommand cmdUpdate = new SqlCommand(query, db.conn);
                cmdUpdate.CommandType = CommandType.StoredProcedure; // Đặt kiểu là StoredProcedure

                cmdUpdate.Parameters.AddWithValue("@MASANPHAM", maSP);
                cmdUpdate.Parameters.AddWithValue("@TENSANPHAM", tenSP);
                cmdUpdate.Parameters.AddWithValue("@DONGIANHAP", donGiaNhap);
                cmdUpdate.Parameters.AddWithValue("@DONGIABAN", donGiaBan);
                cmdUpdate.Parameters.AddWithValue("@MANCC", maNCC);

                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect(); // Mở kết nối nếu chưa mở
                }
                cmdUpdate.ExecuteNonQuery(); // Thực thi lệnh cập nhật
                db.closeConnect(); // Đóng kết nối

                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
