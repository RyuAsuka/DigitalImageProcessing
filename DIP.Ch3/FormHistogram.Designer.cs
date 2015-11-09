namespace DIP.Ch3
{
    partial class FormHistogram
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.originHistogram = new System.Windows.Forms.PictureBox();
            this.afterHistogram = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originHistogram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.originHistogram);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 278);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原直方图";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.afterHistogram);
            this.groupBox2.Location = new System.Drawing.Point(287, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 278);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "均衡化后的直方图";
            // 
            // originHistogram
            // 
            this.originHistogram.Location = new System.Drawing.Point(6, 16);
            this.originHistogram.Name = "originHistogram";
            this.originHistogram.Size = new System.Drawing.Size(256, 256);
            this.originHistogram.TabIndex = 0;
            this.originHistogram.TabStop = false;
            // 
            // afterHistogram
            // 
            this.afterHistogram.Location = new System.Drawing.Point(6, 16);
            this.afterHistogram.Name = "afterHistogram";
            this.afterHistogram.Size = new System.Drawing.Size(256, 256);
            this.afterHistogram.TabIndex = 0;
            this.afterHistogram.TabStop = false;
            // 
            // FormHistogram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 302);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormHistogram";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "直方图";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originHistogram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterHistogram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox originHistogram;
        private System.Windows.Forms.PictureBox afterHistogram;
    }
}