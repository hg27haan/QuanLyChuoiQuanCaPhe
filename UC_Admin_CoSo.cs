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
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;

        public UC_Admin_CoSo(string dataUserName, string dataPassword)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
        }

        private void LoadDuLieu()
        {
            try
            {
                sSC = new SQLServerConnection(dataUserName, dataPassword);

                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XemViewCoSo", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvCoSo.DataSource = dt;


                //Doi ten cac cot
                gvCoSo.Columns["maCS"].HeaderText = "Mã cơ sở";
                gvCoSo.Columns["tenCS"].HeaderText = "Tên cơ sở";
                gvCoSo.Columns["diaChiCS"].HeaderText = "Địa chỉ";
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

        private void UC_Admin_CoSo_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_ThemCoSo", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                cmd.Parameters.AddWithValue("@tenCS", txtTenCS.Text);
                cmd.Parameters.AddWithValue("@diaChiCS", txtDiaChiCS.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Cơ Sở mới thành công!", "Thông báo", 
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
            LoadDuLieu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XoaCoSo", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá dữ liệu Cơ sở thành công!", "Thông báo",
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
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();
                    
                SqlCommand cmd = new SqlCommand("PROC_SuaCoSo", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                cmd.Parameters.AddWithValue("@tenCS", txtTenCS.Text);
                cmd.Parameters.AddWithValue("@diaChiCS", txtDiaChiCS.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa dữ liệu Cơ Sở thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
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
            LoadDuLieu();
        }

        private void btnTimKiemCS_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("SELECT *FROM FUNC_TimKiemCoSoo(@tenCS)", sSC.conn);
                cmd.Parameters.AddWithValue("@tenCS", txtTimKiemTenCS.Text);
                cmd.ExecuteNonQuery();

                SqlDataAdapter timKiemCS = new SqlDataAdapter(cmd);
                DataTable dtCS = new DataTable();
                timKiemCS.Fill(dtCS);
                gvCoSo.DataSource = dtCS;

                if(gvCoSo.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy cơ sở này");
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
        }
    }
}
