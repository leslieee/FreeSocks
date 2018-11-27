namespace v2rayN.Forms
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSysAgentEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSysAgentMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGlobal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPAC = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuKeep = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.bgwPing = new System.ComponentModel.BackgroundWorker();
            this.menuAddServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemoveServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopyServer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetDefaultServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAddCustomServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMoveTop = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoveBottom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menuPingServer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExport2ClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport2ServerConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShareQRCode = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsMain.SuspendLayout();
            this.cmsLv.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyMain
            // 
            this.notifyMain.ContextMenuStrip = this.cmsMain;
            this.notifyMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyMain.Icon")));
            this.notifyMain.Text = "FreeSocks";
            this.notifyMain.Visible = true;
            this.notifyMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyMain_MouseClick);
            // 
            // cmsMain
            // 
            this.cmsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSysAgentEnabled,
            this.menuSysAgentMode,
            this.toolStripSeparator2,
            this.menuExit});
            this.cmsMain.Name = "contextMenuStrip1";
            this.cmsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsMain.ShowCheckMargin = true;
            this.cmsMain.ShowImageMargin = false;
            this.cmsMain.Size = new System.Drawing.Size(153, 98);
            // 
            // menuSysAgentEnabled
            // 
            this.menuSysAgentEnabled.Name = "menuSysAgentEnabled";
            this.menuSysAgentEnabled.Size = new System.Drawing.Size(152, 22);
            this.menuSysAgentEnabled.Text = "启用系统代理";
            this.menuSysAgentEnabled.Click += new System.EventHandler(this.menuSysAgentEnabled_Click);
            // 
            // menuSysAgentMode
            // 
            this.menuSysAgentMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGlobal,
            this.menuPAC,
            this.toolStripMenuItem2,
            this.menuKeep});
            this.menuSysAgentMode.Name = "menuSysAgentMode";
            this.menuSysAgentMode.Size = new System.Drawing.Size(152, 22);
            this.menuSysAgentMode.Text = "系统代理模式";
            // 
            // menuGlobal
            // 
            this.menuGlobal.Name = "menuGlobal";
            this.menuGlobal.Size = new System.Drawing.Size(152, 22);
            this.menuGlobal.Text = "全局模式";
            this.menuGlobal.Click += new System.EventHandler(this.menuGlobal_Click);
            // 
            // menuPAC
            // 
            this.menuPAC.Name = "menuPAC";
            this.menuPAC.Size = new System.Drawing.Size(152, 22);
            this.menuPAC.Text = "PAC模式";
            this.menuPAC.Click += new System.EventHandler(this.menuPAC_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // menuKeep
            // 
            this.menuKeep.Name = "menuKeep";
            this.menuKeep.Size = new System.Drawing.Size(152, 22);
            this.menuKeep.Text = "保持当前模式";
            this.menuKeep.Click += new System.EventHandler(this.menuKeep_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(152, 22);
            this.menuExit.Text = "退出";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // bgwPing
            // 
            this.bgwPing.WorkerReportsProgress = true;
            this.bgwPing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPing_DoWork);
            this.bgwPing.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwPing_ProgressChanged);
            // 
            // menuAddServer
            // 
            this.menuAddServer.Name = "menuAddServer";
            this.menuAddServer.Size = new System.Drawing.Size(232, 22);
            this.menuAddServer.Text = "添加一个服务器";
            this.menuAddServer.Click += new System.EventHandler(this.menuAddServer_Click);
            // 
            // menuRemoveServer
            // 
            this.menuRemoveServer.Name = "menuRemoveServer";
            this.menuRemoveServer.Size = new System.Drawing.Size(232, 22);
            this.menuRemoveServer.Text = "移除所选服务器";
            this.menuRemoveServer.Click += new System.EventHandler(this.menuRemoveServer_Click);
            // 
            // menuCopyServer
            // 
            this.menuCopyServer.Name = "menuCopyServer";
            this.menuCopyServer.Size = new System.Drawing.Size(232, 22);
            this.menuCopyServer.Text = "复制所选服务器";
            this.menuCopyServer.Click += new System.EventHandler(this.menuCopyServer_Click);
            // 
            // menuSetDefaultServer
            // 
            this.menuSetDefaultServer.Name = "menuSetDefaultServer";
            this.menuSetDefaultServer.Size = new System.Drawing.Size(232, 22);
            this.menuSetDefaultServer.Text = "设为活动服务器";
            this.menuSetDefaultServer.Click += new System.EventHandler(this.menuSetDefaultServer_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(229, 6);
            // 
            // menuAddCustomServer
            // 
            this.menuAddCustomServer.Name = "menuAddCustomServer";
            this.menuAddCustomServer.Size = new System.Drawing.Size(232, 22);
            this.menuAddCustomServer.Text = "添加自定义配置服务器";
            this.menuAddCustomServer.Click += new System.EventHandler(this.menuAddCustomServer_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(229, 6);
            // 
            // menuMoveTop
            // 
            this.menuMoveTop.Name = "menuMoveTop";
            this.menuMoveTop.Size = new System.Drawing.Size(232, 22);
            this.menuMoveTop.Text = "上移至顶";
            this.menuMoveTop.Click += new System.EventHandler(this.menuMoveTop_Click);
            // 
            // menuMoveUp
            // 
            this.menuMoveUp.Name = "menuMoveUp";
            this.menuMoveUp.Size = new System.Drawing.Size(232, 22);
            this.menuMoveUp.Text = "上移";
            this.menuMoveUp.Click += new System.EventHandler(this.menuMoveUp_Click);
            // 
            // menuMoveDown
            // 
            this.menuMoveDown.Name = "menuMoveDown";
            this.menuMoveDown.Size = new System.Drawing.Size(232, 22);
            this.menuMoveDown.Text = "下移";
            this.menuMoveDown.Click += new System.EventHandler(this.menuMoveDown_Click);
            // 
            // menuMoveBottom
            // 
            this.menuMoveBottom.Name = "menuMoveBottom";
            this.menuMoveBottom.Size = new System.Drawing.Size(232, 22);
            this.menuMoveBottom.Text = "下移至底";
            this.menuMoveBottom.Click += new System.EventHandler(this.menuMoveBottom_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(229, 6);
            // 
            // menuPingServer
            // 
            this.menuPingServer.Name = "menuPingServer";
            this.menuPingServer.Size = new System.Drawing.Size(232, 22);
            this.menuPingServer.Text = "测试服务器延迟";
            this.menuPingServer.Click += new System.EventHandler(this.menuPingServer_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(229, 6);
            // 
            // menuExport2ClientConfig
            // 
            this.menuExport2ClientConfig.Name = "menuExport2ClientConfig";
            this.menuExport2ClientConfig.Size = new System.Drawing.Size(232, 22);
            this.menuExport2ClientConfig.Text = "导出所选服务器为客户端配置";
            this.menuExport2ClientConfig.Click += new System.EventHandler(this.menuExport2ClientConfig_Click);
            // 
            // menuExport2ServerConfig
            // 
            this.menuExport2ServerConfig.Name = "menuExport2ServerConfig";
            this.menuExport2ServerConfig.Size = new System.Drawing.Size(232, 22);
            this.menuExport2ServerConfig.Text = "导出所选服务器为服务端配置";
            this.menuExport2ServerConfig.Click += new System.EventHandler(this.menuExport2ServerConfig_Click);
            // 
            // menuShareQRCode
            // 
            this.menuShareQRCode.Name = "menuShareQRCode";
            this.menuShareQRCode.Size = new System.Drawing.Size(232, 22);
            this.menuShareQRCode.Text = "分享服务器配置";
            this.menuShareQRCode.Click += new System.EventHandler(this.menuShareQRCode_Click);
            // 
            // cmsLv
            // 
            this.cmsLv.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddServer,
            this.menuRemoveServer,
            this.menuCopyServer,
            this.menuSetDefaultServer,
            this.toolStripSeparator3,
            this.menuAddCustomServer,
            this.toolStripSeparator1,
            this.menuMoveTop,
            this.menuMoveUp,
            this.menuMoveDown,
            this.menuMoveBottom,
            this.toolStripSeparator9,
            this.menuPingServer,
            this.toolStripSeparator6,
            this.menuExport2ClientConfig,
            this.menuExport2ServerConfig,
            this.menuShareQRCode});
            this.cmsLv.Name = "cmsLv";
            this.cmsLv.Size = new System.Drawing.Size(233, 314);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 271);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务开启成功";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(436, 207);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "打开浏览器即可访问被墙网站";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 271);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "FreeSocks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.cmsMain.ResumeLayout(false);
            this.cmsLv.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuSysAgentMode;
        private System.Windows.Forms.ToolStripMenuItem menuGlobal;
        private System.Windows.Forms.ToolStripMenuItem menuPAC;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuKeep;
        private System.Windows.Forms.ToolStripMenuItem menuSysAgentEnabled;
        private System.ComponentModel.BackgroundWorker bgwPing;
        private System.Windows.Forms.ToolStripMenuItem menuAddServer;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveServer;
        private System.Windows.Forms.ToolStripMenuItem menuCopyServer;
        private System.Windows.Forms.ToolStripMenuItem menuSetDefaultServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuAddCustomServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuMoveTop;
        private System.Windows.Forms.ToolStripMenuItem menuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem menuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem menuMoveBottom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem menuPingServer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem menuExport2ClientConfig;
        private System.Windows.Forms.ToolStripMenuItem menuExport2ServerConfig;
        private System.Windows.Forms.ToolStripMenuItem menuShareQRCode;
        private System.Windows.Forms.ContextMenuStrip cmsLv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

