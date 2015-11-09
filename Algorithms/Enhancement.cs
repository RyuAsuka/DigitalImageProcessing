using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace DIP.Algorithms
{
    public class Enhancement
    {
        Bitmap image;

        public Enhancement(Bitmap bmp)
        {
            image = bmp;
        }

        public Bitmap Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// 均值滤波算法
        /// </summary>
        public Bitmap AverageFilter()
        {
            Bitmap retVal = new Bitmap(image.Width, image.Height);
            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    int avr = 0, sum = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            sum += image.GetPixelGray(x + i, y + j);
                        }
                    }

                    avr = (int)(sum / 9.0F);

                    retVal.SetPixelGray(x, y, avr);
                }
            }

            return retVal;
        }

        /// <summary>
        /// 中值滤波算法
        /// </summary>
        public Bitmap MedianFilter()
        {
            Bitmap retVal = new Bitmap(image.Width, image.Height);
            int[] values = new int[9];

            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    int median = 0;
                    values[0] = image.GetPixelGray(x - 1, y - 1);
                    values[1] = image.GetPixelGray(x, y - 1);
                    values[2] = image.GetPixelGray(x + 1, y - 1);
                    values[3] = image.GetPixelGray(x - 1, y);
                    values[4] = image.GetPixelGray(x, y);
                    values[5] = image.GetPixelGray(x + 1, y);
                    values[6] = image.GetPixelGray(x - 1, y + 1);
                    values[7] = image.GetPixelGray(x, y + 1);
                    values[8] = image.GetPixelGray(x + 1, y + 1);

                    IEnumerable<int> query = values.OrderBy(v => v);

                    median = query.ElementAt(4);

                    retVal.SetPixelGray(x, y, median);
                }
            }
            return retVal;
        }

        /// <summary>
        /// 拉普拉斯锐化算法
        /// </summary>
        public Bitmap Laplace()
        {
            Bitmap retVal = new Bitmap(image.Width, image.Height);
            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    int value = image.GetPixelGray(x - 1, y - 1) +
                                image.GetPixelGray(x, y - 1) +
                                image.GetPixelGray(x + 1, y - 1) +
                                image.GetPixelGray(x - 1, y) +
                                image.GetPixelGray(x + 1, y) +
                                image.GetPixelGray(x - 1, y + 1) +
                                image.GetPixelGray(x, y + 1) +
                                image.GetPixelGray(x + 1, y + 1) -
                                8 * image.GetPixelGray(x, y);

                    value = image.GetPixelGray(x, y) - value;
                    if (value > 255) value = 255;
                    if (value < 0) value = 0;

                    retVal.SetPixelGray(x, y, value);
                }
            }

            return retVal;
        }

        /// <summary>
        /// 频域滤波算法
        /// </summary>
        /// <param name="_image">要施加滤波算法的图像</param>
        /// <param name="type">滤波类型</param>
        /// <param name="d0"></param>
        /// <returns></returns>
        public Bitmap FrequencyFilter(Bitmap _image, FilterType type, int d0)
        {
            Bitmap output = new Bitmap(_image);
            int iw = image.Width;
            int ih = image.Height;
            double[] outpix = new double[iw * ih];
            Complex[] complex;

            for (int y = 0; y < ih; y++)
            {
                for (int x = 0; x < iw; x++)
                {
                    outpix[x + y * iw] = image.GetPixelGray(x, y);
                }
            }

            FFT2 fft2 = new FFT2();
            fft2.setData2(iw, ih, outpix);
            complex = fft2.getFFT2();

            Complex bc = new Complex();

            for (int v = 0; v < ih; v++)
            {
                for (int u = 0; u < iw; u++)
                {
                    double dd = Math.Sqrt(u * u + v * v);
                    //double dd = u * u + v * v;

                    switch (type)
                    {
                        case FilterType.IdealLowPass:
                            if (dd <= d0) bc = new Complex(1);
                            else bc = new Complex(0);
                            //bc = new Complex(1 / (1 + 0.4142 * dd / (d0 * d0)));
                            break;
                        case FilterType.IdealHighPass:
                            if (dd <= d0) bc = new Complex(0);
                            else bc = new Complex(1);
                            //bc = new Complex(1 / (1 + 0.4142 * (d0 * d0)/dd));
                            break;
                        case FilterType.GaussianLowPass:
                            bc = new Complex(Math.Exp(-(dd * dd) / (2 * d0 * d0)));
                            //bc = new Complex(Math.Exp(-0.5*Math.Log(2)*dd/(d0*d0)));
                            break;
                        case FilterType.GaussianHighPass:
                            bc = new Complex(Math.Exp(-(dd * dd) / (2 * d0 * d0)));
                            //bc = new Complex(Math.Exp(-0.5 * Math.Log(2) * dd / (d0 * d0)));
                            bc = new Complex(1) - bc;
                            break;
                        default:
                            break;
                    }
                    complex[u + v * iw] = complex[u + v * iw] * bc;
                }
            }

            //FFT2 ifft2 = new FFT2();
            fft2.setData2i(iw, ih, complex);
            outpix = fft2.getPixels2i();

            double max = outpix[0];
            for (int y = 0; y < ih; y++)
            {
                for (int x = 0; x < iw; x++)
                {
                    if (max < outpix[x + y * iw])
                        max = outpix[x + y * iw];
                }
            }

            for (int y = 0; y < ih; y++)
            {
                for (int x = 0; x < iw; x++)
                {
                    int r = (int)(outpix[x + y * iw] * 255 / max);
                    output.SetPixelGray(x, y, r);
                }
            }

            return output;
        }
    }
}
