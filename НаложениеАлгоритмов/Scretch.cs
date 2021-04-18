//частотно-пропорциональное растяжение
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace НаложениеАлгоритмов
{
    class ScretchOld
    {
        public Bitmap bitSource, bitScrethed; //исходное изображение и частотно-пропорциональное растяжение
        IntPtr pointerSource, pointerResult; //адреса Bitmapов
        BitmapData DataSource, DataResult; //ссылки
        public int n; //общее число пикселей
        public double[] frequencyArrayScretched; //массив частот
        public double DevZ; //среднеквадратичное отклонение яркости
        public Scretch(double[] k, double Q) //в конструкторе реализуем сам алгоритм
        {
            //частотно-пропорциональное растяжение
            double[] u = new double[256];
            double[] d = new double[256];
            frequencyArrayScretched = new double[256];
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
            //заменяем пиксели
            bitScrethed = new Bitmap(bitSource.Width, bitSource.Height);
            Array.Clear(bytes1, 0, n);
            Array.Clear(bytes2, 0, n);
            double Zavg; //среднее Z
            //получаем ссылки на Bitmap и выделяем память
            DataSource = bitSource.LockBits(new Rectangle(0, 0, bitSource.Width, bitSource.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            DataResult = bitScrethed.LockBits(new Rectangle(0, 0, bitScrethed.Width, bitScrethed.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            pointerSource = DataSource.Scan0;
            pointerResult = DataResult.Scan0;
            Marshal.Copy(pointerSource, bytes1, 0, bytes1.Length);
            Array.Clear(frequencyArrayScretched, 0, 256);
            for (int i = 0; i < n; i += 3)
            {
                bright = Math.Round(k1 * bytes1[i] + k2 * bytes1[i + 1] + k3 * bytes1[i + 2]); //находим исходную яркость
                bytes2[i] = bytes2[i + 1] = bytes2[i + 2] = z[Convert.ToInt32(bright)]; //приводим значения RGB к общему значению яркости 
                frequencyArrayScretched[bytes2[i]]++; //и инкриментируем элемент с индексом равному полученной яркости в шкале частот
            }
            Marshal.Copy(bytes2, 0, pointerResult, bytes2.Length);
            //получем частоты путем деления яркостей на число пикселей
            Zavg = 0;
            for (int i = 0; i < 256; i++)
            {
                frequencyArrayScretched[i] /= (n / 3); //определяем частоту
                Zavg += i * frequencyArrayScretched[i]; //определяем среднее значение
            }
            for (int i = 0; i < 256; i++)
            {
                DevZ = Math.Pow(i - Zavg, 2) * frequencyArrayScretched[i]; //находим среднеквадратичное отклонение яркости
            }
            Math.Sqrt(DevZ);
            bitSource.UnlockBits(DataSource);
            bitScrethed.UnlockBits(DataResult);
            frequencyArrayTele = new double[256];
        }
    }
}
