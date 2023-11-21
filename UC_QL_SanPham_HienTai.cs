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
    public partial class UC_QL_SanPham_HienTai : UserControl
    {
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;

        public UC_QL_SanPham_HienTai(string dataUserName, string dataPassword)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
        }

        private void doiTenHeader()
        {
            gvThongTinSP.Columns[0].HeaderText = "Mã Sản Phẩm";
            gvThongTinSP.Columns[1].HeaderText = "Tên Sản Phẩm";
            gvThongTinSP.Columns[2].HeaderText = "Chi Phí";
        }

        private void loadThongTinSP()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvThongTinSP.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XemSanPham", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvThongTinSP.DataSource = dataTable;

                doiTenHeader();
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    MessageBox.Show("Lỗi SQLServer: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                sSC.closeConnection();
            }
        }

        private void UC_QL_SanPham_HienTai_Load(object sender, EventArgs e)
        {
            loadThongTinSP();
        }

        private void gvThongTinSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaSP.Text = gvThongTinSP.Rows[numrow].Cells[0].Value.ToString();
                txtTenSP.Text = gvThongTinSP.Rows[numrow].Cells[1].Value.ToString();
                txtChiPhi.Text = gvThongTinSP.Rows[numrow].Cells[2].Value.ToString();
            }
        }
    }
}
