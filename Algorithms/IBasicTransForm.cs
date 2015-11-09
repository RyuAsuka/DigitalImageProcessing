using System.Drawing;

namespace DIP.Algorithms
{
    /// <summary>
    /// 实现基本变换的接口
    /// </summary>
    public interface IBasicTransform
    {
        Bitmap Image { get; set; }

        void Graying();

        void Binaryze(byte threshold);

        Matrix GetConnectedRegion(int choose);

        void Reverse();

        void GetHistogram();

        void GammaTransform(double gamma);

        void LogarithmTransform();
    }
}
