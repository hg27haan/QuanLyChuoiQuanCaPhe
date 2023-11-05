using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_Admin_DoiTac : UserControl
    {

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public UC_Admin_DoiTac()
        {
            InitializeComponent();
        }

        private void LoadDuLieu()
        {
            //Lay cac thong tin tu bang Account
            SqlCommand cmd = new SqlCommand("SELECT * FROM V_ThongTinNhaCungCapCoSo", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvDoiTac.DataSource = dt;


            //Doi ten cac cot
            gvDoiTac.Columns["maNCC"].HeaderText = "Mã nhà cung cấp";
            gvDoiTac.Columns["tenNguoiDaiDien"].HeaderText = "Tên người đại diện";
            gvDoiTac.Columns["soDienThoai"].HeaderText = "Số điện thoại";
            gvDoiTac.Columns["email"].HeaderText = "Email";
            gvDoiTac.Columns["tenCS"].HeaderText = "Tên cơ sở";
            gvDoiTac.Columns["tenNL"].HeaderText = "Tên nguyên liệu";
            gvDoiTac.Columns["tienHopDong"].HeaderText = "Tiền hợp đồng";
        }
        private void UC_Admin_DoiTac_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }
    }
}
