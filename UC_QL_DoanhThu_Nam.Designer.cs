namespace QuanLyChuoiQuanCaPhe
{
    partial class UC_QL_DoanhThu_Nam
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
            this.chartDoanhThu_Nam = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu_Nam)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDoanhThu_Nam
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu_Nam.ChartAreas.Add(chartArea1);
            this.chartDoanhThu_Nam.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartDoanhThu_Nam.Legends.Add(legend1);
            this.chartDoanhThu_Nam.Location = new System.Drawing.Point(0, 0);
            this.chartDoanhThu_Nam.Name = "chartDoanhThu_Nam";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDoanhThu_Nam.Series.Add(series1);
            this.chartDoanhThu_Nam.Size = new System.Drawing.Size(1074, 400);
            this.chartDoanhThu_Nam.TabIndex = 0;
            this.chartDoanhThu_Nam.Text = "chart1";
            // 
            // UC_QL_DoanhThu_Nam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartDoanhThu_Nam);
            this.Name = "UC_QL_DoanhThu_Nam";
            this.Size = new System.Drawing.Size(1074, 400);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu_Nam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu_Nam;
    }
}
