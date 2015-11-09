namespace DIP.ch2
{
    partial class FormGamma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbGamma = new System.Windows.Forms.TrackBar();
            this.txtGammaValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbGamma)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "指数值(Gamma)：";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(98, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(228, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbGamma
            // 
            this.tbGamma.Location = new System.Drawing.Point(13, 69);
            this.tbGamma.Maximum = 47;
            this.tbGamma.Name = "tbGamma";
            this.tbGamma.Size = new System.Drawing.Size(376, 45);
            this.tbGamma.TabIndex = 3;
            this.tbGamma.Value = 10;
            this.tbGamma.Scroll += new System.EventHandler(this.tbGamma_Scroll);
            // 
            // txtGammaValue
            // 
            this.txtGammaValue.Location = new System.Drawing.Point(131, 24);
            this.txtGammaValue.Name = "txtGammaValue";
            this.txtGammaValue.Size = new System.Drawing.Size(100, 21);
            this.txtGammaValue.TabIndex = 4;
            // 
            // FormGamma
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(401, 160);
            this.Controls.Add(this.txtGammaValue);
            this.Controls.Add(this.tbGamma);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGamma";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "伽马变换";
            ((System.ComponentModel.ISupportInitialize)(this.tbGamma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TrackBar tbGamma;
        private System.Windows.Forms.TextBox txtGammaValue;
    }
}