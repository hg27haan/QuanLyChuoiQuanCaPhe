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

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_Admin_CoSo : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public UC_Admin_CoSo()
        {
            InitializeComponent();
        }

        private void UC_Admin_CoSo_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemMoiCoSo", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                cmd.Parameters.AddWithValue("@tenCS", txtTenCS.Text);
                cmd.Parameters.AddWithValue("@diaChiCS", txtDiaChiCS.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Cơ Sở mới thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex) 
            { 
                MessageBox.Show("Lỗi: "+ex.Message,"Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
