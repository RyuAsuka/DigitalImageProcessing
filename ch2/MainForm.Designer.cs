namespace DIP.ch2
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
            this.变换TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBinarylize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuGamma = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLog = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuInverse = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHistogram = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReturn = new System.Windows.Forms.ToolStripMenuItem();
            this.连通域CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuConnect = new System.Windows.Forms.ToolStripMenuItem();
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
            this.变换TToolStripMenuItem,
            this.连通域CToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(653, 25);
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
            this.MenuExit.Text = "退出(&X)...";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // 变换TToolStripMenuItem
            // 
            this.变换TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuBinarylize,
            this.toolStripMenuItem2,
            this.MenuGamma,
            this.MenuLog,
            this.MenuInverse,
            this.toolStripMenuItem3,
            this.MenuHistogram,
            this.MenuReturn});
            this.变换TToolStripMenuItem.Name = "变换TToolStripMenuItem";
            this.变换TToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.变换TToolStripMenuItem.Text = "基本变换(&T)";
            // 
            // MenuBinarylize
            // 
            this.MenuBinarylize.Name = "MenuBinarylize";
            this.MenuBinarylize.Size = new System.Drawing.Size(152, 22);
            this.MenuBinarylize.Text = "二值化(&B)...";
            this.MenuBinarylize.Click += new System.EventHandler(this.MenuBinarylize_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuGamma
            // 
            this.MenuGamma.Name = "MenuGamma";
            this.MenuGamma.Size = new System.Drawing.Size(152, 22);
            this.MenuGamma.Text = "伽马变换(&G)...";
            this.MenuGamma.Click += new System.EventHandler(this.MenuGamma_Click);
            // 
            // MenuLog
            // 
            this.MenuLog.Name = "MenuLog";
            this.MenuLog.Size = new System.Drawing.Size(152, 22);
            this.MenuLog.Text = "对数变换(&L)";
            this.MenuLog.Click += new System.EventHandler(this.MenuLog_Click);
            // 
            // MenuInverse
            // 
            this.MenuInverse.Name = "MenuInverse";
            this.MenuInverse.Size = new System.Drawing.Size(152, 22);
            this.MenuInverse.Text = "反转图像(&I)";
            this.MenuInverse.Click += new System.EventHandler(this.MenuInverse_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // MenuHistogram
            // 
            this.MenuHistogram.Name = "MenuHistogram";
            this.MenuHistogram.Size = new System.Drawing.Size(152, 22);
            this.MenuHistogram.Text = "直方图(&H)...";
            this.MenuHistogram.Click += new System.EventHandler(this.MenuHistogram_Click);
            // 
            // MenuReturn
            // 
            this.MenuReturn.Name = "MenuReturn";
            this.MenuReturn.Size = new System.Drawing.Size(152, 22);
            this.MenuReturn.Text = "还原图像(&R)";
            this.MenuReturn.Click += new System.EventHandler(this.MenuReturn_Click_1);
            // 
            // 连通域CToolStripMenuItem
            // 
            this.连通域CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuConnect});
            this.连通域CToolStripMenuItem.Name = "连通域CToolStripMenuItem";
            this.连通域CToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.连通域CToolStripMenuItem.Text = "连通域(&C)";
            // 
            // MenuConnect
            // 
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Size = new System.Drawing.Size(152, 22);
            this.MenuConnect.Text = "求取连通域(&C)";
            this.MenuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.originImage);
            this.groupBox1.Location = new System.Drawing.Point(13, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 271);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "原图像";
            // 
            // originImage
            // 
            this.originImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.originImage.Location = new System.Drawing.Point(7, 21);
            this.originImage.Name = "originImage";
            this.originImage.Size = new System.Drawing.Size(300, 246);
            this.originImage.TabIndex = 0;
            this.originImage.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.afterImage);
            this.groupBox2.Location = new System.Drawing.Point(334, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 271);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "变换后图像";
            // 
            // afterImage
            // 
            this.afterImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.afterImage.Location = new System.Drawing.Point(6, 20);
            this.afterImage.Name = "afterImage";
            this.afterImage.Size = new System.Drawing.Size(300, 246);
            this.afterImage.TabIndex = 0;
            this.afterImage.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 309);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "数字图像处理：基本图像变换 - By 毛杰文 -";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.afterImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MenuReturn_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem 变换TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuBinarylize;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 连通域CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuConnect;
        private System.Windows.Forms.ToolStripMenuItem MenuGamma;
        private System.Windows.Forms.ToolStripMenuItem MenuLog;
        private System.Windows.Forms.ToolStripMenuItem MenuInverse;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem MenuHistogram;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox originImage;
        private System.Windows.Forms.PictureBox afterImage;
        private System.Windows.Forms.ToolStripMenuItem MenuReturn;
    }
}

