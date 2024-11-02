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
    public partial class US_UpdateProduct : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public US_UpdateProduct()
        {
            cn = db.conn;
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MaSP.Text))
            {
                try
                {
                    string query = "NVSP_SearchProductByID";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MASANPHAM", txt_MaSP.Text)
                    };

                    // Lấy dữ liệu từ database
                    DataTable dt = db.getDataTable(query, "SANPHAM", parameters);

                    // Kiểm tra nếu có dữ liệu và gán giá trị lên các TextBox
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        txt_TenSP.Text = dt.Rows[0]["TENSANPHAM"].ToString();
                        txt_SL.Text = dt.Rows[0]["SOLUONG"].ToString();
                        txt_DonGiaNhap.Text = dt.Rows[0]["DONGIANHAP"].ToString();
                        txt_DonGiaBan.Text = dt.Rows[0]["DONGIABAN"].ToString();
                        txt_MaNCC.Text = dt.Rows[0]["MANCC"].ToString(); // Gán giá trị cho combobox Mã Nhà Cung Cấp
                    }
                    else
                    {
                        MessageBox.Show("Không có mã sản phẩm: " + txt_MaSP.Text + " hiện hữu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ClearAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ClearAll()
        {
            txt_MaSP.Clear();
            txt_TenSP.Clear();
            txt_SL.Clear();
            txt_DonGiaNhap.Clear();
            txt_DonGiaBan.Clear();
            txt_MaNCC.Clear();
        }

        private void btn_UpdateProduct_Click(object sender, EventArgs e)
        {
            string maSP = txt_MaSP.Text;
            string tenSP = txt_TenSP.Text;
            int soLuong;
            decimal donGiaNhap, donGiaBan;
            string maNCC = txt_MaNCC.Text;

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
                cmdUpdate.Parameters.AddWithValue("@SOLUONG", soLuong);
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
