namespace НаложениеАлгоритмов
{
    partial class GrayscaleForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.JPEGpictureBox = new System.Windows.Forms.PictureBox();
            this.JPEGchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sRGBbutton = new System.Windows.Forms.RadioButton();
            this.JPEGbutton = new System.Windows.Forms.RadioButton();
            this.sRGBpictureBox = new System.Windows.Forms.PictureBox();
            this.sRGBchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGchart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBchart)).BeginInit();
            this.SuspendLayout();
            // 
            // JPEGpictureBox
            // 
            this.JPEGpictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.JPEGpictureBox.Location = new System.Drawing.Point(12, 56);
            this.JPEGpictureBox.Name = "JPEGpictureBox";
            this.JPEGpictureBox.Size = new System.Drawing.Size(508, 458);
            this.JPEGpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.JPEGpictureBox.TabIndex = 0;
            this.JPEGpictureBox.TabStop = false;
            // 
            // JPEGchart
            // 
            this.JPEGchart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.Name = "ChartArea1";
            this.JPEGchart.ChartAreas.Add(chartArea1);
            this.JPEGchart.Location = new System.Drawing.Point(541, 56);
            this.JPEGchart.Name = "JPEGchart";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.JPEGchart.Series.Add(series1);
            this.JPEGchart.Size = new System.Drawing.Size(508, 458);
            this.JPEGchart.TabIndex = 1;
            this.JPEGchart.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Частотная гистограмма";
            this.JPEGchart.Titles.Add(title1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sRGBbutton);
            this.panel1.Controls.Add(this.JPEGbutton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 20);
            this.panel1.TabIndex = 3;
            // 
            // sRGBbutton
            // 
            this.sRGBbutton.AutoSize = true;
            this.sRGBbutton.Location = new System.Drawing.Point(61, 3);
            this.sRGBbutton.Name = "sRGBbutton";
            this.sRGBbutton.Size = new System.Drawing.Size(53, 17);
            this.sRGBbutton.TabIndex = 1;
            this.sRGBbutton.Text = "sRGB";
            this.sRGBbutton.UseVisualStyleBackColor = true;
            this.sRGBbutton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // JPEGbutton
            // 
            this.JPEGbutton.AutoSize = true;
            this.JPEGbutton.Checked = true;
            this.JPEGbutton.Location = new System.Drawing.Point(3, 3);
            this.JPEGbutton.Name = "JPEGbutton";
            this.JPEGbutton.Size = new System.Drawing.Size(52, 17);
            this.JPEGbutton.TabIndex = 0;
            this.JPEGbutton.TabStop = true;
            this.JPEGbutton.Text = "JPEG";
            this.JPEGbutton.UseVisualStyleBackColor = true;
            this.JPEGbutton.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // sRGBpictureBox
            // 
            this.sRGBpictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.sRGBpictureBox.Location = new System.Drawing.Point(12, 56);
            this.sRGBpictureBox.Name = "sRGBpictureBox";
            this.sRGBpictureBox.Size = new System.Drawing.Size(508, 458);
            this.sRGBpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sRGBpictureBox.TabIndex = 6;
            this.sRGBpictureBox.TabStop = false;
            this.sRGBpictureBox.Visible = false;
            // 
            // sRGBchart
            // 
            this.sRGBchart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea2.Name = "ChartArea1";
            this.sRGBchart.ChartAreas.Add(chartArea2);
            this.sRGBchart.Location = new System.Drawing.Point(541, 56);
            this.sRGBchart.Name = "sRGBchart";
            series2.ChartArea = "ChartArea1";
            series2.IsVisibleInLegend = false;
            series2.Name = "Series1";
            this.sRGBchart.Series.Add(series2);
            this.sRGBchart.Size = new System.Drawing.Size(508, 458);
            this.sRGBchart.TabIndex = 7;
            this.sRGBchart.Text = "chart3";
            title2.Name = "Title1";
            title2.Text = "Частотная гистограмма";
            this.sRGBchart.Titles.Add(title2);
            this.sRGBchart.Visible = false;
            // 
            // GrayscaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 526);
            this.Controls.Add(this.sRGBpictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.JPEGpictureBox);
            this.Controls.Add(this.sRGBchart);
            this.Controls.Add(this.JPEGchart);
            this.Name = "GrayscaleForm";
            this.Text = "Оттенки серого";
            this.Activated += new System.EventHandler(this.GrayscaleForm_Activated);
            this.Load += new System.EventHandler(this.GrayscaleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.JPEGpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGchart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox JPEGpictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart JPEGchart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton sRGBbutton;
        private System.Windows.Forms.RadioButton JPEGbutton;
        private System.Windows.Forms.PictureBox sRGBpictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart sRGBchart;
    }
}