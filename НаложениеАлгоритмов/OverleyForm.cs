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
            //рисуем гистограммы
            if (Data.OpenFileName != "")
            {
                JPEGpictureBox.Image = Data.JPEGformat.bitoverlay;
                JPEGchart.Series[0].Points.Clear();
                for (int i = 0; i < 256; ++i)
                {
                    JPEGchart.Series[0].Points.AddY(Data.JPEGformat.frequencyArrayoverlay[i]);
                }

                sRGBpictureBox.Image = Data.sRGBformat.bitoverlay;
                sRGBchart.Series[0].Points.Clear();
                for (int i = 0; i < 256; ++i)
                {
                    sRGBchart.Series[0].Points.AddY(Data.sRGBformat.frequencyArrayoverlay[i]);
                }
            }
        }

        private void Runbutton_Click(object sender, EventArgs e)
        {
            Data.k = Convert.ToDouble(kBox.Text);
            Data.JPEGformat = new Overlay(0.299, 0.587, 0.114, Data.Q, Data.qt, Data.qomega, Data.k);
            JPEGpictureBox.Image = Data.JPEGformat.bitoverlay;
            JPEGchart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                JPEGchart.Series[0].Points.AddY(Data.JPEGformat.frequencyArrayoverlay[i]);
            }

            Data.sRGBformat = new Overlay(0.2126, 0.7152, 0.0722, Data.Q, Data.qt, Data.qomega, Data.k);
            sRGBpictureBox.Image = Data.sRGBformat.bitoverlay;
            sRGBchart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                sRGBchart.Series[0].Points.AddY(Data.sRGBformat.frequencyArrayoverlay[i]);
            }
        }
    }
}
