using System;
using System.Linq;
using System.Windows.Forms;

namespace DIP.ch2
{
    public partial class FormGamma : Form
    {
        private double[] gammaValueTable =
            {0.1 ,0.2,0.3,0.4,0.5,0.6,0.7,0.8,0.9,1,1.5,2,2.5,3,3.5,4,4.5,5,5.5,6,6.5,7,7.5,8,8.5,9,9.5,10,10.5,11,11.5,12,12.5,13,13.5,14,14.5 ,15,15.5, 16,16.5 , 17, 17.5  ,  18 , 18.5   , 19 , 19.5   , 20};

        public double Gamma
        {
            get; set;
        }

        double initial = 1.0;

        private int Find(double gamma)
        {
            for(int i = 0; i < gammaValueTable.Count(); i++)
            {
                if (gamma == gammaValueTable[i])
                    return i;
            }
            return -1;
        }

        public FormGamma(double gamma = 0)
        {
            InitializeComponent();
            if (gamma == 0)
            {
                txtGammaValue.Text = initial.ToString();
            }
            else
            {
                txtGammaValue.Text = gamma.ToString();
                tbGamma.Value = Find(gamma);
            }
        }

        private void tbGamma_Scroll(object sender, EventArgs e)
        {
            Gamma = gammaValueTable[tbGamma.Value];
            txtGammaValue.Text = Gamma.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Gamma = double.Parse(txtGammaValue.Text);
                if (Gamma < 0 || Gamma > 20.0) throw new Exception();
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gamma值必须位于0到20之间！", "Gamma变换", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
