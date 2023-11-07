using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataPhanQuyen = null;
        private string dataMaCS = null;

        public UC_QL_NhanVien(string phanQuyen,string dataMaCS)
        {
            InitializeComponent();
            this.dataPhanQuyen = phanQuyen;
            this.dataMaCS = dataMaCS;
        }

        private void loadLenDataGrid(string dataPhanQuyen)
        {
            try
            {
                conn.Open();

                string query = null;
                if(dataPhanQuyen == "ql")
                {
                    query = string.Format("select *from V_NhanVien where maCS = N'{0}' and maNQL <> 'admin'", dataMaCS);
                }
                if(dataPhanQuyen == "ad")
                {
                    query = "select *from V_NhanVien";
                }    
                
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvThongTinNV.DataSource = dataTable;

                doiTenHeader();
            }   
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            { 
                conn.Close(); 
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

        private void UC_QL_NhanVien_Load(object sender, EventArgs e)
        {
            loadLenDataGrid(dataPhanQuyen);
            txtMaCoSo.Text = dataMaCS;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemMoiNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@hoTenNV", txtHoTenNV.Text);
                cmd.Parameters.AddWithValue("@gioiTinhNV", cbbGioiTinhNV.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSDT.Text);
                cmd.Parameters.AddWithValue("@cMND", txtCMND.Text);
                cmd.Parameters.AddWithValue("@maNQL", txtMaNQL.Text);
                cmd.Parameters.AddWithValue("@maCS", txtMaCoSo.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Nhân Viên mới thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
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
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu Nhân Viên thành công!", "Thông báo",
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
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.SuaNhanVien", conn);
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
    }
}
