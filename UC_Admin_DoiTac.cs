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
        SQLServerConnection sSC = new SQLServerConnection();

        private int ncc_daydu = 0;

        private string dataUserName = null;
        private string dataPassword = null;

        public UC_Admin_DoiTac(string dataUserName, string dataPassword)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
        }

        private void LoadDuLieu()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                string query = null;
                if (ncc_daydu == 0)
                {
                    query = "PROC_XemNhaCungCap";
                }
                else
                {
                    query = "PROC_XemNhaCungCapNguyenLieuChoCoSo";
                }
                SqlCommand cmd = new SqlCommand(query, sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvDoiTac.DataSource = dataTable;
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
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            ncc_daydu = 0;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_ThemNhaCungCap", sSC.conn);
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

            LoadDuLieu();
        }

        private void btnChinhSuaNCC_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            ncc_daydu = 0;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_SuaNhaCungCap", sSC.conn);
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

            LoadDuLieu();
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            ncc_daydu = 0;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XoaNhaCungCap", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá dữ liệu Nhà Cung Cấp thành công!", "Thông báo",
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
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            ncc_daydu = 1;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_ThemNhaCungCapNguyenLieuChoCoSo", sSC.conn);
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

            LoadDuLieu();
        }

        private void btnXoaNCC_NL_CS_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            ncc_daydu = 1;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XoaNhaCungCapNguyenLieuChoCoSo", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNCC", txtMaNCC.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá dữ liệu Cung Cấp Nguyên Liệu thành công!", "Thông báo",
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

            LoadDuLieu();
        }

        private void btnSuaNCC_NL_CS_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            ncc_daydu = 1;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_SuaNhaCungCapNguyenLieuChoCoSo", sSC.conn);
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

            LoadDuLieu();
        }

        private void btnTimKiemNCC_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("SELECT *FROM FUNC_TimKiemNhaCungCapNguyenLieuChoCoSo(@soDienThoai)", sSC.conn);
                cmd.Parameters.AddWithValue("@soDienThoai", txtTimKiemNCC.Text);
                cmd.ExecuteNonQuery();
                SqlDataAdapter timKiemNCC = new SqlDataAdapter(cmd);
                DataTable dtNCC = new DataTable();
                timKiemNCC.Fill(dtNCC);
                gvDoiTac.DataSource = dtNCC;

                if (gvDoiTac.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp này này.");
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
    }
}
