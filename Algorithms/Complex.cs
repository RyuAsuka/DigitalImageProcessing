namespace DIP.Algorithms
{
    /// <summary>
    /// 复数类
    /// </summary>
    public class Complex
    {
        private double re;
        private double im;

        /// <summary>
        /// 获取或设置复数的实部
        /// </summary>
        public double Real
        {
            get { return re; }
            set { re = value; }
        }

        /// <summary>
        /// 获取或设置复数的虚部
        /// </summary>
        public double Imaginary
        {
            get { return im; }
            set { im = value; }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Complex()
        {
            re = 0;
            im = 0;
        }

        /// <summary>
        /// 用实部构造一个虚部为0的复数
        /// </summary>
        /// <param name="re">实部的值</param>
        public Complex(double re)
        {
            this.re = re;
            im = 0;
        }

        /// <summary>
        /// 构造复数
        /// </summary>
        /// <param name="re">实部</param>
        /// <param name="im">虚部</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <summary>
        /// 复数加法运算
        /// </summary>
        /// <param name="c1">加数</param>
        /// <param name="c2">加数</param>
        /// <returns>和</returns>
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex retVal = new Complex();
            retVal.Real = c1.Real + c2.Real;
            retVal.Imaginary = c1.Imaginary + c2.Imaginary;
            return retVal;
        }

        /// <summary>
        /// 复数减法运算
        /// </summary>
        /// <param name="c1">被减数</param>
        /// <param name="c2">减数</param>
        /// <returns>差</returns>
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex retVal = new Complex();
            retVal.Real = c1.Real - c2.Real;
            retVal.Imaginary = c1.Imaginary - c2.Imaginary;
            return retVal;
        }

        /// <summary>
        /// 复数乘法运算
        /// </summary>
        /// <param name="c1">乘数</param>
        /// <param name="c2">乘数</param>
        /// <returns>积</returns>
        public static Complex operator*(Complex c1, Complex c2)
        {
            Complex retVal = new Complex();
            retVal.Real = c1.Real*c2.Real-c1.Imaginary*c2.Imaginary;
            retVal.Imaginary = c1.Real * c2.Imaginary + c1.Imaginary * c2.Real;
            return retVal;
        }

        /// <summary>
        /// 复数相等判断
        /// </summary>
        /// <param name="c1">第一个复数</param>
        /// <param name="c2">第二个复数</param>
        /// <returns>是否相等的bool值</returns>
        public static bool operator==(Complex c1, Complex c2)
        {
            if (c1.Real == c2.Real && c1.Imaginary == c2.Imaginary)
                return true;
            else return false;
        }

        /// <summary>
        /// 复数不相等判断
        /// </summary>
        /// <param name="c1">第一个复数</param>
        /// <param name="c2">第二个复数</param>
        /// <returns>是否不想等的bool值</returns>
        public static bool operator !=(Complex c1, Complex c2)
        {
            return !(c1 == c2);
        }

        public override bool Equals(object obj)
        {
            Complex c = (Complex)obj;
            if (Real == c.Real && Imaginary == c.Imaginary)
                return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0}+{1}j", Real, Imaginary);
        }
    }
}
