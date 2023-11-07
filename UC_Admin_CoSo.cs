using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Principal;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_Admin_CoSo : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public UC_Admin_CoSo()
        {
            InitializeComponent();
        }

        private void LoadDuLieu()
        {
            //Lay cac thong tin tu bang Account
            SqlCommand cmd = new SqlCommand("SELECT * FROM V_CoSo", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvCoSo.DataSource = dt;


            //Doi ten cac cot
            gvCoSo.Columns["maCS"].HeaderText = "Mã cơ sở";
            gvCoSo.Columns["tenCS"].HeaderText = "Tên cơ sở";
            gvCoSo.Columns["diaChiCS"].HeaderText = "Địa chỉ";
        }

        private void UC_Admin_CoSo_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemMoiCoSo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                cmd.Parameters.AddWithValue("@tenCS", txtTenCS.Text);
                cmd.Parameters.AddWithValue("@diaChiCS", txtDiaChiCS.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Cơ Sở mới thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) 
            { 
                MessageBox.Show("Lỗi: "+ex.Message,"Thông báo",
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
                SqlCommand cmd = new SqlCommand("dbo.XoaCoSo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá dữ liệu Cơ sở thành công!", "Thông báo",
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

        private void gvCoSo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaCS.Text = gvCoSo.Rows[numrow].Cells[0].Value.ToString();
                txtTenCS.Text = gvCoSo.Rows[numrow].Cells[1].Value.ToString();
                txtDiaChiCS.Text = gvCoSo.Rows[numrow].Cells[2].Value.ToString();
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ChinhSuaCoSo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                cmd.Parameters.AddWithValue("@tenCS", txtTenCS.Text);
                cmd.Parameters.AddWithValue("@diaChiCS", txtDiaChiCS.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa dữ liệu Cơ Sở thành công!", "Thông báo",
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
    }
}
