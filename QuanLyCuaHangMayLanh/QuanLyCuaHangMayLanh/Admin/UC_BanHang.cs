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
    public partial class UC_BanHang : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public UC_BanHang()
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
        private void UC_BanHang_Load(object sender, EventArgs e)
        {
            // Thiết lập placeholder mặc định cho TextBox
            dt_NgayXuat.Value = DateTime.Now;
            txt_MaHDX.Visible = false;
            lbl_MaHDX.Visible = false;

            
            cbo_KH.Visible = false;  // Hiển thị ComboBox cho khách hàng cũ
            txtTenKH.Visible = false;  // Ẩn các TextBox cho khách hàng mới
            lblTenKH.Visible = false;
            lblSDT.Visible = false;
            lblDiaChi.Visible = false;
            txtDiaChi.Visible = false;
            txtSDT.Visible = false;
            
            
            // Vô hiệu hóa không cho phép người dùng chọn ngày khác
            dt_NgayXuat.Enabled = false;
            txt_Search.Text = "Search.......";
            txt_Search.ForeColor = Color.Gray;
            txt_Search.Font = new Font(txt_Search.Font.FontFamily, 14, FontStyle.Italic);

            // Gắn sự kiện Enter và Leave cho TextBox
            txt_Search.Enter += txt_Search_Enter;
            txt_Search.Leave += txt_Search_Leave;

            btn_BanHang.MouseEnter += button_MouseEnter;
            btn_BanHang.MouseLeave += button_MouseLeave;

            btn_InHoaDon.MouseEnter += button_MouseEnter;
            btn_InHoaDon.MouseLeave += button_MouseLeave;

            btn_Reload.MouseEnter += button_MouseEnter;
            btn_Reload.MouseLeave += button_MouseLeave;

            btn_Update.MouseEnter += button_MouseEnter;
            btn_Update.MouseLeave += button_MouseLeave;

            Load_Combobox_KhachHang();
            Load_Combobox_NhanVien();
            Load_Combobox_SanPham();

            Load_DataGridView();


            if (dgv_HoaDonXuat.Columns.Count > 0)
            {
                // Đổi tên các cột để phù hợp với yêu cầu hiển thị
                dgv_HoaDonXuat.Columns["MAHDX"].HeaderText = "Mã Hóa Đơn Xuất";
                dgv_HoaDonXuat.Columns["MANV"].HeaderText = "Mã Nhân Viên";
                dgv_HoaDonXuat.Columns["TENNV"].HeaderText = "Nhân Viên";
                dgv_HoaDonXuat.Columns["MAKH"].HeaderText = "Mã Khách Hàng";
                dgv_HoaDonXuat.Columns["TENKH"].HeaderText = "Tên Khách Hàng";
                dgv_HoaDonXuat.Columns["NGAY"].HeaderText = "Ngày Xuất";
                dgv_HoaDonXuat.Columns["MASANPHAM"].HeaderText = "Mã Sản Phẩm";
                dgv_HoaDonXuat.Columns["TENSANPHAM"].HeaderText = "Tên Sản Phẩm";
                dgv_HoaDonXuat.Columns["SOLUONG"].HeaderText = "Số Lượng";
                dgv_HoaDonXuat.Columns["DONGIA"].HeaderText = "Đơn Giá";
                dgv_HoaDonXuat.Columns["TONGTIEN"].HeaderText = "Tổng Tiền";
            }
            // Tùy chỉnh DataGridView
            dgv_HoaDonXuat.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);
            dgv_HoaDonXuat.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv_HoaDonXuat.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_HoaDonXuat.EnableHeadersVisualStyles = false;

            dgv_HoaDonXuat.DefaultCellStyle.Font = new Font("Arial", 11);
            dgv_HoaDonXuat.DefaultCellStyle.BackColor = Color.White;
            dgv_HoaDonXuat.DefaultCellStyle.ForeColor = Color.Black;
            dgv_HoaDonXuat.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            dgv_HoaDonXuat.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgv_HoaDonXuat.GridColor = Color.DarkGray; // Đặt màu cho đường kẻ
            dgv_HoaDonXuat.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical; // Thêm đường kẻ dọc cho các cột

            foreach (DataGridViewColumn column in dgv_HoaDonXuat.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa dữ liệu
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
                column.DefaultCellStyle.Padding = new Padding(5); // Thêm khoảng cách bên trong các ô
            }

            dgv_HoaDonXuat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_HoaDonXuat.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow;
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
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_Combobox_KhachHang()
        {
            try
            {
                DataTable dtKH = db.getDataTable("NVKH_GetAllKhachHang", "KHACHHANG");

                // Gán dữ liệu cho ComboBox
                cbo_KH.DataSource = dtKH;
                cbo_KH.DisplayMember = "TENKH";
                cbo_KH.ValueMember = "MAKH";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Load_DataGridView()
        {
            try
            {
                // Lấy dữ liệu từ cơ sở dữ liệu và gán vào DataTable
                DataTable dt = db.getDataTable("NVKH_GetAllHoaDonXuat", "HOADONXUAT");

                // Gán dữ liệu cho DataGridView
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgv_HoaDonXuat.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu hóa đơn xuất để hiển thị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_HoaDonXuat.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hóa đơn nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ClearAll()
        {
            txt_MaHDX.Clear();
            cbo_NV.SelectedIndex = -1;
            cbo_KH.SelectedIndex = -1;
            dt_NgayXuat.ResetText();
            cbo_SP.SelectedIndex = -1;
            txt_SL.Clear();
            txt_DonGiaBan.Clear();
            txt_TongTien.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            UC_BanHang_Load(this, null);
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Search.Text) || txt_Search.Text == "Search.......")
            {
                Load_DataGridView();
            }
            else
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                new SqlParameter("@mahdx", txt_Search.Text.Trim())
                };
                try
                {
                    DataTable dt = db.getDataTable("NVKH_SearchHoaDonXuat", "HOADONXUAT", parameters);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dgv_HoaDonXuat.DataSource = dt; // Gán kết quả cho DataGridView

                    }
                    else
                    {
                        dgv_HoaDonXuat.DataSource = null; // Xóa dữ liệu nếu không tìm thấy
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_HoaDonXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv_HoaDonXuat.Rows[e.RowIndex];

                    txt_MaHDX.Text = row.Cells["MAHDX"].Value.ToString();

                    Load_Combobox_NhanVien();
                    Load_Combobox_KhachHang();
                    Load_Combobox_SanPham();

                    cbo_NV.SelectedValue = row.Cells["MANV"].Value.ToString();

                    cbo_KH.SelectedValue = row.Cells["MAKH"].Value.ToString();

                    cbo_SP.SelectedValue = row.Cells["MASANPHAM"].Value.ToString();

                    dt_NgayXuat.Value = Convert.ToDateTime(row.Cells["NGAY"].Value);
                    txt_SL.Text = row.Cells["SOLUONG"].Value.ToString();
                    txt_DonGiaBan.Text = row.Cells["DONGIA"].Value.ToString();

                    decimal donGia = Convert.ToDecimal(txt_DonGiaBan.Text);
                    int soLuong = Convert.ToInt32(txt_SL.Text);
                    txt_TongTien.Text = (donGia * soLuong).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_MaHDX_TextChanged(object sender, EventArgs e)
        {
            SqlParameter[] parameters = { new SqlParameter("@MAHDX", txt_MaHDX.Text) };
            int count = db.getCount("NVKH_CheckHoaDonXuatExistence", parameters);
            if (count == 0)
            {
                pic_AddHDX.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "yes.png");
            }
            else
            {
                pic_AddHDX.ImageLocation = System.IO.Path.Combine(System.IO.Path.Combine(System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, @"..\..\")), "Resources"), "no.png");
            }
        }

        private void cbo_SP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_SP.SelectedIndex != -1)
            {
                string maSP = cbo_SP.SelectedValue.ToString();  // Lấy mã sản phẩm từ ComboBox

                try
                {
                    if (cn.State != ConnectionState.Open)
                    {
                        db.openConnect();
                    }

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@MaSP", maSP)
                    };

                    object result = db.getCount("NVKH_LayDonGiaBanTheoSP", parameters);

                    if (result != null)
                    {
                        decimal giaBan = Convert.ToDecimal(result);  // Convert kết quả thành decimal
                        txt_DonGiaBan.Text = giaBan.ToString("N0");  // Hiển thị giá nhập vào TextBox, định dạng số
                    }
                    else
                    {
                        txt_DonGiaBan.Clear();  // Nếu không tìm thấy giá, xóa TextBox
                    }

                    db.closeConnect();  // Đóng kết nối
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy giá nhập sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool CheckInventory(string maSP, int soLuong)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MASANPHAM", maSP)
            };

            int availableStock = db.getCount("NVKH_GetInventory", parameters);  // Sử dụng stored procedure để lấy số lượng tồn kho

            if (availableStock < soLuong)
            {
                MessageBox.Show("Số lượng bán vượt quá số lượng tồn kho của sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;  // Trả về false nếu không đủ hàng
            }

            return true;  // Trả về true nếu đủ hàng
        }
        private string GenerateNewInvoiceCode()
        {
            string newInvoiceCode = string.Empty;

            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT MAX(MAHDX) FROM HOADONXUAT", cn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        string lastInvoiceCode = result.ToString();
                        int lastInvoiceNumber = int.Parse(lastInvoiceCode.Substring(3));  // Lấy phần số (sau "HDX")
                        newInvoiceCode = "HDX" + (lastInvoiceNumber + 1).ToString("D3");  // Tăng số và định dạng lại (3 chữ số)
                    }
                    else
                    {
                        // Nếu chưa có hóa đơn nào, bắt đầu từ HDX001
                        newInvoiceCode = "HDX001";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã hóa đơn mới: " + ex.Message);
            }

            return newInvoiceCode;
        }


        private string GenerateNewCustomerCode()
        {
            string maKH;
            bool isDuplicate;

            do
            {
                // Mở kết nối nếu chưa mở
                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect();
                }

                // Lấy số khách hàng cuối cùng từ cơ sở dữ liệu
                using (SqlCommand cmd = new SqlCommand("SELECT MAX(MAKH) FROM KHACHHANG", cn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        string lastCode = result.ToString();
                        int lastNumber = int.Parse(lastCode.Substring(2)); // Lấy 3 số cuối
                        maKH = "KH" + (lastNumber + 1).ToString("D3");  // Tạo mã khách hàng mới
                    }
                    else
                    {
                        maKH = "KH001";  // Nếu chưa có khách hàng nào, bắt đầu từ KH001
                    }
                }

                // Kiểm tra xem mã khách hàng mới có bị trùng hay không
                using (SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM KHACHHANG WHERE MAKH = @MAKH", cn))
                {
                    cmdCheck.Parameters.AddWithValue("@MAKH", maKH);
                    int count = (int)cmdCheck.ExecuteScalar();
                    isDuplicate = count > 0;  // Nếu có ít nhất một khách hàng trùng mã, isDuplicate = true
                }

            } while (isDuplicate);  // Lặp lại cho đến khi không còn mã khách hàng trùng

            return maKH;  // Trả về mã khách hàng mới duy nhất
        }


        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            string maKH = "";

            if (rbKhachHangCu.Checked)
            {
                // Lấy mã khách hàng từ ComboBox
                maKH = cbo_KH.SelectedValue.ToString();
            }
            else if (rbKhachHangMoi.Checked)
            {
                // Kiểm tra thông tin nhập vào của khách hàng mới
                string tenKH = txtTenKH.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                string sdt = txtSDT.Text.Trim();

                if (string.IsNullOrEmpty(tenKH) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(sdt))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo mã khách hàng mới tự động
                maKH = GenerateNewCustomerCode();

                // Lưu thông tin khách hàng mới vào cơ sở dữ liệu
                using (SqlCommand cmd = new SqlCommand("NVKH_AddNewCustomer", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MAKH", maKH);
                    cmd.Parameters.AddWithValue("@TENKH", tenKH);
                    cmd.Parameters.AddWithValue("@DIACHI", diaChi);
                    cmd.Parameters.AddWithValue("@SODIENTHOAI", sdt);

                    cmd.ExecuteNonQuery();
                }
            }

            string maHDX = GenerateNewInvoiceCode();  // Gọi phương thức tạo mã hóa đơn mới tự động
            if (string.IsNullOrWhiteSpace(maHDX))
            {
                MessageBox.Show("Không thể tạo mã hóa đơn mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbo_NV.SelectedIndex == -1 || cbo_KH.SelectedIndex == -1 || cbo_SP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên, khách hàng và sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maNV = cbo_NV.SelectedValue.ToString();
            
            DateTime ngayXuat = dt_NgayXuat.Value;
            string maSP = cbo_SP.SelectedValue.ToString();

            if (ngayXuat.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày xuất không thể là ngày tương lai.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int soLuong;
            decimal donGia;

            if (!int.TryParse(txt_SL.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ (lớn hơn 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txt_DonGiaBan.Text, out donGia) || donGia <= 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá hợp lệ (lớn hơn 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CheckInventory(maSP, soLuong))  // Nếu tồn kho không đủ
            {
                return;  // Dừng lại, không thực hiện tiếp
            }

            decimal tongTien = soLuong * donGia;
            txt_TongTien.Text = tongTien.ToString();

            try
            {
                // Mở kết nối
                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect();
                }

                using (SqlCommand cmdHDX = new SqlCommand("NVKH_AddHoaDonXuat", cn))
                {
                    cmdHDX.CommandType = CommandType.StoredProcedure;
                    cmdHDX.Parameters.AddWithValue("@MAHDX", maHDX);  // Sử dụng mã hóa đơn mới tạo
                    cmdHDX.Parameters.AddWithValue("@MAKH", maKH);
                    cmdHDX.Parameters.AddWithValue("@MANV", maNV);
                    cmdHDX.Parameters.AddWithValue("@TONGTIEN", tongTien);
                    cmdHDX.Parameters.AddWithValue("@NGAY", ngayXuat);

                    cmdHDX.ExecuteNonQuery();
                }

                // Thêm chi tiết hóa đơn xuất
                using (SqlCommand cmdCTHDX = new SqlCommand("NVKH_AddChiTietHoaDonXuat", cn))
                {
                    cmdCTHDX.CommandType = CommandType.StoredProcedure;
                    cmdCTHDX.Parameters.AddWithValue("@MACTHDX", "CT" + maHDX);
                    cmdCTHDX.Parameters.AddWithValue("@MAHDX", maHDX);
                    cmdCTHDX.Parameters.AddWithValue("@MASANPHAM", maSP);
                    cmdCTHDX.Parameters.AddWithValue("@SOLUONG", soLuong);
                    cmdCTHDX.Parameters.AddWithValue("@DONGIA", donGia);

                    cmdCTHDX.ExecuteNonQuery();
                }

                // Cập nhật tồn kho sau khi xuất hàng
                using (SqlCommand cmdUpdateInventory = new SqlCommand("NVKH_UpdateInventoryAfterSale", cn))
                {
                    cmdUpdateInventory.CommandType = CommandType.StoredProcedure;
                    cmdUpdateInventory.Parameters.AddWithValue("@MAHDX", maHDX);  // maHDX là mã hóa đơn xuất cần truyền vào

                    cmdUpdateInventory.ExecuteNonQuery();
                }

                db.closeConnect();

                ClearAll();

                MessageBox.Show("Bán hàng và thêm hóa đơn xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Load_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm hóa đơn xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    db.closeConnect();
                }
            }
        }

        private void rbKhachHangCu_CheckedChanged(object sender, EventArgs e)
        {
            cbo_KH.Visible = true; 
            txtTenKH.Visible = false;
            lblTenKH.Visible = false;
            lblDiaChi.Visible = false;
            lblSDT.Visible = false;
            txtDiaChi.Visible = false;
            txtSDT.Visible = false;

        }

        private void rbKhachHangMoi_CheckedChanged(object sender, EventArgs e)
        {
            cbo_KH.Visible = false;
            txtTenKH.Visible = true;
            txtDiaChi.Visible = true;
            txtSDT.Visible = true;
            lblTenKH.Visible = true;
            lblDiaChi.Visible = true;
            lblSDT.Visible = true;
        }

        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            string query = @"SELECT 
    p.MAHDX,
    p.MAKH,
    kh.TENKH,
    p.MANV,
    nv.TENNV,
    p.TONGTIEN,
    p.NGAY,
    c.MACTHDX,
    c.MASANPHAM,
    s.TENSANPHAM,
    c.SOLUONG,
    c.DONGIA
FROM 
    HOADONXUAT p
JOIN 
    CHITIETHOADONXUAT c ON p.MAHDX = c.MAHDX
JOIN 
    SANPHAM s ON c.MASANPHAM = s.MASANPHAM
JOIN 
    KHACHHANG kh ON p.MAKH = kh.MAKH
JOIN 
    NHANVIEN nv ON p.MANV = nv.MANV
WHERE
    p.MAHDX = @MaHDX;

";


            // Thêm tham số vào câu truy vấn
            SqlCommand cmd = new SqlCommand(query, db.conn);
            cmd.Parameters.AddWithValue("@MaHDX", txt_MaHDX.Text);  // Thêm giá trị tham số vào câu truy vấn

            // Thực thi câu truy vấn và lấy dữ liệu
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            rptHoaDonXuat rp = new rptHoaDonXuat();
            rp.SetDataSource(dt);
            frmHoaDonXuat hdx = new frmHoaDonXuat();
            hdx.Show();
            hdx.crvHoaDonXuat.ReportSource = rp;
            hdx.crvHoaDonXuat.Refresh();
            
        }
    }
}
