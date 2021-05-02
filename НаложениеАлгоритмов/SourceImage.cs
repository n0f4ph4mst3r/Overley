using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace НаложениеАлгоритмов
{
    abstract public class SourceImage
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
            bytes = new byte[n * 3];
            Marshal.Copy(pointer, bytes, 0, bytes.Length);
            bit.UnlockBits(Databit);
        }
        protected abstract void Build();
        protected abstract byte GetBright(byte y);
        public abstract void Update();
    }

    public class Grayscale : SourceImage //приведение к оттенкам серого
    {
        protected Bitmap bitGray; //результат обработки
        protected IntPtr pointerGray; //адрес битмапа
        protected BitmapData DatabitGray; //ссылка на битмап
        protected byte[] bytesGray; //байты
        protected double[] frequencyArray; //массив частот
        protected double Yavg, DevY; //среднее Y и среднеквадратичное отклонение яркости
        protected byte[] bright; //массив яркостей
        private byte[] y = new byte[256]; //промежуточный массив ярокстей y
        protected Default_kof kof;

        public double[] Frequencys
        {
            get
            {
                return frequencyArray;
            }
        }

        public Bitmap Bit
        {
            get
            {
                return bitGray;
            }
        }

        public Grayscale(Image file, Default_kof kof) : base(file)
        {
            this.kof = kof;
            byte count = 0;
            for (int i = 0; i < 256; i++)
            {
                y[i] = count;
                count++;
            }
            Build();
        }
        protected override void Build()
        {
            SetBright();
            CopyArray();
            Yavg = GetAvg(y);
            DevY = GetDev(y, Yavg);
        }
        public override void Update()
        {
            Build();
        }

        void SetBright() //находим яркость всех пикселей
        {
            bright = new byte[n];
            for (int i = 0; i < bytes.Length; i += 3)
            {
                bright[i / 3] = Convert.ToByte(Math.Round(kof.k1 * bytes[i] + kof.k2 * bytes[i + 1] + kof.k3 * bytes[i + 2]));
            }
        }

        protected void CopyArray() //копирование в массив байтов
        {
            //формируем новый битмап, адрес и ссылку
            bitGray = new Bitmap(bit.Width, bit.Height);
            DatabitGray = bitGray.LockBits(new Rectangle(0, 0, bitGray.Width, bitGray.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            pointerGray = DatabitGray.Scan0;

            bytesGray = new byte[n * 3];
            frequencyArray = new double[256];
            Array.Clear(frequencyArray, 0, 256);

            for (int i = 0; i < bytesGray.Length; i += 3)
            {
                bytesGray[i] = bytesGray[i + 1] = bytesGray[i + 2] = GetBright(bright[i / 3]); //приводим значения RGB к общему значению яркости
                frequencyArray[bytesGray[i]]++; //и инкриментируем элемент с индексом равному полученной яркости в шкале частот
            }

            Marshal.Copy(bytesGray, 0, pointerGray, bytesGray.Length); //получаем окончательное изображение
            bitGray.UnlockBits(DatabitGray);

            for (int i = 0; i < 256; i++)
            {
                frequencyArray[i] /= n; //определяем частоту путем деления на количество пикселей
            }
        }
        protected double GetAvg (byte[] arr) //определяем среднее значение
        {
            double Avg = 0;
            for (int i = 0; i < 256; i++)
            {
                Avg += arr[i] * frequencyArray[i]; 
            }
            return Avg;
        }
        protected double GetDev(byte[] arr, double Avg) //находим среднеквадратичное отклонение
        {
            double Dev = 0;
            for (int i = 0; i < 256; i++)
            {
                Dev += Math.Pow(arr[i] - Avg, 2) * frequencyArray[i]; 
            }
            Dev = Math.Sqrt(Dev);
            return Dev;
        }

        protected override byte GetBright(byte y)
        {
            return y;
        }
    }

    public class Scretchscale : Grayscale //частотно-пропорциональное растяжение
    {
        protected double q = 1000000000; //коэффициент Q
        protected byte[] z; //промежуточная шкала яркости
        protected double Zavg, DevZ; //среднее Z и среднеквадратичное отклонение яркости

        public double Q
        {
            get
            {
                return q;
            }
            set
            {
                q = value;
                Update();
            }
        }

        public Scretchscale(Image file, Default_kof kof) 
            :base(file, kof)
        {
            Build();
        }

        protected new void Build()
        {
            SetZ();
            CopyArray();
            Zavg = GetAvg(z);
            DevZ = GetDev(z, Zavg);
        }

        public override void Update()
        {
            base.Build();
            Build();
        }

        void SetZ ()
        {
            double[] u = new double[256];
            double[] d = new double[256];
            z = new byte[256];
            double V;
            u[0] = 0;
            d[0] = 0.5 + q * frequencyArray[0] * 255;
            for (int i = 1; i < 256; i++)
            {
                d[i] = 0.5 + q * frequencyArray[i] * 255;
                u[i] = u[i - 1] + d[i - 1] + d[i];
            }
            V = 255 / u[255];
            z[255] = 255;
            for (int i = 0; i < 255; i++)
            {
                z[i] = Convert.ToByte(Math.Abs(Math.Round(V * u[i]))); //итоговая шкала яркости
            }
        }
        protected new byte GetBright(byte y)
        {
            return z[Convert.ToInt32(y)];
        }
    }

    public class Telescale : Scretchscale //телевизионный алгоритм
    {
        private double qt = 1, qomega = 1; //задаваемые характеристики
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

        public Telescale(Image file, Default_kof kof) 
            : base(file, kof)
        {
            Build();
        }

        protected new void Build()
        {
            SetT();
            CopyArray();
        }

        void SetT()
        {
            double Tavg, omegat; //среднее t и омега с индексом t
            Tavg = qt * Zavg;
            omegat = qomega * DevZ;
            double Qinitial, Qexpected; //Q исходное и ожидаемое
            Qinitial = Tavg / Yavg;
            Qexpected = omegat / (Qinitial * DevY);
            byte[] t = new byte[256];
            double temp;
            for (int i = 0; i < 256; i++)
            {
                temp = Qinitial * (i + Qexpected * (i - Yavg));
                if (temp > 255)
                {
                    t[i] = 255;
                    continue;
                }
                if (temp < 0)
                {
                    t[i] = 0;
                    continue;
                }
                t[i] = Convert.ToByte(temp);
            }
        }
        protected new byte GetBright(byte y)
        {
            return t[Convert.ToInt32(y)];
        }
    }

    public class Overley : Telescale //наложение алгоритмов
    {
        private double k = 0.5;

        public double K
        {
            get
            {
                return k;
            }
            set
            {
                k = value;
                Update();
            }
        }

        public Overley(Image file, Default_kof kof) 
            : base(file, kof)
        {
            CopyArray();
        }

        protected new byte GetBright(byte y)
        {
            return (byte)(k * z[Convert.ToInt32(y)] + (1 - k) * t[Convert.ToInt32(y)]);
        }
        public override void Update()
        {
            CopyArray();
        }
    }
}
