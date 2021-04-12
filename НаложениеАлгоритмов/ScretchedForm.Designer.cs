namespace НаложениеАлгоритмов
{
    partial class ScretchedForm
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
            this.sRGBpictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.QBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sRGBbutton = new System.Windows.Forms.RadioButton();
            this.JPEGbutton = new System.Windows.Forms.RadioButton();
            this.JPEGpictureBox = new System.Windows.Forms.PictureBox();
            this.sRGBchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Runbutton = new System.Windows.Forms.Button();
            this.JPEGchart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBpictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBchart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGchart)).BeginInit();
            this.SuspendLayout();
            // 
            // sRGBpictureBox
            // 
            this.sRGBpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.sRGBpictureBox.Location = new System.Drawing.Point(12, 59);
            this.sRGBpictureBox.Name = "sRGBpictureBox";
            this.sRGBpictureBox.Size = new System.Drawing.Size(528, 455);
            this.sRGBpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sRGBpictureBox.TabIndex = 7;
            this.sRGBpictureBox.TabStop = false;
            this.sRGBpictureBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Q =";
            // 
            // QBox
            // 
            this.QBox.Location = new System.Drawing.Point(42, 12);
            this.QBox.Name = "QBox";
            this.QBox.Size = new System.Drawing.Size(100, 20);
            this.QBox.TabIndex = 9;
            this.QBox.Text = "0,0";
            this.QBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.QBox_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.sRGBbutton);
            this.panel1.Controls.Add(this.JPEGbutton);
            this.panel1.Location = new System.Drawing.Point(849, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 20);
            this.panel1.TabIndex = 10;
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
            // JPEGpictureBox
            // 
            this.JPEGpictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.JPEGpictureBox.Location = new System.Drawing.Point(12, 59);
            this.JPEGpictureBox.Name = "JPEGpictureBox";
            this.JPEGpictureBox.Size = new System.Drawing.Size(528, 455);
            this.JPEGpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.JPEGpictureBox.TabIndex = 11;
            this.JPEGpictureBox.TabStop = false;
            // 
            // sRGBchart
            // 
            this.sRGBchart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea3.Name = "ChartArea1";
            this.sRGBchart.ChartAreas.Add(chartArea3);
            this.sRGBchart.Location = new System.Drawing.Point(576, 59);
            this.sRGBchart.Name = "sRGBchart";
            series3.ChartArea = "ChartArea1";
            series3.Name = "Series1";
            this.sRGBchart.Series.Add(series3);
            this.sRGBchart.Size = new System.Drawing.Size(473, 455);
            this.sRGBchart.TabIndex = 12;
            this.sRGBchart.Text = "Частотная гистограмма";
            title3.Name = "Title1";
            title3.Text = "Частотная гистограмма";
            this.sRGBchart.Titles.Add(title3);
            this.sRGBchart.Visible = false;
            // 
            // Runbutton
            // 
            this.Runbutton.Location = new System.Drawing.Point(166, 10);
            this.Runbutton.Name = "Runbutton";
            this.Runbutton.Size = new System.Drawing.Size(75, 23);
            this.Runbutton.TabIndex = 13;
            this.Runbutton.Text = "Run";
            this.Runbutton.UseVisualStyleBackColor = true;
            this.Runbutton.Click += new System.EventHandler(this.Runbutton_Click);
            // 
            // JPEGchart
            // 
            this.JPEGchart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea4.Name = "ChartArea1";
            this.JPEGchart.ChartAreas.Add(chartArea4);
            this.JPEGchart.Location = new System.Drawing.Point(576, 59);
            this.JPEGchart.Name = "JPEGchart";
            series4.ChartArea = "ChartArea1";
            series4.Name = "Series1";
            this.JPEGchart.Series.Add(series4);
            this.JPEGchart.Size = new System.Drawing.Size(473, 455);
            this.JPEGchart.TabIndex = 1;
            this.JPEGchart.Text = "chart1";
            title4.Name = "Title1";
            title4.Text = "Частотная гистограмма";
            this.JPEGchart.Titles.Add(title4);
            // 
            // ScretchedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 526);
            this.Controls.Add(this.Runbutton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.QBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sRGBpictureBox);
            this.Controls.Add(this.JPEGpictureBox);
            this.Controls.Add(this.sRGBchart);
            this.Controls.Add(this.JPEGchart);
            this.Name = "ScretchedForm";
            this.Text = "Частотно-пропорциональное растяжение";
            this.Load += new System.EventHandler(this.ScretchedForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sRGBpictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sRGBchart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JPEGchart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox sRGBpictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox QBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton sRGBbutton;
        private System.Windows.Forms.RadioButton JPEGbutton;
        private System.Windows.Forms.PictureBox JPEGpictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart sRGBchart;
        private System.Windows.Forms.Button Runbutton;
        private System.Windows.Forms.DataVisualization.Charting.Chart JPEGchart;
    }
}