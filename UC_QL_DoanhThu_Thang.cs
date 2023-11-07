using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_QL_DoanhThu_Thang : UserControl
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataMaCS = null;

        public UC_QL_DoanhThu_Thang(string dataMaCS)
        {
            InitializeComponent();
            this.dataMaCS = dataMaCS;
        }

        private void ResestBieuDo(Chart c)
        {
            foreach (Series series in c.Series)
            {
                series.Points.Clear();
            }
        }

        public void LayDataBaseDoanhThuThangNam(ref List<string> lstNgayThang, ref List<string> lstTongTien)
        {
            try
            {
                conn.Open();
                string sql = string.Format("select *from V_DoanhThu where maCS = N'{0}'",dataMaCS);
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    lstNgayThang.Add(sdr["ngayDoanhThu"].ToString());
                    lstTongTien.Add(sdr["soTienDoanhThu"].ToString());
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
        }

        private void LoadBieuDoDoanhThuThang()
        {
            ResestBieuDo(chartDoanhThu_Thang);

            List<string> lstNgay = new List<string>();
            List<string> lstDoanhThu = new List<string>();
            LayDataBaseDoanhThuThangNam(ref lstNgay, ref lstDoanhThu);

            for (int i = 0; i < lstNgay.Count; i++)
            {
                chartDoanhThu_Thang.Series["DoanhThuThang"].Points.AddXY(lstNgay[i], double.Parse(lstDoanhThu[i]));
                chartDoanhThu_Thang.Series["DoanhThuThang"].Points[i].Label = int.Parse(lstDoanhThu[i]).ToString("N0",
                    CultureInfo.CreateSpecificCulture("vi-VN"));
                chartDoanhThu_Thang.Series["DoanhThuThang"].Points[i].Color = Color.SteelBlue;
                chartDoanhThu_Thang.Series["DoanhThuThang"].Points[i].AxisLabel = lstNgay[i];
                chartDoanhThu_Thang.Titles["Title1"].Text = "Doanh thu tháng " + DateTime.Now.Date.ToString("MM/yyyy");
            }
        }

        private void UC_QL_DoanhThu_Thang_Load(object sender, EventArgs e)
        {
            ResestBieuDo(chartDoanhThu_Thang);
            LoadBieuDoDoanhThuThang();
        }
    }
}
