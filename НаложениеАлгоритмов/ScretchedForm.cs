using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace НаложениеАлгоритмов
{
    public partial class ScretchedForm : Form
    {
        public ScretchedForm()
        {
            InitializeComponent();
        }

        private void Runbutton_Click(object sender, EventArgs e)
        {
            Data.sRGBformat.Q = Data.JPEGformat.Q = Convert.ToDouble(QBox.Text);

            JPEGpictureBox.Image = Data.JPEGformat.Scretch.Bit;
            JPEGchart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                JPEGchart.Series[0].Points.AddY(Data.JPEGformat.Scretch.Frequencys[i]);
            }

            sRGBpictureBox.Image = Data.sRGBformat.Scretch.Bit;
            sRGBchart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                sRGBchart.Series[0].Points.AddY(Data.sRGBformat.Scretch.Frequencys[i]);
            }
        }

        private void QBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",") && !QBox.Text.Contains(",") && QBox.Text != "") | e.KeyChar == '\b')
            {
                if (QBox.Text == "0" && e.KeyChar != ',')
                {
                    QBox.Text = QBox.Text.Substring(0, QBox.Text.Length - 1);
                }
                return;
            }
            else
                e.Handled = true;
        }

        private void ScretchedForm_Load(object sender, EventArgs e)
        {
                //рисуем гистограммы
                JPEGpictureBox.Image = Data.JPEGformat.Scretch.Bit;
                JPEGchart.Series[0].Points.Clear();
                for (int i = 0; i < 256; ++i)
                {
                    JPEGchart.Series[0].Points.AddY(Data.JPEGformat.Scretch.Frequencys[i]);
                }

                sRGBpictureBox.Image = Data.sRGBformat.Scretch.Bit;
                sRGBchart.Series[0].Points.Clear();
                for (int i = 0; i < 256; ++i)
                {
                    sRGBchart.Series[0].Points.AddY(Data.sRGBformat.Scretch.Frequencys[i]);
                }
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
    }
}
