using System;
using System.Collections.Generic;
using System.Drawing;

namespace DIP.Algorithms
{
    /// <summary>
    /// 基本变换类
    /// </summary>
    public class BasicTransform : IBasicTransform
    {
        private Bitmap image;
        private int[] histogram;
        private Matrix mat;
        private int mark = 1;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="input">输入的图像</param>
        public BasicTransform(Bitmap input)
        {
            image = input;
            histogram = new int[256];
            mat = new Matrix(image.Width, image.Height);
        }

        /// <summary>
        /// 获取或设置该类的实例中保存的图像
        /// </summary>
        public Bitmap Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        /// <summary>
        /// 获取直方图
        /// </summary>
        public int[] Histogram
        {
            get { return histogram; }
        }

        /// <summary>
        /// 灰度化
        /// </summary>
        public void Graying()
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = image.GetPixel(x, y);
                    var r = color.R;
                    var g = color.G;
                    var b = color.B;
                    var newColor = (r + g + b) / 3;
                    image.SetPixel(x, y, Color.FromArgb(newColor, newColor, newColor));
                }
            }
        }

        /// <summary>
        /// 二值化图像
        /// </summary>
        /// <param name="threshold">所指定的阈值，超过该阈值则标记为1，否则为0</param>
        public void Binaryze(byte threshold)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int graylevel = image.GetPixelGray(x, y);
                    if (graylevel >= threshold)
                    {
                        image.SetPixelGray(x, y, 255);
                    }
                    else
                    {
                        image.SetPixelGray(x, y, 0);
                    }
                }
            }
        }

        /// <summary>
        /// 伽马变换
        /// </summary>
        /// <param name="gamma">伽马值</param>
        public void GammaTransform(double gamma)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // 归一化
                    double current = (double)(image.GetPixelGray(x, y)) / 256.0F;

                    // 计算
                    double newValue = Math.Pow(current, gamma);

                    // 反归一化
                    newValue *= 256.0F;

                    image.SetPixelGray(x, y, (byte)newValue);
                }
            }
        }

        private int f(int x, int y, int choose)
        {
            switch (choose)
            {
                case 1:
                    return image.GetPixelGray(x, y) == 255 ? 1 : 0; // 将白色作为目标颜色
                case 2:
                    return image.GetPixelGray(x, y) == 255 ? 0 : 1; // 将黑色作为目标颜色
                default:
                    return image.GetPixelGray(x, y) == 255 ? 0 : 1;
            }
        }
        /// <summary>
        /// 求取连通域
        /// </summary>
        public Matrix GetConnectedRegion(int choose)
        {
            int x, y;
            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    Connect(x, y, choose);
                }
            }


            // Painting
            List<Color> colorList = CreateRandomColorList(mark + 1);
            for (y = 0; y < image.Height; y++)
            {
                for (x = 0; x < image.Width; x++)
                {
                    if (f(x, y, choose) == 1 && mat[x, y] != 0)
                    {
                        image.SetPixel(x, y, colorList[mat[x, y]]);
                    }
                }
            }

            return mat;
        }

        /// <summary>
        /// 生成随机颜色表
        /// </summary>
        /// <param name="n">随机颜色表的长度</param>
        /// <returns>随机颜色表</returns>
        private List<Color> CreateRandomColorList(int n)
        {
            List<Color> clist = new List<Color>();
            Random rd = new Random();
            byte[] rgb = new byte[3];
            for (int i = 0; i < n; i++)
            {
                int A = 0xFF;
                rd.NextBytes(rgb);
                int colorNum = (A << 24) + (rgb[0] << 16) + (rgb[1] << 8) + rgb[0];
                Color c = Color.FromArgb(colorNum);
                clist.Add(c);
            }
            return clist;
        }

        /// <summary>
        /// 回溯法标记连通域
        /// </summary>
        /// <param name="x">该点的横坐标</param>
        /// <param name="y">该点的纵坐标</param>
        /// <param name="isMarked">是否已经被标记过，用于记录回溯路线。默认值为false，如果该点已经被标记过，则应指定该参数为true。</param>
        private void Connect(int x, int y, int choose, bool isMarked = false)
        {
            if (x == 0 && y == 0) //mat[0, 0]
            {
                if (f(x, y, choose) == 1) mat[x, y] = mark; // new area
            }

            else if (x != 0 && y == 0) // First Row
            {
                if (f(x, y, choose) == 1)
                {
                    if (mat[x - 1, y] != 0)
                    {
                        mat[x, y] = mat[x - 1, y]; // left one
                        Connect(x - 1, y, choose, true);
                    }
                    else
                    {
                        if (isMarked == false)
                            mat[x, y] = ++mark; // new area
                    }
                }
            }

            else if (x == 0 && y != 0) // First Column
            {
                if (f(x, y, choose) == 1)
                {
                    if (mat[x, y - 1] != 0)
                    {
                        mat[x, y] = mat[x, y - 1]; // up one
                        Connect(x, y - 1, choose, true);
                    }
                    else
                    {
                        if (isMarked == false)
                            mat[x, y] = ++mark;
                    }
                }
            }

            else if (x != 0 && y != 0) // other pixel
            {
                if (f(x, y, choose) == 1)
                {
                    if (mat[x, y - 1] == 0 && mat[x - 1, y] == 0) // new area
                    {
                        if (isMarked == false)
                            mat[x, y] = ++mark;
                    }
                    else if (mat[x, y - 1] == 0 && mat[x - 1, y] != 0)
                    {
                        if (isMarked == false)
                            mat[x, y] = mat[x - 1, y];
                        else
                        {
                            if (mat[x - 1, y] > mat[x, y])
                                mat[x - 1, y] = mat[x, y];
                            Connect(x - 1, y, choose, true); // 沿x方向继续回溯
                        }
                    }
                    else if (mat[x, y - 1] != 0 && mat[x - 1, y] == 0)
                    {
                        if (isMarked == false)
                            mat[x, y] = mat[x, y - 1];
                        else
                        {
                            if (mat[x, y - 1] > mat[x, y])
                                mat[x, y - 1] = mat[x, y];
                            Connect(x, y - 1, choose, true); // 沿y方向继续回溯
                        }
                    }
                    else if (mat[x, y - 1] != 0 && mat[x - 1, y] != 0 && mat[x, y - 1] == mat[x - 1, y])
                    {
                        if (isMarked == false)
                            mat[x, y] = mat[x, y - 1];
                        else
                        {
                            if (mat[x, y - 1] > mat[x, y])
                            {
                                mat[x, y - 1] = mat[x - 1, y] = mat[x, y];
                                Connect(x - 1, y, choose, true); // 遇到上边和左边都有已标记像素的情况，两边同时回溯
                                Connect(x, y - 1, choose, true);
                            }
                        }

                    }
                    else if (mat[x, y - 1] != 0 && mat[x - 1, y] != 0 && mat[x, y - 1] != mat[x - 1, y])
                    {
                        mat[x, y] = Math.Min(mat[x - 1, y], mat[x, y - 1]);
                        mat[x - 1, y] = mat[x, y - 1] = mat[x, y]; // 直接消除等价类
                        Connect(x - 1, y, choose, true);
                        Connect(x, y - 1, choose, true);
                    }
                }
            }
        }

        /// <summary>
        /// 生成直方图
        /// </summary>
        public void GetHistogram()
        {
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
            }

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int level = image.GetPixelGray(x, y);
                    histogram[level]++;
                }
            }
        }

        /// <summary>
        /// 直方图均衡化
        /// </summary>
        public void HistEqual()
        {
            GetHistogram();
            double p = (double)255 / (image.Height * image.Width);
            double[] sum = new double[256];
            int[] outg = new int[256];
            int g;

            sum[0] = histogram[0];
            for (int i = 1; i < 256; i++)
            {
                sum[i] = sum[i - 1] + histogram[i];
            }

            for (int i = 0; i < 256; i++)
            {
                outg[i] = (int)(p * sum[i]);
            }

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    g = image.GetPixelGray(x, y);

                    try {
                        image.SetPixelGray(x, y, outg[g]);
                    }
                    catch(Exception ex)
                    {
                        string message = ex.Message;
                    }
                }
            }
        }

        /// <summary>
        /// 对数变换
        /// </summary>
        public void LogarithmTransform()
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // 归一化
                    double current = (double)(image.GetPixelGray(x, y)) / 256.0F;

                    // 计算
                    double newValue = Math.Log(current + 1);

                    // 反归一化
                    newValue *= 256.0F;

                    image.SetPixelGray(x, y, (byte)newValue);
                }
            }
        }

        /// <summary>
        /// 反转
        /// </summary>
        public void Reverse()
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    int graylevel = image.GetPixelGray(x, y);
                    int newlevel = 255 - graylevel;
                    image.SetPixelGray(x, y, newlevel);
                }
            }
        }
    }
}
