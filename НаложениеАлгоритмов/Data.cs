//класс данных, здесь хранятся данные передаваемые между формами
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace НаложениеАлгоритмов
{
    public static class Data
    {
        public static Image file { get; set; } //исходное изображение
        public static Form form { get; set; }
        public static string OpenFileName { get; set; } //путь к файлу
        public static Grayscale JPEGformatGrayscale { get; set; } //изображение, приведенное к оттенкам серого(JPEG)
        public static Grayscale sRGBformatGrayscale { get; set; } //изображение, приведенное к оттенкам серого(sRGB)
        public static Overlay JPEGformatOverlay{ get; set; } //наложение алгоритмов(JPEG)
        public static Overlay sRGBformatOverlay { get; set; } //наложение алгоритмов (sRGB)

        public static double Q { get; set; }
        public static double qt { get; set; }
        public static double qomega { get; set; }
        public static double k {get; set;}

        public static double[] kJPEG = new double [] { 0.299, 0.587, 0.114 };
        public static double[] ksRGB = new double[] { 0.2126, 0.7152, 0.0722 };
    }
}
