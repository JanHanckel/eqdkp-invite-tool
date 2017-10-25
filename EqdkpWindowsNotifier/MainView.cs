using EqdkpApiService.ApiObjects;
using System;
using System.Windows.Forms;

namespace EqdkpWindowsNotifier
{
    public partial class MainView : Form
    {
        private EqdkpApiService.EqdkpApiService _eqdkpApiService;

        public MainView()
        {
            InitializeComponent();
            _eqdkpApiService = new EqdkpApiService.EqdkpApiService();
            LoadSettings();
            Hide();
        }

        private void LoadSettings()
        {
            ConfigSettings.ApiUrl = "http://grauerrat.de";
            ConfigSettings.ApiKey = "0d3f49c31b4a99d136cfb0a8b4f37abcccb9118cfbe7054225944d3c88f9134e";

            tb_serverURL.Text = ConfigSettings.ApiUrl;
            tb_username.Text = ConfigSettings.ApiKey;
        }

        private void UpdateData()
        {
            try
            {
                _eqdkpApiService.Login();
                _eqdkpApiService.GetEvents();
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

        #endregion

        private void button_saveSettings_Click(object sender, EventArgs e)
        {
            ConfigSettings.ApiUrl = tb_serverURL.Text;
            ConfigSettings.ApiKey = tb_username.Text;
        }
    }
}
