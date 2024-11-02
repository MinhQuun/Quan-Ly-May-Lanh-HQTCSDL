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

namespace QuanLyCuaHangMayLanh.NhanVienKhoHang
{
    public partial class NVKH_HoaDonXuat : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public NVKH_HoaDonXuat()
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
        private void NVKH_HoaDonXuat_Load(object sender, EventArgs e)
        {
            // Thiết lập placeholder mặc định cho TextBox
            txt_Search.Text = "Search.......";
            txt_Search.ForeColor = Color.Gray;
            txt_Search.Font = new Font(txt_Search.Font.FontFamily, 14, FontStyle.Italic);

            // Gắn sự kiện Enter và Leave cho TextBox
            txt_Search.Enter += txt_Search_Enter;
            txt_Search.Leave += txt_Search_Leave;

            btn_AddHDX.MouseEnter += button_MouseEnter;
            btn_AddHDX.MouseLeave += button_MouseLeave;

            btn_UpdateHDX.MouseEnter += button_MouseEnter;
            btn_UpdateHDX.MouseLeave += button_MouseLeave;

            btn_Reload.MouseEnter += button_MouseEnter;
            btn_Reload.MouseLeave += button_MouseLeave;

            btn_Delete.MouseEnter += button_MouseEnter;
            btn_Delete.MouseLeave += button_MouseLeave;

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
                dgv_HoaDonXuat.Columns["MAKH"].HeaderText = "Mã Nhà Cung Cấp";
                dgv_HoaDonXuat.Columns["TENKH"].HeaderText = "Nhà Cung Cấp";
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
        public void Load_Combobox_NhanVien()
        {
            string sqlNV = "SELECT * FROM NHANVIEN";
            DataTable dtNV = new DataTable();
            SqlDataAdapter daNV = new SqlDataAdapter(sqlNV, cn);
            daNV.Fill(dtNV);

            // Gán dữ liệu cho ComboBox
            cbo_NV.DataSource = dtNV;
            cbo_NV.DisplayMember = "TENNV";      // Tên nhân viên để hiển thị
            cbo_NV.ValueMember = "MANV";         // Giá trị là mã nhân viên
        }

        public void Load_Combobox_SanPham()
        {
            string sqlSP = "SELECT * FROM SANPHAM";
            DataTable dtSP = new DataTable();
            SqlDataAdapter daSP = new SqlDataAdapter(sqlSP, cn);
            daSP.Fill(dtSP);

            // Gán dữ liệu cho ComboBox
            cbo_SP.DataSource = dtSP;
            cbo_SP.DisplayMember = "TENSANPHAM"; // Tên sản phẩm để hiển thị
            cbo_SP.ValueMember = "MASANPHAM";    // Giá trị là mã sản phẩm
        }
        public void Load_Combobox_KhachHang()
        {
            string sqlKH = "SELECT * FROM KHACHHANG";
            DataTable dtKH = new DataTable();
            SqlDataAdapter daKH = new SqlDataAdapter(sqlKH, cn);
            daKH.Fill(dtKH);

            // Gán dữ liệu cho ComboBox
            cbo_KH.DataSource = dtKH;
            cbo_KH.DisplayMember = "TENKH";
            cbo_KH.ValueMember = "MAKH";
        }
        private void Load_DataGridView()
        {
            try
            {
                string query = @"
                SELECT HDX.MAHDX, NV.MANV, NV.TENNV, KH.MAKH, KH.TENKH, HDX.NGAY, HDX.TONGTIEN, 
                       CTHDX.MASANPHAM, SP.TENSANPHAM, CTHDX.SOLUONG, CTHDX.DONGIA
                FROM HOADONXUAT HDX
                INNER JOIN NHANVIEN NV ON HDX.MANV = NV.MANV
                INNER JOIN KHACHHANG KH ON HDX.MAKH = KH.MAKH
                INNER JOIN CHITIETHOADONXUAT CTHDX ON HDX.MAHDX = CTHDX.MAHDX
                INNER JOIN SANPHAM SP ON CTHDX.MASANPHAM = SP.MASANPHAM";

                // Lấy dữ liệu từ cơ sở dữ liệu và gán vào DataTable
                DataTable dt = db.getDataTable(query, "HOADONXUAT");

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

        private void btn_AddHDX_Click(object sender, EventArgs e)
        {
            string maHDX = txt_MaHDX.Text;
            if (string.IsNullOrWhiteSpace(maHDX))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbo_NV.SelectedIndex == -1 || cbo_KH.SelectedIndex == -1 || cbo_SP.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên, khách hàng và sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maNV = cbo_NV.SelectedValue.ToString();
            string maKH = cbo_KH.SelectedValue.ToString();
            DateTime ngayXuat = dt_NgayXuat.Value;
            string maSP = cbo_SP.SelectedValue.ToString();

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

                // Thêm hóa đơn xuất
                string queryHDN = "INSERT INTO HOADONXUAT (MAHDX, MAKH, MANV, TONGTIEN, NGAY) VALUES (@MAHDX, @MAKH, @MANV, @TONGTIEN, @NGAY)";
                using (SqlCommand cmdHDN = new SqlCommand(queryHDN, cn))
                {
                    cmdHDN.Parameters.AddWithValue("@MAHDX", maHDX);
                    cmdHDN.Parameters.AddWithValue("@MAKH", maKH);
                    cmdHDN.Parameters.AddWithValue("@MANV", maNV);
                    cmdHDN.Parameters.AddWithValue("@TONGTIEN", tongTien);
                    cmdHDN.Parameters.AddWithValue("@NGAY", ngayXuat);

                    cmdHDN.ExecuteNonQuery();
                }

                // Thêm chi tiết hóa đơn xuất
                string queryCTHDN = "INSERT INTO CHITIETHOADONXUAT (MACTHDX, MAHDX, MASANPHAM, SOLUONG, DONGIA) VALUES (@MACTHDX, @MAHDX, @MASANPHAM, @SOLUONG, @DONGIA)";
                using (SqlCommand cmdCTHDN = new SqlCommand(queryCTHDN, cn))
                {
                    cmdCTHDN.Parameters.AddWithValue("@MACTHDX", "CT" + maHDX);
                    cmdCTHDN.Parameters.AddWithValue("@MAHDX", maHDX);
                    cmdCTHDN.Parameters.AddWithValue("@MASANPHAM", maSP);
                    cmdCTHDN.Parameters.AddWithValue("@SOLUONG", soLuong);
                    cmdCTHDN.Parameters.AddWithValue("@DONGIA", donGia);

                    cmdCTHDN.ExecuteNonQuery();
                }

                db.closeConnect();

                // Clear tất cả các trường sau khi thêm thành công
                ClearAll();

                MessageBox.Show("Thêm hóa đơn xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu DataGridView
                Load_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi thêm hóa đơn xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            NVKH_HoaDonXuat_Load(this, null);
        }
        string MaHDX;

        private void dgv_HoaDonXuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Kiểm tra chỉ số hàng hợp lệ
                {
                    MaHDX = dgv_HoaDonXuat.Rows[e.RowIndex].Cells["MAHDX"].Value.ToString(); // Sử dụng tên cột "MAHDX" để lấy giá trị
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn mã hóa đơn xuất: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaHDX))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn xuất để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn xuất này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (cn.State != ConnectionState.Open)
                    {
                        db.openConnect();
                    }

                    // Xóa các chi tiết hóa đơn xuất trước
                    string queryDeleteCTHDX = "DELETE FROM CHITIETHOADONXUAT WHERE MAHDX = @MAHDX";
                    SqlCommand cmdDeleteCTHDX = new SqlCommand(queryDeleteCTHDX, cn);
                    cmdDeleteCTHDX.Parameters.AddWithValue("@MAHDX", MaHDX);
                    cmdDeleteCTHDX.ExecuteNonQuery();

                    // Xóa hóa đơn xuất
                    string queryDeleteHDX = "DELETE FROM HOADONXUAT WHERE MAHDX = @MAHDX";
                    SqlCommand cmdDeleteHDX = new SqlCommand(queryDeleteHDX, cn);
                    cmdDeleteHDX.Parameters.AddWithValue("@MAHDX", MaHDX);
                    cmdDeleteHDX.ExecuteNonQuery();

                    db.closeConnect();

                    MessageBox.Show("Xóa hóa đơn xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu DataGridView
                    Load_DataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            // Câu truy vấn SQL với cú pháp đúng
            string query = @"
                        SELECT HDX.MAHDX, NV.MANV, NV.TENNV, KH.MAKH, KH.TENKH, HDX.NGAY, HDX.TONGTIEN, 
                       CTHDX.MASANPHAM, SP.TENSANPHAM, CTHDX.SOLUONG, CTHDX.DONGIA
                        FROM HOADONXUAT HDX
                        INNER JOIN NHANVIEN NV ON HDX.MANV = NV.MANV
                        INNER JOIN KHACHHANG KH ON HDX.MAKH = KH.MAKH
                        INNER JOIN CHITIETHOADONXUAT CTHDX ON HDX.MAHDX = CTHDX.MAHDX
                        INNER JOIN SANPHAM SP ON CTHDX.MASANPHAM = SP.MASANPHAM
                        WHERE HDX.MAHDX LIKE @mahdx";

            // Tạo parameter với giá trị tìm kiếm từ txt_Search
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@mahdx", "%" + txt_Search.Text.Trim() + "%")
            };

            try
            {
                // Sử dụng DBConnect để lấy dữ liệu và cập nhật DataGridView
                DataTable dt = db.getDataTable(query, "HOADONXUAT", parameters);

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

        private void dgv_HoaDonXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgv_HoaDonXuat.Rows[e.RowIndex];

                    txt_MaHDX.Text = row.Cells["MAHDX"].Value.ToString();

                    // Đảm bảo dữ liệu đã có trong ComboBox trước khi gán giá trị
                    Load_Combobox_NhanVien();
                    Load_Combobox_KhachHang();
                    Load_Combobox_SanPham();

                    // Hiển thị mã nhân viên trong ComboBox
                    cbo_NV.SelectedValue = row.Cells["MANV"].Value.ToString();

                    // Hiển thị mã nhà cung cấp trong ComboBox
                    cbo_KH.SelectedValue = row.Cells["MAKH"].Value.ToString();

                    // Hiển thị mã sản phẩm trong ComboBox
                    cbo_SP.SelectedValue = row.Cells["MASANPHAM"].Value.ToString();

                    dt_NgayXuat.Value = Convert.ToDateTime(row.Cells["NGAY"].Value);
                    txt_SL.Text = row.Cells["SOLUONG"].Value.ToString();
                    txt_DonGiaBan.Text = row.Cells["DONGIA"].Value.ToString();

                    // Tính lại tổng tiền
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

        private void btn_UpdateHDX_Click(object sender, EventArgs e)
        {
            string maHDX = txt_MaHDX.Text;
            string maNV = cbo_NV.SelectedValue.ToString();
            string maKH = cbo_KH.SelectedValue.ToString();
            DateTime ngayXuat = dt_NgayXuat.Value;
            string maSP = cbo_SP.SelectedValue.ToString();
            int soLuong;
            decimal donGia;
            decimal tongTien;

            if (!int.TryParse(txt_SL.Text, out soLuong) || !decimal.TryParse(txt_DonGiaBan.Text, out donGia))
            {
                MessageBox.Show("Vui lòng nhập đúng giá trị cho Số lượng và Đơn giá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tính tổng tiền
            tongTien = soLuong * donGia;
            txt_TongTien.Text = tongTien.ToString();

            try
            {
                string query = "UPDATE HOADONXUAT SET MANV = @MANV, MAKH = @MAKH, NGAY = @NGAY, TONGTIEN = @TONGTIEN WHERE MAHDX = @MAHDX";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@MAHDX", maHDX);
                cmd.Parameters.AddWithValue("@MANV", maNV);
                cmd.Parameters.AddWithValue("@MAKH", maKH);
                cmd.Parameters.AddWithValue("@NGAYNHAP", ngayXuat);
                cmd.Parameters.AddWithValue("@TONGTIEN", tongTien);

                if (cn.State != ConnectionState.Open)
                {
                    db.openConnect();
                }

                cmd.ExecuteNonQuery();

                // Cập nhật chi tiết hóa đơn xuất
                string queryCTHDN = "UPDATE CHITIETHOADONXUAT SET MASANPHAM = @MASANPHAM, SOLUONG = @SOLUONG, DONGIA = @DONGIA WHERE MAHDX = @MAHDX";
                SqlCommand cmdCTHDN = new SqlCommand(queryCTHDN, cn);
                cmdCTHDN.Parameters.AddWithValue("@MAHDX", maHDX);
                cmdCTHDN.Parameters.AddWithValue("@MASANPHAM", maSP);
                cmdCTHDN.Parameters.AddWithValue("@SOLUONG", soLuong);
                cmdCTHDN.Parameters.AddWithValue("@DONGIA", donGia);

                cmdCTHDN.ExecuteNonQuery();

                db.closeConnect();

                ClearAll();

                MessageBox.Show("Cập nhật hóa đơn xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu DataGridView
                Load_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_MaHDX_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT COUNT(*) FROM HOADONXUAT WHERE MAHDX = '" + txt_MaHDX.Text + "'";
            int count = db.getCount(query);
            if (count == 0)
            {
                pic_AddHDX.ImageLocation = @"E:\MinhQuun\HUIT - 2022\Nam 3\HK5\Cong Nghe Dot Net\Project\Icon\yes.png";
            }
            else
            {
                pic_AddHDX.ImageLocation = @"E:\MinhQuun\HUIT - 2022\Nam 3\HK5\Cong Nghe Dot Net\Project\Icon\no.png";
            }
        }



    }
}
