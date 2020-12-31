using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Ambiesoft;
using System.Reflection;
using System.Diagnostics;

namespace Ambiesoft.AfterFinish
{
    public partial class OptionDialog : Form
    {
        static readonly string KEY_chkPlaySound = "chkPlaySound";
        static readonly string KEY_txtWav = "txtWav";
        static readonly string KEY_chkOpenFolder = "chkOpenFolder";
        static readonly string KEY_chkShutdown = "chkShutdown";
        static readonly string KEY_chkLaunchApp = "chkLaunchApp";
        static readonly string KEY_txtApp = "txtApp";
        static readonly string KEY_txtArg = "txtArg";

        bool bShowPlaySound_;
        bool bShowOpenFolder_;
        bool bShowShutdown_;
        bool bShowLaunchApp_;
        public OptionDialog(
            bool bShowPlaySound,
            bool bShowOpenFolder,
            bool bShowShutdown,
            bool bShowLaunchApp)
        {
            InitializeComponent();

            chkPlaySound.Visible = bShowPlaySound_ = bShowPlaySound;
            chkOpenFolder.Visible = bShowOpenFolder_ = bShowOpenFolder;
            chkShutdown.Visible = bShowShutdown_ = bShowShutdown;
            chkLaunchApp.Visible = bShowLaunchApp_ = bShowLaunchApp;

            updateState();
        }

        private void updateState()
        {
            txtWav.Enabled = btnBrowseWav.Enabled = btnTestSound.Enabled = chkPlaySound.Checked;
            txtApp.Enabled = txtArg.Enabled = btnBrowseApp.Enabled = btnBrowseArg.Enabled = btnLanuchTest.Enabled = chkLaunchApp.Checked;
        }
        private void chkLaunchApp_CheckedChanged(object sender, EventArgs e)
        {
            updateState();
        }

        public bool LoadValues(string section, HashIni ini)
        {
            bool b;
            string s;
           
            if(Profile.GetBool(section, KEY_chkPlaySound, false, out b, ini))
                chkPlaySound.Checked = b;
            if (Profile.GetString(section, KEY_txtWav, string.Empty, out s, ini))
                txtWav.Text = s;

            if (Profile.GetBool(section, KEY_chkOpenFolder, false, out b, ini))
                chkOpenFolder.Checked = b;
            if (Profile.GetBool(section, KEY_chkShutdown, false, out b, ini))
                chkShutdown.Checked = b;
            if (Profile.GetBool(section, KEY_chkLaunchApp, false, out b, ini))
                chkLaunchApp.Checked = b;

            if (Profile.GetString(section, KEY_txtApp, string.Empty, out s, ini))
                txtApp.Text = s;
            if (Profile.GetString(section, KEY_txtArg, string.Empty, out s, ini))
                txtArg.Text = s;

            return true;
        }
        public bool SaveValues(string section, HashIni ini)
        {
            bool ok = true;
            
            ok &= Profile.WriteBool(section, KEY_chkPlaySound, chkPlaySound.Checked, ini);
            ok &= Profile.WriteString(section, KEY_txtWav, txtWav.Text, ini);

            ok &= Profile.WriteBool(section, KEY_chkOpenFolder, chkOpenFolder.Checked, ini);
            ok &= Profile.WriteBool(section, KEY_chkShutdown, chkShutdown.Checked, ini);

            ok &= Profile.WriteBool(section, KEY_chkLaunchApp, chkLaunchApp.Checked, ini);
            ok &= Profile.WriteString(section, KEY_txtApp, txtApp.Text, ini);
            ok &= Profile.WriteString(section, KEY_txtArg, txtArg.Text, ini);

            return ok;
        }

        private void btnBrowseApp_Click(object sender, EventArgs e)
        {
            string app = AmbLib.GetOpenFileDialog(Properties.Resources.STR_CHOOSE_APPLICATION,
                AmbLib.GETOPENFILEDIALOGTYPE.APP);
            if (string.IsNullOrEmpty(app))
                return;
            txtApp.Text = app;
        }
        private void btnBrowseArg_Click(object sender, EventArgs e)
        {
            string arg = AmbLib.GetOpenFileDialog(Properties.Resources.STR_CHOOSE_FILE);
            if (string.IsNullOrEmpty(arg))
                return;
            txtArg.Text = arg;
        }

