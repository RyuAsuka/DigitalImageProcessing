using System;
using System.Drawing;

namespace DIP.Algorithms
{
    /// <summary>
    /// 传入生成噪声的方法的委托
    /// </summary>
    /// <param name="noisePara">噪声参数</param>
    /// <returns>噪声值</returns>
    public delegate double MakeNoise(double[] noisePara);

    /// <summary>
    /// 噪声类
    /// </summary>
    public static class Noise
    {

        private static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        /// <summary>
        /// 添加噪声
        /// </summary>
        /// <param name="bmp">传入的图像</param>
        /// <param name="noisePara">噪声参数</param>
        /// <param name="makeNoise">噪声添加函数</param>
        /// <returns>加噪声后的图像</returns>
        public static Bitmap AddNoise(Bitmap bmp, double[] noisePara, MakeNoise makeNoise)
        {
            Bitmap retVal = new Bitmap(bmp.Width, bmp.Height);
            int height = bmp.Height;
            int width = bmp.Width;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double temp = makeNoise(noisePara);

                    int c = bmp.GetPixelGray(x, y) + (int)temp;
                    if (c > 255) c = 255;
                    if (c < 0) c = 0;
                    retVal.SetPixelGray(x, y, c);
                }
            }

            return retVal;
        }

        /// <summary>
        /// 生成高斯噪声
        /// </summary>
        /// <param name="noisePara">噪声参数</param>
        /// <returns>噪声值</returns>
        public static double MakeGaussianNoise(double[] noisePara)
        {
            Random r1 = new Random(GetRandomSeed());
            Random r2 = new Random(GetRandomSeed());
            double v1 = 0, v2 = 0;
            double temp = 0;
            do
            {
                v1 = r1.NextDouble();
            } while (v1 <= 0.0000000001);
            v2 = r2.NextDouble();
            temp = Math.Sqrt(-2 * Math.Log(v1)) * Math.Cos(2 * Math.PI * v2) * noisePara[1] + noisePara[0];
            return temp;
        }


        /// <summary>
        /// 生成瑞利噪声
        /// </summary>
        /// <param name="noisePara">噪声参数</param>
        /// <returns>噪声值</returns>
        public static double MakeRuiliNoise(double[] noisePara)
        {
            Random r1 = new Random(GetRandomSeed());
            Random r2 = new Random(GetRandomSeed());
            double v1 = 0, v2 = 0;
            double temp = 0;
            do
            {
                v1 = r1.NextDouble();
            } while (v1 >= 0.9999999999);

            temp = noisePara[0] + Math.Sqrt(-1 * noisePara[1] * Math.Log(1 - v1));
            return temp;
        }

        /// <summary>
        /// 生成伽马噪声
        /// </summary>
        /// <param name="noisePara">噪声参数</param>
        /// <returns>噪声值</returns>
        public static double MakeGammaNoise(double[] noisePara)
        {
            Random r1 = new Random(GetRandomSeed());
            Random r2 = new Random(GetRandomSeed());
            double v1 = 0, v2 = 0;
            double temp = 0;
            do
            {
                v1 = r1.NextDouble();
            } while (v1 >= 0.9999999999);

            temp = -1 * Math.Log(1 - v1) / noisePara[0];
            return temp;
        }

        public static double MakeSaltPepperNoise(double[] noisePara)
        {
            Random r1 = new Random(GetRandomSeed());
            Random r2 = new Random(GetRandomSeed());
            double v1 = 0, v2 = 0;
            double temp = 0;
            v1 = r1.NextDouble();
            if (v1 <= noisePara[0])
                temp = -500;
            else if (v1 >= (1 - noisePara[1]))
                temp = 500;
            else temp = 0;
            return temp;
        }
    }
}
