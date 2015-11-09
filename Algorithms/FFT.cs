using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Algorithms
{
    /// <summary>
    /// 二维傅里叶变换算法
    /// </summary>
    public class FFT2
    {
        int iw, ih;
        double[] pixels;
        Complex[] td;
        Complex[] fd;

        // 进行傅里叶变换的宽度和高度(2的整数次方)
        // 赋初值
        int w = 1;
        int h = 1;
        int wp = 0;
        int hp = 0;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FFT2() { }

        /// <summary>
        /// 传递数据
        /// </summary>
        /// <param name="iw">图像宽度</param>
        /// <param name="ih">图像高度</param>
        /// <param name="pixels">图像数据数组（一维）</param>
        public void setData2(int iw, int ih, double[] pixels)
        {
            this.iw = iw;
            this.ih = ih;

            this.pixels = new double[iw * ih];
            this.pixels = pixels;

            //计算进行傅里叶变换的宽度和高度(2的整数次方)
            while (w * 2 <= iw)
            {
                w *= 2;
                wp++;
            }
            while (h * 2 <= ih)
            {
                h *= 2;
                hp++;
            }

            td = new Complex[w * h];
            fd = new Complex[w * h];

            //初始化fd,td
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    fd[i + j * iw] = new Complex();
                    td[i + j * iw] = new Complex(pixels[i + j * iw], 0);
                }
            }

            //在y方向上进行快速傅里叶变换
            for (int j = 0; j < h; j++)
            {
                //每一行做傅立叶变换
                Complex[] tempW1 = new Complex[w];
                Complex[] tempW2 = new Complex[w];
                for (int i = 0; i < w; i++)
                {
                    tempW1[i] = new Complex(0, 0);
                    tempW2[i] = new Complex(0, 0);
                }

                for (int i = 0; i < w; i++)
                    tempW1[i] = td[i + j * iw];

                setData1(tempW1, wp);
                tempW2 = getData1();

                for (int i = 0; i < w; i++)
                    fd[i + j * iw] = tempW2[i];
            }

            //保存变换结果
            for (int j = 0; j < h; j++)
                for (int i = 0; i < w; i++)
                    td[i + j * iw] = fd[i + j * iw];

            //对x方向进行傅里叶变换
            for (int i = 0; i < w; i++)
            {
                //每一列做傅立叶变换
                Complex[] tempW1 = new Complex[h];
                Complex[] tempW2 = new Complex[h];

                for (int j = 0; j < h; j++)
                {
                    tempW1[j] = new Complex(0, 0);
                    tempW2[j] = new Complex(0, 0);
                }

                for (int j = 0; j < h; j++)
                    tempW1[j] = td[i + j * iw];

                setData1(tempW1, hp);
                tempW2 = getData1();

                for (int j = 0; j < h; j++)
                    fd[i + j * iw] = tempW2[j];
            }

            for (int j = 0; j < h; j++)
                for (int i = 0; i < w; i++)
                    td[i + j * w] = fd[i + j * w];
        }

        /// <summary>
        /// 返回FFT变换后的值
        /// </summary>	
        public Complex[] getFFT2()
        {
            return td;
        }

        /// <summary>
        /// 将频谱图像化
        /// </summary>
        /// <returns>频谱转换成的图像（一维数组形式）</returns>
        public double[] getPixels2()
        {
            //获得频谱
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    double re = td[i + j * w].Real;
                    double im = td[i + j * w].Imaginary;

                    double temp = Math.Sqrt(re * re + im * im) / 100.0;

                    if (temp > 255) temp = 255;

                    pixels[i + j * w] = temp;
                }
            }
            return pixels;
        }

        //FFT1=============================================

        int count;     //傅里叶变换点数
        int bfsize, p; //中间变量
        int power;

        Complex[] wc, x1, x2, x;
        Complex[] fd1;

        public void setData1(Complex[] data, int power)
        {
            this.power = power;

            //角度
            double angle;

            //计算傅里叶变换的点数
            count = 1 << power;

            //分配空间
            wc = new Complex[count / 2];
            x = new Complex[count];
            x1 = new Complex[count];
            x2 = new Complex[count];
            fd1 = new Complex[count];

            //初始化
            for (int i = 0; i < count / 2; i++)
                wc[i] = new Complex();

            for (int i = 0; i < count; i++)
            {
                x[i] = new Complex();
                x1[i] = new Complex();
                x2[i] = new Complex();
                fd1[i] = new Complex();
            }

            //计算加权系数
            for (int i = 0; i < count / 2; i++)
            {
                angle = -i * Math.PI * 2 / count;
                wc[i].Real = Math.Cos(angle);
                wc[i].Imaginary = Math.Sin(angle);
            }

            //将实域点写入x1
            for (int i = 0; i < count; i++)
                x1[i] = data[i];
        }

        public Complex[] getData1()
        {
            //蝶形运算
            for (int k = 0; k < power; k++)
            {
                for (int j = 0; j < 1 << k; j++)
                {
                    bfsize = 1 << (power - k);
                    for (int i = 0; i < bfsize / 2; i++)
                    {
                        Complex temp1 = new Complex(0, 0);
                        Complex temp2 = new Complex(0, 0);

                        p = j * bfsize;
                        x2[i + p] = x1[i + p] + x1[i + p + bfsize / 2];

                        temp2 = x1[i + p] - x1[i + p + bfsize / 2];

                        x2[i + p + bfsize / 2] = temp2 * wc[i * (1 << k)];
                    }
                }
                x = x1;
                x1 = x2;
                x2 = x;
            }

            //重新排序
            for (int j = 0; j < count; j++)
            {
                p = 0;
                for (int i = 0; i < power; i++)
                    if ((j & (1 << i)) != 0)
                        p += 1 << (power - i - 1);

                fd1[j] = x1[p];
            }
            return fd1;
        }

        //IFF2====================================================         

        /// <summary>
        /// 逆变换传递数据
        /// </summary>
        /// <param name="iw">图像宽度</param>
        /// <param name="ih">图像高度</param>
        /// <param name="complex">频谱矩阵（复数一维数组）</param>
        public void setData2i(int iw, int ih, Complex[] complex)
        {
            this.iw = iw;
            this.ih = ih;
            // 赋初值
            w = 1;
            h = 1;
            wp = 0;
            hp = 0;

            //计算进行傅里叶变换的宽度和高度（2的整数次方）
            while (w * 2 <= iw)
            {
                w *= 2; wp++;
            }
            while (h * 2 <= ih)
            {
                h *= 2; hp++;
            }

            //分配内存
            td = new Complex[w * h];
            fd = new Complex[w * h];

            //初始化fd,td
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    fd[i + j * iw] = new Complex(complex[i + j * iw].Real, complex[i + j * iw].Imaginary);
                    td[i + j * iw] = new Complex();
                }
            }

            for (int j = 0; j < h; j++)
                for (int i = 0; i < w; i++)
                    td[i + j * w] = fd[i + j * w];

            //对x方向进行FFT反变换
            for (int i = 0; i < w; i++)
            {
                //每一列做FFT反变换
                Complex[] tempW1 = new Complex[h];
                Complex[] tempW2 = new Complex[h];

                for (int j = 0; j < h; j++)
                {
                    tempW1[j] = new Complex(0, 0);
                    tempW2[j] = new Complex(0, 0);
                }

                for (int j = 0; j < h; j++)
                    tempW1[j] = td[i + j * iw];

                setData1i(tempW1, hp);

                tempW2 = getData1i();

                for (int j = 0; j < h; j++)
                    fd[i + j * iw] = tempW2[j];
            }

            //保存变换结果
            for (int j = 0; j < h; j++)
                for (int i = 0; i < w; i++)
                    td[i + j * iw] = fd[i + j * iw];

            //在y方向上进行FFT反变换
            for (int j = 0; j < h; j++)
            {
                //每一行做FFT反变换
                Complex[] tempW1 = new Complex[w];
                Complex[] tempW2 = new Complex[w];
                for (int i = 0; i < w; i++)
                {
                    tempW1[i] = new Complex(0, 0);
                    tempW2[i] = new Complex(0, 0);
                }

                for (int i = 0; i < w; i++)
                    tempW1[i] = td[i + j * iw];

                setData1i(tempW1, wp);

                tempW2 = getData1i();

                for (int i = 0; i < w; i++)
                    fd[i + j * iw] = tempW2[i];
            }
        }

        public Complex[] getComplex2i()
        {
            return td;
        }

        /// <summary>
        /// 获得逆变换后的图像
        /// </summary>
        /// <returns>逆变换后的图像</returns>
        public double[] getPixels2i()
        {
            //计算原象素值
            pixels = new double[iw * ih];
            for (int j = 0; j < h; j++)
            {
                for (int i = 0; i < w; i++)
                {
                    double re = fd[i + j * iw].Real;
                    double im = fd[i + j * iw].Imaginary;

                    double temp = Math.Sqrt(re * re + im * im);

                    if (temp > 255) temp = 255;

                    pixels[i + j * iw] = temp;
                }
            }
            return pixels;
        }

        //IFF1=====================================================

        Complex[] fd1i;

        FFT2 fft2;

        public void setData1i(Complex[] data, int power)
        {
            this.power = power;

            //计算傅里叶变换的点数
            count = 1 << power;

            //分配空间
            x = new Complex[count];
            fd1i = new Complex[count];

            for (int i = 0; i < count; i++)
            {
                x[i] = new Complex();
                fd1i[i] = new Complex();
            }

            //将频域点写入x
            for (int i = 0; i < count; i++)
                x[i] = data[i];
        }

        public Complex[] getData1i()
        {
            // 求共轭
            for (int i = 0; i < count; i++)
            {
                double im = -x[i].Imaginary;
                x[i].Imaginary = im;
            }

            fft2 = new FFT2();
            fft2.setData1(x, power);
            fd1i = fft2.getData1();

            for (int i = 0; i < count; i++)
            {
                double re = fd1i[i].Real;
                double im = -fd1i[i].Imaginary;
                fd1i[i].Imaginary = im / count;
                fd1i[i].Real = re / count;
            }
            return fd1i;
        }
    }
}
