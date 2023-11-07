namespace QuanLyChuoiQuanCaPhe
{
    partial class UC_QL_DoanhThu_Thang
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chartDoanhThu_Thang = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu_Thang)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDoanhThu_Thang
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu_Thang.ChartAreas.Add(chartArea1);
            this.chartDoanhThu_Thang.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartDoanhThu_Thang.Legends.Add(legend1);
            this.chartDoanhThu_Thang.Location = new System.Drawing.Point(0, 0);
            this.chartDoanhThu_Thang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartDoanhThu_Thang.Name = "chartDoanhThu_Thang";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "DoanhThuThang";
            this.chartDoanhThu_Thang.Series.Add(series1);
            this.chartDoanhThu_Thang.Size = new System.Drawing.Size(1432, 492);
            this.chartDoanhThu_Thang.TabIndex = 0;
            this.chartDoanhThu_Thang.Text = "chart1";
            title1.Name = "Title1";
            this.chartDoanhThu_Thang.Titles.Add(title1);
            // 
            // UC_QL_DoanhThu_Thang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartDoanhThu_Thang);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UC_QL_DoanhThu_Thang";
            this.Size = new System.Drawing.Size(1432, 492);
            this.Load += new System.EventHandler(this.UC_QL_DoanhThu_Thang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu_Thang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu_Thang;
    }
}
