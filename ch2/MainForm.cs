using System;
using System.Drawing;
using System.Windows.Forms;
using DIP.Algorithms;
using System.IO;

namespace DIP.ch2
{
    public partial class MainForm : Form
    {
        Bitmap curBitmap;
        Bitmap p;
        bool isBinarylized = false;
        BasicTransform processor;

        public byte Threshold
        {
            get;
            set;
        }

        public double Gamma
        {
            get; set;
        }

        public int Choose
        { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"图像文件(*.bmp; *.jpg; *gif; *png; *.tif; *.wmf)| "
                             + "*.bmp;*jpg;*gif;*png;*.tif;*.wmf";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    curBitmap = (Bitmap)Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception exp) { MessageBox.Show(exp.Message); }

                originImage.Refresh();
                originImage.Image = curBitmap;
                p = (Bitmap)curBitmap.Clone();
                processor = new BasicTransform(p);
            }
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            string str;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "图像文件(*.BMP;*.jpg;*.png)|*.BMP;*.jpg;*.PNG|All File(*.*)|*.*";
            saveFileDialog1.ShowDialog();
            str = saveFileDialog1.FileName;
            if(!string.IsNullOrEmpty(str))
                afterImage.Image.Save(str);
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuBinarylize_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormThreshold formThreshold = new FormThreshold();
            formThreshold.Owner = this;
            if (formThreshold.ShowDialog() == DialogResult.OK)
            {
                Threshold = (byte)(formThreshold.Threshold);
                processor.Binaryze(Threshold);

                isBinarylized = true;

                afterImage.Image = processor.Image;
            }
        }

        private bool CheckImage()
        {
            if (processor == null || processor.Image == null)
            {
                MessageBox.Show("请打开文件！", "未打开文件！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void MenuConnect_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            if (!isBinarylized)
            {
                MessageBox.Show("图像未二值化！将在二值化之后继续处理！", "连通域", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MenuBinarylize_Click(sender, e);
            }

            FormChoose fc = new FormChoose();
            fc.Owner = this;
            if (fc.ShowDialog() == DialogResult.OK)
            {
                Choose = fc.Choose;
                Matrix mat = processor.GetConnectedRegion(Choose);
                afterImage.Image = processor.Image;


                using (StreamWriter sw = new StreamWriter(@"mat.txt"))
                {
                    for (int y = 0; y < processor.Image.Height; y++)
                    {
                        for (int x = 0; x < processor.Image.Width; x++)
                        {
                            if (mat[x, y] >= 0 && mat[x, y] < 10)
                                sw.Write("   {0}", mat[x, y]);
                            else if (mat[x, y] >= 10 && mat[x, y] < 100)
                                sw.Write("  {0}", mat[x, y]);
                            else if (mat[x, y] >= 100 && mat[x, y] < 1000)
                                sw.Write(" {0}", mat[x, y]);
                            if (x == processor.Image.Width - 1) sw.Write("\n");
                        }
                    }
                }

                MessageBox.Show("连通域标记完成！", "连通域标记", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MenuGamma_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            FormGamma formGamma = new FormGamma(Gamma);
            formGamma.Owner = this;
            if (formGamma.ShowDialog() == DialogResult.OK)
            {
                Gamma = formGamma.Gamma;
                processor.GammaTransform(Gamma);
                afterImage.Image = processor.Image;
            }
        }

        private void MenuInverse_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            processor.Reverse();
            afterImage.Image = processor.Image;
        }

        private void MenuLog_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            processor.LogarithmTransform();
            afterImage.Image = processor.Image;
        }

        private void MenuHistogram_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            processor.GetHistogram();

            FormHistogram histoForm = new FormHistogram(processor.Histogram);
            histoForm.Owner = this;
            histoForm.ShowDialog();
        }

        private void MenuReturn_Click_1(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            for (int y = 0; y < processor.Image.Height; y++)
            {
                for (int x = 0; x < processor.Image.Width; x++)
                {
                    processor.Image.SetPixel(x, y, curBitmap.GetPixel(x, y));
                }
            }

            afterImage.Image = processor.Image;
            isBinarylized = false;
        }
    }
}
