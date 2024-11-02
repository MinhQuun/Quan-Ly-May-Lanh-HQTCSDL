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

namespace QuanLyCuaHangMayLanh.NhanVienKhoHang
{
    public partial class NVKH_DashBoard : UserControl
    {
        DBConnect db = new DBConnect();
        public NVKH_DashBoard()
        {
            InitializeComponent();
        }

        private void NVKH_DashBoard_Load(object sender, EventArgs e)
        {
            // Đếm số lượng Nhân viên
            string queryEmployee = "SELECT COUNT(*) FROM NGUOIDUNG WHERE MAQUYEN ='Q3'";
            int countEmployee = db.getCount(queryEmployee);
            SetLabel(countEmployee, lbl_Employee);
        }
        private void SetLabel(int count, Label lbl)
        {
            lbl.Text = count.ToString();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            NVKH_DashBoard_Load(this, null);
        }
    }
}
