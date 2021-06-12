//интерфейсы классов
//т.к. в версиях до C# 7.0 в интерфейсах нельзя задавать модификаторы доступа, выполнены в виде абстрактных классов
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace НаложениеАлгоритмов
{
    //для исходного изображения
    abstract public class SourceImageInterface
    {
        //поля
        protected Bitmap bit; //изображение
        protected IntPtr pointer; //адрес битмапа
        protected BitmapData databit; //ссылка на битмап
        protected uint n; //общее число пикселей
        protected byte[] bytes; //байты

        //методы
        protected abstract void Build();
        public void Update()
        {
            Build();
        }

        //свойства
        public virtual Bitmap Bit
        {
            get
            {
                return bit;
            }
        }

        public uint N
        {
            get
            {
                return n;
            }
        }

        public virtual byte[] Bytes
        {
            get
            {
                return bytes;
            }
        }
    }

    abstract public class ImageGen : SourceImageInterface
    {
        //поля
        protected Bitmap source; //исходное изображение
        protected byte[] bytes_source; //байты исходного изображения
        protected double[] frequencyArray; //массив частот

        //методы
        protected abstract byte GetBright(byte bright); //найти конечную яркость для данного пикселя

        protected void SetFreqencys() //вычисление частот
        {
            //формируем новый битмап, адрес и ссылку
            bit = new Bitmap(source.Width, source.Height);
            databit = bit.LockBits(new Rectangle(0, 0, bit.Width, bit.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            pointer = databit.Scan0;

            bytes = new byte[n * 3];
            frequencyArray = new double[256];
            Array.Clear(frequencyArray, 0, 256);

            for (int i = 0; i < bytes.Length; i += 3)
            {
                bytes[i] = bytes[i + 1] = bytes[i + 2] = GetBright(y[i / 3]); //приводим значения RGB к общему значению яркости
                frequencyArray[bytes[i]]++; //и инкриментируем элемент с индексом равному полученной яркости в шкале частот
            }

            Marshal.Copy(bytes, 0, pointer, bytes.Length); //получаем окончательное изображение
            bit.UnlockBits(databit);

            for (int i = 0; i < 256; i++)
            {
                frequencyArray[i] /= n; //определяем частоту путем деления на количество пикселей
            }
        }
        protected void SetBright() //находим яркость всех пикселей
        {
            y = new byte[n];
            for (int i = 0; i < bytes_source.Length; i += 3)
            {
                y[i / 3] = Convert.ToByte(Math.Round(kof.k1 * bytes_source[i] + kof.k2 * bytes_source[i + 1] + kof.k3 * bytes_source[i + 2]));
            }
        }

        //свойства
        public Bitmap BitSource
        {
            get
            {
                return source;
            }
        }

        public byte[] BytesSource
        {
            get
            {
                return bytes_source;
            }
        }

        public double[] Frequencys
        {
            get
            {
                return frequencyArray;
            }
        }
    }

    abstract public class GrayscaleInterface : ImageGen
    {
        protected double GetAvg(double Avg) //определяем среднее значение
        {
            for (int i = 0; i < 256; i++)
            {
                Avg += i * frequencyArray[i];
            }
            return Avg;
        }
        protected double GetDev(double Dev, double Avg) //находим среднеквадратичное отклонение
        {
            for (int i = 0; i < 256; i++)
            {
                Dev += Math.Pow(i - Avg, 2) * frequencyArray[i];
            }
            Dev = Math.Sqrt(Dev);
            return Dev;
        }
        public abstract double Avg { get; }
        public abstract double Dev { get; }
    }

    abstract public class TeleInterface : ImageGen
    {
        protected double qt = 1, qomega = 1;
        protected byte[] t = new byte[256]; //массив яркостей



        public double Qt
        {
            get
            {
                return qt;
            }
            set
            {
                qt = value;
                Update();
            }
        }

        public double Qomega
        {
            get
            {
                return qomega;
            }
            set
            {
                qomega = value;
                Update();
            }
        }
    }
}
