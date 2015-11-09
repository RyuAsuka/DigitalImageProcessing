namespace DIP.Ch3
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
            this.空间域滤波SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAverageFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCenterFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuLaplace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHistogramBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.频率域滤波RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.理想滤波器IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLowPassIdeal = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHighPassIdeal = new System.Windows.Forms.ToolStripMenuItem();
            this.高斯滤波器GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLowPassGauss = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHighPassGauss = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuSpectra = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.originImage = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.afterImage = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.afterImage)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.空间域滤波SToolStripMenuItem,
            this.频率域滤波RToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 25);
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
            // 空间域滤波SToolStripMenuItem
            // 
            this.空间域滤波SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAverageFilter,
            this.MenuCenterFilter,
            this.toolStripMenuItem2,
            this.MenuLaplace,
            this.toolStripMenuItem3,
            this.MenuHistogramBalance});
            this.空间域滤波SToolStripMenuItem.Name = "空间域滤波SToolStripMenuItem";
            this.空间域滤波SToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.空间域滤波SToolStripMenuItem.Text = "空间域滤波(&S)";
            // 
            // MenuAverageFilter
            // 
            this.MenuAverageFilter.Name = "MenuAverageFilter";
            this.MenuAverageFilter.Size = new System.Drawing.Size(162, 22);
            this.MenuAverageFilter.Text = "均值滤波(&A)";
            this.MenuAverageFilter.Click += new System.EventHandler(this.MenuAverageFilter_Click);
            // 
            // MenuCenterFilter
            // 
            this.MenuCenterFilter.Name = "MenuCenterFilter";
            this.MenuCenterFilter.Size = new System.Drawing.Size(162, 22);
            this.MenuCenterFilter.Text = "中值滤波(&C)";
            this.MenuCenterFilter.Click += new System.EventHandler(this.MenuCenterFilter_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 6);
            // 
            // MenuLaplace
            // 
            this.MenuLaplace.Name = "MenuLaplace";
            this.MenuLaplace.Size = new System.Drawing.Size(162, 22);
            this.MenuLaplace.Text = "拉普拉斯锐化(&L)";
            this.MenuLaplace.Click += new System.EventHandler(this.MenuLaplace_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(159, 6);
            // 
            // MenuHistogramBalance
            // 
            this.MenuHistogramBalance.Name = "MenuHistogramBalance";
            this.MenuHistogramBalance.Size = new System.Drawing.Size(162, 22);
            this.MenuHistogramBalance.Text = "直方图均衡(&H)...";
            this.MenuHistogramBalance.Click += new System.EventHandler(this.MenuHistogramBalance_Click);
            // 
            // 频率域滤波RToolStripMenuItem
            // 
            this.频率域滤波RToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.理想滤波器IToolStripMenuItem,
            this.高斯滤波器GToolStripMenuItem,
            this.toolStripMenuItem4,
            this.MenuSpectra});
            this.频率域滤波RToolStripMenuItem.Name = "频率域滤波RToolStripMenuItem";
            this.频率域滤波RToolStripMenuItem.Size = new System.Drawing.Size(96, 21);
            this.频率域滤波RToolStripMenuItem.Text = "频率域滤波(&R)";
            // 
            // 理想滤波器IToolStripMenuItem
            // 
            this.理想滤波器IToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuLowPassIdeal,
            this.MenuHighPassIdeal});
            this.理想滤波器IToolStripMenuItem.Name = "理想滤波器IToolStripMenuItem";
            this.理想滤波器IToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.理想滤波器IToolStripMenuItem.Text = "理想滤波器(&I)";
            // 
            // MenuLowPassIdeal
            // 
            this.MenuLowPassIdeal.Name = "MenuLowPassIdeal";
            this.MenuLowPassIdeal.Size = new System.Drawing.Size(186, 22);
            this.MenuLowPassIdeal.Text = "理想低通滤波器(&L)...";
            this.MenuLowPassIdeal.Click += new System.EventHandler(this.MenuLowPassIdeal_Click);
            // 
            // MenuHighPassIdeal
            // 
            this.MenuHighPassIdeal.Name = "MenuHighPassIdeal";
            this.MenuHighPassIdeal.Size = new System.Drawing.Size(186, 22);
            this.MenuHighPassIdeal.Text = "理想高通滤波器(&H)...";
            this.MenuHighPassIdeal.Click += new System.EventHandler(this.MenuHighPassIdeal_Click);
            // 
            // 高斯滤波器GToolStripMenuItem
            // 
            this.高斯滤波器GToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuLowPassGauss,
            this.MenuHighPassGauss});
            this.高斯滤波器GToolStripMenuItem.Name = "高斯滤波器GToolStripMenuItem";
            this.高斯滤波器GToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.高斯滤波器GToolStripMenuItem.Text = "高斯滤波器(&G)";
            // 
            // MenuLowPassGauss
            // 
            this.MenuLowPassGauss.Name = "MenuLowPassGauss";
            this.MenuLowPassGauss.Size = new System.Drawing.Size(177, 22);
            this.MenuLowPassGauss.Text = "高斯低通滤波器(&L)";
            this.MenuLowPassGauss.Click += new System.EventHandler(this.MenuLowPassGauss_Click);
            // 
            // MenuHighPassGauss
            // 
            this.MenuHighPassGauss.Name = "MenuHighPassGauss";
            this.MenuHighPassGauss.Size = new System.Drawing.Size(177, 22);
            this.MenuHighPassGauss.Text = "高斯高通滤波器(&H)";
            this.MenuHighPassGauss.Click += new System.EventHandler(this.MenuHighPassGauss_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(160, 6);
            // 
            // MenuSpectra
            // 
            this.MenuSpectra.Name = "MenuSpectra";
            this.MenuSpectra.Size = new System.Drawing.Size(163, 22);
            this.MenuSpectra.Text = "查看图像频谱(&S)";
            this.MenuSpectra.Click += new System.EventHandler(this.MenuSpectra_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.originImage);
            this.groupBox1.Location = new System.Drawing.Point(13, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 327);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原图像";
            // 
            // originImage
            // 
            this.originImage.Location = new System.Drawing.Point(7, 21);
            this.originImage.Name = "originImage";
            this.originImage.Size = new System.Drawing.Size(300, 300);
            this.originImage.TabIndex = 0;
            this.originImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.afterImage);
            this.groupBox2.Location = new System.Drawing.Point(342, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 327);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "变换后图像";
            // 
            // afterImage
            // 
            this.afterImage.Location = new System.Drawing.Point(6, 20);
            this.afterImage.Name = "afterImage";
            this.afterImage.Size = new System.Drawing.Size(300, 300);
            this.afterImage.TabIndex = 0;
            this.afterImage.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 370);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "数字图像处理：空间域与频率域滤波 - By 毛杰文 -";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.afterImage)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem 空间域滤波SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuAverageFilter;
        private System.Windows.Forms.ToolStripMenuItem MenuCenterFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuLaplace;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem MenuHistogramBalance;
        private System.Windows.Forms.ToolStripMenuItem 频率域滤波RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 理想滤波器IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuLowPassIdeal;
        private System.Windows.Forms.ToolStripMenuItem MenuHighPassIdeal;
        private System.Windows.Forms.ToolStripMenuItem 高斯滤波器GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuLowPassGauss;
        private System.Windows.Forms.ToolStripMenuItem MenuHighPassGauss;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox originImage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox afterImage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem MenuSpectra;
    }
}

