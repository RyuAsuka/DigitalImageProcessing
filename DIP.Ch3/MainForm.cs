using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIP.Algorithms;

namespace DIP.Ch3
{
    public partial class MainForm : Form
    {
        Bitmap curBitmap;
        Bitmap p1,p2;

        BasicTransform basicProcessor;
        Enhancement ench;
        Complex[] fftData;

        public MainForm()
        {
            InitializeComponent();
        }

        #region 文件操作
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "图像文件(*.bmp;*.jpg;*gif;*png;*.tif;*.wmf)|"
                        + "*.bmp;*jpg;*gif;*png;*.tif;*.wmf";
            if (open.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    curBitmap = (Bitmap)Image.FromFile(open.FileName);
                }
                catch (Exception exp) { MessageBox.Show(exp.Message); }

                originImage.Refresh();
                originImage.Image = curBitmap;
                p1 = (Bitmap)curBitmap.Clone();
                p2 = (Bitmap)curBitmap.Clone();

                basicProcessor = new BasicTransform(p1);
                ench = new Enhancement(p2);
            }
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            string str;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "图像文件(*.BMP;*.PNG;*.JPG)|*.BMP;*.PNG;*.JPG|All File(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                str = saveFileDialog1.FileName;
                if (!string.IsNullOrEmpty(str))
                    afterImage.Image.Save(str);
            }
        }

        #endregion

        private bool CheckImage()
        {
            if (basicProcessor == null || basicProcessor.Image == null)
            {
                MessageBox.Show("请打开文件！", "未打开文件！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void MenuHistogramBalance_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;

            try {
                basicProcessor.HistEqual();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "直方图均衡", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            afterImage.Image = basicProcessor.Image;

            // 显示直方图
            BasicTransform temp = new BasicTransform(curBitmap);
            temp.GetHistogram();
            basicProcessor.GetHistogram();

            FormHistogram histoForm = new FormHistogram(temp.Histogram, basicProcessor.Histogram);
            histoForm.Owner = this;
            histoForm.ShowDialog();
        }

        #region 空间域滤波
        private void MenuCenterFilter_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;

            Bitmap newImage = ench.MedianFilter();

            afterImage.Image = newImage;
        }

        private void MenuLaplace_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;

            Bitmap newImage = ench.Laplace();

            afterImage.Image = newImage;
        }

        private void MenuAverageFilter_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;

            Bitmap newImage = ench.AverageFilter();

            afterImage.Image = newImage;
        }
        #endregion

        #region 频率域滤波
        private void MenuLowPassIdeal_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormFilterParam filterParam = new FormFilterParam();
            filterParam.Owner = this;
            int param = 0;
            if(filterParam.ShowDialog() == DialogResult.OK)
            {
                param = filterParam.FilterParam;
                Bitmap result = ench.FrequencyFilter(curBitmap, FilterType.IdealLowPass, param);
                afterImage.Image = result;
            }
        }

        private void MenuHighPassIdeal_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormFilterParam filterParam = new FormFilterParam();
            filterParam.Owner = this;
            int param = 0;
            if (filterParam.ShowDialog() == DialogResult.OK)
            {
                param = filterParam.FilterParam;
                Bitmap result = ench.FrequencyFilter(curBitmap, FilterType.IdealHighPass, param);
                afterImage.Image = result;
            }
        }

        private void MenuLowPassGauss_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormFilterParam filterParam = new FormFilterParam();
            filterParam.Owner = this;
            int param = 0;
            if (filterParam.ShowDialog() == DialogResult.OK)
            {
                param = filterParam.FilterParam;
                Bitmap result = ench.FrequencyFilter(curBitmap, FilterType.GaussianLowPass, param);
                afterImage.Image = result;
            }
        }



        private void MenuHighPassGauss_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormFilterParam filterParam = new FormFilterParam();
            filterParam.Owner = this;
            int param = 0;
            if (filterParam.ShowDialog() == DialogResult.OK)
            {
                param = filterParam.FilterParam;
                Bitmap result = ench.FrequencyFilter(curBitmap, FilterType.GaussianHighPass, param);
                afterImage.Image = result;
            }
        }
        #endregion

        private void MenuSpectra_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            Bitmap bm = new Bitmap(originImage.Image);
            int iw = bm.Width;
            int ih = bm.Height;

            if (iw == 256 && ih == 256)
            {
                double[] iPix = new double[iw * ih];
                double[] oMod = new double[iw * ih];

                for (int y = 0; y < ih; y++)
                {
                    for (int x = 0; x < iw; x++)
                    {
                        iPix[x+y*iw] = bm.GetPixelGray(x, y);
                    }
                }

                FFT2 fft2 = new FFT2();
                fft2.setData2(iw, ih, iPix);
                fftData = fft2.getFFT2();

                // 生成频谱图像
                int u, v;
                for (int y = 0; y < ih; y++)
                {
                    for (int x = 0; x < iw; x++)
                    {
                        double tem = fftData[x+y*iw].Real * fftData[x+y*iw].Real +
                                    fftData[x+y*iw].Imaginary * fftData[x+y*iw].Imaginary;
                        tem = Math.Sqrt(tem) / 100;
                        if (tem > 255) tem = 255;

                        if (x < iw / 2) u = x + iw / 2;
                        else u = x - iw / 2;
                        if (y < ih / 2) v = y + ih / 2;
                        else v = y - ih / 2;

                        oMod[u+v*iw] = tem;
                    }
                }

                for (int y = 0; y < ih; y++)
                {
                    for (int x = 0; x < iw; x++)
                    {
                        int r = (int)oMod[x+y*iw];
                        try {
                            bm.SetPixelGray(x, y, r);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "查看频谱", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                afterImage.Image = bm;
            }
            else
            {
                MessageBox.Show("仅适用于256*256图像!", "傅里叶变换", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
