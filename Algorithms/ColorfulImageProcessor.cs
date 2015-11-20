using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DIP.Algorithms
{
    public class ColorfulImageProcessor
    {
        Bitmap origin;
        Bitmap after;
        int width;
        int height;
        HSI[,] hsiTable;
        Color[,] rgbTable;

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

        public Bitmap Image
        {
            get { return after; }
            set { after = value; }
        }

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

        public void GetRed()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int h = hsiTable[x, y].H;
                    if (h >= 60 && h <= 300)
                    {
                        hsiTable[x, y].S = 0;
                        hsiTable[x, y].I = 0;
                    }
                }
            }
        }

        private double GetTheta(Color c)
        {
            double r = (double)c.R;
            double g = (double)c.G;
            double b = (double)c.B;
            double theta = Math.Acos((0.5 * ((r - g) + (r - b))) / Math.Sqrt((r - g) * (r - g) + (r - b) * (g - b)));

            return RadiasToDegree(theta);
        }

        private int Min(int R, int G, int B)
        {
            if (R < G && R < B) return R;
            else if (G < R && G < B) return G;
            else if (B < R && B < G) return B;
            else return B;
        }

        private double DegreeToRadias(double angle)
        {
            return angle * Math.PI / 180.0F;
        }

        private double RadiasToDegree(double rad)
        {
            return rad / Math.PI * 180.0F;
        }
    }
}
