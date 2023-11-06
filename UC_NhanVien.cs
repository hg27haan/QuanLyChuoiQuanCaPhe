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
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_NhanVien : UserControl
    {
        private SqlConnection conn =new SqlConnection(Properties.Settings.Default.connStr);
        private DataTable dt = new DataTable();

        List<(Label, CheckBox)> lst = new System.Collections.Generic.List<(Label, CheckBox)>();
        
        public UC_NhanVien()
        {
            InitializeComponent();

            lst.Add((lbl_ESPRESSO, ckbESPRESSO));
            lst.Add((lbl_BACSIU, ckbBACSIU));
        }

        private void tinhTongTien(int chiPhi, int soLuongSP, ref int tongCong)
        {
            tongCong = chiPhi * soLuongSP;
        }

        private void pnlCaPheSua_Click(object sender, EventArgs e)
        {
            //_tenSP = "caphesua";
            //_chiPhi = 15000;
            //tinhTongTien(_chiPhi, _soLuongSP, ref _tongTien);

            //dt.Rows.Add(_tenSP, _chiPhi, _soLuongSP, _tongTien);

            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);
            //gvNLTaoThanhSP.DataSource = dataTable;
            //gvHoaDon.DataSource = 
        }
        private string TaoChuoiHoac() 
        {
            string dk = "";
            int n = lst.Count();
            for (int i=0;i<n-1;i++ )
            {
                if (lst[i].Item2.Checked == true)
                {
                    dk = dk + $"maSP = '{lst[i].Item1.Text}' or ";
                }
            }
           
            dk = dk.Substring(0, dk.Length - 3);
            return dk;
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            lst.Add((lbl_ESPRESSO,ckbESPRESSO));
            string dk = TaoChuoiHoac();
            if (dk == "") return;
            MessageBox.Show(dk);
            string sql = $"select * from SanPham where {dk}";
            
            gvHoaDon.DataSource = null;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvHoaDon.DataSource = dataTable;

                //doiTenHeader();
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
