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
    public partial class UC_QL_Admin_KhachHang : UserControl
    {
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;

        public UC_QL_Admin_KhachHang(string dataUserName, string dataPassWord)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassWord;
        }

        private void loadDanhSachKhachHang()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvKhachHang.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XemKhachHang", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvKhachHang.DataSource = dt;

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

        private void doiTenHeader()
        {
            gvKhachHang.Columns["maKH"].HeaderText = "Mã Khách Hàng";
            gvKhachHang.Columns["tenKH"].HeaderText = "Tên Khách Hàng";
            gvKhachHang.Columns["soDienThoai"].HeaderText = "Số Điện Thoại";
        }

        private void UC_QL_Admin_KhachHang_Load(object sender, EventArgs e)
        {
            loadDanhSachKhachHang();
        }

        private void btnHienThiDanhSachKH_Click(object sender, EventArgs e)
        {
            loadDanhSachKhachHang();
        }

        private void gvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaKH.Text = gvKhachHang.Rows[numrow].Cells[0].Value.ToString();
                txtHoTenKH.Text = gvKhachHang.Rows[numrow].Cells[1].Value.ToString();
                txtSDT.Text = gvKhachHang.Rows[numrow].Cells[2].Value.ToString();
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_SuaKhachHang", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                cmd.Parameters.AddWithValue("@tenKH", txtHoTenKH.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSDT.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Chỉnh sửa dữ liệu Khách Hàng thành công!", "Thông báo",
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
            loadDanhSachKhachHang();
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvKhachHang.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("SELECT *FROM FUNC_TimKiemKhachHang(@soDienThoai)", sSC.conn);
                cmd.Parameters.AddWithValue("@soDienThoai", txtTimSDT.Text);

                SqlDataAdapter timKiemKH = new SqlDataAdapter(cmd);
                DataTable dtKH = new DataTable();

                timKiemKH.Fill(dtKH);
                gvKhachHang.DataSource = dtKH;

                if (gvKhachHang.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy Thông Tin Khách Hàng này.");
                }
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

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XoaKhachHang", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa dữ liệu Khách Hàng thành công!", "Thông báo",
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
            loadDanhSachKhachHang();
        }
    }
}
