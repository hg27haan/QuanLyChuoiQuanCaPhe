using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_Admin_DoiTac : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private int ncc_daydu = 0;

        public UC_Admin_DoiTac()
        {
            InitializeComponent();
        }

        private void LoadDuLieu()
        {
            try
            {
                conn.Open();
                string query = null;
                if (ncc_daydu == 0)
                {
                    query = "select *from V_DanhSachNCC";
                }
                else
                {
                    query = "select *from V_NhaCungCapNguyenLieuChoCoSo";
                }
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvDoiTac.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            doiTenHeader();
        }

        private void doiTenHeader()
        {
            if(ncc_daydu == 0)
            {
                gvDoiTac.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
                gvDoiTac.Columns[1].HeaderText = "Tên Người Đại Diện";
                gvDoiTac.Columns[2].HeaderText = "Số Điện Thoại";
                gvDoiTac.Columns[3].HeaderText = "Email";
            }    
            else
            {
                gvDoiTac.Columns[0].HeaderText = "Mã Nhà Cung Cấp";
                gvDoiTac.Columns[1].HeaderText = "Tên Người Đại Diện";
                gvDoiTac.Columns[2].HeaderText = "Số Điện Thoại";
                gvDoiTac.Columns[3].HeaderText = "Email";
                gvDoiTac.Columns[4].HeaderText = "Mã Cơ Sở";
                gvDoiTac.Columns[5].HeaderText = "Tên Cơ Sở";
                gvDoiTac.Columns[6].HeaderText = "Địa Chỉ Cơ Sở";
                gvDoiTac.Columns[7].HeaderText = "Mã Nguyên Liệu";
                gvDoiTac.Columns[8].HeaderText = "Tên Nguyên Liệu";
                gvDoiTac.Columns[9].HeaderText = "Số Lượng Nguyên Liệu";
            }    
        }

        private void UC_Admin_DoiTac_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemMoiNhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@tenNguoiDaiDien", txtTenNguoiDaiDien.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                cmd.Parameters.AddWithValue("@tienHopDong", txtSoLuongNL.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Nhà Cung Cấp mới thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            LoadDuLieu();
        }

        private void gvDoiTac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ncc_daydu == 0)
            {
                int numrow = e.RowIndex;

                // Kiểm tra xem có hàng nào đang được chọn không
                if (numrow >= 0)
                {
                    txtMaNCC.Text = gvDoiTac.Rows[numrow].Cells[0].Value.ToString();
                    txtTenNguoiDaiDien.Text = gvDoiTac.Rows[numrow].Cells[1].Value.ToString();
                    txtSoDienThoai.Text = gvDoiTac.Rows[numrow].Cells[2].Value.ToString();
                    txtEmail.Text = gvDoiTac.Rows[numrow].Cells[3].Value.ToString();
                }
            }
            else
            {
                int numrow = e.RowIndex;

                // Kiểm tra xem có hàng nào đang được chọn không
                if (numrow >= 0)
                {
                    txtMaNCC.Text = gvDoiTac.Rows[numrow].Cells[0].Value.ToString();
                    txtMaCS.Text = gvDoiTac.Rows[numrow].Cells[4].Value.ToString();
                    txtMaNL.Text = gvDoiTac.Rows[numrow].Cells[7].Value.ToString();
                    txtSoLuongNL.Text = gvDoiTac.Rows[numrow].Cells[9].Value.ToString();
                }
            }    
            
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            ncc_daydu = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemNhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@tenNguoiDaiDien", txtTenNguoiDaiDien.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Nhà Cung Cấp thành công!", "Thông báo",
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

            LoadDuLieu();
        }

        private void btnChinhSuaNCC_Click(object sender, EventArgs e)
        {
            ncc_daydu = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ChinhSuaNhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@tenNguoiDaiDien", txtTenNguoiDaiDien.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSoDienThoai.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa dữ liệu Nhà Cung Cấp thành công!", "Thông báo",
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

            LoadDuLieu();
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            ncc_daydu = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaNhaCungCap", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá dữ liệu Nhà Cung Cấp thành công!", "Thông báo",
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

            LoadDuLieu();
        }

        private void btnXemNCC_Click(object sender, EventArgs e)
        {
            ncc_daydu = 0;
            LoadDuLieu();
        }

        private void btnXemNCC_CS_NL_Click(object sender, EventArgs e)
        {
            ncc_daydu = 1;
            LoadDuLieu();
            txtEmail.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
        }

        private void btnThemNCC_NL_CS_Click(object sender, EventArgs e)
        {
            ncc_daydu = 1;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemNhaCungCapNguyenLieuChoCoSo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                cmd.Parameters.AddWithValue("@soLuongNL", txtSoLuongNL.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Cung Cấp Nguyên Liệu thành công!", "Thông báo",
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

            LoadDuLieu();
        }

        private void btnXoaNCC_NL_CS_Click(object sender, EventArgs e)
        {
            ncc_daydu = 1;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaNhaCungCapNguyenLieuChoCoSo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá dữ liệu Cung Cấp Nguyên Liệu thành công!", "Thông báo",
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

            LoadDuLieu();
        }

        private void btnSuaNCC_NL_CS_Click(object sender, EventArgs e)
        {
            ncc_daydu = 1;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.SuaNhaCungCapNguyenLieuChoCoSo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                cmd.Parameters.AddWithValue("@soLuongNL", txtSoLuongNL.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa dữ liệu Cung Cấp Nguyên Liệu thành công!", "Thông báo",
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

            LoadDuLieu();
        }
    }
}
