using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyChuoiQuanCaPhe
{
    public partial class UC_Admin_TienLuong : UserControl
    {
        SQLServerConnection sSC = new SQLServerConnection();

        private string dataUserName = null;
        private string dataPassword = null;
        private string dataPhanQuyen = null;
        private string dataMaCS = null;

        public UC_Admin_TienLuong(string dataUserName, string dataPassword, string dataPhanQuyen, string dataMaCS)
        {
            InitializeComponent();
            this.dataUserName = dataUserName;
            this.dataPassword = dataPassword;
            this.dataPhanQuyen = dataPhanQuyen;
            this.dataMaCS = dataMaCS;
            if (dataPhanQuyen == "ad")
            {
                txtMaCS.Enabled = true;
            }    
        }

        private void doiTenHeaderMucLuong()
        {
            gvMucLuong.Columns[0].HeaderText = "Mã Mức Lương";
            gvMucLuong.Columns[1].HeaderText = "Số Tiền";
        }

        private void loadMucLuong()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvMucLuong.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XemMucLuong", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvMucLuong.DataSource = dt;

                doiTenHeaderMucLuong();
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    MessageBox.Show("Lỗi SQLServer: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                sSC.closeConnection();
            }
        }

        private void UC_Admin_TienLuong_Load(object sender, EventArgs e)
        {
            loadMucLuong();
        }

        private void gvMucLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow = e.RowIndex;

            // Kiểm tra xem có hàng nào đang được chọn không
            if (numrow >= 0)
            {
                txtMaML.Text = gvMucLuong.Rows[numrow].Cells[0].Value.ToString();
                txtSoTien.Text = gvMucLuong.Rows[numrow].Cells[1].Value.ToString();
            }
        }

        private void btnSuaML_Click(object sender, EventArgs e)
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_SuaMucLuong", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@maML", txtMaML.Text);
                cmd.Parameters.AddWithValue("@soTien", txtSoTien.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Chỉnh sửa Số Tiền của Mức Lương thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    MessageBox.Show("Lỗi SQLServer: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                sSC.closeConnection();
            }
            loadMucLuong();
        }

        private void doiTenHeaderLuongNV()
        {
            gvLuongNhanVien.Columns[0].HeaderText = "Mã Cơ Sở";
            gvLuongNhanVien.Columns[1].HeaderText = "Mã Nhân Viên";
            gvLuongNhanVien.Columns[2].HeaderText = "Họ Và Tên";
            gvLuongNhanVien.Columns[3].HeaderText = "Mã Mức Lương";
            gvLuongNhanVien.Columns[4].HeaderText = "Số Tiền Lương";
        }

        private void loadLuongNV()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            gvLuongNhanVien.DataSource = null;
            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_XemNhanVienHuongLuong", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if(dataPhanQuyen=="ql")
                {
                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maCS", dataMaCS);

                    //query = string.Format("select *from V_NhanVienHuongLuong where maCS=N'{0}'", dataMaCS);
                }    
                else
                {
                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);

                    //query = string.Format("select *from V_NhanVienHuongLuong where maCS=N'{0}'", txtMaCS.Text);
                }
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvLuongNhanVien.DataSource = dt;

                doiTenHeaderMucLuong();
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    MessageBox.Show("Lỗi SQLServer: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                sSC.closeConnection();
            }
            doiTenHeaderLuongNV();
        }

        private void themVaoNhanVienHuongLuong()
        {
            sSC = new SQLServerConnection(dataUserName, dataPassword);

            try
            {
                sSC.openConnection();

                SqlCommand cmd = new SqlCommand("PROC_ThemNhanVienHuongLuong", sSC.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (dataPhanQuyen == "ql")
                {
                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maCS", dataMaCS);
                }    
                else
                {
                    // Thêm các tham số
                    cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                }    
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    MessageBox.Show("Lỗi SQLServer: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            finally
            {
                sSC.closeConnection();
            }
        }    

        private void btnXemLuongNV_Click(object sender, EventArgs e)
        {
            themVaoNhanVienHuongLuong();
            loadLuongNV();
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

        private void XuatRaPDF()
        {
            if (gvLuongNhanVien.DataSource == null)
            {
                MessageBox.Show("Bảng hiển thị dữ liệu Lương Nhân Viên đang bị rỗng", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                BaseFont baseFont = BaseFont.CreateFont("c:\\windows\\fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);
                Document doc = new Document(PageSize.A4, 30, 30, 30, 30);
                try
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog1.FilterIndex = 2;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PdfWriter.GetInstance(doc, new FileStream(saveFileDialog1.FileName, FileMode.Create));

                        doc.Open();

                        PdfPTable pdfTable = new PdfPTable(gvLuongNhanVien.ColumnCount);
                        pdfTable.DefaultCell.Padding = 3;
                        pdfTable.WidthPercentage = 100;
                        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                        foreach (DataGridViewColumn column in gvLuongNhanVien.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                            cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                            pdfTable.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in gvLuongNhanVien.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), font));
                                }
                            }
                        }

                        string title = "Chi tiết tiền lương của Nhân Viên tháng " + DateTime.Now.ToString("MM/yyyy");
                        doc.Add(new Paragraph(title));

                        doc.Add(pdfTable);

                        doc.Close();

                        MessageBox.Show("Tệp PDF đã được lưu thành công!", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btnTongKetLuong_Click(object sender, EventArgs e)
        {
            if(kiemTraCuoiThangSau23h00()==false) 
            {
                MessageBox.Show("Hãy đợi đến sau 23h00 cuối tháng để có thể tổng kết lương", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XuatRaPDF();

                sSC = new SQLServerConnection(dataUserName, dataPassword);

                try
                {
                    sSC.openConnection();

                    SqlCommand cmd = new SqlCommand("PROC_TongKetNhanVienHuongLuong", sSC.conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (dataPhanQuyen == "ql")
                    {
                        // Thêm các tham số
                        cmd.Parameters.AddWithValue("@maCS", dataMaCS);
                    }
                    else
                    {
                        // Thêm các tham số
                        cmd.Parameters.AddWithValue("@maCS", txtMaCS.Text);
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (ex is SqlException)
                    {
                        MessageBox.Show("Lỗi SQLServer: " + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                finally
                {
                    sSC.closeConnection();
                }
                themVaoNhanVienHuongLuong();
                loadLuongNV();
            }    
        }

        private void btnTimNV_Click(object sender, EventArgs e)
        {

        }
    }
}
