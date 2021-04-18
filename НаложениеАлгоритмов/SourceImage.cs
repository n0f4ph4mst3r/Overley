using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace НаложениеАлгоритмов
{
    abstract class SourceImage
    {
        protected Bitmap bit; //исходное изображение
        protected IntPtr pointer; //адрес битмапа
        protected BitmapData Databit; //ссылка на битмап
        protected uint n; //общее число пикселей
        protected byte[] bytes; //байты

       public SourceImage(Image file)
        {
            //получаем исходное изображение и количество пикселей
            bit = new Bitmap(file);
            n = (uint)(bit.Width * bit.Height);
            //получаем ссылку и адрес
            Databit = bit.LockBits(new Rectangle(0, 0, bit.Width, bit.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            pointer = Databit.Scan0;
            //получаеем значения пикселей
            byte[] bytes = new byte[n*3];
            Marshal.Copy(pointer, bytes, 0, bytes.Length);
            bit.UnlockBits(Databit);
        }
    }

    class Grayscale : SourceImage //приведение к оттенкам серого
    {
        public Bitmap bitresult; //результат обработки
        protected IntPtr pointerresult; //адрес битмапа
        protected BitmapData Databitresult; //ссылка на битмап
        protected byte[] bytesresult; //байты
        public double[] frequencyArray; //массив частот
        protected double DevY; //среднеквадратичное отклонение яркости
        protected double[] bright; //массив яркостей
        Default_kof currentformat; //формат (JPEG/sRGB)

        public Grayscale(Image file) : base(file)
        {

            //создаем пустой битмап и получаем ссылки
            bitresult = new Bitmap(bit.Width, bit.Height);
            Databitresult = bitresult.LockBits(new Rectangle(0, 0, bitresult.Width, bitresult.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            pointerresult = Databitresult.Scan0;

            //заполняем массив байтов и частот для обработанного изображения
            bytesresult = new byte[n * 3];
            frequencyArray = new double[256];
            SetBrightAndFrequency();

            //получем частоты путем деления яркостей на число пикселей
            Set_Yavg_And_Dev();
        }
        void SetBrightAndFrequency()
        {
            Array.Clear(frequencyArray, 0, 256);
            for (int i = 0; i < bytesresult.Length; i += 3)
            {
                bright[i / 3] = Math.Round(currentformat.k1 * bytes[i] + currentformat.k2 * bytes[i + 1] + currentformat.k3 * bytes[i + 2]); //находим яркость пикселя и заносим его в массив
                bytesresult[i] = bytesresult[i + 1] = bytesresult[i + 2] = GetBrightByte(bright[i / 3]); //приводим значения RGB к общему значению яркости
                frequencyArray[bytesresult[i]]++; //и инкриментируем элемент с индексом равному полученной яркости в шкале частот
            }
            Marshal.Copy(bytesresult, 0, pointerresult, bytesresult.Length);
            bitresult.UnlockBits(Databitresult);
        }

        byte GetBrightByte(double bright)
        {
            byte brightbyte = Convert.ToByte(bright);
            return brightbyte;
        }

        void Set_Yavg_And_Dev()
        {
            double Yavg = 0; //среднее Y
            for (int i = 0; i < 256; i++)
            {
                frequencyArray[i] /= (n / 3); //определяем частоту
                Yavg += i * frequencyArray[i]; //определяем среднее значение
            }
            DevY = 0;
            for (int i = 0; i < 256; i++)
            {
                DevY += Math.Pow(i - Yavg, 2) * frequencyArray[i]; //находим среднеквадратичное отклонение яркости
            }
            DevY = Math.Sqrt(DevY);
        }

        class Tele : Grayscale //телевизионный алгоритм
        {

        }

        class Overley : Grayscale //наложение алгоритмов
        {

        }
    }

    class Scretch : Grayscale //частотно-пропорциональное растяжение
    {
        double Q = 0;
        public Scretch (Image file) : base(file)
        {
            double[] u = new double[256];
            double[] d = new double[256];
            byte[] z = new byte[256];
            double V;
            u[0] = 0;
            d[0] = 0.5 + Q * frequencyArray[0] * 255;
            for (int i = 1; i < 256; i++)
            {
                d[i] = 0.5 + Q * frequencyArray[i] * 255;
                u[i] = u[i - 1] + d[i - 1] + d[i];
            }
            V = 255 / u[255];
            z[255] = 255;
            for (int i = 0; i < 255; i++)
            {
                z[i] = Convert.ToByte(Math.Abs(Math.Round(V * u[i]))); //итоговая шкала яркости
            }
            base.Grayscale(file);
        }

    }
}
