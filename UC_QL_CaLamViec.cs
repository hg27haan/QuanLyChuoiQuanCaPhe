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

        private string dataMaCS = null;

        public UC_QL_CaLamViec(string dataMaCS)
        {
            InitializeComponent();
            this.dataMaCS = dataMaCS;
        }

        private void doiTenHeaderCLV()
        {
            gvCaLamViec.Columns[0].HeaderText = "Mã Cơ Sở";
            gvCaLamViec.Columns[1].HeaderText = "Ngày Làm";
            gvCaLamViec.Columns[2].HeaderText = "Giờ Bắt Đầu";
            gvCaLamViec.Columns[3].HeaderText = "Giờ Kết Thúc";
            gvCaLamViec.Columns[4].HeaderText = "Mã Nhân Viên";
            gvCaLamViec.Columns[5].HeaderText = "Họ Và Tên";
            gvCaLamViec.Columns[6].HeaderText = "Số Điện Thoại";
        }

        private void loadThongTinCLV()
        {
            try
            {
                conn.Open();

                string query = string.Format("select *from V_CaLamViec where ngayLam = N'{0}' and maCS = N'{1}'",
                    dtpNgayLam.Value.ToString("dd/MM/yyyy"),dataMaCS);

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

        private void UC_QL_CaLamViec_Load(object sender, EventArgs e)
        {
            loadThongTinCLV();
        }

        private void btnXemCLVTheoNgay_Click(object sender, EventArgs e)
        {
            loadThongTinCLV();
        }
    }
}
