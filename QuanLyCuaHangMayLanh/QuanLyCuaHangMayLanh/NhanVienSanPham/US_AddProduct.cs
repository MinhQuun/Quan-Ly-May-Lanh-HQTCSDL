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

namespace QuanLyCuaHangMayLanh.User
{
    public partial class US_AddProduct : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public US_AddProduct()
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

        private void US_AddProduct_Load(object sender, EventArgs e)
        {
            btn_AddProduct.MouseEnter += button_MouseEnter;
            btn_AddProduct.MouseLeave += button_MouseLeave;

            btn_Reload.MouseEnter += button_MouseEnter;
            btn_Reload.MouseLeave += button_MouseLeave;

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
            int soLuong;
            decimal donGiaNhap, donGiaBan;

            // Kiểm tra giá trị hợp lệ của Số Lượng
            if (!int.TryParse(txt_SL.Text.Trim(), out soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên không âm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                    new SqlParameter("@SOLUONG", soLuong),
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


        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            txt_MaSP.Clear();
            txt_TenSP.Clear();
            txt_SL.Clear();
            txt_DonGiaNhap.Clear();
            txt_DonGiaBan.Clear();
            cbo_MaNCC.SelectedIndex = -1;
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
                    pic_AddProduct.ImageLocation = @"E:\MinhQuun\HUIT - 2022\Nam 3\HK5\He Quan Tri Co So Du Lieu\Project\Icon\yes.png";
                }
                else
                {
                    pic_AddProduct.ImageLocation = @"E:\MinhQuun\HUIT - 2022\Nam 3\HK5\He Quan Tri Co So Du Lieu\Project\Icon\no.png";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_Update_Click(object sender, EventArgs e)
        {

        }
    }
}
