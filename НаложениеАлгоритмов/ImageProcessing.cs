//класс-набор изображений, в полях класса хранятся результаты обработки, в свойствах - общие коэффициенты изменяемые в ходе программы
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace НаложениеАлгоритмов
{
    public class ImageProcessing
    {
        private double q, qt, qomega, k;
        public Grayscale Gray; //оттенки серого
        public Scretch Scretch; //растяжение
        public Tele Tele; //телевизионный алгоритм
        public Overley Overley; //наложение

        public double Q //коэффициент растяжения
        {
            get
            {
                return q;
            }
            set
            {
                Scretch.Q = Tele.Q = Overley.Q = q = value;
            }
        }

        public double Qt //исходная характеристика
        {
            get
            {
                return qt;
            }
            set
            {
                Tele.Qt = Overley.Qt = qt = value;
            }
        }

        public double Qomega //ожидаемая характеристика
        {
            get
            {
                return qomega;
            }
            set
            {
                Tele.Qomega = Overley.Qomega = qomega = value;
            }
        }

        public double K //коэффициент наложения
        {
            get
            {
                return k;
            }
            set
            {
                Overley.K = k = value;
            }
        }

        public ImageProcessing(Image file, Default_kof kof)
        {
            Gray = new Grayscale(file, kof);

            Scretch = new Scretch(file, kof);
            q = Scretch.Q;

            Tele = new Tele(file, kof);
            qt = Tele.Qt;
            qomega = Tele.Qomega;

            Overley = new Overley(file, kof);
            k = Overley.K;
        }
    }
}
