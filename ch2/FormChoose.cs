using System;
using System.Windows.Forms;

namespace DIP.ch2
{
    public partial class FormChoose : Form
    {
        public int Choose
        {
            get; set;
        }

        public FormChoose()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (rbBlack.Checked) Choose = 2;
            else if (rbWhite.Checked) Choose = 1;

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
