//приведение к оттенкам серого
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace НаложениеАлгоритмов
{
    public class GrayscaleOld
    {
        public Bitmap bitSource,bitGrayscale; //исходное изображение и результат работы алгоритма
        IntPtr pointerSource, pointerResult; //адреса Bitmapов
        BitmapData DataSource, DataResult; //ссылки
        int n; //общее число пикселей
        public double[] frequencyArray; //массив частот
        public double DevY; //среднеквадратичное отклонение яркости

        public Grayscale(double[] k) //в конструкторе реализуем сам алгоритм
        {
            frequencyArray = new double[256];
            bitSource = new Bitmap(Data.file);
            bitGrayscale = new Bitmap(bitSource.Width, bitSource.Height);
            n = bitSource.Width * bitSource.Height * 3;
            double bright, Yavg; //яркость и среднее Y
            DataSource = bitSource.LockBits(new Rectangle(0, 0, bitSource.Width, bitSource.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);  //получаем ссылки на Bitmap и выделяем память
            DataResult = bitGrayscale.LockBits(new Rectangle(0, 0, bitGrayscale.Width, bitGrayscale.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            pointerSource = DataSource.Scan0;
            pointerResult = DataResult.Scan0;
            //копирование из массива
            byte[] bytes1 = new byte[n];
            byte[] bytes2 = new byte[n];
            Marshal.Copy(pointerSource, bytes1, 0, bytes1.Length);
            Array.Clear(frequencyArray, 0, 256);
            for (int i = 0; i < n; i += 3)
            {
                bright = Math.Round(k[0] * bytes1[i] + k[1] * bytes1[i + 1] + k[2] * bytes1[i + 2]);
                bytes2[i] = bytes2[i + 1] = bytes2[i + 2] = Convert.ToByte(bright); //приводим значения RGB к общему значению яркости
                frequencyArray[bytes2[i]]++; //и инкриментируем элемент с индексом равному полученной яркости в шкале частот
            }
            Marshal.Copy(bytes2, 0, pointerResult, bytes2.Length);
            //получем частоты путем деления яркостей на число пикселей
            Yavg = 0;
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
            bitSource.UnlockBits(DataSource);
            bitGrayscale.UnlockBits(DataResult);
        }
    }
}
