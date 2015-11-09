using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DIP.ch2
{
    public partial class FormHistogram : Form
    {
        public int[] HistogramTable
        {
            get;
            set;
        }

        public FormHistogram(int[] table)
        {
            InitializeComponent();
            HistogramTable = table;

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);


            Graphics g = Graphics.FromImage(pictureBox1.Image);
            Pen p = new Pen(Color.Black);
            int maxValue = GetMaxValue(HistogramTable);

            for (int i = 0; i < 256; i++)
            {
                Point p1 = new Point(i * 2, 400);
                Point p2 = new Point(i * 2, (int)(400 - (double)((HistogramTable[i] * 400) / maxValue)));
                g.DrawLine(p, p1, p2);
            }
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
    }
}
