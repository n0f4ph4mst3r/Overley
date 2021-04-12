using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace НаложениеАлгоритмов
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }


        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Data.OpenFileName = "";
                OpenFileDialog1.Title = "Открытие";
                OpenFileDialog1.FileName = "";
                OpenFileDialog1.DefaultExt = "*.jpg";
                OpenFileDialog1.Filter = "Image Files(*.jpg)|*.jpg";
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Data.OpenFileName = OpenFileDialog1.FileName;
                    Data.file = Image.FromFile(OpenFileDialog1.FileName);
                    Data.Q = 0;
                    Data.qt = Data.qomega = Data.k = 1;
                    Data.JPEGformat = new Overlay(0.299, 0.587, 0.114, Data.Q, Data.qt, Data.qomega, Data.k);
                    Data.sRGBformat = new Overlay(0.2126, 0.7152, 0.0722, Data.Q, Data.qt, Data.qomega, Data.k);
                    GrayscaleForm grayscaleform = new GrayscaleForm();
                    grayscaleform.MdiParent = this;
                    grayscaleform.Show();
                    окнаToolStripMenuItem.Enabled = true;
                }
                else
                    return;
        }

        private void ЧастотнопропорциональноеРастяжениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ScretchedForm scretchedform = new ScretchedForm();
                scretchedform.MdiParent = this;
                scretchedform.Show();
            }
            catch 
            {
                MessageBox.Show("Ошибка при открытии файла", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ОттенкиСерогоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            GrayscaleForm grayscaleform = new GrayscaleForm();
            grayscaleform.MdiParent = this;
            grayscaleform.Show();
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void телевизионныйАлгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TeleForm teleform = new TeleForm();
                teleform.MdiParent = this;
                teleform.Show();
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void наложениеАлгоритмовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OverlayForm overleyform = new OverlayForm();
                overleyform.MdiParent = this;
                overleyform.Show();
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
