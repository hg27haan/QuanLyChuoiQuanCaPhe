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
        private SQLServerConnection sSC = new SQLServerConnection();

        public UC_QL_Admin_KhachHang(string dataUserName, string dataPassWord)
        {
            InitializeComponent();
            sSC = new SQLServerConnection(dataUserName, dataPassWord);
        }

        private void loadDanhSachKhachHang()
        {
            gvKhachHang.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XemKhachHang", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvKhachHang.DataSource = dt;
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông Báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("dbo.SuaKhachHang", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                cmd.Parameters.AddWithValue("@tenKH", txtHoTenKH.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSDT.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Chỉnh sửa dữ liệu Khách Hàng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sSC.closeConnection();
            }
            loadDanhSachKhachHang();
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            gvKhachHang.DataSource = null;
            try
            {
                sSC.openConnection();

                string sql = string.Format("SELECT *FROM TimKiemKhachHang(N'{0}')", txtTimSDT.Text);
                SqlCommand cmd = new SqlCommand(sql, sSC.conn);

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
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                sSC.closeConnection();
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("dbo.XoaKhachHang", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKH.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Xóa dữ liệu Khách Hàng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                sSC.closeConnection();
            }
            loadDanhSachKhachHang();
        }
    }
}
