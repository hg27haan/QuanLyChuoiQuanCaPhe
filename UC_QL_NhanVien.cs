using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_QL_NhanVien : UserControl
    {
        // SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;
        private string dataPhanQuyen = null;
        private string dataMaCS = null;

        public UC_QL_NhanVien(string dataUserName, string dataPassword, string phanQuyen, string dataMaCS)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
            this.dataPhanQuyen = phanQuyen;
            this.dataMaCS = dataMaCS; 

            if(dataPhanQuyen == "ql")
            {
                txtMaCoSo.Enabled = false;
                txtMaCoSo.Text = dataMaCS;
            }   
        }

        private void setNullTextBox()
        {
            txtMaNV.Text = null;
            txtHoTenNV.Text = null;
            cbbGioiTinhNV.Text = null;
            txtSDT.Text = null;
            txtCMND.Text = null;
            txtMaNQL.Text = null;
            txtMaCoSo.Text= null;
        }

        private void loadLenDataGrid(string dataPhanQuyen)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = null;
                if(dataPhanQuyen == "ql")
                {
                    cmd = new SqlCommand("PROC_XemNhanVienTheoCoSo", sSC.conn);

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maCS", dataMaCS);

                }
                if(dataPhanQuyen == "ad")
                {
                    cmd = new SqlCommand("PROC_XemNhanVien", sSC.conn);
                }

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvThongTinNV.DataSource = dataTable;

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
            gvThongTinNV.Columns[0].HeaderText = "Mã Nhân Viên";
            gvThongTinNV.Columns[1].HeaderText = "Họ Và Tên";
            gvThongTinNV.Columns[2].HeaderText = "Giới Tính";
            gvThongTinNV.Columns[3].HeaderText = "Số Điện Thoại";
            gvThongTinNV.Columns[4].HeaderText = "CCCD";
            gvThongTinNV.Columns[5].HeaderText = "Mã Người Quản Lý";
            gvThongTinNV.Columns[6].HeaderText = "Mã Cơ Sở";
        }

        public int LayDataBaseSoLuongNV()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            int soLuong = 0;
            try
            {
                sSC.openConnection();

                SqlCommand command = new SqlCommand("SELECT dbo.FUNC_TinhTongSoLuongNhanVien() AS TotalEmployees", sSC.conn);

                var result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out soLuong))
                {

                }
                else
                {

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
            return soLuong;
        }

        private void UC_QL_NhanVien_Load(object sender, EventArgs e)
        {
            loadLenDataGrid(dataPhanQuyen);
            txtMaCoSo.Text = dataMaCS;

            if (dataPhanQuyen == "ad")
            {
                lblTongSoNV.Visible = true;
                string soLuongNV = LayDataBaseSoLuongNV().ToString();
                lblTongSoNV.Text = "Tổng số Nhân Viên Hiện Tại: " + soLuongNV + " (tính cả admin)";
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_ThemNhanVien", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@hoTenNV", txtHoTenNV.Text);
                cmd.Parameters.AddWithValue("@gioiTinhNV", cbbGioiTinhNV.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@cMND", txtCMND.Text);

                if (txtMaNQL.Text == "")
                {
                    cmd.Parameters.AddWithValue("@maNQL", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@maNQL", txtMaNQL.Text);
                }

                cmd.Parameters.AddWithValue("@maCS", txtMaCoSo.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Nhân Viên mới thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                setNullTextBox();
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

            loadLenDataGrid(dataPhanQuyen);
        }

        private void gvThongTinNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {

                txtMaNV.Text = gvThongTinNV.Rows[numrow].Cells[0].Value.ToString();
                txtHoTenNV.Text = gvThongTinNV.Rows[numrow].Cells[1].Value.ToString();
                cbbGioiTinhNV.Text = gvThongTinNV.Rows[numrow].Cells[2].Value.ToString();
                txtSDT.Text = gvThongTinNV.Rows[numrow].Cells[3].Value.ToString();
                txtCMND.Text = gvThongTinNV.Rows[numrow].Cells[4].Value.ToString();
                txtMaNQL.Text = gvThongTinNV.Rows[numrow].Cells[5].Value.ToString();
                txtMaCoSo.Text = gvThongTinNV.Rows[numrow].Cells[6].Value.ToString();
            }
        }

        private void thucHienXoaNhanVien()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XoaNhanVien", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu Nhân Viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                setNullTextBox();
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

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn Xóa Nhân Viên này khỏi hệ thống?", "Xác Nhận Lại",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                thucHienXoaNhanVien();
            }
            loadLenDataGrid(dataPhanQuyen);
        }

        private void thucHienSuaNhanVien()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_SuaNhanVien", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@hoTenNV", txtHoTenNV.Text);
                cmd.Parameters.AddWithValue("@gioiTinhNV", cbbGioiTinhNV.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@cMND", txtCMND.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa dữ liệu Nhân Viên thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                setNullTextBox();
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

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn Sửa Thông Tin Nhân Viên này trong hệ thống?", "Xác Nhận Lại",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                thucHienSuaNhanVien();
            }
            loadLenDataGrid(dataPhanQuyen);
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName,dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("SELECT *FROM FUNC_TimKiemNhanVien(@hoTenNV)",sSC.conn);
                cmd.Parameters.AddWithValue("@hoTenNV", txtTimKiemTenNV.Text);

                SqlDataAdapter timKiemNV = new SqlDataAdapter(cmd);
                DataTable dtNV = new DataTable();
                timKiemNV.Fill(dtNV);
                gvThongTinNV.DataSource = dtNV;

                if (gvThongTinNV.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên này.");
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
