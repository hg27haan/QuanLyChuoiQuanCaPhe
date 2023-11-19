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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_QL_CaLamViec : UserControl
    {
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;

        private string dataPhanQuyen = null;
        private string dataMaCS = null;
        private string loaiCLV = null;
        private string gioKetThuc = null;
        private string gioLoaiCa = null;

        private int xemCLVHomNay_ALL_QL = 0;
        private int xemNVDangKyCaHomNay_All_QK = 0;

        public UC_QL_CaLamViec(string dataUserName, string dataPassword, string dataPhanQuyen, string dataMaCS)
        {
            InitializeComponent();

            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
            this.dataPhanQuyen = dataPhanQuyen;
            this.dataMaCS = dataMaCS;
            if (dataPhanQuyen == "ad")
            {
                txtMaCS.Enabled = true;
            }    
            else
            {
                txtMaCS.Text = dataMaCS;
            }    
        }

        private void setNullGroup()
        {
            dtpNgayLam.Value = DateTime.Now;
            txtGioBD.Text = null;
            cbbLoaiCLV.SelectedItem = null;
            txtMaCLV.Text = null;
            txtMaNV.Text = null;
            txtMaCLVmaNVDangKy.Text = null;
            lblNgayLam.Text = "dd/MM/yyyy";
        }

        private void doiTenHeaderBangCLV()
        {
            gvCaLamViec.Columns[0].HeaderText = "Mã Ca Làm Việc";
            gvCaLamViec.Columns[1].HeaderText = "Giờ Bắt Đầu";
            gvCaLamViec.Columns[2].HeaderText = "Giờ Kết Thúc";

        }

        private void loadCaLamViec()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvCaLamViec.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = null;

                if (xemCLVHomNay_ALL_QL == 0)
                {
                    cmd = new SqlCommand("select *from FUNC_CaLamViecTheoNgayCuaCoSo(@maCS,@ngayLam)", sSC.conn);

                    lblLoaigvCLV.Text = "Danh Sách Ca Làm Việc Ngày: " + dtpNgayLam.Value.ToString("dd/MM/yyyy");
                    if (dataPhanQuyen == "ql")
                    {
                        cmd.Parameters.AddWithValue("@maCS", dataMaCS);

                        //query = string.Format("select *from dbo.XemCLVTheoNgayTungCoSo(N'{0}',N'{1}')",
                        //    dataMaCS, dtpNgayLam.Value.ToString("ddMMyyyy"));
                    }    
                    else
                    {
                        cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);

                        //query = string.Format("select *from dbo.XemCLVTheoNgayTungCoSo(N'{0}',N'{1}')",
                        //    txtMaCS.Text, dtpNgayLam.Value.ToString("ddMMyyyy"));
                    }
                    cmd.Parameters.AddWithValue("@ngayLam", dtpNgayLam.Value.ToString("ddMMyyyy"));
                }
                else
                {
                    cmd = new SqlCommand("select *from FUNC_TatCaCaLamViecCuaCoSo(@maCS)", sSC.conn);

                    lblLoaigvCLV.Text = "Danh sách tất cả các Ca Làm Việc hiện tại";
                    if (dataPhanQuyen == "ql")
                    {
                        cmd.Parameters.AddWithValue("@maCS", dataMaCS);

                        //query = string.Format("select *from dbo.XemCLVTungCoSo(N'{0}')", dataMaCS);
                    }    
                    else
                    {
                        cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);

                        //query = string.Format("select *from dbo.XemCLVTungCoSo(N'{0}')", txtMaCS.Text);
                    }    
                }

                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvCaLamViec.DataSource = dt;

                doiTenHeaderBangCLV();
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

        private void UC_QL_CaLamViec_Load(object sender, EventArgs e)
        {
            loadCaLamViec();
            loadCLVCuaNhanVien();
        }

        private void kiemTraThoiGian(string gioBatDau)
        {
            try
            {
                DateTime gioBatDauDateTime = DateTime.ParseExact(gioBatDau, "H:mm", null);

                if (gioBatDauDateTime >= DateTime.ParseExact("7:00", "H:mm", null) &&
                    gioBatDauDateTime < DateTime.ParseExact("12:00", "H:mm", null))
                {
                    gioLoaiCa = "casang";
                }
                else if (gioBatDauDateTime >= DateTime.ParseExact("12:00", "H:mm", null) &&
                    gioBatDauDateTime < DateTime.ParseExact("17:00", "H:mm", null))
                {
                    gioLoaiCa = "cachieu";
                }
                else if (gioBatDauDateTime >= DateTime.ParseExact("17:00", "H:mm", null) &&
                    gioBatDauDateTime <= DateTime.ParseExact("18:00", "H:mm", null))
                {
                    gioLoaiCa = "catoi";
                }
                else
                {
                    MessageBox.Show("Nhập sai thời gian quy định trong khung giờ, " +
                        "các khung giờ bắt đầu ca: \n7:00 -> 11:59, \n12:00 -> 16:59, \n17:00 -> 18:00", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                DateTime startTime = DateTime.ParseExact(txtGioBD.Text, "H:mm", null);
                DateTime endTime;
                if (loaiCLV == "QL_A" || loaiCLV == "QL_B")
                {
                    endTime = startTime.AddHours(15);
                }    
                else
                {
                    endTime= startTime.AddHours(5);
                }    
                gioKetThuc = endTime.ToString("H:mm");
            }    
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Nhập sai định dạng, hãy nhập H:mm (Giờ:Phút)\n" + ex.Message, "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaoMaCLV_Click(object sender, EventArgs e)
        {
            if (txtGioBD.Text == null || cbbLoaiCLV.SelectedItem == null)
            {
                MessageBox.Show("Hãy nhập thông tin giờ bắt đầu Ca Làm Việc và chọn Loại Ca Làm Việc!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                switch (cbbLoaiCLV.SelectedItem.ToString())
                {
                    case "Nhân Viên Ca Thường (NV_A)":
                        loaiCLV = "NV_A";
                        break;
                    case "Nhân Viên Ca Lễ (NV_B)":
                        loaiCLV = "NV_B";
                        break;
                    case "Quản Lý Ca Thường (QL_A)":
                        loaiCLV = "QL_A";
                        break;
                    default:
                        loaiCLV = "QL_B";
                        break;
                }

                kiemTraThoiGian(txtGioBD.Text);

                if (dataPhanQuyen == "ql")
                {
                    if (loaiCLV != "QL_A" && loaiCLV != "QL_B")
                    {
                        txtMaCLV.Text = dtpNgayLam.Value.ToString("ddMMyyyy") + "_" + dataMaCS + "_" + gioLoaiCa + "_" +
                            loaiCLV;
                    }
                    else
                    {
                        
                        txtMaCLV.Text = dtpNgayLam.Value.ToString("ddMMyyyy") + "_" + dataMaCS + "_" + loaiCLV;
                    }    
                }    
                else
                {
                    if (loaiCLV != "QL_A" && loaiCLV != "QL_B")
                    {
                        txtMaCLV.Text = dtpNgayLam.Value.ToString("ddMMyyyy") + "_" + txtMaCS.Text + "_" + gioLoaiCa + "_" +
                            loaiCLV;
                    }
                    else
                    {

                        txtMaCLV.Text = dtpNgayLam.Value.ToString("ddMMyyyy") + "_" + txtMaCS.Text + "_" + loaiCLV;
                    }
                }    
            }    
        }

        private void btnXemCLVHomNay_Click(object sender, EventArgs e)
        {
            xemCLVHomNay_ALL_QL = 0;
            dtpNgayLam.Value = DateTime.Now;
            loadCaLamViec();
        }

        private void btnXemTatCaCaLamViec_Click(object sender, EventArgs e)
        {
            xemCLVHomNay_ALL_QL = 1;
            loadCaLamViec();
        }

        private void btnXemCLVTheoNgay_Click(object sender, EventArgs e)
        {
            xemCLVHomNay_ALL_QL = 0;
            loadCaLamViec();
        }

        private void btnThemCLV_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            xemCLVHomNay_ALL_QL = 0;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_ThemCaLamViec", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCLV", txtMaCLV.Text);
                cmd.Parameters.AddWithValue("@gioBD", txtGioBD.Text);
                cmd.Parameters.AddWithValue("@gioKT", gioKetThuc);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Ca Làm Việc mới thành công!", "Thông báo",
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
            loadCaLamViec();
            setNullGroup();
        }

        private void layNgayThang(string chuoiNgayLam)
        {
            string[]arr_ngayLam = chuoiNgayLam.Split('_');
            string ngayLam = arr_ngayLam[0];

            DateTime ngayThangNam;

            // Sử dụng DateTime.TryParseExact để kiểm tra tính hợp lệ của chuỗi
            if (DateTime.TryParseExact(ngayLam, "ddMMyyyy", null, 
                System.Globalization.DateTimeStyles.None, out ngayThangNam))
            {
                // Gán giá trị DateTime cho DateTimePicker
                dtpNgayLam.Value = ngayThangNam;
                lblNgayLam.Text = dtpNgayLam.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                MessageBox.Show("Chuỗi ngày tháng không hợp lệ");
            }
        }

        private void gvCaLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaCLV.Text = gvCaLamViec.Rows[numrow].Cells[0].Value.ToString();
                layNgayThang(gvCaLamViec.Rows[numrow].Cells[0].Value.ToString());
                txtMaCLVmaNVDangKy.Text = txtMaCLV.Text;
            }
        }


        private void btnXoaCLV_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            xemCLVHomNay_ALL_QL = 1;
            if (txtMaCLV.Text == null)
            {
                MessageBox.Show("Lỗi: Chưa chọn Ca Làm Việc muốn xóa từ danh sách", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            else
            {
                try
                {
                    sSC.openConnection();

                    SqlCommand cmd = new SqlCommand("PROC_XoaCaLamViec", sSC.conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maCLV", txtMaCLV.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa dữ liệu Ca Làm Việc này thành công!", "Thông báo",
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
                loadCaLamViec();
                setNullGroup();
            }    
        }

        private void doiTenHeaderNVDangKyCLV()
        {
            gvNhanVienDangKyCa.Columns[0].HeaderText = "Mã Cơ Sở";
            gvNhanVienDangKyCa.Columns[1].HeaderText = "Ngày Làm";
            gvNhanVienDangKyCa.Columns[2].HeaderText = "Giờ Bắt Đầu";
            gvNhanVienDangKyCa.Columns[3].HeaderText = "Giờ Kết Thúc";
            gvNhanVienDangKyCa.Columns[4].HeaderText = "Mã Ca Làm Việc";
            gvNhanVienDangKyCa.Columns[5].HeaderText = "Mã Nhân Viên";
            gvNhanVienDangKyCa.Columns[6].HeaderText = "Họ Và Tên";
            gvNhanVienDangKyCa.Columns[7].HeaderText = "Số Điện Thoại";
        }

        private void loadCLVCuaNhanVien()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvNhanVienDangKyCa.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = null;

                if (xemNVDangKyCaHomNay_All_QK == 0)
                {
                    cmd = new SqlCommand("PROC_XemCaLamViecNhanVienTheoNgay", sSC.conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    lblLoaigvNhanVienDangKyCa.Text = "Danh sách Ca Làm Việc của Nhân Viên ngày: " +
                        DateTime.Now.ToString("dd/MM/yyyy");
                    if (dataPhanQuyen == "ql")
                    {
                        // Thêm các tham số
                        cmd.Parameters.AddWithValue("@maCS", dataMaCS);

                        //query = string.Format("select *from V_CaLamViecCuaNhanVien where maCS=N'{0}' and ngayLam=N'{1}'",
                        //    dataMaCS, DateTime.Now.ToString("dd/MM/yyyy"));
                    }    
                    else
                    {
                        // Thêm các tham số
                        cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);

                        //query = string.Format("select *from V_CaLamViecCuaNhanVien where ngayLam=N'{0}'",
                        //    DateTime.Now.ToString("dd/MM/yyyy"));
                    }
                    cmd.Parameters.AddWithValue("@ngayLam", dtpNgayLam.Value.ToString("ddMMyyyy"));
                }
                else
                {
                    cmd = new SqlCommand("PROC_XemCaLamViecNhanVien", sSC.conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    lblLoaigvNhanVienDangKyCa.Text = "Danh sách tất cả các Ca Làm Việc của Nhân Viên";
                    if (dataPhanQuyen == "ql")
                    {
                        cmd.Parameters.AddWithValue("@maCS", dataMaCS);
                        //query = string.Format("select *from V_CaLamViecCuaNhanVien where maCS=N'{0}'", dataMaCS);
                    }    
                    else
                    {
                        cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                        //query = string.Format("select *from V_CaLamViecCuaNhanVien");
                    }    
                }

                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvNhanVienDangKyCa.DataSource = dt;

                doiTenHeaderNVDangKyCLV();
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

        private void btnThemCLVNhanVien_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataMaCS);

            xemCLVHomNay_ALL_QL = 0;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_ThemNhanVienDangKyCaLam", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCLV", txtMaCLVmaNVDangKy.Text);
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@ngayLam", lblNgayLam.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Nhân Viên Đăng Ký Ca Làm Việc mới thành công!", "Thông báo",
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
            loadCLVCuaNhanVien();
            setNullGroup();
        }

        private void gvNhanVienDangKyCa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaNV.Text = gvNhanVienDangKyCa.Rows[numrow].Cells[5].Value.ToString();
                txtMaCLVmaNVDangKy.Text = gvNhanVienDangKyCa.Rows[numrow].Cells[4].Value.ToString();
                lblNgayLam.Text = gvNhanVienDangKyCa.Rows[numrow].Cells[1].Value.ToString();
            }
        }

        private void btnXoaCLVNhanVien_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            xemCLVHomNay_ALL_QL = 0;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XoaNhanVienDangKyCaLam", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCLV", txtMaCLVmaNVDangKy.Text);
                cmd.Parameters.AddWithValue("@maNV", txtMaNV.Text);
                cmd.Parameters.AddWithValue("@ngayLam", lblNgayLam.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu Nhân Viên Đăng Ký Ca Làm Việc thành công!", "Thông báo",
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
            loadCLVCuaNhanVien();
            setNullGroup();
        }

        private void btnXemNVDangKyCLVHomNay_Click(object sender, EventArgs e)
        {
            xemNVDangKyCaHomNay_All_QK = 0;
            dtpNgayLam.Value = DateTime.Now;
            loadCLVCuaNhanVien();
        }

        private void btnXemTatCaNVDangKyCLV_Click(object sender, EventArgs e)
        {
            xemNVDangKyCaHomNay_All_QK = 1;
            loadCLVCuaNhanVien();
        }

        private void btnXemNVDangKyCLVTheoNgay_Click(object sender, EventArgs e)
        {
            xemNVDangKyCaHomNay_All_QK = 0;
            loadCLVCuaNhanVien();
        }
    }
}

        
