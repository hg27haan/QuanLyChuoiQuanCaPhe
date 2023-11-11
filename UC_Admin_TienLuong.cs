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
    public partial class UC_Admin_TienLuong : UserControl
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataPhanQuyen = null;
        private string dataMaCS = null;

        public UC_Admin_TienLuong(string dataPhanQuyen, string dataMaCS)
        {
            InitializeComponent();
            this.dataPhanQuyen = dataPhanQuyen;
            this.dataMaCS = dataMaCS;
        }

        private void doiTenHeaderMucLuong()
        {
            gvMucLuong.Columns[0].HeaderText = "Mã Mức Lương";
            gvMucLuong.Columns[1].HeaderText = "Số Tiền";
        }

        private void loadMucLuong()
        {
            gvMucLuong.DataSource = null;
            try
            {
                conn.Open();

                string query = string.Format("select *from V_MucLuong");

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvMucLuong.DataSource = dt;

                doiTenHeaderMucLuong();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void UC_Admin_TienLuong_Load(object sender, EventArgs e)
        {
            loadMucLuong();
        }
    }
}
