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

namespace QuanLyCuaHangMayLanh.NhanVienNhapHang
{
    public partial class NVNH_DashBoard : UserControl
    {
        DBConnect db = new DBConnect();
        public NVNH_DashBoard()
        {
            InitializeComponent();
        }

        private void NVNH_DashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                // Đếm số lượng Nhân viên
                int countEmployee = db.getCount("NVSP_CountEmployees");
                SetLabel(countEmployee, lbl_Employee);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bảng điều khiển: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetLabel(int count, Label lbl)
        {
            lbl.Text = count.ToString();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            NVNH_DashBoard_Load(this, null);
        }

    }
}
