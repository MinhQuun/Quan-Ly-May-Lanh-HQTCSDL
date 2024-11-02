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
    public partial class US_AddSupplier : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public US_AddSupplier()
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

        private void US_AddSupplier_Load(object sender, EventArgs e)
        {
            btn_AddSupplier.MouseEnter += button_MouseEnter;
            btn_AddSupplier.MouseLeave += button_MouseLeave;

            btn_Reload.MouseEnter += button_MouseEnter;
            btn_Reload.MouseLeave += button_MouseLeave;
        }

        private void btn_AddSupplier_Click(object sender, EventArgs e)
        {
            string ma = txt_MaNCC.Text;
            string ten = txt_TenNCC.Text;
            string dc = txt_DiaChi.Text;

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


        private void btn_Reload_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            txt_MaNCC.Clear();
            txt_TenNCC.Clear();
            txt_DiaChi.Clear();

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
                    pic_AddSupplier.ImageLocation = @"E:\MinhQuun\HUIT - 2022\Nam 3\HK5\He Quan Tri Co So Du Lieu\Project\Icon\yes.png";
                }
                else
                {
                    pic_AddSupplier.ImageLocation = @"E:\MinhQuun\HUIT - 2022\Nam 3\HK5\He Quan Tri Co So Du Lieu\Project\Icon\no.png";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra mã nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
