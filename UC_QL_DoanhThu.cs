using QuanLyChuoiQuanCaPhe;
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
    public partial class UC_QL_DoanhThu : UserControl
    {
        public UC_QL_DoanhThu()
        {
            InitializeComponent();
            grbDoanhThu_Ngay.Text = string.Format("Doanh Thu Hôm Nay ({0})",DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void btnXemDoanhThu_Ngay_Click(object sender, EventArgs e)
        {
            UserControl uc_QL_DoanhThu_Ngay = new UC_QL_DoanhThu_Ngay();
            pnlDoanhThu_Center.Controls.Clear();
            pnlDoanhThu_Center.Controls.Add(uc_QL_DoanhThu_Ngay);
            uc_QL_DoanhThu_Ngay.Dock = DockStyle.Fill;
            uc_QL_DoanhThu_Ngay.BringToFront();
        }
    }
}
