namespace EqdkpWindowsNotifier
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EqdkpInviteTool = new System.Windows.Forms.NotifyIcon(this.components);
            this.label_serverurl = new System.Windows.Forms.Label();
            this.tb_serverURL = new System.Windows.Forms.TextBox();
            this.tb_apikey = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.tb_wowpath = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.button_saveSettings = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chkStartUp = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.updateNowToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(141, 70);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // updateNowToolStripMenuItem
            // 
            this.updateNowToolStripMenuItem.Name = "updateNowToolStripMenuItem";
            this.updateNowToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.updateNowToolStripMenuItem.Text = "Update Now";
            this.updateNowToolStripMenuItem.Click += new System.EventHandler(this.updateNowToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // EqdkpInviteTool
            // 
            this.EqdkpInviteTool.ContextMenuStrip = this.contextMenuStrip;
            this.EqdkpInviteTool.Icon = ((System.Drawing.Icon)(resources.GetObject("EqdkpInviteTool.Icon")));
            this.EqdkpInviteTool.Text = "EqdkpInviteTool";
            this.EqdkpInviteTool.Visible = true;
            this.EqdkpInviteTool.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // label_serverurl
            // 
            this.label_serverurl.AutoSize = true;
            this.label_serverurl.Location = new System.Drawing.Point(13, 13);
            this.label_serverurl.Name = "label_serverurl";
            this.label_serverurl.Size = new System.Drawing.Size(66, 13);
            this.label_serverurl.TabIndex = 1;
            this.label_serverurl.Text = "Server URL:";
            // 
            // tb_serverURL
            // 
            this.tb_serverURL.Location = new System.Drawing.Point(82, 10);
            this.tb_serverURL.Name = "tb_serverURL";
            this.tb_serverURL.Size = new System.Drawing.Size(190, 20);
            this.tb_serverURL.TabIndex = 2;
            this.tb_serverURL.Leave += new System.EventHandler(this.tb_serverURL_Leave);
            // 
            // tb_apikey
            // 
            this.tb_apikey.Location = new System.Drawing.Point(82, 36);
            this.tb_apikey.Name = "tb_apikey";
            this.tb_apikey.Size = new System.Drawing.Size(190, 20);
            this.tb_apikey.TabIndex = 4;
            this.tb_apikey.Leave += new System.EventHandler(this.tb_apikey_Leave);
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(13, 39);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(49, 13);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Api Key :";
            // 
            // tb_wowpath
            // 
            this.tb_wowpath.HideSelection = false;
            this.tb_wowpath.Location = new System.Drawing.Point(82, 62);
            this.tb_wowpath.Name = "tb_wowpath";
            this.tb_wowpath.Size = new System.Drawing.Size(190, 20);
            this.tb_wowpath.TabIndex = 6;
            this.tb_wowpath.Enter += new System.EventHandler(this.tb_password_Enter);
            this.tb_wowpath.Leave += new System.EventHandler(this.tb_wowpath_Leave);
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(13, 65);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(60, 13);
            this.label_password.TabIndex = 5;
            this.label_password.Text = "WoW-Path";
            // 
            // button_saveSettings
            // 
            this.button_saveSettings.Location = new System.Drawing.Point(16, 112);
            this.button_saveSettings.Name = "button_saveSettings";
            this.button_saveSettings.Size = new System.Drawing.Size(256, 23);
            this.button_saveSettings.TabIndex = 7;
            this.button_saveSettings.Text = "Save Settings";
            this.button_saveSettings.UseVisualStyleBackColor = true;
            this.button_saveSettings.Click += new System.EventHandler(this.button_saveSettings_Click);
            // 
            // chkStartUp
            // 
            this.chkStartUp.AutoSize = true;
            this.chkStartUp.Location = new System.Drawing.Point(13, 89);
            this.chkStartUp.Name = "chkStartUp";
            this.chkStartUp.Size = new System.Drawing.Size(117, 17);
            this.chkStartUp.TabIndex = 8;
            this.chkStartUp.Text = "Start with Windows";
            this.chkStartUp.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.chkStartUp.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 143);
            this.Controls.Add(this.chkStartUp);
            this.Controls.Add(this.button_saveSettings);
            this.Controls.Add(this.tb_wowpath);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.tb_apikey);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.tb_serverURL);
            this.Controls.Add(this.label_serverurl);
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EQDKP Invite Tool Settings";
            this.Move += new System.EventHandler(this.MainView_Move);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon EqdkpInviteTool;
        private System.Windows.Forms.Label label_serverurl;
        private System.Windows.Forms.TextBox tb_serverURL;
        private System.Windows.Forms.TextBox tb_apikey;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.TextBox tb_wowpath;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Button button_saveSettings;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chkStartUp;
    }
}

