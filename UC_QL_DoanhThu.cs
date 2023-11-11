﻿using QuanLyChuoiQuanCaPhe;
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
    public partial class UC_QL_DoanhThu : UserControl
    {
        private SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);

        private string dataPhanQuyen = null;
        private string dataMaCS = null;

        private int vuaMoiTongKetNgay = 0;

        public UC_QL_DoanhThu(string dataPhanQuyen, string dataMaCS)
        {
            InitializeComponent();
            grbDoanhThu_Ngay.Text = string.Format("Doanh Thu Hôm Nay ({0})",DateTime.Now.ToString("dd/MM/yyyy"));
            this.dataPhanQuyen = dataPhanQuyen;
            this.dataMaCS = dataMaCS;
            if (dataPhanQuyen == "ad")
            {
                txtMaCS.Enabled = true;
            }    
        }

        public int LayDataBaseSoTienHoaDon()
        {
            int tongTien = 0;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT dbo.TinhTongTienHoaDon(@maCS)", conn);
                // Đặt giá trị tham số @maHoaDon
                if (dataPhanQuyen == "ql")
                {
                    command.Parameters.AddWithValue("@maCS", dataMaCS);
                }    
                else
                {
                    command.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                }    

                // Đặt kiểu dữ liệu trả về của hàm
                command.CommandType = CommandType.Text;

                // Thực thi câu lệnh và lấy kết quả
                tongTien = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return tongTien;
        }

        private void btnXemDoanhThu_Ngay_Click(object sender, EventArgs e)
        {
            if (vuaMoiTongKetNgay == 0)
            {
                UserControl uc_QL_DoanhThu_Ngay;
                if (dataPhanQuyen == "ql")
                {
                    uc_QL_DoanhThu_Ngay = new UC_QL_DoanhThu_Ngay(dataMaCS);
                }    
                else
                {
                    uc_QL_DoanhThu_Ngay = new UC_QL_DoanhThu_Ngay(txtMaCS.Text);
                }    
                pnlDoanhThu_Center.Controls.Clear();
                pnlDoanhThu_Center.Controls.Add(uc_QL_DoanhThu_Ngay);
                uc_QL_DoanhThu_Ngay.Dock = DockStyle.Fill;
                uc_QL_DoanhThu_Ngay.BringToFront();
                lblTongTienNgay.Text = LayDataBaseSoTienHoaDon().ToString() + " đ";
                grbDoanhThu_Ngay.Text = string.Format("Doanh Thu Hôm Nay ({0})", DateTime.Now.ToString("dd/MM/yyyy"));
            }    
            else
            {
                MessageBox.Show("Đã tổng kết doanh thu ngày hôm nay, hãy qua Doanh Thu Tháng để xem chi tiết!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private bool isPast11PM()
        {
            DateTime now = DateTime.Now;

            DateTime tenPM = now.Date.AddHours(23);

            if (now >= tenPM)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnTongKet_Ngay_Click(object sender, EventArgs e)
        {
            if(isPast11PM() == false)
            {
                MessageBox.Show("Lỗi: Chưa đến thời gian kết thúc ca!", "Cảnh báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
            else
            {
                DialogResult drl = MessageBox.Show("Bạn chắc chắc muốn tổng kết Doanh Thu hôm nay?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (drl == DialogResult.OK)
                {
                    try
                    {
                        vuaMoiTongKetNgay = 1;

                        string maDoanhThu = DateTime.Now.ToString("ddMMyyyy") + "_" + dataMaCS;
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("dbo.AddDoanhThuThang", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số
                        cmd.Parameters.AddWithValue("@maDoanhThu", maDoanhThu);
                        cmd.Parameters.AddWithValue("@maCS", dataMaCS);
                        cmd.Parameters.AddWithValue("@ngayDoanhThu", DateTime.Now.ToString("dd/MM/yyyy"));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tổng Kết Cuối Ca thành công!", "Thông báo",
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
            }    
        }

        public int LayDataBaseSoTienDoanhThu()
        {
            int tongTien = 0;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT dbo.TinhTongTienDoanhThu(@maCS)", conn);
                // Đặt giá trị tham số @maHoaDon
                if (dataPhanQuyen == "ql")
                {
                    command.Parameters.AddWithValue("@maCS", dataMaCS);
                }
                else
                {
                    command.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                }

                // Đặt kiểu dữ liệu trả về của hàm
                command.CommandType = CommandType.Text;

                // Thực thi câu lệnh và lấy kết quả
                tongTien = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return tongTien;
        }

        private void btnXemDoanhThu_Thang_Click(object sender, EventArgs e)
        {
            UserControl uc_QL_DoanhThu_Thang;
            if (dataPhanQuyen == "ql")
            {
                uc_QL_DoanhThu_Thang = new UC_QL_DoanhThu_Thang(dataMaCS);
            }
            else
            {
                uc_QL_DoanhThu_Thang = new UC_QL_DoanhThu_Thang(txtMaCS.Text);
            }
            pnlDoanhThu_Center.Controls.Clear();
            pnlDoanhThu_Center.Controls.Add(uc_QL_DoanhThu_Thang);
            uc_QL_DoanhThu_Thang.Dock = DockStyle.Fill;
            uc_QL_DoanhThu_Thang.BringToFront();
            lblTongTienThang.Text = LayDataBaseSoTienDoanhThu().ToString() + " đ";
        }

        private bool kiemTraCuoiThangSau23h00()
        {
            DateTime now = DateTime.Now;
            int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
            bool isLastDayOfMonth = now.Day == daysInMonth;

            if (isLastDayOfMonth == true && DateTime.Now > DateTime.Today.AddHours(23).AddMinutes(00))
            {
                return true;
            }
            return false;
        }

        private void btnTongKet_Thang_Click(object sender, EventArgs e)
        {
            if (kiemTraCuoiThangSau23h00() == false)
            {
                MessageBox.Show("Lỗi: Chưa đến thời gian chốt Doanh Thu Tháng!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult drl = MessageBox.Show("Bạn chắc chắn muốn tổng kết Doanh Thu cuối tháng?", "Thông báo",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (drl == DialogResult.OK)
                {
                    try
                    {
                        string maDoanhThu = DateTime.Now.ToString("ddMMyyyy") + "_" + dataMaCS;
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("dbo.TongKetDoanhThu", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số
                        if (dataPhanQuyen == "ql")
                        {
                            cmd.Parameters.AddWithValue("@maCS", dataMaCS);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                        }


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Tổng Kết Cuối Tháng thành công!", "Thông báo",
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
            }
        }
    }
}
