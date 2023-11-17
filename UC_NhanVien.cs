using System;
using System.Collections;
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
        //private SqlConnection conn = new SqlConnection(@" Data Source = GIAHANHUYNH; Initial Catalog = ProjectQuanLyChuoiQuanCaPhe;User Id=" + un + ";Password=" + pw + ";");
        private SqlConnection conn =new SqlConnection(Properties.Settings.Default.connStr);
        private DataTable dt = new DataTable();

        List<(Label, CheckBox,TextBox)> lst = new System.Collections.Generic.List<(Label, CheckBox, TextBox)>();
        List<Int32> list_sLsanpham = new List<Int32>();
        //string TenCS = get_dataTenCS();

        private string dataMaCS;

        public UC_NhanVien(string dataMaCS)
        {
            InitializeComponent();

            lst.Add((lb_caphesua, cb_caphesua, txt_caphesua));
            lst.Add((lb_bacxiu, cb_bacxiu, txt_bacxiu));
            lst.Add((lb_espresso, cb_espresso, txt_espresso));
            lst.Add((lb_capheden, cb_capheden, txt_capheden));
            lst.Add((lb_americano, cb_americano, txt_americano));
            lst.Add((lb_capuchino, cb_capuchino, txt_capuchino));
            lst.Add((lb_lattedau, cb_lattedau, txt_lattedau));
            lst.Add((lb_lattekm, cb_lattekm, txt_lattekm));
            lst.Add((lb_lattemc, cb_lattemc, txt_lattemc));
            lst.Add((lb_latte, cb_latte, txt_latte));
            lst.Add((lb_trachanh, cb_trachanh, txt_trachanh));
            lst.Add((lb_tradao, cb_tradao, txt_tradao));
            lst.Add((lb_travai, cb_travai, txt_travai));
            lst.Add((lb_trasua, cb_trasua, txt_trasua));
            lst.Add((lb_cadx, cb_cadx, txt_cadx));
            lst.Add((lb_matchadx, cb_matchadx, txt_matchadx));
            lst.Add((lb_nuocsuoi, cb_nuocsuoi, txt_nuocsuoi));
            lst.Add((lb_tiramisu, cb_tiramisu, txt_tiramisu));
            lst.Add((lb_redvelvet, cb_redvelvet, txt_redvelvet));
            lst.Add((lb_macaron, cb_macaron, txt_macaron));
            lst.Add((lb_banhflan, cb_banhflan, txt_banhflan));
            this.dataMaCS = dataMaCS;

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
            for (int i=0;i<n;i++ )
            {
                if (lst[i].Item2.Checked == true)
                {
                    dk = dk + $"maSP = '{lst[i].Item1.Text}' or ";
                    list_sLsanpham.Add(Int32.Parse(lst[i].Item3.Text));
                }
            }
           
            dk = dk.Substring(0, dk.Length - 3);
            return dk;
        }
        
                
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            string dk = TaoChuoiHoac();
            if (dk == "") return;
            string sql = $"select * from SanPham where {dk}";
            
            gvHoaDon.DataSource = null;
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                //add column
                dataTable.Columns.Add("SL", typeof(System.Int32));
                int tong_tien = 0;
                //add value in column
                int n = list_sLsanpham.Count();
                if (n != 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        dataTable.Rows[i][3] = list_sLsanpham[i];
                        tong_tien += list_sLsanpham[i] * Int32.Parse(dataTable.Rows[i][2].ToString());
                    }
                }
                gvHoaDon.DataSource = dataTable;
                lblTongTienHoaDon.Text = tong_tien.ToString()+" dong";
                //doiTenHeader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                list_sLsanpham.Clear();
                conn.Close();
            }

        }

        private void picbBacXiu_Click(object sender, EventArgs e)
        {

        }

        private void bt_KhoiTaoMa_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = $"Select count(maHoaDon) from HoaDon";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                try
                {
                    lblMaHoaDon.Text = DateTime.Now.ToString("ddMMyyyy") + "_" 
                        + (Int32.Parse(dataTable.Rows[0][0].ToString())+1).ToString() 
                        + "_" + dataMaCS;
                }
                catch
                {
                    lblMaHoaDon.Text = DateTime.Now.ToString("ddMMyyyy") + "_" + 1.ToString() + "_" + dataMaCS;
                }

                //MessageBox.Show(dataTable.Rows[0][0].ToString());

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
        String maKH="";
        private void btnTimKiemKhachHang_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT *FROM TimKiemKhachHang(@soDienThoai)", conn);
                cmd.Parameters.AddWithValue("@soDienThoai", txtTimKiemSdt.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    /*lblTimMaKH.Text = reader["maKH"].ToString();*/
                    maKH = reader["maKH"].ToString();
                    lblTenKH.Text = reader["tenKH"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng này.");
                }
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

        private void btnMoi_Click(object sender, EventArgs e)
        {
            lblTongTienHoaDon.Text = "... đ";
            txtVoucher.Text = "";
            gvHoaDon.DataSource = "null";
            lblMaHoaDon.Text = "(mã hoá đơn)";
            txtTimKiemSdt.Text = "";
            int n = lst.Count();
            for (int i = 0; i < n; i++)
            {
                lst[i].Item3.Text = "1";
                lst[i].Item2.CheckState = CheckState.Unchecked;
            }
        }

        private void btnApDungVoucher_Click(object sender, EventArgs e)
        {
            string tong_tien = lblTongTienHoaDon.Text;
            tong_tien = tong_tien.Substring(0, tong_tien.Length - " dong".Length);
            string sql = $"SELECT * FROM Voucher WHERE nguongKichHoat<{tong_tien} ORDER BY  nguongKichHoat DESC";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                try
                {
                    txtVoucher.Text = dataTable.Rows[0][0].ToString();
                    tong_tien = (Int32.Parse(tong_tien) - Math.Floor(Double.Parse(tong_tien)* Double.Parse(dataTable.Rows[0][1].ToString())/100)).ToString();
                    lblTongTienHoaDon.Text = tong_tien+" dong";
                }
                catch
                {
                    MessageBox.Show("Khong the ap dung voucher vi chua du dieu kien");
                }
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

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            string tong_tien = lblTongTienHoaDon.Text;
            tong_tien = tong_tien.Substring(0, tong_tien.Length - " dong".Length);
            string sql = $"insert into HoaDon (maHoaDon,maCS,tongTien,maNV,maKH) values('{lblMaHoaDon.Text}','{dataMaCS}','{tong_tien}','{txtMaNV.Text}','{maKH.ToString()}');";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                //Add datatable
                try
                {
                    foreach (DataGridViewRow row in gvHoaDon.Rows)
                    {
                        //MessageBox.Show(row.Cells[0].Value.ToString());
                        sql = $"insert into SanPhamTrongHoaDon(maHoaDon,maSP,chiPhiSP,soLuongSP) values ('{lblMaHoaDon.Text}','{row.Cells[0].Value.ToString()}',{row.Cells[2].Value.ToString()},{row.Cells[3].Value.ToString()});";
                        cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch
                {

                }
                MessageBox.Show("Tạo Hóa Đơn thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.ThemMoiKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@tenKH", txtTenKhachHang.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSoDienThoai.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu Khách Hàng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
            finally
            {
                conn.Close();
            }
            loadKhachHang();
        }

        private void doiTenHeaderKhachHang()
        {
            gvKhachHang.Columns[0].HeaderText = "Mã Khách Hàng";
            gvKhachHang.Columns[0].HeaderText = "Tên Khách Hàng";
            gvKhachHang.Columns[0].HeaderText = "Số Điện Thoại";
        }

        private void loadKhachHang()
        {
            gvKhachHang.DataSource = null;
            try
            {
                conn.Open();

                string query = string.Format("select *from V_KhachHang");

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                gvKhachHang.DataSource = dataTable;

                doiTenHeaderKhachHang();
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

        private void tabpgKH_Click(object sender, EventArgs e)
        {
            loadKhachHang();
        }

        private void gvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;
            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaKhachHang.Text = gvKhachHang.Rows[numrow].Cells[0].Value.ToString();
                txtTenKhachHang.Text = gvKhachHang.Rows[numrow].Cells[1].Value.ToString();
                txtSoDienThoai.Text = gvKhachHang.Rows[numrow].Cells[2].Value.ToString();
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.SuaKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text);
                cmd.Parameters.AddWithValue("@tenKH", txtTenKhachHang.Text);
                cmd.Parameters.AddWithValue("@soDienThoai", txtSoDienThoai.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa dữ liệu Khách Hàng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            loadKhachHang();
        }

        private void tabctrlNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabctrlNhanVien.SelectedIndex == 0)
            {
                //LoadTrendingThueXe();
            }
            if (tabctrlNhanVien.SelectedIndex == 1)
            {
                loadKhachHang();
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.XoaKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maKH", txtMaKhachHang.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa dữ liệu Khách Hàng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            loadKhachHang();
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT *FROM TimKiemKhachHang(@soDienThoai)", conn);
                cmd.Parameters.AddWithValue("@soDienThoai", txtTimSoDienThoai.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblTimMaKH.Text = reader["maKH"].ToString();
                    lblTimTenKH.Text = reader["tenKH"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng này.");
                }
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

        private void pnlBacXiu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
