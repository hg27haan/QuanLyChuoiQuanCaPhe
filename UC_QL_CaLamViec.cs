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
    public partial class UC_QL_CaLamViec : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public UC_QL_CaLamViec()
        {
            InitializeComponent();
        }

        private void doiTenHeaderCLV()
        {
            gvCaLamViec.Columns[0].HeaderText = "Mã Ca Làm Việc";
            gvCaLamViec.Columns[1].HeaderText = "Giờ Bắt Đầu";
            gvCaLamViec.Columns[2].HeaderText = "Giờ Kết Thúc";
        }

        private void loadThongTinCLV()
        {
            try
            {
                conn.Open();

                string query = "select *from V_CaLamViec";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvCaLamViec.DataSource = dataTable;

                doiTenHeaderCLV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnXemCLV_Click(object sender, EventArgs e)
        {
            loadThongTinCLV();
        }
    }
}
