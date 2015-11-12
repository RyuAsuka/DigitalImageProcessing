using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DIP.Algorithms
{
    /// <summary>
    /// 图像复原空间滤波算法
    /// </summary>
    public class RecoverySpace
    {
        Bitmap image;
        double[,] imageMat, newMat;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="input">输入的图像</param>
        public RecoverySpace(Bitmap input)
        {
            image = input;
            imageMat = new double[input.Width, input.Height];
            newMat = new double[input.Width, input.Height];
            Digitalize();
        }

        /// <summary>
        /// 获取或设置参与变换的图像
        /// </summary>
        public Bitmap Image
        {
            get { return image; }
            set { image = value; Digitalize(); }
        }

        /// <summary>
        /// 清空缓冲区
        /// </summary>
        private void Clear()
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    newMat[x, y] = 0.0f;
                }
            }
        }

        /// <summary>
        /// 图像数字化，提高处理速度
        /// </summary>
        private void Digitalize()
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    imageMat[x, y] = image.GetPixelGray(x, y);
                    if (imageMat[x, y] <= 0.00000001) imageMat[x, y] = 0.01;
                }
            }
        }

        /// <summary>
        /// 将数组转换为图像
        /// </summary>
        private void ToPicture()
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    image.SetPixelGray(x, y, (int)newMat[x, y]);
                }
            }
        }

        #region 均值滤波方法
        /// <summary>
        /// 算术均值滤波
        /// </summary>
        /// <param name="n">窗口大小</param>
        public void ArithmeticMeanFilter(int n)
        {
            Clear();
            int start = 0;
            double sum = 0;
            double average = 0;
            switch (n)
            {
                case 3:
                    start = 1;
                    break;
                case 5:
                    start = 2;
                    break;
                case 9:
                    start = 4;
                    break;
                default:
                    throw new Exception("阶数必须为奇数！");
            }

            for (int y = start; y < image.Height - start; y++)
            {
                for (int x = start; x < image.Width - start; x++)
                {
                    sum = 0;
                    for (int s = -(n - 1) / 2; s <= (n - 1) / 2; s++)
                    {
                        for (int t = -(n - 1) / 2; t <= (n - 1) / 2; t++)
                        {
                            average = imageMat[x + s, y + t] / (n * n);
                            sum += average;
                        }
                    }

                    if (sum > 255) sum = 255;
                    if (sum < 0) sum = 0;
                    newMat[x, y] = sum;
                }
            }

            ToPicture();

        }

        /// <summary>
        /// 几何均值滤波
        /// </summary>
        /// <param name="n">窗口大小</param>
        public void GeometricMeanFilter(int n)
        {
            Clear();
            int start = 0;
            double product = 1;
            double average = 0;
            switch (n)
            {
                case 3:
                    start = 1;
                    break;
                case 5:
                    start = 2;
                    break;
                case 9:
                    start = 4;
                    break;
                default:
                    throw new Exception("阶数必须为奇数！");
            }

            for (int y = start; y < image.Height - start; y++)
            {
                for (int x = start; x < image.Width - start; x++)
                {
                    product = 1;
                    for (int s = -(n - 1) / 2; s <= (n - 1) / 2; s++)
                    {
                        for (int t = -(n - 1) / 2; t <= (n - 1) / 2; t++)
                        {
                            double pixelValue = imageMat[x + s, y + t];
                            average = Math.Pow(pixelValue, 1.0F / (n * n));
                            product *= average;
                        }
                    }


                    if (product > 255) product = 255;
                    if (product < 0) product = 0;
                    newMat[x, y] = product;
                }
            }

            ToPicture();
        }

        /// <summary>
        /// 谐波变换均值滤波
        /// </summary>
        /// <param name="n">窗口大小</param>
        public void HarmonicMeanFilter(int n)
        {
            Clear();
            int start = 0;
            switch (n)
            {
                case 3:
                    start = 1;
                    break;
                case 5:
                    start = 2;
                    break;
                case 9:
                    start = 4;
                    break;
                default:
                    throw new Exception("阶数必须为奇数！");
            }

            for (int y = start; y < image.Height - start; y++)
            {
                for (int x = start; x < image.Width - start; x++)
                {
                    double ans = 0;
                    for (int s = -(n - 1) / 2; s <= (n - 1) / 2; s++)
                    {
                        for (int t = -(n - 1) / 2; t <= (n - 1) / 2; t++)
                        {
                            ans += 1.0F / imageMat[x + s, y + t];
                        }
                    }

                    double average = (n * n) / ans;
                    if (average > 255) average = 255;
                    if (average < 0) average = 0;
                    newMat[x, y] = average;
                }
            }
            ToPicture();
        }

        /// <summary>
        /// 逆谐波变换滤波
        /// </summary>
        /// <param name="n">窗口大小</param>
        /// <param name="Q">指数Q</param>
        public void ContraharmonicMeanFilter(int n, double Q)
        {
            Clear();
            int start = 0;
            switch (n)
            {
                case 3:
                    start = 1;
                    break;
                case 5:
                    start = 2;
                    break;
                case 9:
                    start = 4;
                    break;
                default:
                    throw new Exception("阶数必须为奇数！");
            }

            for (int y = start; y < image.Height - start; y++)
            {
                for (int x = start; x < image.Width - start; x++)
                {
                    double ans1 = 0;
                    double ans2 = 0;
                    for (int s = -(n - 1) / 2; s <= (n - 1) / 2; s++)
                    {
                        for (int t = -(n - 1) / 2; t <= (n - 1) / 2; t++)
                        {
                            ans1 += Math.Pow(imageMat[x + s, y + t], Q + 1);
                            ans2 += Math.Pow(imageMat[x + s, y + t], Q);
                        }
                    }

                    double average = ans1 / ans2;
                    if (average > 255) average = 255;
                    if (average < 0) average = 0;
                    newMat[x, y] = average;
                }
            }

            ToPicture();
        }
        #endregion

        #region 统计排序滤波方法
        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="n">窗口大小</param>
        public void MedianFilter(int n)
        {
            Clear();
            int start = 0;
            int m = 0;
            List<double> plist = new List<double>();
            switch (n)
            {
                case 3:
                    start = 1;
                    m = 4;
                    break;
                case 5:
                    start = 2;
                    m = 12;
                    break;
                case 9:
                    start = 4;
                    m = 40;
                    break;
                default:
                    throw new Exception("阶数必须为奇数！");
            }

            for (int y = start; y < image.Height - start; y++)
            {
                for (int x = start; x < image.Width - start; x++)
                {
                    plist.Clear();
                    for (int s = -(n - 1) / 2; s <= (n - 1) / 2; s++)
                    {
                        for (int t = -(n - 1) / 2; t <= (n - 1) / 2; t++)
                        {
                            plist.Add(imageMat[x + s, y + t]);
                        }
                    }

                    plist.Sort();
                    newMat[x, y] = plist[m];
                }
            }

            ToPicture();
        }

        /// <summary>
        /// 最大值滤波
        /// </summary>
        /// <param name="n">窗口大小</param>
        public void MaxFilter(int n)
        {
            Clear();
            int start = 0;
            double max = 0;
            switch (n)
            {
                case 3:
                    start = 1;
                    break;
                case 5:
                    start = 2;
                    break;
                case 9:
                    start = 4;
                    break;
                default:
                    throw new Exception("阶数必须为奇数！");
            }

            for (int y = start; y < image.Height - start; y++)
            {
                for (int x = start; x < image.Width - start; x++)
                {
                    max = 0;
                    for (int s = -(n - 1) / 2; s <= (n - 1) / 2; s++)
                    {
                        for (int t = -(n - 1) / 2; t <= (n - 1) / 2; t++)
                        {
                            if (max < imageMat[x + s, y + t]) max = imageMat[x + s, y + t];
                        }
                    }

                    newMat[x, y] = max;
                }
            }

            ToPicture();
        }

        /// <summary>
        /// 最小值滤波
        /// </summary>
        /// <param name="n">窗口大小</param>
        public void MinFilter(int n)
        {
            Clear();
            int start = 0;
            double min = 255;
            switch (n)
            {
                case 3:
                    start = 1;
                    break;
                case 5:
                    start = 2;
                    break;
                case 9:
                    start = 4;
                    break;
                default:
                    throw new Exception("阶数必须为奇数！");
            }

            for (int y = start; y < image.Height - start; y++)
            {
                for (int x = start; x < image.Width - start; x++)
                {
                    min = 255;
                    for (int s = -(n - 1) / 2; s <= (n - 1) / 2; s++)
                    {
                        for (int t = -(n - 1) / 2; t <= (n - 1) / 2; t++)
                        {
                            if (min > imageMat[x + s, y + t]) min = imageMat[x + s, y + t];
                        }
                    }

                    newMat[x, y] = min;
                }
            }

            ToPicture();
        }


        /// <summary>
        /// 中点滤波
        /// </summary>
        /// <param name="n">窗口大小</param>
        public void MiddlePointFilter(int n)
        {
            Clear();
            int start = 0;
            double max = 0;
            double min = 255;
            switch (n)
            {
                case 3:
                    start = 1;
                    break;
                case 5:
                    start = 2;
                    break;
                case 9:
                    start = 4;
                    break;
                default:
                    throw new Exception("阶数必须为奇数！");
            }

            for (int y = start; y < image.Height - start; y++)
            {
                for (int x = start; x < image.Width - start; x++)
                {
                    min = 255;
                    max = 0;
                    for (int s = -(n - 1) / 2; s <= (n - 1) / 2; s++)
                    {
                        for (int t = -(n - 1) / 2; t <= (n - 1) / 2; t++)
                        {
                            if (min > imageMat[x + s, y + t]) min = imageMat[x + s, y + t];
                            if (max < imageMat[x + s, y + t]) max = imageMat[x + s, y + t]; 
                        }
                    }

                    newMat[x, y] = (max + min) / 2;
                }
            }

            ToPicture();
        }
        #endregion

    }
}


