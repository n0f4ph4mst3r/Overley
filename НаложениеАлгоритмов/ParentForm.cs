using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        string OpenFileName = "";
        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
                OpenFileDialog1.Title = "Открытие";
                OpenFileDialog1.FileName = "";
                OpenFileDialog1.DefaultExt = "*.jpg";
                OpenFileDialog1.Filter = "Image Files(*.jpg)|*.jpg";

                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    OpenFileName = OpenFileDialog1.FileName;
                    Image file = Image.FromFile(OpenFileDialog1.FileName);

                    Data.JPEGContainer = new ImageContainer(file, Data.JPEG);
                    Data.sRGBContainer = new ImageContainer(file, Data.sRGB);

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

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Data.SelectedBit != null) 
            {
                Image image = Data.SelectedBit;
                SaveFileDialog savedialog = new SaveFileDialog();
                string SaveFileName, OpenFileNameReplaced = OpenFileName;
                savedialog.Title = "Сохранить картинку как...";
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                if (savedialog.ShowDialog() == DialogResult.OK) 
                {
                    SaveFileName = savedialog.FileName;
                    try
                    {
                        if (OpenFileName != SaveFileName) 
                        image.Save(savedialog.FileName);
                        else
                        {
                            SaveFileName += "Replace";
                            OpenFileNameReplaced += "Replaced";
                            image.Save(SaveFileName);
                            File.Replace(OpenFileName, SaveFileName, OpenFileNameReplaced);
                            File.Delete(SaveFileName);
                            File.Delete(OpenFileNameReplaced);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
