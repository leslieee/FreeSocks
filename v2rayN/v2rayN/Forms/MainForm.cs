﻿using System;
using System.Windows.Forms;
using v2rayN.Handler;
using v2rayN.HttpProxyHandler;
using v2rayN.Mode;

namespace v2rayN.Forms
{
    public partial class MainForm : BaseForm
    {
        private V2rayHandler v2rayHandler;

        private PACListHandle pacListHandle;

        #region Window 事件

        public MainForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            // this.WindowState = FormWindowState.Minimized;
            this.Text = Utils.GetVersion();

            Application.ApplicationExit += (sender, args) =>
            {
                Utils.ClearTempPath();
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConfigHandler.LoadConfig(ref config);
            v2rayHandler = new V2rayHandler();
            v2rayHandler.ProcessEvent += v2rayHandler_ProcessEvent;

            pacListHandle = new PACListHandle();
            pacListHandle.UpdateCompleted += (sender2, args) =>
            {
                if (args.Success)
                {
                    v2rayHandler_ProcessEvent(false, "PAC更新成功！");
                }
                else
                {
                    v2rayHandler_ProcessEvent(false, "PAC更新失败！");
                }
            };
            pacListHandle.Error += (sender2, args) =>
            {
                v2rayHandler_ProcessEvent(true, args.GetException().Message);
            };
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitServersView();
            RefreshServers();

            LoadV2ray();

            //自动从网络同步本地时间
            if (config.autoSyncTime)
            {
                //CDateTime.SetLocalTime();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                HideForm();
                return;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideForm();
            }
        }

        #endregion

        #region 显示服务器 listview 和 menu

        /// <summary>
        /// 刷新服务器
        /// </summary>
        private void RefreshServers()
        {
            RefreshServersView();
            RefreshServersMenu();
        }

        /// <summary>
        /// 初始化服务器列表
        /// </summary>
        private void InitServersView()
        {
            

        }

        /// <summary>
        /// 刷新服务器列表
        /// </summary>
        private void RefreshServersView()
        {
            

        }

        /// <summary>
        /// 刷新托盘服务器菜单
        /// </summary>
        private void RefreshServersMenu()
        {
           
        }

