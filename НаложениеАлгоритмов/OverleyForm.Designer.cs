
namespace НаложениеАлгоритмов
{
    partial class OverlayForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.JPEGpictureBox = new System.Windows.Forms.PictureBox();
            this.JPEGchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.sRGBpictureBox = new System.Windows.Forms.PictureBox();
            this.sRGBchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sRGBbutton = new System.Windows.Forms.RadioButton();
            this.JPEGbutton = new System.Windows.Forms.RadioButton();
            this.kBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Runbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBchart)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // JPEGpictureBox
            // 
            this.JPEGpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.JPEGpictureBox.Location = new System.Drawing.Point(26, 66);
            this.JPEGpictureBox.Name = "JPEGpictureBox";
            this.JPEGpictureBox.Size = new System.Drawing.Size(491, 404);
            this.JPEGpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.JPEGpictureBox.TabIndex = 16;
            this.JPEGpictureBox.TabStop = false;
            // 
            // JPEGchart
            // 
            this.JPEGchart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea3.Name = "ChartArea1";
            this.JPEGchart.ChartAreas.Add(chartArea3);
            this.JPEGchart.Location = new System.Drawing.Point(556, 66);
            this.JPEGchart.Name = "JPEGchart";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.JPEGchart.Series.Add(series3);
            this.JPEGchart.Size = new System.Drawing.Size(473, 404);
            this.JPEGchart.TabIndex = 18;
            this.JPEGchart.Text = "chart1";
            title3.Name = "Title1";
            title3.Text = "Частотная гистограмма";
            this.JPEGchart.Titles.Add(title3);
            // 
            // sRGBpictureBox
            // 
            this.sRGBpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sRGBpictureBox.Location = new System.Drawing.Point(26, 66);
            this.sRGBpictureBox.Name = "sRGBpictureBox";
            this.sRGBpictureBox.Size = new System.Drawing.Size(491, 404);
            this.sRGBpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sRGBpictureBox.TabIndex = 19;
            this.sRGBpictureBox.TabStop = false;
            this.sRGBpictureBox.Visible = false;
            // 
            // sRGBchart
            // 
            this.sRGBchart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea4.Name = "ChartArea1";
            this.sRGBchart.ChartAreas.Add(chartArea4);
            this.sRGBchart.Location = new System.Drawing.Point(556, 66);
            this.sRGBchart.Name = "sRGBchart";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series1";
            this.sRGBchart.Series.Add(series4);
            this.sRGBchart.Size = new System.Drawing.Size(473, 404);
            this.sRGBchart.TabIndex = 20;
            this.sRGBchart.Text = "Частотная гистограмма";
            title4.Name = "Title1";
            title4.Text = "Частотная гистограмма";
            this.sRGBchart.Titles.Add(title4);
            this.sRGBchart.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.sRGBbutton);
            this.panel1.Controls.Add(this.JPEGbutton);
            this.panel1.Location = new System.Drawing.Point(829, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 20);
            this.panel1.TabIndex = 21;
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
            // kBox
            // 
            this.kBox.Location = new System.Drawing.Point(57, 14);
            this.kBox.Name = "kBox";
            this.kBox.Size = new System.Drawing.Size(100, 20);
            this.kBox.TabIndex = 22;
            this.kBox.Text = "1";
            this.kBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "k =";
            // 
            // Runbutton
            // 
            this.Runbutton.Location = new System.Drawing.Point(163, 12);
            this.Runbutton.Name = "Runbutton";
            this.Runbutton.Size = new System.Drawing.Size(75, 23);
            this.Runbutton.TabIndex = 24;
            this.Runbutton.Text = "Run";
            this.Runbutton.UseVisualStyleBackColor = true;
            this.Runbutton.Click += new System.EventHandler(this.Runbutton_Click);
            // 
            // OverlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 526);
            this.Controls.Add(this.Runbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.JPEGchart);
            this.Controls.Add(this.sRGBchart);
            this.Controls.Add(this.JPEGpictureBox);
            this.Controls.Add(this.sRGBpictureBox);
            this.Name = "OverlayForm";
            this.Text = "Наложение";
            this.Load += new System.EventHandler(this.OverlayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.JPEGpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBchart)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox JPEGpictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart JPEGchart;
        private System.Windows.Forms.PictureBox sRGBpictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart sRGBchart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton sRGBbutton;
        private System.Windows.Forms.RadioButton JPEGbutton;
        private System.Windows.Forms.TextBox kBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Runbutton;
    }
}