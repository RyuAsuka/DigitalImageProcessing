using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIP.Ch3
{
    public partial class FormHistogram : Form
    {
        public int[] OriginHistogram
        {
            get;
            set;
        }

        public int[] AfterHistogram
        {
            get;
            set;
        }

        private int GetMaxValue(int[] table)
        {
            int max = 0;
            for (int i = 0; i < table.Count(); i++)
            {
                if (table[i] > max)
                    max = table[i];
            }

            return max;
        }

        public FormHistogram(int[] h1, int[] h2)
        {
            InitializeComponent();

            OriginHistogram = h1;
            AfterHistogram = h2;

            // 画原图直方图
            originHistogram.Image = new Bitmap(originHistogram.Width, originHistogram.Height);


            Graphics g = Graphics.FromImage(originHistogram.Image);
            Pen pen1 = new Pen(Color.Black);
            int maxValue = GetMaxValue(OriginHistogram);

            for (int i = 0; i < 256; i++)
            {
                Point p1 = new Point(i, 256);
                Point p2 = new Point(i, (int)(256 - (double)((OriginHistogram[i] * 256) / maxValue)));
                g.DrawLine(pen1, p1, p2);
            }

            // 画均衡化直方图
            afterHistogram.Image = new Bitmap(afterHistogram.Width, afterHistogram.Height);


            g = Graphics.FromImage(afterHistogram.Image);
            Pen pen2 = new Pen(Color.Black);
            maxValue = GetMaxValue(AfterHistogram);

            for (int i = 0; i < 256; i++)
            {
                Point p1 = new Point(i, 256);
                Point p2 = new Point(i, (int)(256 - (double)((AfterHistogram[i] * 256) / maxValue)));
                g.DrawLine(pen2, p1, p2);
            }
        }
    }
}
