namespace QuanLyChuoiQuanCaPhe
{
    partial class UC_QL_DoanhThu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QL_DoanhThu));
            this.pnlDoanhThu_Center = new System.Windows.Forms.Panel();
            this.grbDoanhThu_Ngay = new System.Windows.Forms.GroupBox();
            this.btnTongKet_Ngay = new System.Windows.Forms.Button();
            this.btnXemDoanhThu_Ngay = new System.Windows.Forms.Button();
            this.grbDoanhThu_Thang = new System.Windows.Forms.GroupBox();
            this.btnTongKet_Thang = new System.Windows.Forms.Button();
            this.btnXemDoanhThu_Thang = new System.Windows.Forms.Button();
            this.lblTongTienNgay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTongTienThang = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaCS = new System.Windows.Forms.TextBox();
            this.grbDoanhThu_Ngay.SuspendLayout();
            this.grbDoanhThu_Thang.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDoanhThu_Center
            // 
            this.pnlDoanhThu_Center.BackColor = System.Drawing.Color.White;
            this.pnlDoanhThu_Center.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDoanhThu_Center.Location = new System.Drawing.Point(12, 46);
            this.pnlDoanhThu_Center.Name = "pnlDoanhThu_Center";
            this.pnlDoanhThu_Center.Size = new System.Drawing.Size(1074, 367);
            this.pnlDoanhThu_Center.TabIndex = 0;
            // 
            // grbDoanhThu_Ngay
            // 
            this.grbDoanhThu_Ngay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grbDoanhThu_Ngay.BackgroundImage")));
            this.grbDoanhThu_Ngay.Controls.Add(this.btnTongKet_Ngay);
            this.grbDoanhThu_Ngay.Controls.Add(this.btnXemDoanhThu_Ngay);
            this.grbDoanhThu_Ngay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDoanhThu_Ngay.Location = new System.Drawing.Point(105, 427);
            this.grbDoanhThu_Ngay.Name = "grbDoanhThu_Ngay";
            this.grbDoanhThu_Ngay.Size = new System.Drawing.Size(232, 155);
            this.grbDoanhThu_Ngay.TabIndex = 1;
            this.grbDoanhThu_Ngay.TabStop = false;
            this.grbDoanhThu_Ngay.Text = "Doanh Thu Hôm Nay";
            // 
            // btnTongKet_Ngay
            // 
            this.btnTongKet_Ngay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTongKet_Ngay.Location = new System.Drawing.Point(25, 97);
            this.btnTongKet_Ngay.Name = "btnTongKet_Ngay";
            this.btnTongKet_Ngay.Size = new System.Drawing.Size(183, 49);
            this.btnTongKet_Ngay.TabIndex = 3;
            this.btnTongKet_Ngay.Text = "Tổng Kết Cuối Ngày";
            this.btnTongKet_Ngay.UseVisualStyleBackColor = false;
            this.btnTongKet_Ngay.Click += new System.EventHandler(this.btnTongKet_Ngay_Click);
            // 
            // btnXemDoanhThu_Ngay
            // 
            this.btnXemDoanhThu_Ngay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnXemDoanhThu_Ngay.Location = new System.Drawing.Point(25, 35);
            this.btnXemDoanhThu_Ngay.Name = "btnXemDoanhThu_Ngay";
            this.btnXemDoanhThu_Ngay.Size = new System.Drawing.Size(183, 49);
            this.btnXemDoanhThu_Ngay.TabIndex = 0;
            this.btnXemDoanhThu_Ngay.Text = "Xem Doanh Thu Hôm Nay";
            this.btnXemDoanhThu_Ngay.UseVisualStyleBackColor = false;
            this.btnXemDoanhThu_Ngay.Click += new System.EventHandler(this.btnXemDoanhThu_Ngay_Click);
            // 
            // grbDoanhThu_Thang
            // 
            this.grbDoanhThu_Thang.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("grbDoanhThu_Thang.BackgroundImage")));
            this.grbDoanhThu_Thang.Controls.Add(this.btnTongKet_Thang);
            this.grbDoanhThu_Thang.Controls.Add(this.btnXemDoanhThu_Thang);
            this.grbDoanhThu_Thang.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDoanhThu_Thang.Location = new System.Drawing.Point(640, 427);
            this.grbDoanhThu_Thang.Name = "grbDoanhThu_Thang";
            this.grbDoanhThu_Thang.Size = new System.Drawing.Size(232, 155);
            this.grbDoanhThu_Thang.TabIndex = 2;
            this.grbDoanhThu_Thang.TabStop = false;
            this.grbDoanhThu_Thang.Text = "Doanh Thu Tháng Này";
            // 
            // btnTongKet_Thang
            // 
            this.btnTongKet_Thang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTongKet_Thang.Location = new System.Drawing.Point(25, 97);
            this.btnTongKet_Thang.Name = "btnTongKet_Thang";
            this.btnTongKet_Thang.Size = new System.Drawing.Size(183, 49);
            this.btnTongKet_Thang.TabIndex = 3;
            this.btnTongKet_Thang.Text = "Tổng Kết Cuối Tháng";
            this.btnTongKet_Thang.UseVisualStyleBackColor = false;
            this.btnTongKet_Thang.Click += new System.EventHandler(this.btnTongKet_Thang_Click);
            // 
            // btnXemDoanhThu_Thang
            // 
            this.btnXemDoanhThu_Thang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnXemDoanhThu_Thang.Location = new System.Drawing.Point(25, 35);
            this.btnXemDoanhThu_Thang.Name = "btnXemDoanhThu_Thang";
            this.btnXemDoanhThu_Thang.Size = new System.Drawing.Size(183, 49);
            this.btnXemDoanhThu_Thang.TabIndex = 0;
            this.btnXemDoanhThu_Thang.Text = "Xem Doanh Thu Tháng";
            this.btnXemDoanhThu_Thang.UseVisualStyleBackColor = false;
            this.btnXemDoanhThu_Thang.Click += new System.EventHandler(this.btnXemDoanhThu_Thang_Click);
            // 
            // lblTongTienNgay
            // 
            this.lblTongTienNgay.AutoSize = true;
            this.lblTongTienNgay.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienNgay.ForeColor = System.Drawing.Color.Red;
            this.lblTongTienNgay.Location = new System.Drawing.Point(353, 488);
            this.lblTongTienNgay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTienNgay.Name = "lblTongTienNgay";
            this.lblTongTienNgay.Size = new System.Drawing.Size(0, 23);
            this.lblTongTienNgay.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(353, 447);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tổng Cộng:";
            // 
            // lblTongTienThang
            // 
            this.lblTongTienThang.AutoSize = true;
            this.lblTongTienThang.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienThang.ForeColor = System.Drawing.Color.Red;
            this.lblTongTienThang.Location = new System.Drawing.Point(920, 488);
            this.lblTongTienThang.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongTienThang.Name = "lblTongTienThang";
            this.lblTongTienThang.Size = new System.Drawing.Size(0, 23);
            this.lblTongTienThang.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(920, 447);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tổng Cộng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(445, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mã Cơ Sở:";
            // 
            // txtMaCS
            // 
            this.txtMaCS.Enabled = false;
            this.txtMaCS.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCS.Location = new System.Drawing.Point(522, 16);
            this.txtMaCS.Name = "txtMaCS";
            this.txtMaCS.Size = new System.Drawing.Size(132, 23);
            this.txtMaCS.TabIndex = 9;
            // 
            // UC_QL_DoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtMaCS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTongTienThang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTongTienNgay);
            this.Controls.Add(this.grbDoanhThu_Thang);
            this.Controls.Add(this.grbDoanhThu_Ngay);
            this.Controls.Add(this.pnlDoanhThu_Center);
            this.DoubleBuffered = true;
            this.Name = "UC_QL_DoanhThu";
            this.Size = new System.Drawing.Size(1099, 595);
            this.grbDoanhThu_Ngay.ResumeLayout(false);
            this.grbDoanhThu_Thang.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDoanhThu_Center;
        private System.Windows.Forms.GroupBox grbDoanhThu_Ngay;
        private System.Windows.Forms.Button btnXemDoanhThu_Ngay;
        private System.Windows.Forms.Button btnTongKet_Ngay;
        private System.Windows.Forms.GroupBox grbDoanhThu_Thang;
        private System.Windows.Forms.Button btnTongKet_Thang;
        private System.Windows.Forms.Button btnXemDoanhThu_Thang;
        private System.Windows.Forms.Label lblTongTienNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTongTienThang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaCS;
    }
}
