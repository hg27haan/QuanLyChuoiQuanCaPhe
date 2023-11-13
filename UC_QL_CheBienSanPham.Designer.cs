namespace QuanLyChuoiQuanCaPhe
{
    partial class UC_QL_CheBienSanPham
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
            this.gvNLTaoThanhSP = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSoLuongNLCan = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.txtMaNL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSuaThongTin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvNLTaoThanhSP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvNLTaoThanhSP
            // 
            this.gvNLTaoThanhSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvNLTaoThanhSP.Location = new System.Drawing.Point(10, 10);
            this.gvNLTaoThanhSP.Name = "gvNLTaoThanhSP";
            this.gvNLTaoThanhSP.Size = new System.Drawing.Size(630, 574);
            this.gvNLTaoThanhSP.TabIndex = 0;
            this.gvNLTaoThanhSP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvNLTaoThanhSP_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSoLuongNLCan);
            this.groupBox1.Controls.Add(this.txtMaSP);
            this.groupBox1.Controls.Add(this.txtMaNL);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(661, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 176);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nguyên Liệu Làm Ra Sản Phẩm";
            // 
            // txtSoLuongNLCan
            // 
            this.txtSoLuongNLCan.Enabled = false;
            this.txtSoLuongNLCan.Location = new System.Drawing.Point(215, 117);
            this.txtSoLuongNLCan.Name = "txtSoLuongNLCan";
            this.txtSoLuongNLCan.Size = new System.Drawing.Size(97, 23);
            this.txtSoLuongNLCan.TabIndex = 5;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Enabled = false;
            this.txtMaSP.Location = new System.Drawing.Point(131, 76);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(146, 23);
            this.txtMaSP.TabIndex = 4;
            // 
            // txtMaNL
            // 
            this.txtMaNL.Enabled = false;
            this.txtMaNL.Location = new System.Drawing.Point(146, 39);
            this.txtMaNL.Name = "txtMaNL";
            this.txtMaNL.Size = new System.Drawing.Size(131, 23);
            this.txtMaNL.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Lượng Nguyên Liệu Cần:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Sản Phẩm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Nguyên Liệu:";
            // 
            // btnSuaThongTin
            // 
            this.btnSuaThongTin.BackColor = System.Drawing.Color.Yellow;
            this.btnSuaThongTin.Enabled = false;
            this.btnSuaThongTin.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaThongTin.Location = new System.Drawing.Point(792, 373);
            this.btnSuaThongTin.Name = "btnSuaThongTin";
            this.btnSuaThongTin.Size = new System.Drawing.Size(169, 65);
            this.btnSuaThongTin.TabIndex = 6;
            this.btnSuaThongTin.Text = "Chỉnh Sửa Thành Phần Sản Phẩm";
            this.btnSuaThongTin.UseVisualStyleBackColor = false;
            this.btnSuaThongTin.Click += new System.EventHandler(this.btnSuaThongTin_Click);
            // 
            // UC_QL_CheBienSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSuaThongTin);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvNLTaoThanhSP);
            this.Name = "UC_QL_CheBienSanPham";
            this.Size = new System.Drawing.Size(1099, 595);
            ((System.ComponentModel.ISupportInitialize)(this.gvNLTaoThanhSP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvNLTaoThanhSP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSoLuongNLCan;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.TextBox txtMaNL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSuaThongTin;
    }
}
