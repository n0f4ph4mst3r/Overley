﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace НаложениеАлгоритмов
{
    public partial class TeleForm : Form
    {
        public TeleForm()
        {
            InitializeComponent();
        }

        private void Runbutton_Click(object sender, EventArgs e)
        {
            Data.sRGBformat.Qt = Data.JPEGformat.Qt = Convert.ToDouble(qtBox.Text);
            Data.sRGBformat.Qt = Data.JPEGformat.Qomega = Convert.ToDouble(qomegaBox.Text);
        
            JPEGpictureBox.Image = Data.JPEGformat.Tele.Bit;
            JPEGchart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                JPEGchart.Series[0].Points.AddY(Data.JPEGformat.Tele.Frequencys[i]);
            }

            sRGBpictureBox.Image = Data.sRGBformat.Tele.Bit;
            sRGBchart.Series[0].Points.Clear();
            for (int i = 0; i < 256; ++i)
            {
                sRGBchart.Series[0].Points.AddY(Data.sRGBformat.Tele.Frequencys[i]);
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

        private void qtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",") && !qtBox.Text.Contains(",") && qtBox.Text != "") | e.KeyChar == '\b')
            {
                if (qtBox.Text == "0" && e.KeyChar != ',')
                {
                    qtBox.Text = qtBox.Text.Substring(0, qtBox.Text.Length - 1);
                }
                return;
            }
            else
                e.Handled = true;
        }

        private void qomegaBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",") && !qomegaBox.Text.Contains(",") && qomegaBox.Text != "") | e.KeyChar == '\b')
            {
                if (qomegaBox.Text == "0" && e.KeyChar != ',')
                {
                    qomegaBox.Text = qomegaBox.Text.Substring(0, qomegaBox.Text.Length - 1);
                }
                return;
            }
            else
                e.Handled = true;
        }

        private void TeleForm_Load(object sender, EventArgs e)
        {
                //рисуем гистограммы
                JPEGpictureBox.Image = Data.JPEGformat.Tele.Bit;
                JPEGchart.Series[0].Points.Clear();
                for (int i = 0; i < 256; ++i)
                {
                    JPEGchart.Series[0].Points.AddY(Data.JPEGformat.Tele.Frequencys[i]);
                }

                sRGBpictureBox.Image = Data.sRGBformat.Tele.Bit;
                sRGBchart.Series[0].Points.Clear();
                for (int i = 0; i < 256; ++i)
                {
                    sRGBchart.Series[0].Points.AddY(Data.sRGBformat.Tele.Frequencys[i]);
                }
        }
    }
}
