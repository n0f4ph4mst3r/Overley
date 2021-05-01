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
                string OpenFileName = "";
                OpenFileDialog1.Title = "Открытие";
                OpenFileDialog1.FileName = "";
                OpenFileDialog1.DefaultExt = "*.jpg";
                OpenFileDialog1.Filter = "Image Files(*.jpg)|*.jpg";

                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    OpenFileName = OpenFileDialog1.FileName;
                    Image file = Image.FromFile(OpenFileDialog1.FileName);

                    Data.JPEGformat = new ImageProcessing(file, Data.JPEG);
                    Data.sRGBformat = new ImageProcessing(file, Data.sRGB);

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
