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
        }

        private void LoadSettings()
        {
            ConfigSettings.ApiUrl = "http://grauerrat.de";
            ConfigSettings.UserName = "Gelaxor";
            ConfigSettings.Password = "odl05gr06";
            ConfigSettings.PasswordSalt = "";
        }

        private void UpdateData()
        {
            try
            {
                _eqdkpApiService.Login();
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
    }
}
