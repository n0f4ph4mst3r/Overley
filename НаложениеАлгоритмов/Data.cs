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
        public static ImageContainer JPEGContainer;

        public static ImageContainer sRGBContainer;

        public static Default_kof JPEG = new Default_kof(0.299, 0.587, 0.114);

        public static Default_kof sRGB = new Default_kof(0.2126, 0.7152, 0.0722);
    }
}
