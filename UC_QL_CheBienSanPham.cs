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
    public partial class UC_QL_CheBienSanPham : UserControl
    {
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;

        public UC_QL_CheBienSanPham(string dataUserName, string dataPassword)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
        }

        private void doiTenHeader()
        {
            gvNLTaoThanhSP.Columns[0].HeaderText = "Mã Nguyên Liệu";
            gvNLTaoThanhSP.Columns[1].HeaderText = "Tên Nguyên Liệu";
            gvNLTaoThanhSP.Columns[2].HeaderText = "Mã Sản Phẩm";
            gvNLTaoThanhSP.Columns[3].HeaderText = "Tên Sản Phẩm";
            gvNLTaoThanhSP.Columns[4].HeaderText = "Số Lượng Nguyên Liệu Cần";
        }

        private void loadThongTinSP()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvNLTaoThanhSP.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XemNguyenLieuTaoThanhSanPham", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvNLTaoThanhSP.DataSource = dataTable;

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

        private void gvNLTaoThanhSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaNL.Text = gvNLTaoThanhSP.Rows[numrow].Cells[0].Value.ToString();
                txtMaSP.Text = gvNLTaoThanhSP.Rows[numrow].Cells[2].Value.ToString();
                txtSoLuongNLCan.Text = gvNLTaoThanhSP.Rows[numrow].Cells[4].Value.ToString();
            }
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_SuaNguyenLieuTaoThanhSanPham", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);
                cmd.Parameters.AddWithValue("@soLuongNLCan", txtSoLuongNLCan.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa dữ liệu Thành Phần Trong Sản Phẩm thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            loadThongTinSP();
        }
    }
}
