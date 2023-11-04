namespace Quan_Ly_Quan_Ca_Phe
{
    partial class UC_QL_Voucher
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
            this.gvVoucher = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaVoucher = new System.Windows.Forms.TextBox();
            this.txtGiam = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoLuongCon = new System.Windows.Forms.TextBox();
            this.txtDieuKienMuaBan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDieuKienThuong = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.btnThemVoucher = new System.Windows.Forms.Button();
            this.btnXoaVoucher = new System.Windows.Forms.Button();
            this.btnSuaVoucher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvVoucher)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvVoucher
            // 
            this.gvVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvVoucher.Location = new System.Drawing.Point(13, 13);
            this.gvVoucher.Name = "gvVoucher";
            this.gvVoucher.Size = new System.Drawing.Size(603, 566);
            this.gvVoucher.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDieuKienThuong);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDieuKienMuaBan);
            this.groupBox1.Controls.Add(this.txtSoLuongCon);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGiam);
            this.groupBox1.Controls.Add(this.txtMaVoucher);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(639, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 369);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Voucher";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Voucher:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "(%) Giảm:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Lượng Còn:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Điều Kiện Mua Bán:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Điều KiệnThưởng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mã Nhân Viên (Tạo Ra Voucher):";
            // 
            // txtMaVoucher
            // 
            this.txtMaVoucher.Location = new System.Drawing.Point(135, 35);
            this.txtMaVoucher.Name = "txtMaVoucher";
            this.txtMaVoucher.Size = new System.Drawing.Size(156, 23);
            this.txtMaVoucher.TabIndex = 6;
            // 
            // txtGiam
            // 
            this.txtGiam.Location = new System.Drawing.Point(135, 90);
            this.txtGiam.Name = "txtGiam";
            this.txtGiam.Size = new System.Drawing.Size(81, 23);
            this.txtGiam.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(222, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "(%)";
            // 
            // txtSoLuongCon
            // 
            this.txtSoLuongCon.Location = new System.Drawing.Point(146, 148);
            this.txtSoLuongCon.Name = "txtSoLuongCon";
            this.txtSoLuongCon.Size = new System.Drawing.Size(91, 23);
            this.txtSoLuongCon.TabIndex = 9;
            // 
            // txtDieuKienMuaBan
            // 
            this.txtDieuKienMuaBan.Location = new System.Drawing.Point(177, 206);
            this.txtDieuKienMuaBan.Name = "txtDieuKienMuaBan";
            this.txtDieuKienMuaBan.Size = new System.Drawing.Size(124, 23);
            this.txtDieuKienMuaBan.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "(đồng)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(296, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "(hóa đơn)";
            // 
            // txtDieuKienThuong
            // 
            this.txtDieuKienThuong.Location = new System.Drawing.Point(166, 266);
            this.txtDieuKienThuong.Name = "txtDieuKienThuong";
            this.txtDieuKienThuong.Size = new System.Drawing.Size(124, 23);
            this.txtDieuKienThuong.TabIndex = 12;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(263, 324);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(124, 23);
            this.txtMaNV.TabIndex = 14;
            // 
            // btnThemVoucher
            // 
            this.btnThemVoucher.BackColor = System.Drawing.Color.Red;
            this.btnThemVoucher.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemVoucher.Location = new System.Drawing.Point(659, 408);
            this.btnThemVoucher.Name = "btnThemVoucher";
            this.btnThemVoucher.Size = new System.Drawing.Size(164, 68);
            this.btnThemVoucher.TabIndex = 2;
            this.btnThemVoucher.Text = "Thêm Voucher";
            this.btnThemVoucher.UseVisualStyleBackColor = false;
            // 
            // btnXoaVoucher
            // 
            this.btnXoaVoucher.BackColor = System.Drawing.Color.Yellow;
            this.btnXoaVoucher.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaVoucher.Location = new System.Drawing.Point(906, 408);
            this.btnXoaVoucher.Name = "btnXoaVoucher";
            this.btnXoaVoucher.Size = new System.Drawing.Size(164, 68);
            this.btnXoaVoucher.TabIndex = 3;
            this.btnXoaVoucher.Text = "Xóa Voucher";
            this.btnXoaVoucher.UseVisualStyleBackColor = false;
            // 
            // btnSuaVoucher
            // 
            this.btnSuaVoucher.BackColor = System.Drawing.Color.Lime;
            this.btnSuaVoucher.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaVoucher.Location = new System.Drawing.Point(785, 504);
            this.btnSuaVoucher.Name = "btnSuaVoucher";
            this.btnSuaVoucher.Size = new System.Drawing.Size(164, 68);
            this.btnSuaVoucher.TabIndex = 4;
            this.btnSuaVoucher.Text = "Sửa Thông Tin Voucher";
            this.btnSuaVoucher.UseVisualStyleBackColor = false;
            // 
            // UC_QL_Voucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSuaVoucher);
            this.Controls.Add(this.btnXoaVoucher);
            this.Controls.Add(this.btnThemVoucher);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvVoucher);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UC_QL_Voucher";
            this.Size = new System.Drawing.Size(1099, 595);
            ((System.ComponentModel.ISupportInitialize)(this.gvVoucher)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvVoucher;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDieuKienThuong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDieuKienMuaBan;
        private System.Windows.Forms.TextBox txtSoLuongCon;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiam;
        private System.Windows.Forms.TextBox txtMaVoucher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemVoucher;
        private System.Windows.Forms.Button btnXoaVoucher;
        private System.Windows.Forms.Button btnSuaVoucher;
    }
}
