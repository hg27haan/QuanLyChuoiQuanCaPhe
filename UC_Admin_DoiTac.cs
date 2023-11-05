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
        public UC_Admin_DoiTac()
        {
            InitializeComponent();
        }

        private void LoadDuLieu()
        {
            //Lay cac thong tin tu bang Account
            SqlCommand cmd = new SqlCommand("SELECT * FROM V_ThongTinNhaCungCapCoSo", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvDoiTac.DataSource = dt;


            //Doi ten cac cot
            gvDoiTac.Columns["maNCC"].HeaderText = "Mã nhà cung cấp";
            gvDoiTac.Columns["tenNguoiDaiDien"].HeaderText = "Tên người đại diện";
            gvDoiTac.Columns["soDienThoai"].HeaderText = "Số điện thoại";
            gvDoiTac.Columns["email"].HeaderText = "Email";
            gvDoiTac.Columns["tenCS"].HeaderText = "Tên cơ sở";
            gvDoiTac.Columns["tenNL"].HeaderText = "Tên nguyên liệu";
            gvDoiTac.Columns["tienHopDong"].HeaderText = "Tiền hợp đồng";
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
                cmd.Parameters.AddWithValue("@tienHopDong", txtTienHopDong.Text);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaHoanToanNhaCungCap", conn);
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

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
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

        private void gvDoiTac_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
