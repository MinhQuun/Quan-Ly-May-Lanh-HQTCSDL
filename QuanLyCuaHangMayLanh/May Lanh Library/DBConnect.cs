using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace May_Lanh_Library
{
    public class DBConnect
    {
        private SqlConnection _conn;
        private string _strConnect, _strServerName, _strDBName, _strUserID, _strPassword;
        private DataSet _dset;

        public DataSet Dset
        {
            get { return _dset; }
            set { _dset = value; }
        }
        public SqlConnection conn
        {
            get { return _conn; }
            set { _conn = value; }
        }
        public string strConnect
        {
            get { return _strConnect; }
            set { _strConnect = value; }
        }
        public string strServerName
        {
            get { return _strServerName; }
            set { _strServerName = value; }
        }
        public string strDBName
        {
            get { return _strDBName; }
            set { _strDBName = value; }
        }
        public string strUserID
        {
            get { return _strUserID; }
            set { _strUserID = value; }
        }
        public string strPassword
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }

        public DBConnect()
        {
            //strServerName = @".";
            strServerName = @"MSI\TRNDON";//Tên máy server của mình (tên máy của SV)
            //strDBName = "QL_SINHVIEN";
            strDBName = "QL_MAYLANH_HQTCSDL";

            //Dùng với quyền của của Windows
            strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName +
            ";Integrated Security=true";

            //Dùng với quyền của SQL Server
            //strUserID = "";
            //strPassword = "";
            //strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName +
            //";User ID=" + strUserID + ";Password=" + strPassword;

            conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
            Dset = new DataSet(strConnect);       //Khởi tạo đối tượng DâtSet là CSDL ảo trên Client
        }

        public DBConnect(string pServerName, string pDBName)
        {
            //Dùng với quyền của của Windows
            strServerName = pServerName;
            strDBName = pDBName;
            strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName +
            ";Integrated Security=true";

            conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
            Dset = new DataSet(strConnect);      //Khởi tạo đối tượng DâtSet là CSDL ảo trên Client
        }

        public DBConnect(string pServerName, string pDBName, string pUserID, string pPassword)
        {
            //Dùng với quyền của SQL Server
            strServerName = pServerName;
            strDBName = pDBName;
            strUserID = pUserID;
            strPassword = pPassword;
            strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName +
            ";User ID=" + strUserID + ";Password=" + strPassword;

            conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
            Dset = new DataSet(strConnect);      //Khởi tạo đối tượng DâtSet là CSDL ảo trên Client
        }

        public void openConnect()
        {
            //Mở kết nối
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public void closeConnect()
        {
            //Đóng kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public void disposeConnect()
        {
            //Hủy đối tượng kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Dispose();  //Giải phóng vùng nhớ đã cấp phát cho conn
        }

        public void updateToDataBase(string strSQL)
        {
            //Cho phép cập nhật CSDL với các thao tác gồm: Thêm, Xóa, Sửa
            openConnect(); //Mở kết nối
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSQL; //Câu truy vấn đưa vào
            cmd.ExecuteNonQuery(); //Thực thi
            closeConnect(); //Đóng kết nối
        }

        public int getCount(string strSQL, SqlParameter[] parameters = null)
        {
            openConnect(); // Mở kết nối
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            cmd.CommandType = CommandType.StoredProcedure; // Đặt kiểu lệnh là Stored Procedure
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            object result = cmd.ExecuteScalar();
            int count = (result == DBNull.Value) ? 0 : Convert.ToInt32(result);

            closeConnect(); // Đóng kết nối
            return count;
        }


        public bool checkExist(string tableName, string columnName, string value)
        {
            string query = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = @value", tableName, columnName);

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@value", value);

            openConnect();
            int count = (int)cmd.ExecuteScalar();
            closeConnect();

            return count > 0;
        }


        public SqlDataAdapter getDataAdapter(string strSQL, string tableName)
        {
            openConnect();
            SqlDataAdapter ada = new SqlDataAdapter(strSQL, conn);
            ada.Fill(Dset, tableName);
            closeConnect();
            return ada;
        }
        public DataTable getDataTable(string query, string tableName, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                openConnect();  // Mở kết nối

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure; // Đặt kiểu lệnh là Stored Procedure
                // Kiểm tra và thêm tham số
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataTable);  // Đổ dữ liệu vào DataTable
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi trong quá trình lấy dữ liệu: " + ex.Message);
            }
            finally
            {
                closeConnect();  // Đóng kết nối
            }

            return dataTable;
        }
        public DataTable getDataTable(string strSQL, string tableName, params string[] keyNames)
        {
            openConnect();
            SqlDataAdapter ada = new SqlDataAdapter(strSQL, conn);
            ada.Fill(Dset, tableName);
            //Tao khoa chinh cho DataTable
            int n = keyNames.Length;
            DataColumn[] primaryKey = new DataColumn[n];
            for (int i = 0; i < n; i++)
            {
                primaryKey[i] = Dset.Tables[tableName].Columns[keyNames[i]];
            }
            Dset.Tables[tableName].PrimaryKey = primaryKey;
            closeConnect();
            return Dset.Tables[tableName];
        }

    }
}
