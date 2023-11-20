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
        private string userName = null;
        private string passWord = null;
        public SqlConnection conn;

        public SQLServerConnection()
        {
        }

        public SQLServerConnection(string UserName, string PassWord)
        {
            this.userName = UserName;
            this.passWord = PassWord;
            conn = new SqlConnection(@"Data Source = GIAHANHUYNH; Initial Catalog = 
                ProjectQuanLyChuoiQuanCaPhe;User Id=" + this.userName + ";Password=" + this.passWord + ";");
        }

        public string UserName { get => this.userName; set => this.userName = value; }
        public string PassWord { get => this.passWord; set => this.passWord = value; }

        

        public void openConnection()
        {
            //MessageBox.Show(this.UserName + " " + this.PassWord);
            

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
