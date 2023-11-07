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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaML = new System.Windows.Forms.TextBox();
            this.txtTienLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSuaTienLuong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvMucLuong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvMucLuong
            // 
            this.gvMucLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMucLuong.Location = new System.Drawing.Point(16, 23);
            this.gvMucLuong.Name = "gvMucLuong";
            this.gvMucLuong.RowHeadersWidth = 51;
            this.gvMucLuong.RowTemplate.Height = 24;
            this.gvMucLuong.Size = new System.Drawing.Size(650, 475);
            this.gvMucLuong.TabIndex = 3;
            this.gvMucLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMucLuong_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSuaTienLuong);
            this.groupBox1.Controls.Add(this.txtTienLuong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtMaML);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 521);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 210);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Mức Lương";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Mức Lương:";
            // 
            // txtMaML
            // 
            this.txtMaML.Location = new System.Drawing.Point(154, 33);
            this.txtMaML.Name = "txtMaML";
            this.txtMaML.Size = new System.Drawing.Size(189, 28);
            this.txtMaML.TabIndex = 1;
            // 
            // txtTienLuong
            // 
            this.txtTienLuong.Location = new System.Drawing.Point(154, 84);
            this.txtTienLuong.Name = "txtTienLuong";
            this.txtTienLuong.Size = new System.Drawing.Size(189, 28);
            this.txtTienLuong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tiền Lương:";
            // 
            // btnSuaTienLuong
            // 
            this.btnSuaTienLuong.Location = new System.Drawing.Point(89, 150);
            this.btnSuaTienLuong.Name = "btnSuaTienLuong";
            this.btnSuaTienLuong.Size = new System.Drawing.Size(189, 45);
            this.btnSuaTienLuong.TabIndex = 4;
            this.btnSuaTienLuong.Text = "Sửa Tiền Lương";
            this.btnSuaTienLuong.UseVisualStyleBackColor = true;
            this.btnSuaTienLuong.Click += new System.EventHandler(this.btnSuaTienLuong_Click);
            // 
            // UC_Admin_TienLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gvMucLuong);
            this.Name = "UC_Admin_TienLuong";
            this.Size = new System.Drawing.Size(1601, 767);
            this.Load += new System.EventHandler(this.UC_Admin_TienLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMucLuong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvMucLuong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSuaTienLuong;
        private System.Windows.Forms.TextBox txtTienLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaML;
        private System.Windows.Forms.Label label1;
    }
}
