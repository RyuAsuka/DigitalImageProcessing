using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIP.Ch5
{
    public partial class FilterSize : Form
    {
        public int WindowSize
        {
            get; set;
        }

        public double NumQ
        { get; set; }

        bool enableQ;

        double[] qlist = { -2.5, -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2, 2.5 };

        public FilterSize(bool _enableQ = false)
        {
            InitializeComponent();
            enableQ = _enableQ;
            if(!enableQ)
            {
                label2.Enabled = false;
                tbQ.Enabled = false;
                txtQ.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rd3.Checked) WindowSize = 3;
            if (rd5.Checked) WindowSize = 5;
            if (rd9.Checked) WindowSize = 9;
            if(enableQ)
            {
                NumQ = Convert.ToDouble(txtQ.Text);
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tbQ_Scroll(object sender, EventArgs e)
        {
            txtQ.Text = qlist[tbQ.Value].ToString();
        }
    }
}
