namespace QuanLyChuoiQuanCaPhe
{
    partial class UC_Admin_TienLuong
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
            this.gvMucLuong = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSuaML = new System.Windows.Forms.Button();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.txtMaML = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gvLuongNhanVien = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaCS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTongKetLuong = new System.Windows.Forms.Button();
            this.btnXemLuongNV = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.btnTimNV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvMucLuong)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLuongNhanVien)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvMucLuong
            // 
            this.gvMucLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMucLuong.Location = new System.Drawing.Point(14, 35);
            this.gvMucLuong.Name = "gvMucLuong";
            this.gvMucLuong.Size = new System.Drawing.Size(240, 150);
            this.gvMucLuong.TabIndex = 0;
            this.gvMucLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMucLuong_CellClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bảng Mức Lương";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSuaML);
            this.groupBox1.Controls.Add(this.txtSoTien);
            this.groupBox1.Controls.Add(this.txtMaML);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 199);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 153);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Mức Lương";
            // 
            // btnSuaML
            // 
            this.btnSuaML.Location = new System.Drawing.Point(47, 108);
            this.btnSuaML.Name = "btnSuaML";
            this.btnSuaML.Size = new System.Drawing.Size(139, 38);
            this.btnSuaML.TabIndex = 3;
            this.btnSuaML.Text = "Sửa Số Tiền Lương";
            this.btnSuaML.UseVisualStyleBackColor = true;
            this.btnSuaML.Click += new System.EventHandler(this.btnSuaML_Click);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Enabled = false;
            this.txtSoTien.Location = new System.Drawing.Point(70, 70);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(154, 23);
            this.txtSoTien.TabIndex = 3;
            // 
            // txtMaML
            // 
            this.txtMaML.Enabled = false;
            this.txtMaML.Location = new System.Drawing.Point(118, 28);
            this.txtMaML.Name = "txtMaML";
            this.txtMaML.Size = new System.Drawing.Size(106, 23);
            this.txtMaML.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số Tiền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Mức Lương:";
            // 
            // gvLuongNhanVien
            // 
            this.gvLuongNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLuongNhanVien.Location = new System.Drawing.Point(287, 35);
            this.gvLuongNhanVien.Name = "gvLuongNhanVien";
            this.gvLuongNhanVien.Size = new System.Drawing.Size(900, 573);
            this.gvLuongNhanVien.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(270, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(2, 573);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã Mức Lương:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(287, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(900, 23);
            this.label5.TabIndex = 5;
            this.label5.Text = "Bảng Nhân Viên Được Hưởng Lương";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaCS
            // 
            this.txtMaCS.Enabled = false;
            this.txtMaCS.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCS.Location = new System.Drawing.Point(122, 363);
            this.txtMaCS.Name = "txtMaCS";
            this.txtMaCS.Size = new System.Drawing.Size(103, 23);
            this.txtMaCS.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mã Cơ Sở:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnTongKetLuong);
            this.groupBox2.Controls.Add(this.btnXemLuongNV);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 401);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(240, 131);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhân Viên Được Hưởng Lương";
            // 
            // btnTongKetLuong
            // 
            this.btnTongKetLuong.Location = new System.Drawing.Point(38, 84);
            this.btnTongKetLuong.Name = "btnTongKetLuong";
            this.btnTongKetLuong.Size = new System.Drawing.Size(164, 38);
            this.btnTongKetLuong.TabIndex = 5;
            this.btnTongKetLuong.Text = "Tổng Kết Lương";
            this.btnTongKetLuong.UseVisualStyleBackColor = true;
            // 
            // btnXemLuongNV
            // 
            this.btnXemLuongNV.Location = new System.Drawing.Point(38, 32);
            this.btnXemLuongNV.Name = "btnXemLuongNV";
            this.btnXemLuongNV.Size = new System.Drawing.Size(164, 38);
            this.btnXemLuongNV.TabIndex = 4;
            this.btnXemLuongNV.Text = "Xem Lương Nhân Viên";
            this.btnXemLuongNV.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 547);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Mã Nhân Viên:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(116, 544);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(138, 23);
            this.txtMaNV.TabIndex = 10;
            // 
            // btnTimNV
            // 
            this.btnTimNV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimNV.Location = new System.Drawing.Point(52, 573);
            this.btnTimNV.Name = "btnTimNV";
            this.btnTimNV.Size = new System.Drawing.Size(164, 38);
            this.btnTimNV.TabIndex = 11;
            this.btnTimNV.Text = "Tìm Nhân Viên";
            this.btnTimNV.UseVisualStyleBackColor = true;
            // 
            // UC_Admin_TienLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTimNV);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMaCS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gvLuongNhanVien);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvMucLuong);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UC_Admin_TienLuong";
            this.Size = new System.Drawing.Size(1201, 623);
            this.Load += new System.EventHandler(this.UC_Admin_TienLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMucLuong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLuongNhanVien)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvMucLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSuaML;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TextBox txtMaML;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvLuongNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaCS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTongKetLuong;
        private System.Windows.Forms.Button btnXemLuongNV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Button btnTimNV;
    }
}
