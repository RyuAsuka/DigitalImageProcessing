using System.Drawing;

namespace DIP.Algorithms
{
    /// <summary>
    /// BitmapGray扩展方法类，提供对灰度图像简便处理的Bitmap类扩展方法。
    /// </summary>
    public static class BitmapGray
    {
        /// <summary>
        /// 获得灰度图像的像素值（灰度等级）
        /// </summary>
        /// <param name="image">图像</param>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <returns>一个表示该像素灰度值（0-255)的字节。</returns>
        public static int GetPixelGray(this Bitmap image, int x, int y)
        {
            Color color = image.GetPixel(x, y);
            return (color.R + color.G + color.B) / 3; // 均值法
        }

        /// <summary>
        /// 设置指定坐标处的像素灰度值
        /// </summary>
        /// <param name="image">图像</param>
        /// <param name="x">横坐标</param>
        /// <param name="y">纵坐标</param>
        /// <param name="graylevel">要设置的灰度等级(0-255)</param>
        public static void SetPixelGray(this Bitmap image, int x, int y, int graylevel)
        {
            image.SetPixel(x, y, Color.FromArgb(graylevel, graylevel, graylevel));
        }
    }
}
