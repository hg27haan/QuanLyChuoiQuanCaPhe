using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_QL_NhanVien : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataPhanQuyen = null;
        private string dataMaCS = null;

        public UC_QL_NhanVien(string phanQuyen,string dataMaCS)
        {
            InitializeComponent();
            this.dataPhanQuyen = phanQuyen;
            this.dataMaCS = dataMaCS;
        }

        private void loadLenDataGrid(string dataPhanQuyen)
        {
            try
            {
                conn.Open();

                string query = null;
                if(dataPhanQuyen == "ql")
                {
                    query = string.Format("select *from V_NhanVien where maCS = N'{0}'", dataMaCS);
                }
                if(dataPhanQuyen == "ad")
                {
                    query = "select *from V_NhanVien";
                }    
                
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvThongTinNV.DataSource = dataTable;

                doiTenHeader();
            }   
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            { 
                conn.Close(); 
            }
        }

        private void doiTenHeader()
        {
            gvThongTinNV.Columns[0].HeaderText = "Mã Nhân Viên";
            gvThongTinNV.Columns[1].HeaderText = "Họ Và Tên";
            gvThongTinNV.Columns[2].HeaderText = "Giới Tính";
            gvThongTinNV.Columns[3].HeaderText = "Số Điện Thoại";
            gvThongTinNV.Columns[4].HeaderText = "CCCD";
            gvThongTinNV.Columns[5].HeaderText = "Mã Người Quản Lý";
            gvThongTinNV.Columns[6].HeaderText = "Mã Cơ Sở";
        }

        private void UC_QL_NhanVien_Load(object sender, EventArgs e)
        {
            loadLenDataGrid(dataPhanQuyen);
            txtMaCoSo.Text = dataMaCS;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
        }
    }
}
