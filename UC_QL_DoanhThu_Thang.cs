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
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;
        private string dataMaCS = null;

        public UC_QL_DoanhThu_Thang(string dataUserName, string dataPassword, string dataMaCS)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
            this.dataMaCS = dataMaCS;
        }

        private void ResestBieuDo(Chart c)
        {
            foreach (Series series in c.Series)
            {
                series.Points.Clear();
            }
        }

        public void LayDataBaseDoanhThuThang(ref List<string> lstNgayThang, ref List<string> lstTongTien)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();
                SqlCommand cmd = new SqlCommand("PROC_XemDoanhThuTrongThang", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@maCS", dataMaCS);

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    lstNgayThang.Add(sdr["ngayDoanhThu"].ToString());
                    lstTongTien.Add(sdr["soTienDoanhThu"].ToString());
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

        private void LoadBieuDoDoanhThuThang()
        {
            ResestBieuDo(chartDoanhThu_Thang);

            List<string> lstNgay = new List<string>();
            List<string> lstDoanhThu = new List<string>();
            LayDataBaseDoanhThuThang(ref lstNgay, ref lstDoanhThu);

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
