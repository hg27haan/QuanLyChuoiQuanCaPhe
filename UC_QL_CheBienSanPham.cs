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
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataPhanQuyen = null;

        public UC_QL_CheBienSanPham(string dataPhanQuyen)
        {
            InitializeComponent();
            this.dataPhanQuyen = dataPhanQuyen;
            if(this.dataPhanQuyen == "ad" )
            {
                txtMaNL.Enabled = true;
                txtMaSP.Enabled = true;
                txtSoLuongNLCan.Enabled = true;
                btnSuaThongTin.Enabled = true;
                btnThemThongTin.Enabled = true;
            }
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
            gvNLTaoThanhSP.DataSource = null;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select *from V_NguyenLieuTaoThanhSanPham", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvNLTaoThanhSP.DataSource = dataTable;

                doiTenHeader();
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

        private void btnThemThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemNguyenLieuTaoThanhSanPham", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);
                cmd.Parameters.AddWithValue("@soLuongNLCan", txtSoLuongNLCan.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Thành Phần Trong Sản Phẩm thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            loadThongTinSP();
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
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.SuaNguyenLieuTaoThanhSanPham", conn);
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
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }

            loadThongTinSP();
        }

        private void btnXoaThongTin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaNguyenLieuTaoThanhSanPham", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu Thành Phần Trong Sản Phẩm thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            loadThongTinSP();
        }
    }
}
