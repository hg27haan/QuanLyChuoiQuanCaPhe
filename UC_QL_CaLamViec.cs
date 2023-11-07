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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_QL_CaLamViec : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private int cLV_CLVNhanVien = 0;
        private int tong_NgayCLVNhanVien = 0;

        private string dataPhanQuyen = null;
        private string dataMaCS = null;
        private string dataNgayLam = null;

        public UC_QL_CaLamViec(string dataPhanQuyen, string dataMaCS)
        {
            InitializeComponent();
            this.dataPhanQuyen = dataPhanQuyen;
            this.dataMaCS = dataMaCS;
        }

        private void UC_QL_CaLamViec_Load(object sender, EventArgs e)
        {
            loadThongTinCLVCuaNhanVien();
        }

        private void btnXemCLVTheoNgay_Click(object sender, EventArgs e)
        {
            tong_NgayCLVNhanVien = 1;
            loadThongTinCLVCuaNhanVien();
        }

        private void btnXemCLV_Click(object sender, EventArgs e)
        {
            loadThongTinCLV();
        }

        private void doiTenHeaderCLV()
        {
            gvCaLamViec.Columns[0].HeaderText = "Mã Ca Làm Việc";
            gvCaLamViec.Columns[1].HeaderText = "Giờ Bắt Đầu";
            gvCaLamViec.Columns[2].HeaderText = "Giờ Kết Thúc";
        }

        private void loadThongTinCLV()
        {
            cLV_CLVNhanVien = 1;
            gvCaLamViec.DataSource = null;
            try
            {
                conn.Open();

                string query = string.Format("select *from V_CaLamViec");

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvCaLamViec.DataSource = dataTable;

                doiTenHeaderCLV();
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

        private void btnTaoCLV_Click(object sender, EventArgs e)
        {
            if (txtMaCLV.Text == "")
            {
                MessageBox.Show("Lỗi: Hãy tạo Mã Ca Làm Việc và Giờ Bắt Đầu, Giờ Kết Thúc!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }    
            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.ThemMoiCLV", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maCLV", txtMaCLV.Text);
                    cmd.Parameters.AddWithValue("@gioBD", cbbGioBD.Text);
                    cmd.Parameters.AddWithValue("@gioKT", cbbGioKT.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm dữ liệu Ca Làm Việc mới thành công!", "Thông báo",
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
            loadThongTinCLV();
        }

        private void btnXoaCLV_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaCLV", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCLV", txtMaCLV.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu Ca Làm Việc thành công!", "Thông báo",
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

            loadThongTinCLV();
        }

        private void gvCaLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cLV_CLVNhanVien == 0)
            {
                int numrow = e.RowIndex;
                // Kiểm tra xem có hàng nào đang được chọn không
                if (numrow >= 0)
                {
                    txtMaNV.Text = gvCaLamViec.Rows[numrow].Cells[5].Value.ToString();
                    //dataNgayLam = gvCaLamViec.Rows[numrow].Cells[1].Value.ToString();
                    txtMaCLV.Text = gvCaLamViec.Rows[numrow].Cells[4].Value.ToString();
                    DateTime selectedDate;

                    if (DateTime.TryParse(gvCaLamViec.Rows[numrow].Cells[1].Value.ToString(), out selectedDate))
                    {
                        // Nếu giá trị nhập vào là ngày tháng hợp lệ, đặt giá trị cho DateTimePicker
                        dtpNgayLam.Value = selectedDate;
                    }
                }
            }   
            else
            {
                int numrow = e.RowIndex;
                // Kiểm tra xem có hàng nào đang được chọn không
                if (numrow >= 0)
                {
                    txtMaCLV.Text = gvCaLamViec.Rows[numrow].Cells[0].Value.ToString();
                    cbbGioBD.Text = gvCaLamViec.Rows[numrow].Cells[1].Value.ToString();
                    cbbGioKT.Text = gvCaLamViec.Rows[numrow].Cells[2].Value.ToString();
                }
            }    
        }

        private void doiTenHeaderCLVCuaNhanVien()
        {
            gvCaLamViec.Columns[0].HeaderText = "Mã Cơ Sở";
            gvCaLamViec.Columns[1].HeaderText = "Ngày Làm";
            gvCaLamViec.Columns[2].HeaderText = "Giờ Bắt Đầu";
            gvCaLamViec.Columns[3].HeaderText = "Giờ Kết Thúc";
            gvCaLamViec.Columns[4].HeaderText = "Mã Ca Làm Việc";
            gvCaLamViec.Columns[5].HeaderText = "Mã Nhân Viên";
            gvCaLamViec.Columns[6].HeaderText = "Họ Và Tên";
            gvCaLamViec.Columns[7].HeaderText = "Số Điện Thoại";
        }

        private void loadThongTinCLVCuaNhanVien()
        {
            cLV_CLVNhanVien = 0;
            gvCaLamViec.DataSource = null;
            try
            {
                conn.Open();

                string query = null;
                if (tong_NgayCLVNhanVien == 0)
                {
                    if(dataPhanQuyen=="ql")
                    {
                        query = string.Format("select *from V_CaLamViecCuaNhanVien where maCS = N'{0}'", dataMaCS);
                    }    
                    else
                    {
                        query = string.Format("select *from V_CaLamViecCuaNhanVien");
                    }    
                }
                else
                {
                    if (dataPhanQuyen == "ql")
                    {
                        query = string.Format("select *from V_CaLamViecCuaNhanVien where ngayLam = N'{0}' and maCS = N'{1}'",
                            dtpNgayLam.Value.ToString("dd/MM/yyyy"), dataMaCS);
                    }    
                    else
                    {
                        query = string.Format("select *from V_CaLamViecCuaNhanVien where ngayLam = N'{0}'",
                            dtpNgayLam.Value.ToString("dd/MM/yyyy"));
                    }    
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvCaLamViec.DataSource = dataTable;

                doiTenHeaderCLVCuaNhanVien();
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

        private void btnXemCLVCuaNhanVien_Click(object sender, EventArgs e)
        {
            tong_NgayCLVNhanVien = 0;
            loadThongTinCLVCuaNhanVien();
        }

        private void btnThemCLVCuaNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemNhanVienDangKyCaLam", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@maCLV", txtMaCLV.Text);
                cmd.Parameters.AddWithValue("@ngayLam", dtpNgayLam.Value.ToString("dd/MM/yyyy"));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Ca Làm Việc của Nhân Viên thành công!", "Thông báo",
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

            tong_NgayCLVNhanVien = 0;
            loadThongTinCLVCuaNhanVien();
        }

        private void btnXoaCLVCuaNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaNhanVienDangKyCaLam", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@maCLV", txtMaCLV.Text);
                cmd.Parameters.AddWithValue("@ngayLam", dataNgayLam);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu Ca Làm Việc của Nhân Viên thành công!", "Thông báo",
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

            tong_NgayCLVNhanVien = 0;
            loadThongTinCLVCuaNhanVien();
        }

        private void btnTaoMaCLV_Click(object sender, EventArgs e)
        {
            string maLuong = "coban";
            if (ckbCaThayThe.Checked == true)
            {
                maLuong = "tienthuong";
            }
            txtMaCLV.Text = DateTime.Now.ToString("ddMMyyy") + "_" + dataMaCS + "_" + maLuong;
        }
    }
}
