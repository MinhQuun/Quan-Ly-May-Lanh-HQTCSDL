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
    public partial class UC_NhapHang : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public UC_NhapHang()
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

        private void UC_NhapHang_Load(object sender, EventArgs e)
        {
            // Thiết lập placeholder mặc định cho TextBox
            dt_NgayNhap.Enabled = false;
            lbl_MaHDN.Visible = false;
            txt_MaHDN.Visible = false;
            dt_NgayNhap.Value = DateTime.Now;
            txt_Search.Text = "Search.......";
            txt_Search.ForeColor = Color.Gray;
            txt_Search.Font = new Font(txt_Search.Font.FontFamily, 14, FontStyle.Italic);

            // Gắn sự kiện Enter và Leave cho TextBox
            txt_Search.Enter += txt_Search_Enter;
            txt_Search.Leave += txt_Search_Leave;

            btn_AddHDN.MouseEnter += button_MouseEnter;
            btn_AddHDN.MouseLeave += button_MouseLeave;

            btn_InHoaDon.MouseEnter += button_MouseEnter;
            btn_InHoaDon.MouseLeave += button_MouseLeave;

            btn_Reload.MouseEnter += button_MouseEnter;
            btn_Reload.MouseLeave += button_MouseLeave;

            btn_Update.MouseEnter += button_MouseEnter;
            btn_Update.MouseLeave += button_MouseLeave;

            Load_Combobox_MaNCC();
            Load_Combobox_NhanVien();
            Load_Combobox_SanPham();

            Load_DataGridView();
            if (dgv_HoaDonNhap.Columns.Count > 0)
            {
                // Đổi tên các cột để phù hợp với yêu cầu hiển thị
                dgv_HoaDonNhap.Columns["MAHDN"].HeaderText = "Mã Hóa Đơn Nhập";
                dgv_HoaDonNhap.Columns["MANV"].HeaderText = "Mã Nhân Viên";
                dgv_HoaDonNhap.Columns["TENNV"].HeaderText = "Nhân Viên";
                dgv_HoaDonNhap.Columns["MANCC"].HeaderText = "Mã Nhà Cung Cấp";
                dgv_HoaDonNhap.Columns["TENNCC"].HeaderText = "Nhà Cung Cấp";
                dgv_HoaDonNhap.Columns["NGAYNHAP"].HeaderText = "Ngày Nhập";
                dgv_HoaDonNhap.Columns["MASANPHAM"].HeaderText = "Mã Sản Phẩm";
                dgv_HoaDonNhap.Columns["TENSANPHAM"].HeaderText = "Tên Sản Phẩm";
                dgv_HoaDonNhap.Columns["SOLUONG"].HeaderText = "Số Lượng";
                dgv_HoaDonNhap.Columns["DONGIA"].HeaderText = "Đơn Giá";
                dgv_HoaDonNhap.Columns["TONGTIEN"].HeaderText = "Tổng Tiền";
            }
            // Tùy chỉnh DataGridView
            dgv_HoaDonNhap.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dgv_HoaDonNhap.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv_HoaDonNhap.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_HoaDonNhap.EnableHeadersVisualStyles = false;

            dgv_HoaDonNhap.DefaultCellStyle.Font = new Font("Arial", 11);
            dgv_HoaDonNhap.DefaultCellStyle.BackColor = Color.White;
            dgv_HoaDonNhap.DefaultCellStyle.ForeColor = Color.Black;
            dgv_HoaDonNhap.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv_HoaDonNhap.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv_HoaDonNhap.GridColor = Color.DarkGray; // Đặt màu cho đường kẻ
            dgv_HoaDonNhap.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical; // Thêm đường kẻ dọc cho các cột

            foreach (DataGridViewColumn column in dgv_HoaDonNhap.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa dữ liệu
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
                column.DefaultCellStyle.Padding = new Padding(5); // Thêm khoảng cách bên trong các ô
            }

            dgv_HoaDonNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_HoaDonNhap.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
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

        public void Load_Combobox_NhanVien()
        {
            try
            {
                DataTable dtNV = db.getDataTable("NVKH_GetAllNhanVien", "NHANVIEN");

                // Gán dữ liệu cho ComboBox
                cbo_NV.DataSource = dtNV;
                cbo_NV.DisplayMember = "TENNV";      // Tên nhân viên để hiển thị
                cbo_NV.ValueMember = "MANV";         // Giá trị là mã nhân viên
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void Load_Combobox_SanPham()
        {
            try
            {
                DataTable dtSP = db.getDataTable("NVSP_GetAllProducts", "SANPHAM");

                // Gán dữ liệu cho ComboBox
                cbo_SP.DataSource = dtSP;
                cbo_SP.DisplayMember = "TENSANPHAM"; // Tên sản phẩm để hiển thị
                cbo_SP.ValueMember = "MASANPHAM";    // Giá trị là mã sản phẩm
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
                // Lấy dữ liệu từ cơ sở dữ liệu và gán vào DataTable
                DataTable dt = db.getDataTable("NVKH_GetAllHoaDonNhap", "HOADONNHAP");

                // Gán dữ liệu cho DataGridView
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv_HoaDonNhap.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn nhập để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_HoaDonNhap.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            txt_MaHDN.Clear();
            cbo_NV.SelectedIndex = -1;
            cbo_MaNCC.SelectedIndex = -1;
            dt_NgayNhap.ResetText();
            cbo_SP.SelectedIndex = -1;
            txt_SL.Clear();
            txt_DonGiaNhap.Clear();
            txt_TongTien.Clear();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UC_NhapHang_Load(this, null);
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
                try
                {
                    SqlParameter[] parameters = { new SqlParameter("@MAHDN", "%" + txt_Search.Text.Trim() + "%") };
                    DataTable dt = db.getDataTable("NVKH_SearchHoaDonNhap", "HOADONNHAP", parameters);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dgv_HoaDonNhap.DataSource = dt;
                    }
                    else
                    {
                        dgv_HoaDonNhap.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }     
        }

        private void dgv_HoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv_HoaDonNhap.Rows[e.RowIndex];

                    txt_MaHDN.Text = row.Cells["MAHDN"].Value.ToString();

                    // Đảm bảo dữ liệu đã có trong ComboBox trước khi gán giá trị
                    Load_Combobox_NhanVien();
                    Load_Combobox_MaNCC();
                    Load_Combobox_SanPham();

                    // Hiển thị mã nhân viên trong ComboBox
                    cbo_NV.SelectedValue = row.Cells["MANV"].Value.ToString();

                    // Hiển thị mã nhà cung cấp trong ComboBox
                    cbo_MaNCC.SelectedValue = row.Cells["MANCC"].Value.ToString();

                    // Hiển thị mã sản phẩm trong ComboBox
                    cbo_SP.SelectedValue = row.Cells["MASANPHAM"].Value.ToString();

                    dt_NgayNhap.Value = Convert.ToDateTime(row.Cells["NGAYNHAP"].Value);
                    txt_SL.Text = row.Cells["SOLUONG"].Value.ToString();
                    txt_DonGiaNhap.Text = row.Cells["DONGIA"].Value.ToString();

                    // Tính lại tổng tiền
                    decimal donGia = Convert.ToDecimal(txt_DonGiaNhap.Text);
                    int soLuong = Convert.ToInt32(txt_SL.Text);
                    txt_TongTien.Text = (donGia * soLuong).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_MaHDN_TextChanged(object sender, EventArgs e)
        {
            SqlParameter[] parameters = { new SqlParameter("@MAHDN", txt_MaHDN.Text) };
            int count = db.getCount("NVKH_CheckHoaDonNhapExists", parameters);
            if (count == 0)
            {
                pic_AddHDN.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "yes.png");
            }
            else
            {
                pic_AddHDN.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "no.png");
            }
        }

        private void cbo_SP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có sản phẩm nào được chọn không
            if (cbo_SP.SelectedIndex != -1)
            {
                string maSP = cbo_SP.SelectedValue.ToString();  // Lấy mã sản phẩm từ ComboBox

                try
                {
                    // Mở kết nối tới cơ sở dữ liệu
                    if (cn.State != ConnectionState.Open)
                    {
                        db.openConnect();
                    }

                    // Sử dụng thủ tục lưu trữ để lấy giá nhập của sản phẩm theo mã sản phẩm
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@MaSP", maSP)
                    };

                    // Gọi thủ tục lưu trữ "NVKH_LayDonGiaNhapTheoSP" để lấy giá nhập sản phẩm
                    object result = db.getCount("NVKH_LayDonGiaNhapTheoSP", parameters);

                    // Kiểm tra kết quả và hiển thị giá nhập
                    if (result != null)
                    {
                        decimal giaNhap = Convert.ToDecimal(result);  // Convert kết quả thành decimal
                        txt_DonGiaNhap.Text = giaNhap.ToString("N0");  // Hiển thị giá nhập vào TextBox, định dạng số
                    }
                    else
                    {
                        txt_DonGiaNhap.Clear();  // Nếu không tìm thấy giá, xóa TextBox
                    }

                    db.closeConnect();  // Đóng kết nối
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy giá nhập sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string GetNextMaHDN()
        {
            try
            {
                // Kết nối tới cơ sở dữ liệu
                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect();
                }

                // Truy vấn mã hóa đơn nhập lớn nhất
                SqlCommand cmd = new SqlCommand("SELECT MAX(MAHDN) FROM HOADONNHAP", cn);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    string currentMaxMaHDN = result.ToString();  // Lấy mã hóa đơn nhập lớn nhất
                    int lastNumber = int.Parse(currentMaxMaHDN.Substring(4));  // Lấy 3 chữ số cuối của mã hóa đơn nhập
                    lastNumber++;  // Tăng số cuối lên 1
                    return "HDN" + lastNumber.ToString("D3");  // Trả về mã hóa đơn nhập mới với 3 chữ số cuối tự động tăng
                }
                else
                {
                    // Nếu chưa có hóa đơn nhập nào, bắt đầu từ "HDN001"
                    return "HDN001";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã hóa đơn nhập tiếp theo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                // Đảm bảo đóng kết nối
                if (cn.State == ConnectionState.Open)
                {
                    db.closeConnect();
                }
            }
        }

        private void btn_AddHDN_Click(object sender, EventArgs e)
        {
            // Gọi phương thức để lấy mã hóa đơn nhập tự động
            string maHDN = GetNextMaHDN();

            if (string.IsNullOrWhiteSpace(maHDN))
            {
                MessageBox.Show("Không thể tạo mã hóa đơn nhập mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Các kiểm tra dữ liệu khác (như mã nhân viên, nhà cung cấp, sản phẩm, số lượng, đơn giá...) như trước
            if (cbo_NV.SelectedIndex == -1 || cbo_MaNCC.SelectedIndex == -1 || cbo_SP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên, nhà cung cấp và sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maNV = cbo_NV.SelectedValue.ToString();
            string maNCC = cbo_MaNCC.SelectedValue.ToString();
            DateTime ngayNhap = dt_NgayNhap.Value;
            string maSP = cbo_SP.SelectedValue.ToString();

            // Kiểm tra nếu ngày nhập là ngày tương lai
            if (ngayNhap.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày nhập không thể là ngày tương lai.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int soLuong;
            decimal donGia;

            if (!int.TryParse(txt_SL.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ (lớn hơn 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txt_DonGiaNhap.Text, out donGia) || donGia <= 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá hợp lệ (lớn hơn 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính tổng tiền
            decimal tongTien = soLuong * donGia;
            txt_TongTien.Text = tongTien.ToString();

            try
            {
                // Mở kết nối
                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect();
                }

                // Thêm hóa đơn nhập
                using (SqlCommand cmdHDN = new SqlCommand("NVKH_AddHoaDonNhap", cn))
                {
                    cmdHDN.CommandType = CommandType.StoredProcedure;
                    cmdHDN.Parameters.AddWithValue("@MAHDN", maHDN);
                    cmdHDN.Parameters.AddWithValue("@MANV", maNV);
                    cmdHDN.Parameters.AddWithValue("@MANCC", maNCC);
                    cmdHDN.Parameters.AddWithValue("@TONGTIEN", tongTien);
                    cmdHDN.Parameters.AddWithValue("@NGAYNHAP", ngayNhap);

                    cmdHDN.ExecuteNonQuery();
                }

                // Thêm chi tiết hóa đơn nhập
                using (SqlCommand cmdCTHDN = new SqlCommand("NVKH_AddCTHoaDonNhap", cn))
                {
                    cmdCTHDN.CommandType = CommandType.StoredProcedure;
                    cmdCTHDN.Parameters.AddWithValue("@MACTHDN", "CT" + maHDN);
                    cmdCTHDN.Parameters.AddWithValue("@MAHDN", maHDN);
                    cmdCTHDN.Parameters.AddWithValue("@MASANPHAM", maSP);
                    cmdCTHDN.Parameters.AddWithValue("@SOLUONG", soLuong);
                    cmdCTHDN.Parameters.AddWithValue("@DONGIA", donGia);
                    cmdCTHDN.ExecuteNonQuery();
                }

                using (SqlCommand cmdCTHDN = new SqlCommand("NVKH_UpdateInventoryUsingCursor", cn))
                {
                    cmdCTHDN.CommandType = CommandType.StoredProcedure;
                    cmdCTHDN.Parameters.AddWithValue("@MAHDN", maHDN);  // maHDN là mã hóa đơn nhập cần truyền vào
                    cmdCTHDN.ExecuteNonQuery();
                }
                db.closeConnect();

                // Clear tất cả các trường sau khi thêm thành công
                ClearAll();

                MessageBox.Show("Thêm hóa đơn nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu DataGridView
                Load_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo kết nối được đóng trong mọi trường hợp
                if (cn.State == ConnectionState.Open)
                {
                    db.closeConnect();
                }
            }
        }


        private void cbo_MaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu người dùng đã chọn nhà cung cấp
                if (cbo_MaNCC.SelectedValue != null)
                {
                    string selectedMaNCC = cbo_MaNCC.SelectedValue.ToString();

                    // Gọi hàm để tải danh sách sản phẩm theo nhà cung cấp
                    LoadProductsByMaNCC(selectedMaNCC);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadProductsByMaNCC(string maNCC)
        {
            try
            {
                // Kết nối tới cơ sở dữ liệu
                SqlCommand cmd = new SqlCommand("NVKH_GetProductsByMaNCC", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);

                // Tạo DataAdapter để lấy dữ liệu trả về từ Stored Procedure
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Cập nhật ComboBox sản phẩm với dữ liệu lấy được
                cbo_SP.DataSource = dt;
                cbo_SP.DisplayMember = "TENSANPHAM"; // Hiển thị tên sản phẩm
                cbo_SP.ValueMember = "MASANPHAM";  // Lưu trữ mã sản phẩm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
