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
    public partial class FNhanVien : Form
    {
        public FNhanVien()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
     
        }

        private void picbCaPheSua_Click(object sender, EventArgs e)
        {
            lblCheckHang.Text="con hang";
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            Form themkhackhang = new FThemKhachHang();
            themkhackhang.Show();
        }

        private void lblCaPheDaXay_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form themkhackhang = new FThemKhachHang();
            themkhackhang.Show();
        }
    }
}
