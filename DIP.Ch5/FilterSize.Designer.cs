namespace DIP.Ch5
{
    partial class FilterSize
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
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rd5 = new System.Windows.Forms.RadioButton();
            this.rd9 = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbQ = new System.Windows.Forms.TrackBar();
            this.txtQ = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbQ)).BeginInit();
            this.SuspendLayout();
            // 
            // rd3
            // 
            this.rd3.AutoSize = true;
            this.rd3.Checked = true;
            this.rd3.Location = new System.Drawing.Point(32, 53);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(41, 16);
            this.rd3.TabIndex = 0;
            this.rd3.TabStop = true;
            this.rd3.Text = "3x3";
            this.rd3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择滤波窗口大小：";
            // 
            // rd5
            // 
            this.rd5.AutoSize = true;
            this.rd5.Location = new System.Drawing.Point(97, 53);
            this.rd5.Name = "rd5";
            this.rd5.Size = new System.Drawing.Size(41, 16);
            this.rd5.TabIndex = 0;
            this.rd5.Text = "5x5";
            this.rd5.UseVisualStyleBackColor = true;
            // 
            // rd9
            // 
            this.rd9.AutoSize = true;
            this.rd9.Location = new System.Drawing.Point(162, 53);
            this.rd9.Name = "rd9";
            this.rd9.Size = new System.Drawing.Size(41, 16);
            this.rd9.TabIndex = 0;
            this.rd9.Text = "9x9";
            this.rd9.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(49, 190);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(130, 190);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "选择调谐指数Q：";
            // 
            // tbQ
            // 
            this.tbQ.Location = new System.Drawing.Point(12, 139);
            this.tbQ.Name = "tbQ";
            this.tbQ.Size = new System.Drawing.Size(236, 45);
            this.tbQ.TabIndex = 3;
            this.tbQ.Value = 5;
            this.tbQ.Scroll += new System.EventHandler(this.tbQ_Scroll);
            // 
            // txtQ
            // 
            this.txtQ.Location = new System.Drawing.Point(114, 89);
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(100, 21);
            this.txtQ.TabIndex = 4;
            this.txtQ.Text = "0";
            // 
            // FilterSize
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(263, 244);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.tbQ);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rd9);
            this.Controls.Add(this.rd5);
            this.Controls.Add(this.rd3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterSize";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "选择滤波窗口大小";
            ((System.ComponentModel.ISupportInitialize)(this.tbQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rd3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rd5;
        private System.Windows.Forms.RadioButton rd9;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tbQ;
        private System.Windows.Forms.TextBox txtQ;
    }
}