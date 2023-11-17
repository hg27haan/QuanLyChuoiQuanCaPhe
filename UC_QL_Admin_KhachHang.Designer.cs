namespace QuanLyChuoiQuanCaPhe
{
    partial class UC_QL_Admin_KhachHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_QL_Admin_KhachHang));
            this.gvKhachHang = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtHoTenKH = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnSuaKH = new System.Windows.Forms.Button();
            this.btnXoaKH = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTimKH = new System.Windows.Forms.Button();
            this.txtTimSDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHienThiDanhSachKH = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvKhachHang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvKhachHang
            // 
            this.gvKhachHang.AllowUserToAddRows = false;
            this.gvKhachHang.AllowUserToDeleteRows = false;
            this.gvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvKhachHang.Location = new System.Drawing.Point(13, 207);
            this.gvKhachHang.MultiSelect = false;
            this.gvKhachHang.Name = "gvKhachHang";
            this.gvKhachHang.ReadOnly = true;
            this.gvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvKhachHang.Size = new System.Drawing.Size(1067, 376);
            this.gvKhachHang.TabIndex = 0;
            this.gvKhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvKhachHang_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnXoaKH);
            this.groupBox1.Controls.Add(this.txtSDT);
            this.groupBox1.Controls.Add(this.btnSuaKH);
            this.groupBox1.Controls.Add(this.txtHoTenKH);
            this.groupBox1.Controls.Add(this.txtMaKH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 177);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Khách Hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ Và Tên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Điện Thoại:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Enabled = false;
            this.txtMaKH.Location = new System.Drawing.Point(135, 30);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(189, 23);
            this.txtMaKH.TabIndex = 3;
            // 
            // txtHoTenKH
            // 
            this.txtHoTenKH.Location = new System.Drawing.Point(101, 65);
            this.txtHoTenKH.Name = "txtHoTenKH";
            this.txtHoTenKH.Size = new System.Drawing.Size(189, 23);
            this.txtHoTenKH.TabIndex = 4;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(123, 102);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(189, 23);
            this.txtSDT.TabIndex = 5;
            // 
            // btnSuaKH
            // 
            this.btnSuaKH.BackColor = System.Drawing.Color.Khaki;
            this.btnSuaKH.Location = new System.Drawing.Point(21, 131);
            this.btnSuaKH.Name = "btnSuaKH";
            this.btnSuaKH.Size = new System.Drawing.Size(188, 38);
            this.btnSuaKH.TabIndex = 2;
            this.btnSuaKH.Text = "Sửa Thông Tin Khách Hàng";
            this.btnSuaKH.UseVisualStyleBackColor = false;
            this.btnSuaKH.Click += new System.EventHandler(this.btnSuaKH_Click);
            // 
            // btnXoaKH
            // 
            this.btnXoaKH.BackColor = System.Drawing.Color.LightBlue;
            this.btnXoaKH.Location = new System.Drawing.Point(254, 131);
            this.btnXoaKH.Name = "btnXoaKH";
            this.btnXoaKH.Size = new System.Drawing.Size(139, 38);
            this.btnXoaKH.TabIndex = 3;
            this.btnXoaKH.Text = "Xóa Khách Hàng";
            this.btnXoaKH.UseVisualStyleBackColor = false;
            this.btnXoaKH.Click += new System.EventHandler(this.btnXoaKH_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnTimKH);
            this.groupBox2.Controls.Add(this.txtTimSDT);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(638, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 177);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Khách Hàng";
            // 
            // btnTimKH
            // 
            this.btnTimKH.BackColor = System.Drawing.Color.Fuchsia;
            this.btnTimKH.Location = new System.Drawing.Point(227, 133);
            this.btnTimKH.Name = "btnTimKH";
            this.btnTimKH.Size = new System.Drawing.Size(157, 38);
            this.btnTimKH.TabIndex = 3;
            this.btnTimKH.Text = "Tìm Kiếm Khách Hàng";
            this.btnTimKH.UseVisualStyleBackColor = false;
            this.btnTimKH.Click += new System.EventHandler(this.btnTimKH_Click);
            // 
            // txtTimSDT
            // 
            this.txtTimSDT.Location = new System.Drawing.Point(128, 46);
            this.txtTimSDT.Name = "txtTimSDT";
            this.txtTimSDT.Size = new System.Drawing.Size(189, 23);
            this.txtTimSDT.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số Điện Thoại:";
            // 
            // btnHienThiDanhSachKH
            // 
            this.btnHienThiDanhSachKH.BackColor = System.Drawing.Color.Chartreuse;
            this.btnHienThiDanhSachKH.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienThiDanhSachKH.Location = new System.Drawing.Point(450, 78);
            this.btnHienThiDanhSachKH.Name = "btnHienThiDanhSachKH";
            this.btnHienThiDanhSachKH.Size = new System.Drawing.Size(157, 57);
            this.btnHienThiDanhSachKH.TabIndex = 4;
            this.btnHienThiDanhSachKH.Text = "Hiển Thị Danh Sách Khách Hàng";
            this.btnHienThiDanhSachKH.UseVisualStyleBackColor = false;
            this.btnHienThiDanhSachKH.Click += new System.EventHandler(this.btnHienThiDanhSachKH_Click);
            // 
            // UC_QL_Admin_KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnHienThiDanhSachKH);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvKhachHang);
            this.Name = "UC_QL_Admin_KhachHang";
            this.Size = new System.Drawing.Size(1099, 595);
            this.Load += new System.EventHandler(this.UC_QL_Admin_KhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvKhachHang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvKhachHang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoaKH;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnSuaKH;
        private System.Windows.Forms.TextBox txtHoTenKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimKH;
        private System.Windows.Forms.TextBox txtTimSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHienThiDanhSachKH;
    }
}