        private void chkPlaySound_CheckedChanged(object sender, EventArgs e)
        {
            updateState();
        }

        private void btnBrowseWav_Click(object sender, EventArgs e)
        {
            var extentions = new Dictionary<string,string[]>();
            extentions["wav"]=new string[]{"*.wav"};
            string wav = AmbLib.GetOpenFileDialog(Properties.Resources.STR_CHOOSE_APPLICATION,
                extentions);
              
            if (string.IsNullOrEmpty(wav))
                return;
            txtWav.Text = wav;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(chkPlaySound.Checked)
            {
                if (string.IsNullOrEmpty(txtWav.Text))
                {
                    MessageBox.Show(Properties.Resources.STR_WAVISEMPTY,
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    txtWav.Focus();

                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
            if(chkLaunchApp.Checked)
            {
                if(string.IsNullOrEmpty(txtApp.Text) && string.IsNullOrEmpty(txtArg.Text))
                {
                    MessageBox.Show(Properties.Resources.STR_APPANDARGISEMPTY,
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    if (string.IsNullOrEmpty(txtApp.Text))
                        txtApp.Focus();

                    this.DialogResult = DialogResult.None;
                    return;
                }
            }
        }

        private System.Media.SoundPlayer player = null;
        private void btnTestSound_Click(object sender, EventArgs e)
        {
            PlayWav(false);
        }
        public void PlayWav(bool bShowNoError)
        {
            if (!bShowNoError)
            {
                if (string.IsNullOrEmpty(txtWav.Text))
                {
                    MessageBox.Show(Properties.Resources.STR_WAVISEMPTY,
                          Application.ProductName,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    return;
                }

                if (!File.Exists(txtWav.Text))
                {
                    MessageBox.Show(Properties.Resources.STR_WAVFILENOTEXIST,
                          Application.ProductName,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    return;
                }
            }

            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }

            try
            {
                player = new System.Media.SoundPlayer(txtWav.Text);
                player.Play();
            }
            catch (Exception ex)
            {
                if (!bShowNoError)
                {
                    MessageBox.Show(ex.Message,
                          Application.ProductName,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public string ToDescription()
        {
            StringBuilder sb = new StringBuilder();
            if (bShowPlaySound_ && chkPlaySound.Checked)
            {
                sb.AppendLine("Play Sound");
                sb.AppendLine(" wav sound:" + txtWav.Text);
            }
            if (bShowOpenFolder_ && chkOpenFolder.Checked)
            {
                sb.AppendLine("Open Folder");
            }
            if (bShowShutdown_ && chkShutdown.Checked)
            {
                sb.AppendLine("Shutdown OS");
            }
            if (bShowLaunchApp_ && chkLaunchApp.Checked)
            {
                sb.AppendLine("Launch App");
                sb.AppendLine(" Application:" + txtApp.Text);
                sb.AppendLine(" Arguments:" + txtArg.Text);
            }
            return sb.ToString();
        }

        private void btnLanuchTest_Click(object sender, EventArgs e)
        {
            LaunchApp();
        }
        void LaunchApp()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtApp.Text) && !string.IsNullOrEmpty(txtArg.Text))
                    Process.Start(txtApp.Text, txtArg.Text);
                else
                    Process.Start(!string.IsNullOrEmpty(txtApp.Text) ?
                        txtApp.Text : txtArg.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    
        public void DoNotify()
        {
            if(bShowPlaySound_ && chkPlaySound.Checked)
            {
                PlayWav(false);
            }
            if(bShowOpenFolder_ && chkOpenFolder.Checked)
            {
                MessageBox.Show("Show Folder is not implemented",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            if(bShowShutdown_ && chkShutdown.Checked)
            {
                MessageBox.Show("Shutdown is not implemented",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            if(bShowLaunchApp_ && chkLaunchApp.Checked)
            {
                LaunchApp();
            }
        }
    }
}
