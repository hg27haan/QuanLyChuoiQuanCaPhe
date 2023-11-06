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
using System.Runtime.InteropServices;
using System.Diagnostics.Eventing.Reader;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_DangNhap : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataMaCS = string.Empty;
        private string dataPhanQuyen = string.Empty;
        private string dataTenCS = string.Empty;
        private string dataDiaChiCS = string.Empty;

        public UC_DangNhap()
        {
            InitializeComponent();
            XoaVoucherHetHan();
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            txtUserName.BackColor = Color.White;
            pnlUser.BackColor = Color.White;
            txtPassword.BackColor = SystemColors.Control;
            pnlPassword.BackColor = SystemColors.Control;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            pnlPassword.BackColor = Color.White;
            txtUserName.BackColor = SystemColors.Control;
            pnlUser.BackColor = SystemColors.Control;
        }

        private void pbPassword_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }

        private void pbPassword_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void layPhanQuyen(string userName, string password)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT maCS, phanQuyen FROM dbo.GetUserMaCSAndPhanQuyen(@userName,@password)", conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataMaCS = reader["maCS"].ToString();
                    dataPhanQuyen = reader["phanQuyen"].ToString();
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

        private void layTenCoSoVaDiaChi(string maCS)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT tenCS, diaChiCS FROM dbo.GetTenAndDiaChiCS(@maCS)", conn);
                cmd.Parameters.AddWithValue("@maCS", maCS);
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dataTenCS = reader["tenCS"].ToString();
                        dataDiaChiCS = reader["diaChiCS"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally 
            { 
                conn.Close(); 
            }
        }

        private void XoaVoucherHetHan()
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaTuDongVoucher", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@ngayHan", DateTime.Now.ToString("MM/dd/yyyy"));
                cmd.ExecuteNonQuery();
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

        private void loadUCNhanVien()
        {
            UserControl uc_NhanVien = new UC_NhanVien();
            this.Controls.Clear();
            this.Controls.Add(uc_NhanVien);
            uc_NhanVien.Dock = DockStyle.Fill;
        }

        private void loadUCQuanLyVaAdmin()
        {
            UserControl uc_QuanLy = new UC_QuanLyVaAdmin(dataPhanQuyen, dataMaCS);
            this.Controls.Clear();
            this.Controls.Add(uc_QuanLy);
            uc_QuanLy.Dock = DockStyle.Fill;
        }

        private void doiTenForm(string tenCS, string diaChiCS)
        {
            Form parentForm = this.ParentForm as Form;

            if (parentForm != null)
            {
                parentForm.Text = tenCS + " - " + diaChiCS;
            }
        }

        private void thucHienDangNhap()
        {
            layPhanQuyen(txtUserName.Text,txtPassword.Text);
            layTenCoSoVaDiaChi(dataMaCS);
            if (dataPhanQuyen == "nv")
            {
                loadUCNhanVien();
                doiTenForm(dataTenCS, dataDiaChiCS);
            }
            else if (dataPhanQuyen == "ql" || dataPhanQuyen == "ad")
            {
                loadUCQuanLyVaAdmin();
                if (dataPhanQuyen == "ql")
                {
                    doiTenForm(dataTenCS, dataDiaChiCS);
                }
            }
            else
            {
                MessageBox.Show("Sai Tên Đăng Nhập hoặc Mật Khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            thucHienDangNhap();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn không cho ký tự Enter xuất hiện trong TextBox
                thucHienDangNhap();
            }
        }
    }
}