        private void ts_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem ts = (ToolStripItem)sender;
                int index = Convert.ToInt32(ts.Tag);
                SetDefaultServer(index);
            }
            catch
            {
            }
        }

        #endregion

        #region v2ray 操作

        /// <summary>
        /// 载入V2ray
        /// </summary>
        private void LoadV2ray()
        {
            if (Global.reloadV2ray)
            {
                ClearMsg();
            }
            v2rayHandler.LoadV2ray(config);
            Global.reloadV2ray = false;

            ChangeSysAgent(config.sysAgentEnabled);
        }

        /// <summary>
        /// 关闭V2ray
        /// </summary>
        private void CloseV2ray()
        {
            ConfigHandler.ToJsonFile(config);

            ChangeSysAgent(false);

            v2rayHandler.V2rayStop();
        }

        #endregion

        #region 功能按钮

        private void lvServers_DoubleClick(object sender, EventArgs e)
        {
            int index = GetLvSelectedIndex();
            if (index < 0)
            {
                return;
            }

            if (config.vmess[index].configType == (int)EConfigType.Normally)
            {
                AddServerForm fm = new AddServerForm();
                fm.EditIndex = index;
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    //刷新
                    RefreshServers();
                    LoadV2ray();
                }
            }
            else
            {
                AddServer2Form fm2 = new AddServer2Form();
                fm2.EditIndex = index;
                if (fm2.ShowDialog() == DialogResult.OK)
                {
                    //刷新
                    RefreshServers();
                    LoadV2ray();
                }
            }

        }

        private void menuAddServer_Click(object sender, EventArgs e)
        {
            AddServerForm fm = new AddServerForm();
            fm.EditIndex = -1;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
        }

        private void menuRemoveServer_Click(object sender, EventArgs e)
        {
            int index = GetLvSelectedIndex();
            if (index < 0)
            {
                return;
            }
            if (UI.ShowYesNo("是否确定移除服务器?") == DialogResult.No)
            {
                return;
            }
            if (ConfigHandler.RemoveServer(ref config, index) == 0)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
        }

        private void menuCopyServer_Click(object sender, EventArgs e)
        {
            int index = GetLvSelectedIndex();
            if (index < 0)
            {
                return;
            }
            if (ConfigHandler.CopyServer(ref config, index) == 0)
            {
                //刷新
                RefreshServers();
            }
        }

        private void menuSetDefaultServer_Click(object sender, EventArgs e)
        {
            int index = GetLvSelectedIndex();
            if (index < 0)
            {
                return;
            }
            SetDefaultServer(index);
        }

        private void menuPingServer_Click(object sender, EventArgs e)
        {
            bgwPing.RunWorkerAsync();
        }


        private void menuExport2ClientConfig_Click(object sender, EventArgs e)
        {
            int index = GetLvSelectedIndex();
            if (index < 0)
            {
                return;
            }
            if (config.vmess[index].configType != (int)EConfigType.Normally)
            {
                UI.Show("自定义配置，此功能无效");
                return;
            }

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Config|*.json";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileName = fileDialog.FileName;
            if (Utils.IsNullOrEmpty(fileName))
            {
                return;
            }
            Config configCopy = Utils.DeepCopy<Config>(config);
            configCopy.index = index;
            string msg;
            if (V2rayConfigHandler.Export2ClientConfig(configCopy, fileName, out msg) != 0)
            {
                UI.Show(msg);
            }
            else
            {
                UI.Show(string.Format("客户端配置文件保存在:{0}", fileName));
            }
        }

        private void menuExport2ServerConfig_Click(object sender, EventArgs e)
        {
            int index = GetLvSelectedIndex();
            if (index < 0)
            {
                return;
            }
            if (config.vmess[index].configType != (int)EConfigType.Normally)
            {
                UI.Show("自定义配置，此功能无效");
                return;
            }

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Config|*.json";
            fileDialog.FilterIndex = 2;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileName = fileDialog.FileName;
            if (Utils.IsNullOrEmpty(fileName))
            {
                return;
            }
            Config configCopy = Utils.DeepCopy<Config>(config);
            configCopy.index = index;
            string msg;
            if (V2rayConfigHandler.Export2ServerConfig(configCopy, fileName, out msg) != 0)
            {
                UI.Show(msg);
            }
            else
            {
                UI.Show(string.Format("服务端配置文件保存在:{0}", fileName));
            }
        }

        private void menuShareQRCode_Click(object sender, EventArgs e)
        {
            int index = GetLvSelectedIndex();
            if (index < 0)
            {
                return;
            }
            if (config.vmess[index].configType != (int)EConfigType.Normally)
            {
                UI.Show("自定义配置，此功能无效");
                return;
            }

            QRCodeForm fm = new QRCodeForm();
            fm.Index = index;
            fm.ShowDialog();
        }

        private void tsbOptionSetting_Click(object sender, EventArgs e)
        {
            OptionSettingForm fm = new OptionSettingForm();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
        }

        private void tsbReload_Click(object sender, EventArgs e)
        {
            Global.reloadV2ray = true;
            LoadV2ray();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {


            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 设置活动服务器
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int SetDefaultServer(int index)
        {
            if (index < 0)
            {
                UI.Show("请先选择服务器");
                return -1;
            }
            if (ConfigHandler.SetDefaultServer(ref config, index) == 0)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
            return 0;
        }

        /// <summary>
        /// 取得ListView选中的行
        /// </summary>
        /// <returns></returns>
        private int GetLvSelectedIndex()
        {
            return 0; 
        }

        private void menuAddCustomServer_Click(object sender, EventArgs e)
        {
            UI.Show("注意,自定义配置：" +
                    "\r\n完全依赖您自己的配置，不能使用所有设置功能。" +
                    "\r\n在自定义配置inbound中有socks port等于设置中的port时，系统代理才可用");

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Config|*.json|所有文件|*.*";
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileName = fileDialog.FileName;
            if (Utils.IsNullOrEmpty(fileName))
            {
                return;
            }

            if (ConfigHandler.AddCustomServer(ref config, fileName) == 0)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
                UI.Show(string.Format("成功导入自定义配置服务器"));
            }
            else
            {
                UI.Show(string.Format("导入自定义配置服务器失败"));
            }
        }


        #endregion


        #region 提示信息

        /// <summary>
        /// 消息委托
        /// </summary>
        /// <param name="notify"></param>
        /// <param name="msg"></param>
        void v2rayHandler_ProcessEvent(bool notify, string msg)
        {
            try
            {
                AppendText(msg);
                if (notify)
                {
                    notifyMsg(msg);
                }
            }
            catch
            {
            }
        }

        delegate void AppendTextDelegate(string text);

        void AppendText(string text)
        {
            
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMsg(string msg)
        {
            
        }

        /// <summary>
        /// 清除信息
        /// </summary>
        private void ClearMsg()
        {
        }

        /// <summary>
        /// 托盘信息
        /// </summary>
        /// <param name="msg"></param>
        private void notifyMsg(string msg)
        {
            notifyMain.Text = msg;
        }

        #endregion


        #region 托盘事件

        private void notifyMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ShowForm();
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            CloseV2ray();

            this.Visible = false;
            this.Close();
            //this.Dispose();
            //System.Environment.Exit(System.Environment.ExitCode);
            Application.Exit();
        }

        private void menuUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Global.UpdateUrl);
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Global.AboutUrl);
        }

        private void ShowForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            //this.notifyIcon1.Visible = false;
        }

        private void HideForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            this.notifyMain.Visible = true;
        }

        #endregion

        #region 后台测速

        private void bgwPing_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                for (int k = 0; k < config.vmess.Count; k++)
                {
                    long time = Utils.Ping(config.vmess[k].address);
                    bgwPing.ReportProgress(k, string.Format("{0}ms", time));
                }
            }
            catch
            {
            }
        }

        private void bgwPing_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                

            }
            catch
            {
            }
        }

        #endregion

        #region 移动服务器

        private void menuMoveTop_Click(object sender, EventArgs e)
        {
            MoveServer(EMove.Top);
        }

        private void menuMoveUp_Click(object sender, EventArgs e)
        {
            MoveServer(EMove.Up);
        }

        private void menuMoveDown_Click(object sender, EventArgs e)
        {
            MoveServer(EMove.Down);
        }

        private void menuMoveBottom_Click(object sender, EventArgs e)
        {
            MoveServer(EMove.Bottom);
        }

        private void MoveServer(EMove eMove)
        {
            int index = GetLvSelectedIndex();
            if (index < 0)
            {
                UI.Show("请先选择服务器");
                return;
            }
            if (ConfigHandler.MoveServer(ref config, index, eMove) == 0)
            {
                //刷新
                RefreshServers();
                LoadV2ray();
            }
        }

        #endregion

        #region PAC相关


        private void menuUpdatePACList_Click(object sender, EventArgs e)
        {
            pacListHandle.UpdatePACFromGFWList(config);
        }

        private void menuCopyPACUrl_Click(object sender, EventArgs e)
        {
            Utils.SetClipboardData(HttpProxyHandle.GetPacUrl());
        }

        private void menuSysAgentEnabled_Click(object sender, EventArgs e)
        {
            bool isChecked = !config.sysAgentEnabled;
            config.sysAgentEnabled = isChecked;
            ChangeSysAgent(isChecked);
        }

        private void menuGlobal_Click(object sender, EventArgs e)
        {
            config.listenerType = 1;
            ChangePACButtonStatus(1);
        }

        private void menuPAC_Click(object sender, EventArgs e)
        {
            config.listenerType = 2;
            ChangePACButtonStatus(2);
        }

        private void menuKeep_Click(object sender, EventArgs e)
        {
            config.listenerType = 0;
            ChangePACButtonStatus(0);
        }

        private void ChangePACButtonStatus(int type)
        {
            if (HttpProxyHandle.Update(config, false))
            {
                switch (type)
                {
                    case 0:
                        menuGlobal.Checked = false;
                        menuKeep.Checked = true;
                        menuPAC.Checked = false;
                        break;
                    case 1:
                        menuGlobal.Checked = true;
                        menuKeep.Checked = false;
                        menuPAC.Checked = false;
                        break;
                    case 2:
                        menuGlobal.Checked = false;
                        menuKeep.Checked = false;
                        menuPAC.Checked = true;
                        break;
                }
            }

        }

        /// <summary>
        /// 改变系统代理
        /// </summary>
        /// <param name="isChecked"></param>
        private void ChangeSysAgent(bool isChecked)
        {
            if (isChecked)
            {
                if (HttpProxyHandle.RestartHttpAgent(config, false))
                {
                    ChangePACButtonStatus(config.listenerType);
                }
            }
            else
            {
                HttpProxyHandle.Update(config, true);
                HttpProxyHandle.CloseHttpAgent(config);
            }

            menuSysAgentEnabled.Checked =
            menuSysAgentMode.Enabled = isChecked;
        }
        #endregion



    }
}
