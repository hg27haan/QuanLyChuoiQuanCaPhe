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
    public partial class UC_QL_DoanhThu_Ngay : UserControl
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataMaCS = null;

        public UC_QL_DoanhThu_Ngay(string dataMaCS)
        {
            InitializeComponent();
            this.dataMaCS = dataMaCS;
        }

        private void doiTenHeader()
        {
            gvDoanhThu_Ngay.Columns[0].HeaderText = "Mã Hóa Đơn";
            gvDoanhThu_Ngay.Columns[1].HeaderText = "Mã Cơ Sở";
            gvDoanhThu_Ngay.Columns[2].HeaderText = "Tổng Tiền";
            gvDoanhThu_Ngay.Columns[3].HeaderText = "Nhân Viên Tạo Hóa Đơn";
            gvDoanhThu_Ngay.Columns[4].HeaderText = "Khách Hàng";
        }    

        private void UC_QL_DoanhThu_Ngay_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sqlQuery = string.Format("SELECT * FROM V_HoaDonTrongNgay WHERE maCS = N'{0}'", dataMaCS);
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvDoanhThu_Ngay.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            doiTenHeader();
        }
    }
}
