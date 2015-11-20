using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP.Algorithms
{
    /// <summary>
    /// HSI彩色模型
    /// </summary>
    public struct HSI
    {
        int _h;
        int _s;
        int _i;

        public HSI(int h, int s, int i)
        {
            _h = h;
            _s = s;
            _i = i;
        }

        /// <summary>
        /// 表示该像素的色调
        /// </summary>
        public int H
        {
            get { return _h; }
            set { _h = value; }
        }

        /// <summary>
        /// 表示该像素的饱和度
        /// </summary>
        public int S
        {
            get { return _s; }
            set { _s = value; }
        }

        /// <summary>
        /// 表示该像素的强度
        /// </summary>
        public int I
        {
            get { return _i; }
            set { _i = value; }
        }
    }
}
