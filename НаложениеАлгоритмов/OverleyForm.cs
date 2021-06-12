using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace НаложениеАлгоритмов
{
    public partial class OverlayForm : Form
    {
        public OverlayForm()
        {
            InitializeComponent();
        }

        private void kBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",") && !kBox.Text.Contains(",") && kBox.Text != "") | e.KeyChar == '\b')
            {
                if (kBox.Text == "0" && e.KeyChar != ',')
                {
                    kBox.Text = kBox.Text.Substring(0, kBox.Text.Length - 1);
                }
                return;
            }
            else
                e.Handled = true;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            if (JPEGbutton.Checked)
            {
                JPEGpictureBox.Visible = true;
                sRGBpictureBox.Visible = false;
                JPEGchart.Visible = true;
                sRGBchart.Visible = false;
            }
            if (sRGBbutton.Checked)
            {
                sRGBpictureBox.Visible = true;
                JPEGpictureBox.Visible = false;
                JPEGchart.Visible = false;
                sRGBchart.Visible = true;
            }
        }

        private void OverlayForm_Load(object sender, EventArgs e)
        {
            DrawHistogramm();
        }

        private void Runbutton_Click(object sender, EventArgs e)
        {
            Data.sRGBContainer.K = Data.JPEGContainer.K = Convert.ToDouble(kBox.Text);
            DrawHistogramm();
        }
        private void DrawHistogramm()
        {
            //рисуем гистограммы
            JPEGpictureBox.Image = Data.JPEGContainer.OverleyBit;
            JPEGchart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                JPEGchart.Series[0].Points.AddY(Data.JPEGContainer.OverleyFrequencys[i]);
            }

            sRGBpictureBox.Image = Data.JPEGContainer.OverleyBit;
            sRGBchart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                sRGBchart.Series[0].Points.AddY(Data.JPEGContainer.OverleyFrequencys[i]);
            }
        }
    }
}
