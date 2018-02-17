using EqdkpApiService.ApiObjects;
using EqdkpWindowsNotifier.Objects;
using EqdkpWindowsNotifier.Service;
using Microsoft.Win32;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Tools;

namespace EqdkpWindowsNotifier
{
    public partial class MainView : Form
    {
        private DataService _DataService;
        private WowAddonService _WowAddonService;
        private string _AppName = "EQDKPWindowsNotifier";
        private RegistryKey _RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private Regex UrlRegex = new Regex(@"http:\/\/.*|https:\/\/.*", RegexOptions.Compiled);

        public MainView()
        {
            InitializeComponent();
            _DataService = new DataService();
            _WowAddonService = new WowAddonService();

            chkStartUp.Checked = GetStartUpValue();

            var timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = TimeSpan.FromMinutes(15).TotalMilliseconds;
            timer.Enabled = true;

            LoadSettings();
            Hide();            
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateData(false);
        }

        private bool GetStartUpValue()
        {
            return _RegistryKey.GetValue(_AppName) != null;
        }

        private void LoadSettings()
        {
            var settings = _DataService.GetSettings();
            if (settings != null)
            {
                tb_serverURL.Text = ConfigSettings.ApiUrl = settings.ApiUrl;
                tb_apikey.Text = ConfigSettings.ApiKey = settings.ApiKey;
                tb_wowpath.Text = settings.WowPath;
            }
        }

        private void UpdateData(bool notifyOnUpdate = true)
        {
            try
            {
                var players = _DataService.GetPlayers();
                var events = _DataService.GetEvents();

                var raids = DataConverter.Convert(events);

                var test = LuaDataSerializer.Convert(raids);

                FileHandler.SaveAddonData(_DataService.GetSettings().WowPath, "raidData.lua", test);

                if(notifyOnUpdate) NotifyInfo("Data updated.");
            }
            catch (Exception ex)
            {
                NotifyError($"{ex.Message}");
            }
        }

        private void NotifyInfo(string message)
        {
            EqdkpInviteTool.ShowBalloonTip(1000, "Info", message, ToolTipIcon.Info);
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
            if (chkStartUp.Checked)
                _RegistryKey.SetValue(_AppName, Application.ExecutablePath);
            else
                _RegistryKey.DeleteValue(_AppName, false);
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
            SetStartup();
            var settings = new SettingsData
            {
                ApiUrl = UrlRegex.IsMatch(tb_serverURL.Text) ? tb_serverURL.Text : $"http://{tb_serverURL.Text}",
                ApiKey = tb_apikey.Text,
                WowPath = tb_wowpath.Text
            };

            _DataService.SaveSettings(settings);
            _DataService.UpdateSettings();
            LoadSettings();
        }
    }
}
