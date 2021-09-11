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
    public partial class GrayscaleForm : Form
    {

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
            SelectImage();
        }

        private void GrayscaleForm_Load(object sender, EventArgs e)
        {
                    //рисуем гистограммы
                    JPEGpictureBox.Image = Data.JPEGContainer.GrayBit;
                    JPEGchart.Series[0].Points.Clear();
                    for (int i = 0; i < 256; ++i)
                    {
                        JPEGchart.Series[0].Points.AddY(Data.JPEGContainer.GrayFrequencys[i]);
                    }
                    sRGBpictureBox.Image = Data.JPEGContainer.GrayBit;
                    sRGBchart.Series[0].Points.Clear();
                    for (int i = 0; i < 256; ++i)
                    {
                        sRGBchart.Series[0].Points.AddY(Data.JPEGContainer.GrayFrequencys[i]);
                    }
        }

        private void GrayscaleForm_Activated(object sender, EventArgs e)
        {
            SelectImage();
        }

        void SelectImage()
        {
            if (JPEGpictureBox.Visible)
                Data.SelectImage(Data.JPEGContainer.GrayBit);
            else Data.SelectImage(Data.sRGBContainer.GrayBit);
        }

        public GrayscaleForm()
        {
            InitializeComponent();
        }
        }
}
