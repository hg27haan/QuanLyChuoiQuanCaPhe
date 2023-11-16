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
    public partial class UC_QL_KhoNguyenLieu : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private int danhSachNL_NLCuaCS = 0;

        private string dataPhanQuyen= null;
        private string dataMaCS = null;

        public UC_QL_KhoNguyenLieu(string dataPhanQuyen, string dataMaCS)
        {
            InitializeComponent();
            this.dataPhanQuyen = dataPhanQuyen;
            this.dataMaCS = dataMaCS;
            if(this.dataPhanQuyen == "ql" ) 
            {
                danhSachNL_NLCuaCS = 1;
            }
            else
            {
                txtMaNL.Enabled = true;
                txtTenNL.Enabled = true;
                txtChiPhi.Enabled = true;
                btnXemDanhSachNL.Enabled = true;
                btnXemDanhSachNLCuaCS.Enabled = true;
                btnThemNL.Enabled = true;
            }    
        }

        private void doiTenHeader()
        {
            //gvThongTinNL.Columns[0].HeaderText = "Mã Cơ Sở";
            //gvThongTinNL.Columns[1].HeaderText = "Mã Nguyên Liệu";
            //gvThongTinNL.Columns[2].HeaderText = "Tên Nguyên Liệu";
            //gvThongTinNL.Columns[3].HeaderText = "Số Lượng Nguyên Liệu";
            //gvThongTinNL.Columns[4].HeaderText = "Chi Phí";
            //gvThongTinNL.Columns[5].HeaderText = "Tên Người Đại Diện";
            //gvThongTinNL.Columns[6].HeaderText = "Số Điện Thoại";
            //gvThongTinNL.Columns[7].HeaderText = "Email";
        }

        private void loadDanhSachNguyenLieu()
        {
            gvThongTinNL.DataSource = null;
            try
            {
                conn.Open();

                string query = null;
                if (danhSachNL_NLCuaCS == 0)
                {
                    query = string.Format("select *from V_NguyenLieu");
                }    
                else
                {
                    query = string.Format("select *from V_NguyenLieuConVaCungCap where maCS = N'{0}'", dataMaCS);
                }    
                
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvThongTinNL.DataSource = dataTable;

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

        private void UC_QL_KhoNguyenLieu_Load(object sender, EventArgs e)
        {
            loadDanhSachNguyenLieu();
        }

        private void gvThongTinNL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaNL.Text = gvThongTinNL.Rows[numrow].Cells[1].Value.ToString();
                txtTenNL.Text = gvThongTinNL.Rows[numrow].Cells[2].Value.ToString();
                txtSoLuongConLai.Text = gvThongTinNL.Rows[numrow].Cells[3].Value.ToString();
                txtChiPhi.Text = gvThongTinNL.Rows[numrow].Cells[4].Value.ToString();
                txtMaCS.Text = gvThongTinNL.Rows[numrow].Cells[0].Value.ToString();
            }
        }

        //private void xoaNL()
        //{
        //    try
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand("dbo.XoaNguyenLieu", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        // Thêm các tham số
        //        cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("Xóa dữ liệu Nguyên Liệu thành công!", "Thông báo",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    loadDanhSachNguyenLieu();
        //}

        //private void btnXoaNL_Click(object sender, EventArgs e)
        //{
        //    xoaNL();
        //}


        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            gvThongTinNL.DataSource = null;
            try
            {
                conn.Open();
                SqlCommand cmd = null;
                if (danhSachNL_NLCuaCS == 0)
                {
                    cmd = new SqlCommand("dbo.SuaNguyenLieu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                    cmd.Parameters.AddWithValue("@tenNL", txtTenNL.Text);
                    cmd.Parameters.AddWithValue("@chiPhi", txtChiPhi.Text);
                }

                cmd.ExecuteNonQuery();
                if (danhSachNL_NLCuaCS == 0)
                {
                    MessageBox.Show("Sửa dữ liệu Nguyên Liệu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            loadDanhSachNguyenLieu();
        }

        private void themNguyenLieu()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = null;
                if (danhSachNL_NLCuaCS == 0)
                {
                    cmd = new SqlCommand("dbo.ThemNguyenLieu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                    cmd.Parameters.AddWithValue("@tenNL", txtTenNL.Text);
                    cmd.Parameters.AddWithValue("@chiPhi", txtChiPhi.Text);
                }
                else
                {
                    cmd = new SqlCommand("dbo.ThemNguyenLieuCuaCoSo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                    cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                    cmd.Parameters.AddWithValue("@soLuongCon", txtSoLuongConLai.Text);
                }

                cmd.ExecuteNonQuery();
                if (danhSachNL_NLCuaCS == 0)
                {
                    MessageBox.Show("Thêm dữ liệu Nguyên Liệu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
                else
                {
                    MessageBox.Show("Thêm dữ liệu Nguyên Liệu Của Cơ Sở thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
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
            loadDanhSachNguyenLieu();
        }

        private void btnXemDanhSachNL_Click(object sender, EventArgs e)
        {
            danhSachNL_NLCuaCS = 0;
            loadDanhSachNguyenLieu();
        }

        private void btnXemDanhSachNLCuaCS_Click(object sender, EventArgs e)
        {
            danhSachNL_NLCuaCS = 1;
            loadDanhSachNguyenLieu();
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            themNguyenLieu();
        }
    }
}
