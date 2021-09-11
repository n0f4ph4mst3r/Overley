//пользовательские типы для создаваемых изображений
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace НаложениеАлгоритмов
{
    public struct ImageContainer //контейнер для изображений
    {
        SourceImage source;
        Gray gray;
        Scretch scretch;
        Tele tele;
        Overley overley;

        public ImageContainer(Image file, Default_kof kof) 
        {
            source = new SourceImage(file);
            gray = new Gray(source, kof);
            scretch = new Scretch(gray);
            tele = new Tele(gray, scretch);
            overley = new Overley(scretch, tele);
        }

        public Bitmap GrayBit
        {
            get
            {
                return gray.Bit;
            }
        }

        public double[] GrayFrequencys
        {
            get
            {
                return gray.Frequencys;
            }
        }

        public Bitmap ScretchBit
        {
            get
            {
                return scretch.Bit;
            }
        }

        public double[] ScretchFrequencys
        {
            get
            {
                return scretch.Frequencys;
            }
        }

        public Bitmap TeleBit
        {
            get
            {
                return tele.Bit;
            }
        }

        public double[] TeleFrequencys
        {
            get
            {
                return tele.Frequencys;
            }
        }

        public Bitmap OverleyBit
        {
            get
            {
                return overley.Bit;
            }
        }

        public double[] OverleyFrequencys
        {
            get
            {
                return overley.Frequencys;
            }
        }

        public double Q
        {
            get
            {
                return scretch.Q;
            }
            set
            {
                scretch.Q = value;
                tele.Update(scretch);
                overley.Update(scretch, tele);
            }
        }

        public double Qt
        {
            get
            {
                return tele.Qt;
            }
            set
            {
                tele.Qt = value;
                overley.Update(tele);
            }
        }

        public double Qomega
        {
            get
            {
                return tele.Qomega;
            }
            set
            {
                tele.Qomega = value;
                overley.Update();
            }
        }

        public double K
        {
            get
            {
                return overley.K;
            }
            set
            {
                overley.K = value;
            }
        }
        public class SourceImage : AbstractImage //для исходного изображения
        {
            //поля
            Image file;

            public SourceImage(Image file)
            {
                Update(file);
            }

            //методы
            override public void Update()
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
                Update();
            }
        }

        public class Gray : ImageGen.MathMod
        {
            //поля
            Default_kof kof; //набор коэффициентов
            double yavg, ydev; //среднее Y и среднеквадратичное отклонение яркости

            public Gray(SourceImage source, Default_kof kof)
            {
                Update(source, kof);
            }

            //методы
            public void Update(SourceImage source, Default_kof kof)
            {
                this.kof = kof;
                this.source = source.Bit;
                bytes_source = source.Bytes;
                n = source.N;
                Update();
            }

            override public void Update()
            {
                y = new byte[n*3];
                for (int i = 0; i < y.Length; i += 3)
                {
                    y[i / 3] = Convert.ToByte(Math.Round(kof.k1 * bytes_source[i] + kof.k2 * bytes_source[i + 1] + kof.k3 * bytes_source[i + 2]));
                }
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
                    return yavg;
                }
            }
        }

        public class Scretch : ImageGen.MathMod
        {
            //поля
            Gray gray;

            double q = 0; //коэффициент Q
            byte[] z; //промежуточная шкала яркости
            double zavg, zdev; //среднее Y и среднеквадратичное отклонение яркости

            public Scretch(Gray source)
            {
                Update(source);
            }

            //методы
            public void Update(Gray gray)
            {
                this.gray = gray;
                source = gray.BitSource;
                bytes_source = gray.BytesSource;
                n = gray.N;
                y = gray.Y;
                Update();
            }

            //методы
            override public void Update()
            {
                frequencyArray = gray.Frequencys;

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

            override protected byte GetBright(byte y)
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
                set
                {
                    q = value;
                    Update();
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

        public class Tele : ImageGen
        {
            //поля
            Gray gray;
            Scretch scretch;

            double qt = 1, qomega = 1; //задаваемые характеристики
            byte[] t = new byte[256]; //массив яркостей

            public Tele(Gray gray, Scretch scretch)
            {
                Update(gray, scretch);
            }

            //методы
            public void Update (Scretch scretch)
            {
                this.scretch = scretch;
                source = scretch.BitSource;
                bytes_source = scretch.BytesSource;
                n = scretch.N;
                y = scretch.Y;
                Update();
            }
            public void Update(Gray gray, Scretch scretch)
            {
                this.gray = gray;
                Update(scretch);
            }

            override public void Update()
            {
                frequencyArray = scretch.Frequencys;

                double Tavg, omegat; //среднее t и омега с индексом t
                Tavg = qt * scretch.Avg;
                omegat = qomega * scretch.Dev;
                double Qinitial, Qexpected; //Q исходное и ожидаемое
                Qinitial = Tavg / gray.Avg;
                Qexpected = omegat / (Qinitial * gray.Dev);
                double temp;
                for (int i = 0; i < 256; i++)
                {
                    temp = Qinitial * (i + Qexpected * (i - gray.Avg));
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
                    temp = Math.Round(temp);
                    t[i] = (byte)temp;
                }
                SetFreqencys();
            }
            protected override byte GetBright(byte y)
            {
                return t[Convert.ToInt32(y)];
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

            public byte[] T
            {
                get
                {
                    return t;
                }
            }
        }

        public class Overley : ImageGen //наложение алгоритмов
        {
            Scretch scretch;
            Tele tele;

            double k = 0.5;

            public Overley(Scretch scretch, Tele tele)
            {
                Update(scretch, tele);
            }

            protected override byte GetBright(byte y)
            {
                return (byte)(k * scretch.Z[Convert.ToInt32(y)] + (1 - k) * tele.T[Convert.ToInt32(y)]);
            }

            public void Update (Scretch scretch, Tele tele)
            {
                this.scretch = scretch;
                Update(tele);
            }

            public void Update (Tele tele)
            {
                this.tele = tele;
                source = tele.BitSource;
                bytes_source = tele.BytesSource;
                n = tele.N;
                y = tele.Y;
                Update();
            }
            public override void Update()
            {
                frequencyArray = tele.Frequencys;
                SetFreqencys();
            }

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
        }
    }
}
