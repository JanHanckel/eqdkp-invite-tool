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
            this.tb_username = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.button_saveSettings = new System.Windows.Forms.Button();
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
            this.label_serverurl.Size = new System.Drawing.Size(63, 13);
            this.label_serverurl.TabIndex = 1;
            this.label_serverurl.Text = "Server URL";
            // 
            // tb_serverURL
            // 
            this.tb_serverURL.Location = new System.Drawing.Point(82, 10);
            this.tb_serverURL.Name = "tb_serverURL";
            this.tb_serverURL.Size = new System.Drawing.Size(190, 20);
            this.tb_serverURL.TabIndex = 2;
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(82, 36);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(190, 20);
            this.tb_username.TabIndex = 4;
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Location = new System.Drawing.Point(13, 39);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(55, 13);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Username";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(82, 62);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(190, 20);
            this.tb_password.TabIndex = 6;
            this.tb_password.UseSystemPasswordChar = true;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(13, 65);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(53, 13);
            this.label_password.TabIndex = 5;
            this.label_password.Text = "Password";
            // 
            // button_saveSettings
            // 
            this.button_saveSettings.Location = new System.Drawing.Point(16, 88);
            this.button_saveSettings.Name = "button_saveSettings";
            this.button_saveSettings.Size = new System.Drawing.Size(256, 23);
            this.button_saveSettings.TabIndex = 7;
            this.button_saveSettings.Text = "Save Settings";
            this.button_saveSettings.UseVisualStyleBackColor = true;
            this.button_saveSettings.Click += new System.EventHandler(this.button_saveSettings_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 120);
            this.Controls.Add(this.button_saveSettings);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.tb_username);
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
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Button button_saveSettings;
    }
}

