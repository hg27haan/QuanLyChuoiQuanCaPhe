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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_QL_Voucher : UserControl
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        public UC_QL_Voucher()
        {
            InitializeComponent();
        }

        private void LoadDuLieu()
        {
            //Lay cac thong tin tu bang Account
            SqlCommand cmd = new SqlCommand("SELECT * FROM V_Voucher", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvVoucher.DataSource = dt;


            //Doi ten cac cot
            gvVoucher.Columns["maVoucher"].HeaderText = "Mã voucher";
            gvVoucher.Columns["phanTramGiam"].HeaderText = "Phần trăm giảm";
            gvVoucher.Columns["nguongKichHoat"].HeaderText = "Ngưỡng kích hoạt";
            gvVoucher.Columns["ngayHan"].HeaderText = "Ngày hạn";

        }
        private void UC_QL_Voucher_Load(object sender, EventArgs e)
        {
            LoadDuLieu();
        }

        private void gvVoucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaVoucher.Text = gvVoucher.Rows[numrow].Cells[0].Value.ToString();
                txtGiam.Text = gvVoucher.Rows[numrow].Cells[1].Value.ToString();
                txtNguongKichHoat.Text = gvVoucher.Rows[numrow].Cells[2].Value.ToString();
                //dtpNgayHan.Text = gvVoucher.Rows[numrow].Cells[3].Value.ToString();
                DateTime selectedDate;

                if (DateTime.TryParse(gvVoucher.Rows[numrow].Cells[3].Value.ToString(), out selectedDate))
                {
                    // Nếu giá trị nhập vào là ngày tháng hợp lệ, đặt giá trị cho DateTimePicker
                    dtpNgayHan.Value = selectedDate;
                }
            }
           
        }

        private void btnThemVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemVoucher", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maVoucher", txtMaVoucher.Text);
                cmd.Parameters.AddWithValue("@phanTramGiam", txtGiam.Text);
                cmd.Parameters.AddWithValue("@nguongKichHoat", txtNguongKichHoat.Text);
                cmd.Parameters.AddWithValue("@ngayHan", dtpNgayHan.Value.ToString("MM/dd/yyyy"));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Voucher mới thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            LoadDuLieu();
        }

        private void btnXoaVoucher_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaThuCongVoucher", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maVoucher", txtMaVoucher.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xoá dữ liệu Voucher mới thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            LoadDuLieu();
        }
    }
}
