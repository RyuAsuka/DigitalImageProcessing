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

namespace DIP.Ch5
{
    public partial class MainForm : Form
    {
        Bitmap curBitmap;
        Bitmap pro;
        RecoverySpace rs;

        public double[] NoiseParams
        {
            get; set;
        }

        public int WindowSize
        {
            get; set;
        }

        public double NumQ
        {
            get; set;
        }

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

                pbOrigin.Refresh();
                pbOrigin.Image = curBitmap;

                pro = (Bitmap)curBitmap.Clone();

                rs = new RecoverySpace(pro);
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
                    pbAfter.Image.Save(str);
            }
        }

        #endregion

        private bool CheckImage()
        {
            if (rs == null || rs.Image == null)
            {
                MessageBox.Show("请打开文件！", "未打开文件！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        #region 空间均值滤波
        private void MenuArith_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FilterSize fs = new FilterSize();
            fs.Owner = this;
            if(fs.ShowDialog() == DialogResult.OK)
            {
                this.WindowSize = fs.WindowSize;
            }

            try
            {
                rs.ArithmeticMeanFilter(WindowSize);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "空间均值滤波", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbAfter.Image = rs.Image;
        }

        private void MenuGeo_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FilterSize fs = new FilterSize();
            fs.Owner = this;
            if (fs.ShowDialog() == DialogResult.OK)
            {
                this.WindowSize = fs.WindowSize;
            }

            try
            {
                rs.GeometricMeanFilter(WindowSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "空间均值滤波", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbAfter.Image = rs.Image;
        }

        private void MenuHarmonic_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FilterSize fs = new FilterSize();
            fs.Owner = this;
            if (fs.ShowDialog() == DialogResult.OK)
            {
                this.WindowSize = fs.WindowSize;
            }

            try
            {
                rs.HarmonicMeanFilter(WindowSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "空间均值滤波", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbAfter.Image = rs.Image;
        }

        private void MenuConharmonic_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FilterSize fs = new FilterSize(true);
            fs.Owner = this;
            if (fs.ShowDialog() == DialogResult.OK)
            {
                this.WindowSize = fs.WindowSize;
                NumQ = fs.NumQ;
            }

            //try
           // {
                rs.ContraharmonicMeanFilter(WindowSize, NumQ);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "空间均值滤波", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            pbAfter.Image = rs.Image;
        }


        #endregion

        #region 图像加噪
        private void MenuGaussian_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormAddNoise fan = new FormAddNoise(1);
            fan.Owner = this;
            if(fan.ShowDialog() == DialogResult.OK)
            {
                NoiseParams = fan.Params;
                pbAfter.Image = Noise.AddNoise(pro, NoiseParams, Noise.MakeGaussianNoise);
                rs.Image = (Bitmap)pbAfter.Image;
            }
        }
        

        private void MenuRuili_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormAddNoise fan = new FormAddNoise(2);
            fan.Owner = this;
            if (fan.ShowDialog() == DialogResult.OK)
            {
                NoiseParams = fan.Params;
                pbAfter.Image = Noise.AddNoise(pro, NoiseParams, Noise.MakeRuiliNoise);
                rs.Image = (Bitmap)pbAfter.Image;
            }
        }

        private void MenuGaama_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormAddNoise fan = new FormAddNoise(3);
            fan.Owner = this;
            if (fan.ShowDialog() == DialogResult.OK)
            {
                NoiseParams = fan.Params;
                pbAfter.Image = Noise.AddNoise(pro, NoiseParams, Noise.MakeGammaNoise);
                rs.Image = (Bitmap)pbAfter.Image;
            }
        }

        private void MenuSalt_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormAddNoise fan = new FormAddNoise(4);
            fan.Owner = this;
            if (fan.ShowDialog() == DialogResult.OK)
            {
                NoiseParams = fan.Params;
                pbAfter.Image = Noise.AddNoise(pro, NoiseParams, Noise.MakeSaltPepperNoise);
                rs.Image = (Bitmap)pbAfter.Image;
            }
        }
        #endregion

        private void MenuMedianFilter_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FilterSize fs = new FilterSize();
            fs.Owner = this;
            if (fs.ShowDialog() == DialogResult.OK)
            {
                this.WindowSize = fs.WindowSize;
            }

            try
            {
                rs.MedianFilter(WindowSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "统计排序滤波", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbAfter.Image = rs.Image;
        }

        private void MenuMaxFilter_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FilterSize fs = new FilterSize();
            fs.Owner = this;
            if (fs.ShowDialog() == DialogResult.OK)
            {
                this.WindowSize = fs.WindowSize;
            }

            try
            {
                rs.MaxFilter(WindowSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "统计排序滤波", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbAfter.Image = rs.Image;
        }

        private void MenuMinFilter_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FilterSize fs = new FilterSize();
            fs.Owner = this;
            if (fs.ShowDialog() == DialogResult.OK)
            {
                this.WindowSize = fs.WindowSize;
            }

            try
            {
                rs.MinFilter(WindowSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "统计排序滤波", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbAfter.Image = rs.Image;
        }

        private void MenuMiddleFilter_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FilterSize fs = new FilterSize();
            fs.Owner = this;
            if (fs.ShowDialog() == DialogResult.OK)
            {
                this.WindowSize = fs.WindowSize;
            }

            try
            {
                rs.MiddlePointFilter(WindowSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "统计排序滤波", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pbAfter.Image = rs.Image;
        }
    }
}
