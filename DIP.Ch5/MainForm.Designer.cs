namespace DIP.Ch5
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.图像加噪NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGaussian = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRuili = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGaama = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSalt = new System.Windows.Forms.ToolStripMenuItem();
            this.空间滤波SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuArith = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGeo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHarmonic = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConharmonic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuMedianFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMaxFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMinFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMiddleFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbOrigin = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pbAfter = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigin)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.图像加噪NToolStripMenuItem,
            this.空间滤波SToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(830, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpen,
            this.MenuSave,
            this.toolStripMenuItem1,
            this.MenuExit});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem.Text = "文件(&F)";
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(127, 22);
            this.MenuOpen.Text = "打开(&O)...";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(127, 22);
            this.MenuSave.Text = "保存(&S)...";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(124, 6);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(127, 22);
            this.MenuExit.Text = "退出(&X)";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // 图像加噪NToolStripMenuItem
            // 
            this.图像加噪NToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGaussian,
            this.MenuRuili,
            this.MenuGaama,
            this.MenuSalt});
            this.图像加噪NToolStripMenuItem.Name = "图像加噪NToolStripMenuItem";
            this.图像加噪NToolStripMenuItem.Size = new System.Drawing.Size(86, 21);
            this.图像加噪NToolStripMenuItem.Text = "图像加噪(&N)";
            // 
            // MenuGaussian
            // 
            this.MenuGaussian.Name = "MenuGaussian";
            this.MenuGaussian.Size = new System.Drawing.Size(150, 22);
            this.MenuGaussian.Text = "高斯噪声(&G)...";
            this.MenuGaussian.Click += new System.EventHandler(this.MenuGaussian_Click);
            // 
            // MenuRuili
            // 
            this.MenuRuili.Name = "MenuRuili";
            this.MenuRuili.Size = new System.Drawing.Size(150, 22);
            this.MenuRuili.Text = "瑞利噪声(&R)...";
            this.MenuRuili.Click += new System.EventHandler(this.MenuRuili_Click);
            // 
            // MenuGaama
            // 
            this.MenuGaama.Name = "MenuGaama";
            this.MenuGaama.Size = new System.Drawing.Size(150, 22);
            this.MenuGaama.Text = "伽马噪声(&A)...";
            this.MenuGaama.Click += new System.EventHandler(this.MenuGaama_Click);
            // 
            // MenuSalt
            // 
            this.MenuSalt.Name = "MenuSalt";
            this.MenuSalt.Size = new System.Drawing.Size(150, 22);
            this.MenuSalt.Text = "椒盐噪声(&S)...";
            this.MenuSalt.Click += new System.EventHandler(this.MenuSalt_Click);
            // 
            // 空间滤波SToolStripMenuItem
            // 
            this.空间滤波SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuArith,
            this.MenuGeo,
            this.MenuHarmonic,
            this.MenuConharmonic,
            this.toolStripMenuItem2,
            this.MenuMedianFilter,
            this.MenuMaxFilter,
            this.MenuMinFilter,
            this.MenuMiddleFilter});
            this.空间滤波SToolStripMenuItem.Name = "空间滤波SToolStripMenuItem";
            this.空间滤波SToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.空间滤波SToolStripMenuItem.Text = "空间滤波(&S)";
            // 
            // MenuArith
            // 
            this.MenuArith.Name = "MenuArith";
            this.MenuArith.Size = new System.Drawing.Size(185, 22);
            this.MenuArith.Text = "算术均值滤波(&A)...";
            this.MenuArith.Click += new System.EventHandler(this.MenuArith_Click);
            // 
            // MenuGeo
            // 
            this.MenuGeo.Name = "MenuGeo";
            this.MenuGeo.Size = new System.Drawing.Size(185, 22);
            this.MenuGeo.Text = "几何均值滤波(&G)...";
            this.MenuGeo.Click += new System.EventHandler(this.MenuGeo_Click);
            // 
            // MenuHarmonic
            // 
            this.MenuHarmonic.Name = "MenuHarmonic";
            this.MenuHarmonic.Size = new System.Drawing.Size(185, 22);
            this.MenuHarmonic.Text = "谐波均值滤波(&H)...";
            this.MenuHarmonic.Click += new System.EventHandler(this.MenuHarmonic_Click);
            // 
            // MenuConharmonic
            // 
            this.MenuConharmonic.Name = "MenuConharmonic";
            this.MenuConharmonic.Size = new System.Drawing.Size(185, 22);
            this.MenuConharmonic.Text = "逆谐波均值滤波(&C)...";
            this.MenuConharmonic.Click += new System.EventHandler(this.MenuConharmonic_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 6);
            // 
            // MenuMedianFilter
            // 
            this.MenuMedianFilter.Name = "MenuMedianFilter";
            this.MenuMedianFilter.Size = new System.Drawing.Size(185, 22);
            this.MenuMedianFilter.Text = "中值滤波(&M)...";
            this.MenuMedianFilter.Click += new System.EventHandler(this.MenuMedianFilter_Click);
            // 
            // MenuMaxFilter
            // 
            this.MenuMaxFilter.Name = "MenuMaxFilter";
            this.MenuMaxFilter.Size = new System.Drawing.Size(185, 22);
            this.MenuMaxFilter.Text = "最大值滤波(&X)...";
            this.MenuMaxFilter.Click += new System.EventHandler(this.MenuMaxFilter_Click);
            // 
            // MenuMinFilter
            // 
            this.MenuMinFilter.Name = "MenuMinFilter";
            this.MenuMinFilter.Size = new System.Drawing.Size(185, 22);
            this.MenuMinFilter.Text = "最小值滤波(&N)...";
            this.MenuMinFilter.Click += new System.EventHandler(this.MenuMinFilter_Click);
            // 
            // MenuMiddleFilter
            // 
            this.MenuMiddleFilter.Name = "MenuMiddleFilter";
            this.MenuMiddleFilter.Size = new System.Drawing.Size(185, 22);
            this.MenuMiddleFilter.Text = "中点滤波(&P)...";
            this.MenuMiddleFilter.Click += new System.EventHandler(this.MenuMiddleFilter_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbOrigin);
            this.groupBox1.Location = new System.Drawing.Point(13, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 400);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原图像";
            // 
            // pbOrigin
            // 
            this.pbOrigin.Location = new System.Drawing.Point(7, 21);
            this.pbOrigin.Name = "pbOrigin";
            this.pbOrigin.Size = new System.Drawing.Size(387, 373);
            this.pbOrigin.TabIndex = 0;
            this.pbOrigin.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pbAfter);
            this.groupBox2.Location = new System.Drawing.Point(420, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 400);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "变换后图像";
            // 
            // pbAfter
            // 
            this.pbAfter.Location = new System.Drawing.Point(7, 21);
            this.pbAfter.Name = "pbAfter";
            this.pbAfter.Size = new System.Drawing.Size(387, 373);
            this.pbAfter.TabIndex = 0;
            this.pbAfter.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 439);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "数字图像处理：图像复原与重建 - By 毛杰文 -";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOrigin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem 图像加噪NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuGaussian;
        private System.Windows.Forms.ToolStripMenuItem MenuRuili;
        private System.Windows.Forms.ToolStripMenuItem MenuGaama;
        private System.Windows.Forms.ToolStripMenuItem MenuSalt;
        private System.Windows.Forms.ToolStripMenuItem 空间滤波SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuArith;
        private System.Windows.Forms.ToolStripMenuItem MenuGeo;
        private System.Windows.Forms.ToolStripMenuItem MenuHarmonic;
        private System.Windows.Forms.ToolStripMenuItem MenuConharmonic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbOrigin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbAfter;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuMedianFilter;
        private System.Windows.Forms.ToolStripMenuItem MenuMaxFilter;
        private System.Windows.Forms.ToolStripMenuItem MenuMinFilter;
        private System.Windows.Forms.ToolStripMenuItem MenuMiddleFilter;
    }
}

