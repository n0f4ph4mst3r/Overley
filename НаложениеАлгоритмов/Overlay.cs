using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace НаложениеАлгоритмов
{
   public class Overlay
    {
        public Bitmap bitSource, bitGrayscale, bitScrethed, bitTele, bitoverlay; //исходное изображение, оттенки серого, частотно-пропорциональное растяжение, телевизионный алгоритм, наложение
        IntPtr pointerSource, pointerResult; //адреса Bitmapов
        BitmapData DataSource, DataResult; //ссылки
        public int n; //общее число пикселей
        public double[] frequencyArray; //массив частот
        public double DevY; //среднеквадратичное отклонение яркости
        public double[] frequencyArrayScretched; //массив частот(для частотно-пропорционального растяжения)
        public double DevZ; //среднеквадратичное отклонение яркости(для частотно-пропорционального растяжения)
        public double[] frequencyArrayTele; //массив частот(для телевизионного алгоритма)
        public double[] frequencyArrayoverlay; //массив частот(наложение алгоритомов)
        public Overlay(double k1, double k2, double k3, double Q, double qt, double qomega, double k)
        {
                //приведение к оттенкам серого
                frequencyArray = new double[256];
                bitSource = new Bitmap(Data.file);
                bitGrayscale = new Bitmap(bitSource.Width, bitSource.Height);
                n = bitSource.Width * bitSource.Height * 3;
                double bright, Yavg; //яркость и среднее Y
                //получаем ссылки на Bitmap и выделяем память
                DataSource = bitSource.LockBits(new Rectangle(0, 0, bitSource.Width, bitSource.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);  
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
                    bright = Math.Round(k1 * bytes1[i] + k2 * bytes1[i + 1] + k3 * bytes1[i + 2]);
                    bytes2[i] = bytes2[i + 1] = bytes2[i + 2] = Convert.ToByte(bright); //приводим значения RGB к общему значению яркости
                    frequencyArray[bytes2[i]]++; //и инкриментируем элемент с индексом равному полученной яркости в шкале частот
                }
                Marshal.Copy(bytes2, 0, pointerResult, bytes2.Length);
                //получем частоты путем деления яркостей на число пикселей
                Yavg = 0;
                for (int i = 0; i < 256; i++)
                {
                    frequencyArray[i] /= (n/3); //определяем частоту
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
                frequencyArrayScretched[i] /= (n/3); //определяем частоту
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
            //телевизионный алгоритм
            frequencyArrayTele = new double[256];
            double Tavg, omegat; //среднее t и омега с индексом t
            Tavg = qt * Zavg;
            omegat = qomega * DevZ;
            double Qinitial, Qexpected;
            Qinitial = Tavg / Yavg;
            Qexpected = omegat / (Qinitial * DevY);
            byte[] t = new byte[256];
            double temp;
            for (int i = 0; i < 256; i++) {
                temp = Qinitial * (i + Qexpected*(i - Yavg));
                if (temp > 255)
                {
                    t[i] = 255;
                        continue;
                }
                if (temp < 0) {
                    t[i] = 0;
                    continue;
                }
                t[i] = Convert.ToByte(temp);
            }
            bitTele = new Bitmap(bitSource.Width, bitSource.Height);
            Array.Clear(bytes1, 0, n);
            Array.Clear(bytes2, 0, n);
            //получаем ссылки на Bitmap и выделяем память
            DataSource = bitSource.LockBits(new Rectangle(0, 0, bitSource.Width, bitSource.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            DataResult = bitTele.LockBits(new Rectangle(0, 0, bitTele.Width, bitTele.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            pointerSource = DataSource.Scan0;
            pointerResult = DataResult.Scan0;
            Marshal.Copy(pointerSource, bytes1, 0, bytes1.Length);
            Array.Clear(frequencyArrayTele, 0, 256);
            for (int i = 0; i < n; i += 3)
            {
                bright = Math.Round(k1 * bytes1[i] + k2 * bytes1[i + 1] + k3 * bytes1[i + 2]); //находим исходную яркость
                bytes2[i] = bytes2[i + 1] = bytes2[i + 2] = t[Convert.ToInt32(bright)]; //приводим значения RGB к общему значению яркости 
                frequencyArrayTele[bytes2[i]]++; //и инкриментируем элемент с индексом равному полученной яркости в шкале частот
            }
            Marshal.Copy(bytes2, 0, pointerResult, bytes2.Length);
            //получем частоты путем деления яркостей на число пикселей
            for (int i = 0; i < 256; i++)
            {
                frequencyArrayTele[i] /= (n / 3); //определяем частоту
            }
            bitSource.UnlockBits(DataSource);
            bitTele.UnlockBits(DataResult);
            //наложение алгоритмов
            frequencyArrayoverlay = new double[256];
            bitoverlay = new Bitmap(bitSource.Width, bitSource.Height);
            Array.Clear(bytes1, 0, n);
            Array.Clear(bytes2, 0, n);
            //получаем ссылки на Bitmap и выделяем память
            DataSource = bitSource.LockBits(new Rectangle(0, 0, bitSource.Width, bitSource.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            DataResult = bitoverlay.LockBits(new Rectangle(0, 0, bitoverlay.Width, bitoverlay.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            pointerSource = DataSource.Scan0;
            pointerResult = DataResult.Scan0;
            Marshal.Copy(pointerSource, bytes1, 0, bytes1.Length);
            for (int i = 0; i < n; i += 3)
            {
                bright = Math.Round(k1 * bytes1[i] + k2 * bytes1[i + 1] + k3 * bytes1[i + 2]); //находим исходную яркость
                bytes2[i] = bytes2[i + 1] = bytes2[i + 2] = (byte)(k *z[Convert.ToInt32(bright)]+(1-k)*t[Convert.ToInt32(bright)]); //приводим значения RGB к общему значению яркости 
                frequencyArrayoverlay[bytes2[i]]++; //и инкриментируем элемент с индексом равному полученной яркости в шкале частот
            }
            Marshal.Copy(bytes2, 0, pointerResult, bytes2.Length);
            //получем частоты путем деления яркостей на число пикселей
            for (int i = 0; i < 256; i++)
            {
                frequencyArrayoverlay[i] /= (n / 3); //определяем частоту
            }
            bitSource.UnlockBits(DataSource);
            bitoverlay.UnlockBits(DataResult);
        }
        }
    }
