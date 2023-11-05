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
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataPhanQuyen = null;

        public UC_QL_SanPham_HienTai(string dataPhanQuyen)
        {
            InitializeComponent();
            this.dataPhanQuyen = dataPhanQuyen;
            if (dataPhanQuyen == "ad") 
            {
                txtMaSP.Enabled = true;
                txtTenSP.Enabled = true;
                txtChiPhi.Enabled = true;
                btnThemSP.Enabled = true;
                btnSuaSP.Enabled = true;
                btnXoaSP.Enabled = true;
            }
        }

        private void doiTenHeader()
        {
            gvThongTinSP.Columns[0].HeaderText = "Mã Sản Phẩm";
            gvThongTinSP.Columns[1].HeaderText = "Tên Sản Phẩm";
            gvThongTinSP.Columns[2].HeaderText = "Chi Phí";
        }

        private void loadThongTinSP()
        {
            gvThongTinSP.DataSource = null;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select *from V_SanPham", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvThongTinSP.DataSource = dataTable;

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

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemSanPham", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);
                cmd.Parameters.AddWithValue("@tenSP", txtTenSP.Text);
                cmd.Parameters.AddWithValue("@chiPhi", txtChiPhi.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Sản Phẩm mới thành công!", "Thông báo",
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

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.SuaSanPham", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maSP", txtMaSP.Text);
                cmd.Parameters.AddWithValue("@tenSP", txtTenSP.Text);
                cmd.Parameters.AddWithValue("@chiPhi", txtChiPhi.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa dữ liệu Sản Phẩm thành công!", "Thông báo",
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

        private void btnXoaSP_Click(object sender, EventArgs e)
        {

        }
    }
}
