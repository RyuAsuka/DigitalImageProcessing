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

namespace DIP.Ch6
{
    public partial class MainForm : Form
    {
        Bitmap curBitmap;
        Bitmap pro;
        ColorfulImageProcessor cp;

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

                cp = new ColorfulImageProcessor(pro);
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
            if (cp == null || cp.Image == null)
            {
                MessageBox.Show("请打开文件！", "未打开文件！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void MenuRed_Click(object sender, EventArgs e)
        {
            if (!CheckImage()) return;
            cp.RGBToHSI();
            cp.GetRed();
            cp.HSIToRGB();

            pbAfter.Image = cp.Image;

        }
    }
}
