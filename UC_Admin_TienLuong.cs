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

        List<int> luong = new List<int>();

        public UC_Admin_TienLuong()
        {
            InitializeComponent();

            try
            {
                conn.Open();
                string sqlQuery = string.Format("SELECT * FROM V_MucLuong");
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                int n= dataTable.Rows.Count;
                for(int i=0;i<n;i++)
                {
                    luong.Add(Int32.Parse(dataTable.Rows[i][1].ToString()));
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void doiTenHeader()
        {
            gvMucLuong.Columns[0].HeaderText = "Mã Mức Lương";
            gvMucLuong.Columns[1].HeaderText = "Số Tiền Lương";
        }

        private void loadThongTinML()
        {
            try
            {
                conn.Open();
                string sqlQuery = string.Format("SELECT * FROM V_MucLuong");
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvMucLuong.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }

            doiTenHeader();
        }

        private void btnSuaTienLuong_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThayDoiTienLuong", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maML", txtMaML.Text);
                cmd.Parameters.AddWithValue("@soTien", txtTienLuong.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa dữ liệu Mức Lương thành công!", "Thông báo",
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

            loadThongTinML();
        }

        private void gvMucLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaML.Text = gvMucLuong.Rows[numrow].Cells[0].Value.ToString();
                txtTienLuong.Text = gvMucLuong.Rows[numrow].Cells[1].Value.ToString();
            }
        }

        private void UC_Admin_TienLuong_Load(object sender, EventArgs e)
        {
            loadThongTinML();
        }
    }
}
