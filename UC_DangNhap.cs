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

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_DangNhap : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataMaCS = string.Empty;
        private string dataPhanQuyen = string.Empty;

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

        private int layPhanQuyen(string userName)
        {
            int result = 0;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT maCS, phanQuyen FROM dbo.GetUserMaCSAndPhanQuyen(@userName)", conn);
                cmd.Parameters.AddWithValue("@userName", userName);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dataMaCS = reader["maCS"].ToString();
                    dataPhanQuyen = reader["phanQuyen"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        private void loadUCNhanVien()
        {
            UserControl uc_NhanVien = new UC_NhanVien();
            this.Controls.Clear();
            this.Controls.Add(uc_NhanVien);
            uc_NhanVien.Dock = DockStyle.Fill;

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (dataPhanQuyen == "nv");
            {
                loadUCNhanVien();
            }    
        }
    }
}
