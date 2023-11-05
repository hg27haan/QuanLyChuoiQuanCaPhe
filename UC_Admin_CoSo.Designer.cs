namespace QuanLyChuoiQuanCaPhe
{
    partial class UC_Admin_CoSo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiaChiCS = new System.Windows.Forms.TextBox();
            this.txtTenCS = new System.Windows.Forms.TextBox();
            this.txtMaCS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gvCoSo = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnChinhSua = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCoSo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiaChiCS);
            this.groupBox1.Controls.Add(this.txtTenCS);
            this.groupBox1.Controls.Add(this.txtMaCS);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(384, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 162);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Về Cơ Sở";
            // 
            // txtDiaChiCS
            // 
            this.txtDiaChiCS.Location = new System.Drawing.Point(76, 105);
            this.txtDiaChiCS.Name = "txtDiaChiCS";
            this.txtDiaChiCS.Size = new System.Drawing.Size(195, 23);
            this.txtDiaChiCS.TabIndex = 5;
            // 
            // txtTenCS
            // 
            this.txtTenCS.Location = new System.Drawing.Point(96, 67);
            this.txtTenCS.Name = "txtTenCS";
            this.txtTenCS.Size = new System.Drawing.Size(196, 23);
            this.txtTenCS.TabIndex = 4;
            // 
            // txtMaCS
            // 
            this.txtMaCS.Location = new System.Drawing.Point(91, 29);
            this.txtMaCS.Name = "txtMaCS";
            this.txtMaCS.Size = new System.Drawing.Size(146, 23);
            this.txtMaCS.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa Chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Cơ Sở:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Cơ Sở:";
            // 
            // gvCoSo
            // 
            this.gvCoSo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCoSo.Location = new System.Drawing.Point(16, 19);
            this.gvCoSo.Name = "gvCoSo";
            this.gvCoSo.Size = new System.Drawing.Size(1067, 286);
            this.gvCoSo.TabIndex = 30;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoa.Location = new System.Drawing.Point(716, 522);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(0);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(209, 54);
            this.btnXoa.TabIndex = 34;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Chartreuse;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.Location = new System.Drawing.Point(445, 522);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(209, 54);
            this.btnThem.TabIndex = 33;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnChinhSua
            // 
            this.btnChinhSua.BackColor = System.Drawing.Color.DarkViolet;
            this.btnChinhSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChinhSua.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChinhSua.Location = new System.Drawing.Point(174, 522);
            this.btnChinhSua.Margin = new System.Windows.Forms.Padding(0);
            this.btnChinhSua.Name = "btnChinhSua";
            this.btnChinhSua.Size = new System.Drawing.Size(209, 54);
            this.btnChinhSua.TabIndex = 32;
            this.btnChinhSua.Text = "Chỉnh Sửa";
            this.btnChinhSua.UseVisualStyleBackColor = false;
            // 
            // UC_Admin_CoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvCoSo);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnChinhSua);
            this.Name = "UC_Admin_CoSo";
            this.Size = new System.Drawing.Size(1099, 595);
            this.Load += new System.EventHandler(this.UC_Admin_CoSo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCoSo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiaChiCS;
        private System.Windows.Forms.TextBox txtTenCS;
        private System.Windows.Forms.TextBox txtMaCS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvCoSo;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnChinhSua;
    }
}
