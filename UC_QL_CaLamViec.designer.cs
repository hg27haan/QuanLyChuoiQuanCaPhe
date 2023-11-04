namespace QuanLyChuoiQuanCaPhe
{
    partial class UC_QL_CaLamViec
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
            this.gvCaLamViec = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMaCLV = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dptNgayLam = new System.Windows.Forms.DateTimePicker();
            this.btnSuaCLV = new System.Windows.Forms.Button();
            this.btnXoaCLV = new System.Windows.Forms.Button();
            this.btnThemCLV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvCaLamViec)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvCaLamViec
            // 
            this.gvCaLamViec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCaLamViec.Location = new System.Drawing.Point(13, 13);
            this.gvCaLamViec.Name = "gvCaLamViec";
            this.gvCaLamViec.Size = new System.Drawing.Size(1073, 327);
            this.gvCaLamViec.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dptNgayLam);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaCLV);
            this.groupBox1.Controls.Add(this.txtMaNV);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 365);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 213);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Ca Làm";
            // 
            // txtMaCLV
            // 
            this.txtMaCLV.Location = new System.Drawing.Point(124, 123);
            this.txtMaCLV.Name = "txtMaCLV";
            this.txtMaCLV.Size = new System.Drawing.Size(190, 23);
            this.txtMaCLV.TabIndex = 8;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(124, 59);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(190, 23);
            this.txtMaNV.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Ca Làm Việc:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Nhân Viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ngày Làm:";
            // 
            // dptNgayLam
            // 
            this.dptNgayLam.Location = new System.Drawing.Point(344, 44);
            this.dptNgayLam.Name = "dptNgayLam";
            this.dptNgayLam.Size = new System.Drawing.Size(271, 23);
            this.dptNgayLam.TabIndex = 10;
            // 
            // btnSuaCLV
            // 
            this.btnSuaCLV.BackColor = System.Drawing.Color.Lime;
            this.btnSuaCLV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaCLV.Location = new System.Drawing.Point(778, 470);
            this.btnSuaCLV.Name = "btnSuaCLV";
            this.btnSuaCLV.Size = new System.Drawing.Size(229, 78);
            this.btnSuaCLV.TabIndex = 7;
            this.btnSuaCLV.Text = "Sửa Thông Tin Ca Làm Việc Của Nhân Viên";
            this.btnSuaCLV.UseVisualStyleBackColor = false;
            // 
            // btnXoaCLV
            // 
            this.btnXoaCLV.BackColor = System.Drawing.Color.Yellow;
            this.btnXoaCLV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaCLV.Location = new System.Drawing.Point(924, 369);
            this.btnXoaCLV.Name = "btnXoaCLV";
            this.btnXoaCLV.Size = new System.Drawing.Size(135, 77);
            this.btnXoaCLV.TabIndex = 6;
            this.btnXoaCLV.Text = "Xóa Ca Làm Việc Của Nhân Viên";
            this.btnXoaCLV.UseVisualStyleBackColor = false;
            // 
            // btnThemCLV
            // 
            this.btnThemCLV.BackColor = System.Drawing.Color.Red;
            this.btnThemCLV.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCLV.ForeColor = System.Drawing.Color.White;
            this.btnThemCLV.Location = new System.Drawing.Point(724, 369);
            this.btnThemCLV.Name = "btnThemCLV";
            this.btnThemCLV.Size = new System.Drawing.Size(135, 78);
            this.btnThemCLV.TabIndex = 5;
            this.btnThemCLV.Text = "Thêm Ca Làm Việc Cho Nhân Viên";
            this.btnThemCLV.UseVisualStyleBackColor = false;
            // 
            // UC_QL_CaLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSuaCLV);
            this.Controls.Add(this.btnXoaCLV);
            this.Controls.Add(this.btnThemCLV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvCaLamViec);
            this.Name = "UC_QL_CaLamViec";
            this.Size = new System.Drawing.Size(1099, 595);
            ((System.ComponentModel.ISupportInitialize)(this.gvCaLamViec)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvCaLamViec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dptNgayLam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaCLV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuaCLV;
        private System.Windows.Forms.Button btnXoaCLV;
        private System.Windows.Forms.Button btnThemCLV;
    }
}
