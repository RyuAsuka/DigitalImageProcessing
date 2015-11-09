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
    public partial class FormFilterParam : Form
    {
        /// <summary>
        /// 滤波器参数
        /// </summary>
        public int FilterParam
        {
            get; set;
        }

        public FormFilterParam()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FilterParam = Convert.ToInt32(txtFilterParam.Text);
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
