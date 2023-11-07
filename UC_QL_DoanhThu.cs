using QuanLyChuoiQuanCaPhe;
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
    public partial class UC_QL_DoanhThu : UserControl
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataMaCS = null;

        public UC_QL_DoanhThu(string dataMaCS)
        {
            InitializeComponent();
            grbDoanhThu_Ngay.Text = string.Format("Doanh Thu Hôm Nay ({0})",DateTime.Now.ToString("dd/MM/yyyy"));
            this.dataMaCS = dataMaCS;
        }

        public int LayDataBaseSoTienHoaDon()
        {
            int tongTien = 0;
            try
            {
                conn.Open();
                string sql = string.Format("SELECT * FROM V_HoaDonTrongNgay WHERE maCS = N'{0}'", dataMaCS);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    tongTien+=int.Parse(sdr["tongTien"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return tongTien;
        }

        private void btnXemDoanhThu_Ngay_Click(object sender, EventArgs e)
        {
            UserControl uc_QL_DoanhThu_Ngay = new UC_QL_DoanhThu_Ngay(dataMaCS);
            pnlDoanhThu_Center.Controls.Clear();
            pnlDoanhThu_Center.Controls.Add(uc_QL_DoanhThu_Ngay);
            uc_QL_DoanhThu_Ngay.Dock = DockStyle.Fill;
            uc_QL_DoanhThu_Ngay.BringToFront();
            lblTongTienNgay.Text = LayDataBaseSoTienHoaDon().ToString()+" đ";
            grbDoanhThu_Ngay.Text = string.Format("Doanh Thu Hôm Nay ({0})", DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private bool isPast10PM()
        {
            DateTime now = DateTime.Now;

            DateTime tenPM = now.Date.AddHours(22);

            if (now >= tenPM)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnTongKet_Ngay_Click(object sender, EventArgs e)
        {
            if(isPast10PM() == false)
            {
                MessageBox.Show("Lỗi: Chưa đến thời gian kết thúc ca!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else
            {
                try
                {
                    string maDoanhThu = DateTime.Now.ToString("ddMMyyyy") +"_"+ dataMaCS;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.AddDoanhThuThang", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maDoanhThu", maDoanhThu);
                    cmd.Parameters.AddWithValue("@maCS", dataMaCS);
                    cmd.Parameters.AddWithValue("@ngayDoanhThu", DateTime.Now.ToString("dd/MM/yyyy"));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tổng Kết Cuối Ca thành công!", "Thông báo",
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
            }    
        }

        public int LayDataBaseSoTienDoanhThu()
        {
            int tongTien = 0;
            try
            {
                conn.Open();
                string sql = string.Format("SELECT * FROM V_DoanhThu WHERE maCS = N'{0}'", dataMaCS);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    tongTien += int.Parse(sdr["soTienDoanhThu"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return tongTien;
        }

        private void btnXemDoanhThu_Thang_Click(object sender, EventArgs e)
        {
            UserControl uc_QL_DoanhThu_Thang = new UC_QL_DoanhThu_Thang(dataMaCS);
            pnlDoanhThu_Center.Controls.Clear();
            pnlDoanhThu_Center.Controls.Add(uc_QL_DoanhThu_Thang);
            uc_QL_DoanhThu_Thang.Dock = DockStyle.Fill;
            uc_QL_DoanhThu_Thang.BringToFront();
            lblTongTienThang.Text = LayDataBaseSoTienDoanhThu().ToString() + " đ";

        }

        private bool kiemTraCuoiThangSau22h30()
        {
            DateTime now = DateTime.Now;
            int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
            bool isLastDayOfMonth = now.Day == daysInMonth;

            if (isLastDayOfMonth == true && DateTime.Now > DateTime.Today.AddHours(22).AddMinutes(00))
            {
                return true;
            }
            return false;
        }

        private void btnTongKet_Thang_Click(object sender, EventArgs e)
        {
            if (kiemTraCuoiThangSau22h30() == false)
            {
                MessageBox.Show("Lỗi: Chưa đến thời gian chốt Doanh Thu Tháng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string maDoanhThu = DateTime.Now.ToString("ddMMyyyy") + "_" + dataMaCS;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.TongKetDoanhThu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maCS", dataMaCS);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tổng Kết Cuối Tháng thành công!", "Thông báo",
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
            }
        }
    }
}
