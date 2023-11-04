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
    public partial class UC_Admin : UserControl
    {
        bool navigationExpand = false;

        public UC_Admin()
        {
            InitializeComponent();
            pnlNavigation.Width = pnlNavigation.MinimumSize.Width;
        }

        private void timerDayTime_Tick(object sender, EventArgs e)
        {
            lblUC_QuanLy_DateTimeNow.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy hh:mm:ss");
        }

        private void timerNavigation_Tick(object sender, EventArgs e)
        {
            if (navigationExpand == true)
            {
                // nếu navigation đang mở, đóng nó
                pnlNavigation.Width -= 10;
                if (pnlNavigation.Width == pnlNavigation.MinimumSize.Width)
                {
                    navigationExpand = false;
                    timerNavigation.Stop();
                }
            }
            else
            {
                // nếu navigation đang đóng, mở nó
                pnlNavigation.Width += 10;
                if (pnlNavigation.Width == pnlNavigation.MaximumSize.Width)
                {
                    navigationExpand = true;
                    timerNavigation.Stop();
                }
            }
        }

        private void UC_Admin_Load(object sender, EventArgs e)
        {
            hienThi_ThongTinNV();
        }

        private void maximumSize_Navigation_Mouse_Enter()
        {
            if (navigationExpand == false)
            {
                timerNavigation.Start();
            }
            if (navigationExpand == true)
            {
                timerNavigation.Stop();
            }
        }

        private void maximumSize_Navigation_Mouse_Leave()
        {
            if (navigationExpand == true)
            {
                timerNavigation.Start();
            }
        }

        private void pnlNavigation_MouseEnter(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Enter();
        }

        private void pnlNavigation_MouseLeave(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Leave();
        }

        private void btnNavigation_ThongTinNV_MouseEnter(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Enter();
        }

        private void btnNavigation_ThongTinNV_MouseLeave(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Leave();
        }

        private void btnNavigation_TienLuong_MouseEnter(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Enter();
        }

        private void btnNavigation_TienLuong_MouseLeave(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Leave();
        }

        private void btnNavigation_HinhPhat_MouseEnter(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Enter();
        }

        private void btnNavigation_HinhPhat_MouseLeave(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Leave();
        }

        private void btnNavigation_DoiTac_MouseEnter(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Enter();
        }

        private void btnNavigation_DoiTac_MouseLeave(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Leave();
        }

        private void btnNavigation_CoSo_MouseEnter(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Enter();
        }

        private void btnNavigation_CoSo_MouseLeave(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Leave();
        }

        private void btnAccount_MouseEnter(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Enter();
        }

        private void btnAccount_MouseLeave(object sender, EventArgs e)
        {
            maximumSize_Navigation_Mouse_Leave();
        }

        private void hienThi_ThongTinNV()
        {
            UserControl uc_QL_NhanVien = new UC_QL_NhanVien();
            pnlAdmin_Container_Center.Controls.Clear();
            pnlAdmin_Container_Center.Controls.Add(uc_QL_NhanVien);
            uc_QL_NhanVien.Dock = DockStyle.Fill;
            uc_QL_NhanVien.BringToFront();
            lblTrangThaiQuanLy.Text = "Quản Lý Nhân Viên";
        }

        private void btnNavigation_ThongTinNV_Click(object sender, EventArgs e)
        {
            hienThi_ThongTinNV();
        }

        private void btnNavigation_TienLuong_Click(object sender, EventArgs e)
        {

        }

        private void btnNavigation_HinhPhat_Click(object sender, EventArgs e)
        {
            UserControl uc_Admin_HinhPhat = new UC_Admin_HinhPhat();
            pnlAdmin_Container_Center.Controls.Clear();
            pnlAdmin_Container_Center.Controls.Add(uc_Admin_HinhPhat);
            uc_Admin_HinhPhat.Dock = DockStyle.Fill;
            uc_Admin_HinhPhat.BringToFront();
            lblTrangThaiQuanLy.Text = "Quản Lý Hình Phạt";
        }

        private void btnNavigation_DoiTac_Click(object sender, EventArgs e)
        {
            UserControl uc_Admin_DoiTac = new UC_Admin_DoiTac();
            pnlAdmin_Container_Center.Controls.Clear();
            pnlAdmin_Container_Center.Controls.Add(uc_Admin_DoiTac);
            uc_Admin_DoiTac.Dock = DockStyle.Fill;
            uc_Admin_DoiTac.BringToFront();
            lblTrangThaiQuanLy.Text = "Quản Lý Đối Tác";
        }

        private void btnNavigation_CoSo_Click(object sender, EventArgs e)
        {
            UserControl uc_Admin_CoSo = new UC_Admin_CoSo();
            pnlAdmin_Container_Center.Controls.Clear();
            pnlAdmin_Container_Center.Controls.Add(uc_Admin_CoSo);
            uc_Admin_CoSo.Dock = DockStyle.Fill;
            uc_Admin_CoSo.BringToFront();
            lblTrangThaiQuanLy.Text = "Quản Lý Cơ Sở";
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            UserControl uc_Admin_Account = new UC_Admin_Account();
            pnlAdmin_Container_Center.Controls.Clear();
            pnlAdmin_Container_Center.Controls.Add(uc_Admin_Account);
            uc_Admin_Account.Dock = DockStyle.Fill;
            uc_Admin_Account.BringToFront();
            lblTrangThaiQuanLy.Text = "Quản Lý Account (Tài Khoản)";
        }
    }
}
