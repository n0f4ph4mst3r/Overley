
namespace НаложениеАлгоритмов
{
    partial class TeleForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.sRGBbutton = new System.Windows.Forms.RadioButton();
            this.JPEGbutton = new System.Windows.Forms.RadioButton();
            this.qtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.qomegaBox = new System.Windows.Forms.TextBox();
            this.qomegalabel = new System.Windows.Forms.Label();
            this.sRGBpictureBox = new System.Windows.Forms.PictureBox();
            this.JPEGpictureBox = new System.Windows.Forms.PictureBox();
            this.sRGBchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.JPEGchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Runbutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGchart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.sRGBbutton);
            this.panel1.Controls.Add(this.JPEGbutton);
            this.panel1.Location = new System.Drawing.Point(849, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 20);
            this.panel1.TabIndex = 11;
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
            // qtBox
            // 
            this.qtBox.Location = new System.Drawing.Point(31, 3);
            this.qtBox.Name = "qtBox";
            this.qtBox.Size = new System.Drawing.Size(100, 20);
            this.qtBox.TabIndex = 10;
            this.qtBox.Text = "1";
            this.qtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qtBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "qя =";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.qomegaBox);
            this.panel2.Controls.Add(this.qomegalabel);
            this.panel2.Controls.Add(this.qtBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(139, 61);
            this.panel2.TabIndex = 13;
            // 
            // qomegaBox
            // 
            this.qomegaBox.Location = new System.Drawing.Point(31, 29);
            this.qomegaBox.Name = "qomegaBox";
            this.qomegaBox.Size = new System.Drawing.Size(100, 20);
            this.qomegaBox.TabIndex = 14;
            this.qomegaBox.Text = "1";
            this.qomegaBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.qomegaBox_KeyPress);
            // 
            // qomegalabel
            // 
            this.qomegalabel.AutoSize = true;
            this.qomegalabel.Location = new System.Drawing.Point(4, 32);
            this.qomegalabel.Name = "qomegalabel";
            this.qomegalabel.Size = new System.Drawing.Size(31, 13);
            this.qomegalabel.TabIndex = 13;
            this.qomegalabel.Text = "qк = ";
            // 
            // sRGBpictureBox
            // 
            this.sRGBpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sRGBpictureBox.Location = new System.Drawing.Point(12, 79);
            this.sRGBpictureBox.Name = "sRGBpictureBox";
            this.sRGBpictureBox.Size = new System.Drawing.Size(491, 404);
            this.sRGBpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sRGBpictureBox.TabIndex = 14;
            this.sRGBpictureBox.TabStop = false;
            this.sRGBpictureBox.Visible = false;
            // 
            // JPEGpictureBox
            // 
            this.JPEGpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.JPEGpictureBox.Location = new System.Drawing.Point(12, 79);
            this.JPEGpictureBox.Name = "JPEGpictureBox";
            this.JPEGpictureBox.Size = new System.Drawing.Size(491, 404);
            this.JPEGpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.JPEGpictureBox.TabIndex = 15;
            this.JPEGpictureBox.TabStop = false;
            // 
            // sRGBchart
            // 
            this.sRGBchart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.Name = "ChartArea1";
            this.sRGBchart.ChartAreas.Add(chartArea1);
            this.sRGBchart.Location = new System.Drawing.Point(562, 79);
            this.sRGBchart.Name = "sRGBchart";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.sRGBchart.Series.Add(series1);
            this.sRGBchart.Size = new System.Drawing.Size(473, 404);
            this.sRGBchart.TabIndex = 16;
            this.sRGBchart.Text = "Частотная гистограмма";
            title1.Name = "Title1";
            title1.Text = "Частотная гистограмма";
            this.sRGBchart.Titles.Add(title1);
            this.sRGBchart.Visible = false;
            // 
            // JPEGchart
            // 
            this.JPEGchart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea2.Name = "ChartArea1";
            this.JPEGchart.ChartAreas.Add(chartArea2);
            this.JPEGchart.Location = new System.Drawing.Point(562, 79);
            this.JPEGchart.Name = "JPEGchart";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            this.JPEGchart.Series.Add(series2);
            this.JPEGchart.Size = new System.Drawing.Size(473, 404);
            this.JPEGchart.TabIndex = 17;
            this.JPEGchart.Text = "chart1";
            title2.Name = "Title1";
            title2.Text = "Частотная гистограмма";
            this.JPEGchart.Titles.Add(title2);
            // 
            // Runbutton
            // 
            this.Runbutton.Location = new System.Drawing.Point(157, 18);
            this.Runbutton.Name = "Runbutton";
            this.Runbutton.Size = new System.Drawing.Size(75, 23);
            this.Runbutton.TabIndex = 18;
            this.Runbutton.Text = "Run";
            this.Runbutton.UseVisualStyleBackColor = true;
            this.Runbutton.Click += new System.EventHandler(this.Runbutton_Click);
            // 
            // TeleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 526);
            this.Controls.Add(this.Runbutton);
            this.Controls.Add(this.JPEGchart);
            this.Controls.Add(this.sRGBchart);
            this.Controls.Add(this.JPEGpictureBox);
            this.Controls.Add(this.sRGBpictureBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TeleForm";
            this.Text = "Телевизионный алгоритм";
            this.Load += new System.EventHandler(this.TeleForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGchart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton sRGBbutton;
        private System.Windows.Forms.RadioButton JPEGbutton;
        private System.Windows.Forms.TextBox qtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox qomegaBox;
        private System.Windows.Forms.Label qomegalabel;
        private System.Windows.Forms.PictureBox sRGBpictureBox;
        private System.Windows.Forms.PictureBox JPEGpictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart sRGBchart;
        private System.Windows.Forms.DataVisualization.Charting.Chart JPEGchart;
        private System.Windows.Forms.Button Runbutton;
    }
}