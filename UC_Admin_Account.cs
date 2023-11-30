using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_Admin_Account : UserControl
    {
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;

        public UC_Admin_Account(string dataUserName, string dataPassword)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
        }

        private void LoadDuLieu()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                //Lay cac thong tin tu bang Account
                SqlCommand cmd = new SqlCommand("PROC_XemAccount", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvAccount.DataSource = dt;


                //Doi ten cac cot
                gvAccount.Columns["maCS"].HeaderText = "Mã cơ sở";
                gvAccount.Columns["userName"].HeaderText = "Tên đăng nhập";
                gvAccount.Columns["password"].HeaderText = "Mật khẩu";
                gvAccount.Columns["phanQuyen"].HeaderText = "Phân quyền";
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

        private void UC_Admin_Account_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void gvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {

                txtMaCS.Text = gvAccount.Rows[numrow].Cells[0].Value.ToString();
                txtUserName.Text = gvAccount.Rows[numrow].Cells[1].Value.ToString();
                txtPassword.Text = gvAccount.Rows[numrow].Cells[2].Value.ToString();
                txtPhanQuyen.Text = gvAccount.Rows[numrow].Cells[3].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_ThemAccount", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                cmd.Parameters.AddWithValue("@userName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@phanQuyen", txtPhanQuyen.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Account mới thành công!", "Thông báo",
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
                SqlCommand cmd = new SqlCommand("PROC_XoaAccount", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@userName", txtUserName.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá dữ liệu Account thành công!", "Thông báo",
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

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);
            try
            {
                sSC.openConnection();
                SqlCommand cmd = new SqlCommand("PROC_SuaAccount", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@userName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@newPassword", txtPassword.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa mật khẩu của account thành công!", "Thông báo",
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
    }
}
