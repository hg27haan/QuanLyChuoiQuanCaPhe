using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_DangNhap : UserControl
    {
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
    }
}
