using EqdkpApiService.ApiObjects;
using EqdkpWindowsNotifier.Objects;
using EqdkpWindowsNotifier.Service;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tools;

namespace EqdkpWindowsNotifier
{
    public partial class MainView : Form
    {
        private DataService _DataService;        

        public MainView()
        {
            InitializeComponent();
            _DataService = new DataService();

            LoadSettings();
            Hide();
            //UpdateData();
        }

        private void LoadSettings()
        {
            var settings = _DataService.GetSettings();
            if (settings != null)
            {
                tb_serverURL.Text = ConfigSettings.ApiUrl = settings.ApiUrl;// "http://grauerrat.de"; //"http://192.168.0.22:1337";
                tb_apikey.Text = ConfigSettings.ApiKey = settings.ApiKey; //"0d3f49c31b4a99d136cfb0a8b4f37abcccb9118cfbe7054225944d3c88f9134e";
                tb_wowpath.Text = settings.WowPath;
            }
        }

        private void UpdateData()
        {
            try
            {
                var players = _DataService.GetPlayers();
                var events = _DataService.GetEvents();

                var raids = DataConverter.Convert(events);

                var test = LuaDataSerializer.Convert(raids);
            }
            catch (Exception ex)
            {
                NotifyError(ex.Message);
            }
        }

        private void NotifyError(string message)
        {
            EqdkpInviteTool.ShowBalloonTip(1000, "Error", message, ToolTipIcon.Error);
        }

        #region window events

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void updateNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainView_Move(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                EqdkpInviteTool.ShowBalloonTip(1000, "Still running", "Will update in background.", ToolTipIcon.Info);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {                
                Hide();
                e.Cancel = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowSettings();
        }

        private void ShowSettings()
        {
            Show();
            Focus();
        }

        public void ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tb_wowpath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SetStartup()
        {
            //RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            //if (chkStartUp.Checked)
            //    rk.SetValue(AppName, Application.ExecutablePath.ToString());
            //else
            //    rk.DeleteValue(AppName, false);
        }

        #endregion

        private void button_saveSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void tb_password_Enter(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void tb_serverURL_Leave(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void tb_apikey_Leave(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void tb_wowpath_Leave(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            var settings = new SettingsData
            {
                ApiUrl = $"http://{tb_serverURL.Text}",
                ApiKey = tb_apikey.Text,
                WowPath = tb_wowpath.Text
            };

            _DataService.SaveSettings(settings);
        }
    }
}
