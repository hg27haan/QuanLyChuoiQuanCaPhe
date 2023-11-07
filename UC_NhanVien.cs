using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_NhanVien : UserControl
    {
        private SqlConnection conn =new SqlConnection(Properties.Settings.Default.connStr);
        private DataTable dt = new DataTable();

        List<(Label, CheckBox)> lst = new System.Collections.Generic.List<(Label, CheckBox)>();
        
        public UC_NhanVien()
        {
            InitializeComponent();

            lst.Add((lbl_ESPRESSO, ckbESPRESSO));
            lst.Add((lbl_BACSIU, ckbBACSIU));
        }

        private void tinhTongTien(int chiPhi, int soLuongSP, ref int tongCong)
        {
            tongCong = chiPhi * soLuongSP;
        }

        private void pnlCaPheSua_Click(object sender, EventArgs e)
        {
            //_tenSP = "caphesua";
            //_chiPhi = 15000;
            //tinhTongTien(_chiPhi, _soLuongSP, ref _tongTien);

            //dt.Rows.Add(_tenSP, _chiPhi, _soLuongSP, _tongTien);

            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);
            //gvNLTaoThanhSP.DataSource = dataTable;
            //gvHoaDon.DataSource = 
        }
        private string TaoChuoiHoac() 
        {
            string dk = "";
            int n = lst.Count();
            for (int i=0;i<n-1;i++ )
            {
                if (lst[i].Item2.Checked == true)
                {
                    dk = dk + $"maSP = '{lst[i].Item1.Text}' or ";
                }
            }
           
            dk = dk.Substring(0, dk.Length - 3);
            return dk;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            lst.Add((lbl_ESPRESSO,ckbESPRESSO));
            string dk = TaoChuoiHoac();
            if (dk == "") return;
            MessageBox.Show(dk);
            string sql = $"select * from SanPham where {dk}";
            
            gvHoaDon.DataSource = null;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvHoaDon.DataSource = dataTable;

                //doiTenHeader();
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

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemMoiKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@tenKH", txtTenKhachHang.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSoDienThoai.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Khách Hàng thành công!", "Thông báo",
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
            loadKhachHang();
        }

        private void doiTenHeaderKhachHang()
        {
            gvKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            gvKhachHang.Columns[0].HeaderText = "Tên Khách Hàng";
            gvKhachHang.Columns[0].HeaderText = "Số Điện Thoại";
        }

        private void loadKhachHang()
        {
            gvKhachHang.DataSource = null;
            try
            {
                conn.Open();

                string query = string.Format("select *from V_KhachHang");

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvKhachHang.DataSource = dataTable;

                doiTenHeaderKhachHang();
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

        private void tabpgKH_Click(object sender, EventArgs e)
        {
            loadKhachHang();
        }

        private void gvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaKhachHang.Text = gvKhachHang.Rows[numrow].Cells[0].Value.ToString();
                txtTenKhachHang.Text = gvKhachHang.Rows[numrow].Cells[1].Value.ToString();
                txtSoDienThoai.Text = gvKhachHang.Rows[numrow].Cells[2].Value.ToString();
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.SuaKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@tenKH", txtTenKhachHang.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSoDienThoai.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa dữ liệu Khách Hàng thành công!", "Thông báo",
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
            loadKhachHang();
        }

        private void tabctrlNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabctrlNhanVien.SelectedIndex == 0)
            {
                //LoadTrendingThueXe();
            }
            if (tabctrlNhanVien.SelectedIndex == 1)
            {
                loadKhachHang();
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu Khách Hàng thành công!", "Thông báo",
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
            loadKhachHang();
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT *FROM TimKiemKhachHang(@soDienThoai)", conn);
                cmd.Parameters.AddWithValue("@soDienThoai", txtTimSoDienThoai.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblTimMaKH.Text = reader["maKH"].ToString();
                    lblTimTenKH.Text = reader["tenKH"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng với mã này.");
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
        }
    }
}
