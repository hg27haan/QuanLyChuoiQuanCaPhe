using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChuoiQuanCaPhe
{
    internal class DBConnection : UC_DangNhap
    {
       
        
        public void hahhaa()
        {
            string huhu;
          /*  UserControl nguqua = new UC_DangNhap();
            nguqua.LayHam();*/
            Class1 huhuhuhu = new Class1();
            huhuhuhu.LayHam();
            SqlConnection conn = new SqlConnection(@"Data Source = GIAHANHUYNH; Initial Catalog = ProjectQuanLyChuoiQuanCaPhe;User Id=" +  + ";Password=" + pw + ";");
        }
    }
}
