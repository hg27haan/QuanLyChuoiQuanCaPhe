using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChuoiQuanCaPhe
{
    internal class SQLServerConnection
    {
        private static string userName = null;
        private static string passWord = null;

        public SQLServerConnection()
        {
        }

        public SQLServerConnection(string UserName, string PassWord)
        {
            userName = UserName;
            passWord = PassWord;
        }

        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }

        public SqlConnection conn = new SqlConnection(@"Data Source = HARUTO\TRONGDUNG; Initial Catalog = 
            ProjectQuanLyChuoiQuanCaPhe;Integrated Security=True;User Id=" + userName + ";Password=" + passWord + ";");

        public void openConnection()
        {
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
