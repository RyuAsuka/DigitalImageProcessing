using System;
using System.Windows.Forms;

namespace DIP.ch2
{
    public partial class FormThreshold : Form
    {
        public int Threshold
        {
            get; set;
        }

        public FormThreshold()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Threshold = int.Parse(txtThreshold.Text);
                if (Threshold >= 0 && Threshold <= 255)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("阈值必须介于 0 和 255 之间！", "二值化阈值", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
