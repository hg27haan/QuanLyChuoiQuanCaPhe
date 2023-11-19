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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Admin_TienLuong));
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
            this.gvMucLuong.BackgroundColor = System.Drawing.Color.White;
            this.gvMucLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMucLuong.Location = new System.Drawing.Point(19, 43);
            this.gvMucLuong.Margin = new System.Windows.Forms.Padding(4);
            this.gvMucLuong.Name = "gvMucLuong";
            this.gvMucLuong.RowHeadersWidth = 51;
            this.gvMucLuong.Size = new System.Drawing.Size(320, 153);
            this.gvMucLuong.TabIndex = 0;
            this.gvMucLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMucLuong_CellClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bảng Mức Lương";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSuaML);
            this.groupBox1.Controls.Add(this.txtSoTien);
            this.groupBox1.Controls.Add(this.txtMaML);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 210);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(320, 188);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Mức Lương";
            // 
            // btnSuaML
            // 
            this.btnSuaML.Location = new System.Drawing.Point(63, 133);
            this.btnSuaML.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuaML.Name = "btnSuaML";
            this.btnSuaML.Size = new System.Drawing.Size(185, 47);
            this.btnSuaML.TabIndex = 3;
            this.btnSuaML.Text = "Sửa Số Tiền Lương";
            this.btnSuaML.UseVisualStyleBackColor = true;
            this.btnSuaML.Click += new System.EventHandler(this.btnSuaML_Click);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(93, 86);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(204, 27);
            this.txtSoTien.TabIndex = 3;
            // 
            // txtMaML
            // 
            this.txtMaML.Enabled = false;
            this.txtMaML.Location = new System.Drawing.Point(157, 34);
            this.txtMaML.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaML.Name = "txtMaML";
            this.txtMaML.Size = new System.Drawing.Size(140, 27);
            this.txtMaML.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số Tiền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Mức Lương:";
            // 
            // gvLuongNhanVien
            // 
            this.gvLuongNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvLuongNhanVien.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLuongNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLuongNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLuongNhanVien.Location = new System.Drawing.Point(385, 46);
            this.gvLuongNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.gvLuongNhanVien.Name = "gvLuongNhanVien";
            this.gvLuongNhanVien.RowHeadersWidth = 51;
            this.gvLuongNhanVien.Size = new System.Drawing.Size(1064, 666);
            this.gvLuongNhanVien.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(360, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(3, 677);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã Mức Lương:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(643, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(532, 31);
            this.label5.TabIndex = 5;
            this.label5.Text = "Bảng Nhân Viên Được Hưởng Lương";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaCS
            // 
            this.txtMaCS.Enabled = false;
            this.txtMaCS.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCS.Location = new System.Drawing.Point(163, 412);
            this.txtMaCS.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaCS.Name = "txtMaCS";
            this.txtMaCS.Size = new System.Drawing.Size(136, 27);
            this.txtMaCS.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(60, 416);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 21);
            this.label6.TabIndex = 6;
            this.label6.Text = "Mã Cơ Sở:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnTongKetLuong);
            this.groupBox2.Controls.Add(this.btnXemLuongNV);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(19, 459);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(320, 161);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhân Viên Được Hưởng Lương";
            // 
            // btnTongKetLuong
            // 
            this.btnTongKetLuong.Location = new System.Drawing.Point(51, 103);
            this.btnTongKetLuong.Margin = new System.Windows.Forms.Padding(4);
            this.btnTongKetLuong.Name = "btnTongKetLuong";
            this.btnTongKetLuong.Size = new System.Drawing.Size(219, 47);
            this.btnTongKetLuong.TabIndex = 5;
            this.btnTongKetLuong.Text = "Tổng Kết Lương";
            this.btnTongKetLuong.UseVisualStyleBackColor = true;
            this.btnTongKetLuong.Click += new System.EventHandler(this.btnTongKetLuong_Click);
            // 
            // btnXemLuongNV
            // 
            this.btnXemLuongNV.Location = new System.Drawing.Point(51, 39);
            this.btnXemLuongNV.Margin = new System.Windows.Forms.Padding(4);
            this.btnXemLuongNV.Name = "btnXemLuongNV";
            this.btnXemLuongNV.Size = new System.Drawing.Size(219, 47);
            this.btnXemLuongNV.TabIndex = 4;
            this.btnXemLuongNV.Text = "Xem Lương Nhân Viên";
            this.btnXemLuongNV.UseVisualStyleBackColor = true;
            this.btnXemLuongNV.Click += new System.EventHandler(this.btnXemLuongNV_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 633);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "Mã Nhân Viên:";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(155, 629);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(183, 27);
            this.txtMaNV.TabIndex = 10;
            // 
            // btnTimNV
            // 
            this.btnTimNV.BackColor = System.Drawing.Color.White;
            this.btnTimNV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimNV.Location = new System.Drawing.Point(69, 665);
            this.btnTimNV.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimNV.Name = "btnTimNV";
            this.btnTimNV.Size = new System.Drawing.Size(219, 47);
            this.btnTimNV.TabIndex = 11;
            this.btnTimNV.Text = "Tìm Nhân Viên";
            this.btnTimNV.UseVisualStyleBackColor = false;
            // 
            // UC_Admin_TienLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_Admin_TienLuong";
            this.Size = new System.Drawing.Size(1465, 732);
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
