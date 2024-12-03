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
    public partial class US_UpdateSupplier : UserControl
    {
        SqlConnection cn;
        DBConnect db = new DBConnect();
        public US_UpdateSupplier()
        {
            cn = db.conn;
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MaNCC.Text))
            {
                try
                {
                    // Tạo câu truy vấn để tìm nhà cung cấp dựa vào mã nhà cung cấp
                    string query = "NVSP_SearchSupplierByID";
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@MANCC", txt_MaNCC.Text)
                    };

                    // Lấy dữ liệu từ database
                    DataTable dt = db.getDataTable(query, "NHACUNGCAP", parameters);

                    // Kiểm tra nếu có dữ liệu và gán giá trị lên các TextBox
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        txt_TenNCC.Text = dt.Rows[0]["TENNCC"].ToString();
                        txt_DiaChi.Text = dt.Rows[0]["DIACHI"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có mã nhà cung cấp: " + txt_MaNCC.Text + " hiện hữu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        
    }
}
