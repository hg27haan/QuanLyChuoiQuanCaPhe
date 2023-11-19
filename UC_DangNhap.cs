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
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataMaCS = "";
        private string dataPhanQuyen = "";
        private string dataTenCS = "";
        private string dataDiaChiCS = "";
        public UC_DangNhap()
        {
            InitializeComponent();
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


        private void layMaCSVaPhanQuyen()
        {
            sSC = new SQLServerConnection(txtUserName.Text, txtPassword.Text);

            try
            {
                sSC.openConnection();


                SqlCommand cmd = new SqlCommand("SELECT* FROM FUNC_GetmaCSAndphanQuyen(@userName,@password)", sSC.conn);


                cmd.Parameters.AddWithValue("@userName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataMaCS = reader["maCS"].ToString();
                    dataPhanQuyen = reader["phanQuyen"].ToString();
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

        private void layTenCoSoVaDiaChi()
        {
            sSC = new SQLServerConnection(txtUserName.Text, txtPassword.Text);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("SELECT * FROM FUNC_GettenCSAnddiaChiCS(@maCS)", sSC.conn);
                cmd.Parameters.AddWithValue("@maCS", dataMaCS);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dataTenCS = reader["tenCS"].ToString();
                        dataDiaChiCS = reader["diaChiCS"].ToString();
                    }
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

        private void loadUCNhanVien()
        {
            UserControl uc_NhanVien = new UC_NhanVien(txtUserName.Text, txtPassword.Text, dataMaCS);
            this.Controls.Clear();
            this.Controls.Add(uc_NhanVien);
            uc_NhanVien.Dock = DockStyle.Fill;
        }

        private void loadUCQuanLyVaAdmin()
        {
            UserControl uc_QuanLy_Admin = new UC_QuanLyVaAdmin(txtUserName.Text, txtPassword.Text, dataPhanQuyen, dataMaCS);
            this.Controls.Clear();
            this.Controls.Add(uc_QuanLy_Admin);
            uc_QuanLy_Admin.Dock = DockStyle.Fill;
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
            layMaCSVaPhanQuyen();
            layTenCoSoVaDiaChi();
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
