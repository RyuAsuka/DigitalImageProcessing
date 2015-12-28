using System;
using System.Drawing;

namespace DIP.Algorithms
{
    /// <summary>
    /// 彩色图像处理
    /// </summary>
    public class ColorfulImageProcessor
    {
        Bitmap origin;
        Bitmap after;
        int width;
        int height;
        HSI[,] hsiTable;
        Color[,] rgbTable;

        /// <summary>
        /// 构造函数，从输入图像生成RGB矩阵和HSI矩阵
        /// </summary>
        /// <param name="input">输入图像</param>
        public ColorfulImageProcessor(Bitmap input)
        {
            origin = input;
            after = (Bitmap)origin.Clone();
            width = input.Width;
            height = input.Height;
            hsiTable = new HSI[width, height];
            rgbTable = new Color[width, height];
            GetRGBTable();
        }

        /// <summary>
        /// 生成RGB矩阵
        /// </summary>
        private void GetRGBTable()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    rgbTable[x, y] = origin.GetPixel(x, y);
                }
            }
        }

        /// <summary>
        /// 获取或设置图像
        /// </summary>
        public Bitmap Image
        {
            get { return after; }
            set { after = value; }
        }

        /// <summary>
        /// RGB矩阵转HSI矩阵
        /// </summary>
        public void RGBToHSI()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c = origin.GetPixel(x, y);
                    int r = c.R;
                    int g = c.G;
                    int b = c.B;
                    if (r + g + b == 0)
                    {
                        r = 1;
                        g = 1;
                        b = 1;
                    }
                    if (b <= g) hsiTable[x, y].H = (int)GetTheta(c);
                    else hsiTable[x, y].H = (int)(360 - GetTheta(c));

                    hsiTable[x, y].S = 1 - ((3 / (r + g + b)) * Min(r, g, b));

                    hsiTable[x, y].I = (r + g + b) / 3;
                }
            }
        }

        /// <summary>
        /// HSI矩阵转RGB矩阵
        /// </summary>
        public void HSIToRGB()
        {
            int R = 0, G = 0, B = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int h = hsiTable[x, y].H;
                    int s = hsiTable[x, y].S;
                    int i = hsiTable[x, y].I;

                    if (0 <= h && h < 120)
                    {
                        B = i * (1 - s);
                        R = i * (int)(1 + (s * Math.Cos(DegreeToRadias(h))) / (Math.Cos(DegreeToRadias(60 - h))));
                        G = 3 * i - R - B;
                    }
                    else if (120 <= h && h < 240)
                    {
                        h -= 120;
                        R = i * (1 - s);
                        G = i * (int)(1 + (s * Math.Cos(DegreeToRadias(h))) / (Math.Cos(DegreeToRadias(60 - h))));
                        B = 3 * i - R - G;
                    }
                    else if (240 <= h && h < 360)
                    {
                        h -= 240;
                        G = i * (1 - s);
                        B = i * (int)(1 + (s * Math.Cos(DegreeToRadias(h))) / (Math.Cos(DegreeToRadias(60 - h))));
                        R = 3 * i - B - G;
                    }
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R > 255) R = 255;

                    after.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
        }

        /// <summary>
        /// 提取红色
        /// </summary>
        public void GetRed()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int h = hsiTable[x, y].H;
                    if (h >= 20 && h <= 340)
                    {
                        hsiTable[x, y].S = 0;
                        hsiTable[x, y].I = 0;
                    }
                }
            }
        }

        /// <summary>
        /// 从RGB值获得色盘角度
        /// </summary>
        /// <param name="c">颜色c</param>
        /// <returns>色盘角度值</returns>
        private double GetTheta(Color c)
        {
            double r = (double)c.R;
            double g = (double)c.G;
            double b = (double)c.B;
            double theta = Math.Acos((0.5 * ((r - g) + (r - b))) / Math.Sqrt((r - g) * (r - g) + (r - b) * (g - b)));

            return RadiasToDegree(theta);
        }

        /// <summary>
        /// 求RGB三个值的最小值
        /// </summary>
        /// <param name="R">红色</param>
        /// <param name="G">绿色</param>
        /// <param name="B">蓝色</param>
        /// <returns></returns>
        private int Min(int R, int G, int B)
        {
            if (R < G && R < B) return R;
            else if (G < R && G < B) return G;
            else if (B < R && B < G) return B;
            else return B;
        }

        /// <summary>
        /// 角度转弧度
        /// </summary>
        /// <param name="angle">角度</param>
        /// <returns>对应的弧度值</returns>
        private double DegreeToRadias(double angle)
        {
            return angle * Math.PI / 180.0F;
        }

        /// <summary>
        /// 弧度转角度
        /// </summary>
        /// <param name="rad">弧度值</param>
        /// <returns>对应的角度值</returns>
        private double RadiasToDegree(double rad)
        {
            return rad / Math.PI * 180.0F;
        }
    }
}
