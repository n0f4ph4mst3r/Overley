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
        public static Overlay JPEGformat { get; set; }
        public static Overlay sRGBformat { get; set; }
        public static double Q { get; set; }
        public static double qt { get; set; }
        public static double qomega { get; set; }
        public static double k {get; set;}
    }
}
