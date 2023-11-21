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
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;
        private string dataMaCS = null;

        public UC_QL_DoanhThu_Ngay(string dataUserName, string dataPassword, string dataMaCS)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
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
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XemDoanhThuTrongNgay", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maCS", dataMaCS);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvDoanhThu_Ngay.DataSource = dataTable;
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

            doiTenHeader();
        }
    }
}
