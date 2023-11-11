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
    public partial class UC_Admin_TienLuong : UserControl
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataPhanQuyen = null;
        private string dataMaCS = null;

        public UC_Admin_TienLuong(string dataPhanQuyen, string dataMaCS)
        {
            InitializeComponent();
            this.dataPhanQuyen = dataPhanQuyen;
            this.dataMaCS = dataMaCS;
            if (dataPhanQuyen == "ad")
            {
                txtSoTien.Enabled = true;
                txtMaCS.Enabled = true;
            }    
        }

        private void doiTenHeaderMucLuong()
        {
            gvMucLuong.Columns[0].HeaderText = "Mã Mức Lương";
            gvMucLuong.Columns[1].HeaderText = "Số Tiền";
        }

        private void loadMucLuong()
        {
            gvMucLuong.DataSource = null;
            try
            {
                conn.Open();

                string query = string.Format("select *from V_MucLuong");

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvMucLuong.DataSource = dt;

                doiTenHeaderMucLuong();
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
        }

        private void UC_Admin_TienLuong_Load(object sender, EventArgs e)
        {
            loadMucLuong();
        }

        private void gvMucLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaML.Text = gvMucLuong.Rows[numrow].Cells[0].Value.ToString();
                txtSoTien.Text = gvMucLuong.Rows[numrow].Cells[1].Value.ToString();
            }
        }

        private void btnSuaML_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThayDoiTienLuong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maML", txtMaML.Text);
                cmd.Parameters.AddWithValue("@soTien", txtSoTien.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa Số Tiền của Mức Lương thành công!", "Thông báo",
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
            loadMucLuong();
        }

        private void doiTenHeaderLuongNV()
        {
            gvLuongNhanVien.Columns[0].HeaderText = "Mã Cơ Sở";
            gvLuongNhanVien.Columns[1].HeaderText = "Mã Nhân Viên";
            gvLuongNhanVien.Columns[2].HeaderText = "Họ Và Tên";
            gvLuongNhanVien.Columns[3].HeaderText = "Mã Mức Lương";
            gvLuongNhanVien.Columns[4].HeaderText = "Số Tiền Lương";
        }

        private void loadLuongNV()
        {
            gvLuongNhanVien.DataSource = null;
            try
            {
                conn.Open();

                string query = null;
                if(dataPhanQuyen=="ql")
                {
                    query = string.Format("select *from V_NhanVienHuongLuong where maCS=N'{0}'", dataMaCS);
                }    
                else
                {
                    query = string.Format("select *from V_NhanVienHuongLuong where maCS=N'{0}'", txtMaCS.Text);
                }    

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvLuongNhanVien.DataSource = dt;

                doiTenHeaderMucLuong();
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
            doiTenHeaderLuongNV();
        }

        private void themVaoNhanVienHuongLuong()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AddVaoNhanVienHuongLuong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCS", dataMaCS);


                cmd.ExecuteNonQuery();
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

        private void btnXemLuongNV_Click(object sender, EventArgs e)
        {
            themVaoNhanVienHuongLuong();
            loadLuongNV();
        }
    }
}
