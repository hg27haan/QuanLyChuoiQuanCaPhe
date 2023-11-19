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
        SQLServerConnection sSC = new SQLServerConnection();

        private int danhSachNL_NLCuaCS = 0;

        private string dataUserName = null;
        private string dataPassword = null;
        private string dataPhanQuyen= null;
        private string dataMaCS = null;

        public UC_QL_KhoNguyenLieu(string dataUserName, string dataPassword, string dataPhanQuyen, string dataMaCS)
        {
            InitializeComponent();
            this.dataPhanQuyen = dataPhanQuyen;
            this.dataMaCS = dataMaCS;
            if(this.dataPhanQuyen == "ql" ) 
            {
                danhSachNL_NLCuaCS = 1;
            }
        }

        private void doiTenHeader()
        {
            if (danhSachNL_NLCuaCS == 0)
            {
                gvThongTinNL.Columns[0].HeaderText = "Mã Nguyên Liệu";
                gvThongTinNL.Columns[1].HeaderText = "Tên Nguyên Liệu";
                gvThongTinNL.Columns[1].HeaderText = "Chi Phí";
            }   
            else
            {
                gvThongTinNL.Columns[0].HeaderText = "Mã Cơ Sở";
                gvThongTinNL.Columns[1].HeaderText = "Mã Nguyên Liệu";
                gvThongTinNL.Columns[2].HeaderText = "Tên Nguyên Liệu";
                gvThongTinNL.Columns[3].HeaderText = "Số Lượng Nguyên Liệu";
                gvThongTinNL.Columns[4].HeaderText = "Chi Phí";
                gvThongTinNL.Columns[5].HeaderText = "Tên Người Đại Diện";
                gvThongTinNL.Columns[6].HeaderText = "Số Điện Thoại";
                gvThongTinNL.Columns[7].HeaderText = "Email";
            }    
        }

        private void loadDanhSachNguyenLieu()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvThongTinNL.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = null;
                

                if (danhSachNL_NLCuaCS == 0)
                {
                    cmd = new SqlCommand("PROC_XemNguyenLieu", sSC.conn);
                }    
                else
                {
                    cmd = new SqlCommand("PROC_XemSoLuongNguyenLieuConVaNhaCungCap", sSC.conn);
                    if (dataPhanQuyen == "ql")
                    {
                        cmd.Parameters.AddWithValue("@maCS", dataMaCS);
                    }    
                    else
                    {
                        cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                    }    
                    
                }

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvThongTinNL.DataSource = dataTable;

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

        private void btnSuaNL_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvThongTinNL.DataSource = null;
            try
            {
                sSC.openConnection();

                if (danhSachNL_NLCuaCS == 0)
                {
                    SqlCommand cmd = new SqlCommand("PROC_SuaNguyenLieu", sSC.conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maNL", txtMaNL.Text);
                    cmd.Parameters.AddWithValue("@tenNL", txtTenNL.Text);
                    cmd.Parameters.AddWithValue("@chiPhi", txtChiPhi.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Sửa dữ liệu Nguyên Liệu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bảng dữ liệu phải hiển thị Danh Sách Nguyên Liệu mới được " +
                        "phép Sửa Thông Tin Nguyên Liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
