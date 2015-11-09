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
    public partial class FormAddNoise : Form
    {

        private double[] _params;

        public double[] Params
        {
            get { return _params; }
            set { _params = value; }
        }

        private string para1_name;
        private string para2_name;

        public FormAddNoise(int type)
        {
            InitializeComponent();
            switch(type)
            {
                case 1:
                    para1_name = "均值";
                    para2_name = "方差";
                    break;
                case 2:
                case 3:
                    para1_name = "参数1";
                    para2_name = "参数2";
                    break;
                case 4:
                    para1_name = "含椒量";
                    para2_name = "含盐量";
                    break;
            }
            label2.Text = para1_name;
            label3.Text = para2_name;
            if (type == 3)
            {
                label3.Enabled = false;
                txtParam2.Enabled = false;
                txtParam2.Text = "0";
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _params = new double[2];
            _params[0] = double.Parse(txtParam1.Text);
            _params[1] = double.Parse(txtParam2.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
