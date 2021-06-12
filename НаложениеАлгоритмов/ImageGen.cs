using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace НаложениеАлгоритмов
{
    public class SourceImageGen : SourceImageInterface
    {
        //поля
        Image file;

        public SourceImageGen(Image file)
        {
            Update(file);    
        }

        //методы
        protected override void Build()
        {
            //получаем исходное изображение и количество пикселей
            bit = new Bitmap(file);
            n = (uint)(bit.Width * bit.Height);
            //получаем ссылку и адрес
            databit = bit.LockBits(new Rectangle(0, 0, bit.Width, bit.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            pointer = databit.Scan0;
            //получаеем значения пикселей
            bytes = new byte[n * 3];
            Marshal.Copy(pointer, bytes, 0, bytes.Length);
            bit.UnlockBits(databit);
        }

        public void Update(Image file)
        {
            this.file = file;
            Build();
        }
    }

    public class GrayscaleGen : GrayscaleInterface
    {
        //поля
        Default_kof kof; //набор коэффициентов
        byte[] y; //яркость каждого пикселя в сиходном изображении
        double yavg, ydev; //среднее Y и среднеквадратичное отклонение яркости

        public GrayscaleGen(SourceImageGen source, Default_kof kof)
        {
            Update(source, kof);
        }

        //методы
        public void Update(SourceImageGen source, Default_kof kof)
        {
            this.kof = kof;
            this.source = source.Bit;
            bytes_source = source.Bytes;
            Build();
        }

        protected override void Build()
        {
            SetBright();
            SetFreqencys();
            yavg = GetAvg(yavg);
            ydev = GetDev(ydev, yavg);
        }

        protected override byte GetBright(byte y)
        {
            return y;
        }

        //свойства
        public override double Dev
        {
            get
            {
                return ydev;
            }
        }
        public override double Avg
        {
            get
            {
                return Avg;
            }
        }
    }

    public class ScretchGen : GrayscaleInterface
    {
        //поля
        private double q = 0; //коэффициент Q
        private byte[] z; //промежуточная шкала яркости
        double zavg, zdev; //среднее Y и среднеквадратичное отклонение яркости

        public ScretchGen(GrayscaleGen source)
        {
            Update(source);
        }
        
        //методы
        public void Update (GrayscaleGen source)
        {
            this.source = source.BitSource;
            bytes_source = source.BytesSource;
            frequencyArray = source.Frequencys;
        }

        //методы
        override protected void Build()
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
            SetFreqencys();
            zavg = GetAvg(zavg);
            zdev = GetDev(zdev, zavg);
        }

        override protected byte GetBright (byte y)
        {
            return z[Convert.ToInt32(y)];
        }

        //свойства
        public double Q
        {
            get
            {
                return q;
            }
        }

        public byte[] Z
        {
            get
            {
                return z;
            }
        }

        override public double Dev
        {
            get
            {
                return zdev;
            }
        }

        override public double Avg
        {
            get
            {
                return zavg;
            }
        }
    }

    public class TeleGen : ImageGen
    {
        //поля
        double qt = 1, qomega = 1; //задаваемые характеристики
        byte[] t = new byte[256]; //массив яркостей
        double devy, yavg, devz;

        public TeleGen(GrayscaleGen gray, ScretchGen scretch)
        {
            Update(gray, scretch);
        }

        //методы
        public void Update (GrayscaleGen gray, ScretchGen scretch)
        {
            source = scretch.BitSource;
            bytes_source = scretch.BytesSource;
            frequencyArray = scretch.Frequencys;
            devz = scretch.Dev;
            devy = gray.Dev;
            yavg = gray.Avg;

            Build();
        }

        override protected void Build()
        {
            double Tavg, omegat; //среднее t и омега с индексом t
            Tavg = qt * devz;
            omegat = qomega * devz;
            double Qinitial, Qexpected; //Q исходное и ожидаемое
            Qinitial = Tavg / yavg;
            Qexpected = omegat / (Qinitial * devy);
            byte[] t = new byte[256];
            double temp;
            for (int i = 0; i < 256; i++)
            {
                temp = Qinitial * (i + Qexpected * (i - yavg));
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
            SetFreqencys();
        }
        //свойства
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
