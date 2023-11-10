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
    public partial class UC_Admin_TienLuong : UserControl
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        List<int> luong = new List<int>();

        public UC_Admin_TienLuong()
        {
            InitializeComponent();

            
        }
    }
}
