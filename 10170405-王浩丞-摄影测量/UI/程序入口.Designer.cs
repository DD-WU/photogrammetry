namespace _10170405_王浩丞_摄影测量
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.打开 = new System.Windows.Forms.ToolStripMenuItem();
            this.打开相对定向 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.后方交会 = new System.Windows.Forms.ToolStripMenuItem();
            this.前方交会 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.相对定向 = new System.Windows.Forms.ToolStripMenuItem();
            this.绝对定向 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.撤销控件 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.toolStripDropDownButton2,
            this.toolStripTextBox1,
            this.toolStripSeparator3,
            this.撤销控件,
            this.toolStripLabel1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1027, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoSize = false;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开,
            this.打开相对定向});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(100, 25);
            this.toolStripDropDownButton1.Text = "读数据";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // 打开
            // 
            this.打开.Name = "打开";
            this.打开.Size = new System.Drawing.Size(224, 26);
            this.打开.Text = "打开（后方交会）";
            this.打开.Click += new System.EventHandler(this.打开_Click);
            // 
            // 打开相对定向
            // 
            this.打开相对定向.Name = "打开相对定向";
            this.打开相对定向.Size = new System.Drawing.Size(224, 26);
            this.打开相对定向.Text = "打开（相对定向）";
            this.打开相对定向.Click += new System.EventHandler(this.打开相对定向_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.后方交会,
            this.前方交会});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(239, 25);
            this.toolStripDropDownButton2.Text = "单像空间后方交会-双像前方交会";
            this.toolStripDropDownButton2.Visible = false;
            this.toolStripDropDownButton2.Click += new System.EventHandler(this.toolStripDropDownButton2_Click);
            // 
            // 后方交会
            // 
            this.后方交会.Name = "后方交会";
            this.后方交会.Size = new System.Drawing.Size(152, 26);
            this.后方交会.Text = "后方交会";
            this.后方交会.Click += new System.EventHandler(this.后方交会_Click);
            // 
            // 前方交会
            // 
            this.前方交会.Name = "前方交会";
            this.前方交会.Size = new System.Drawing.Size(152, 26);
            this.前方交会.Text = "前方交会";
            this.前方交会.Click += new System.EventHandler(this.前方交会_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相对定向,
            this.绝对定向});
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(149, 25);
            this.toolStripTextBox1.Text = "相对定向-绝对定向";
            this.toolStripTextBox1.Visible = false;
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // 相对定向
            // 
            this.相对定向.Name = "相对定向";
            this.相对定向.Size = new System.Drawing.Size(152, 26);
            this.相对定向.Text = "相对定向";
            this.相对定向.Click += new System.EventHandler(this.相对定向_Click);
            // 
            // 绝对定向
            // 
            this.绝对定向.Name = "绝对定向";
            this.绝对定向.Size = new System.Drawing.Size(152, 26);
            this.绝对定向.Text = "绝对定向";
            this.绝对定向.Click += new System.EventHandler(this.绝对定向_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // 撤销控件
            // 
            this.撤销控件.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.撤销控件.Image = ((System.Drawing.Image)(resources.GetObject("撤销控件.Image")));
            this.撤销控件.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.撤销控件.Name = "撤销控件";
            this.撤销控件.Size = new System.Drawing.Size(29, 25);
            this.撤销控件.Text = "（未实现）";
            this.撤销控件.Click += new System.EventHandler(this.撤销控件_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 25);
            this.toolStripLabel1.Text = "（未实现）";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 25);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1027, 546);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "程序入口";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 打开;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem 后方交会;
        private System.Windows.Forms.ToolStripButton 撤销控件;
        private System.Windows.Forms.ToolStripMenuItem 前方交会;
        private System.Windows.Forms.ToolStripMenuItem 打开相对定向;
        private System.Windows.Forms.ToolStripDropDownButton toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem 相对定向;
        private System.Windows.Forms.ToolStripMenuItem 绝对定向;
        private System.Windows.Forms.ToolStripButton toolStripLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}

