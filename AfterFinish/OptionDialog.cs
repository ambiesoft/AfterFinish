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
using System.Threading;
using System.Media;
using System.Threading.Tasks;

namespace Ambiesoft.AfterFinish
{
    public partial class OptionDialog : Form
    {
        static readonly string KEY_chkPlaySound = "chkPlaySound";
        static readonly string KEY_txtWav = "txtWav";
        static readonly string KEY_udRepeatCount = "udRepeatCount";
        static readonly string KEY_chkOpenFolder = "chkOpenFolder";
        static readonly string KEY_chkShutdown = "chkShutdown";
        static readonly string KEY_chkLaunchApp = "chkLaunchApp";
        static readonly string KEY_txtApp = "txtApp";
        static readonly string KEY_txtArg = "txtArg";

        bool bShowPlaySound_;
        bool bShowOpenFolder_;
        bool bShowShutdown_;
        bool bShowLaunchApp_;

        /// <summary>
        /// Raised before an application is launched. Subscribers can set LaunchEventArgs.Cancel = true to prevent the launch.
        /// </summary>
        public event EventHandler<LaunchEventArgs> OnLaunch;

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
            txtWav.Enabled = btnBrowseWav.Enabled = btnTestSound.Enabled = udRepeatCount.Enabled = chkPlaySound.Checked;
            txtApp.Enabled = txtArg.Enabled = btnBrowseApp.Enabled = btnBrowseArg.Enabled = btnLanuchTest.Enabled = chkLaunchApp.Checked;
        }
        private void chkLaunchApp_CheckedChanged(object sender, EventArgs e)
        {
            updateState();
        }

        public bool LoadValues(string section, HashIni ini)
        {
            bool b;
            int i;
            string s;
           
            if(Profile.GetBool(section, KEY_chkPlaySound, false, out b, ini))
                chkPlaySound.Checked = b;
            if (Profile.GetString(section, KEY_txtWav, string.Empty, out s, ini))
                txtWav.Text = s;
            if (Profile.GetInt(section, KEY_udRepeatCount, 1, out i, ini))
                udRepeatCount.Value = i;

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
            ok &= Profile.WriteInt(section, KEY_udRepeatCount, Decimal.ToInt32(udRepeatCount.Value), ini);

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

        MacroManager _mm;
        public void SetArgMacro(string name , string value)
        {
            if (_mm == null)
                _mm = new MacroManager();
            _mm.SetMacro(name, value);
        }
        public string ExpandMacro()
        {
            if (_mm == null)
                return null;
            _mm.InputString = txtArg.Text;
            return _mm.ResultString;
        }
        private void btnBrowseArg_Click(object sender, EventArgs e)
        {
            if (_mm != null)
            {
                _mm.Text = string.Format("{0} - Macro", Application.ProductName);
                _mm.InputString = txtArg.Text;
                if (DialogResult.OK != _mm.ShowDialog())
                    return;
                txtArg.Text = _mm.InputString;
            }
            else
            {
                string arg = AmbLib.GetOpenFileDialog(Properties.Resources.STR_CHOOSE_FILE);
                if (string.IsNullOrEmpty(arg))
                    return;
                txtArg.Text = arg;
            }
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


        volatile int playid_;
        bool TogglePlayButton(bool? on = null)
        {
            int tt = on == null ? 1 : ((bool)on ? 2 : 3);
            if (tt != 3 && (tt == 2 || btnTestSound.Tag == null || !((bool)btnTestSound.Tag)))
            {
                btnTestSound.Tag = true;
                btnTestSound.Text = Properties.Resources.BTN_TESTSOUND_STOP;
                return true;
            }
            else
            {
                btnTestSound.Tag = false;
                btnTestSound.Text = Properties.Resources.BTN_TESTSOUND_START;
                return false;
            }
        }
        private void btnTestSound_Click(object sender, EventArgs e)
        {
            if(TogglePlayButton())
            {
                if (!PlayWav(false))
                    TogglePlayButton(false);
            }
            else
            {
                StopWav();
            }
        }
        public void StopWav()
        {
            ++playid_;
        }
        public bool PlayWav(bool bShowNoError)
        {
            if (!bShowNoError)
            {
                if (string.IsNullOrEmpty(txtWav.Text))
                {
                    MessageBox.Show(Properties.Resources.STR_WAVISEMPTY,
                          Application.ProductName,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    return false;
                }

                if (!File.Exists(txtWav.Text))
                {
                    MessageBox.Show(Properties.Resources.STR_WAVFILENOTEXIST,
                          Application.ProductName,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    return false;
                }
            }

            try
            {
                int pi = ++playid_;
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var player = new SoundPlayer(txtWav.Text);
                        int count = Decimal.ToInt32(udRepeatCount.Value);
                        for (int i = 0; i < count; ++i)
                        {
                            if (pi != playid_)
                                break;
                            player.PlaySync();
                        }

                        PlayFinished();
                    }
                    catch(Exception ex)
                    {
                        PlayErrored(ex);
                    }
                });
            }
            catch (Exception ex)
            {
                if (!bShowNoError)
                {
                    MessageBox.Show(ex.Message,
                          Application.ProductName,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        void PlayErrored(Exception ex)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => { PlayErrored(ex); }));
                return;
            }
            MessageBox.Show(ex.Message,
                Application.ProductName,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        void PlayFinished()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(() => { PlayFinished(); }));
                return;
            }
            TogglePlayButton(false);
        }

        public string ToDescription()
        {
            StringBuilder sb = new StringBuilder();
            if (bShowPlaySound_ && chkPlaySound.Checked)
            {
                sb.AppendLine("Play Sound");
                sb.AppendLine(" wav sound:" + txtWav.Text);
                sb.AppendLine(" Repeat Count:" + udRepeatCount.Value);
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

        void LaunchApp(bool bNotShowError)
        {
            try
            {
                string arg = txtArg.Text;
                if (_mm != null)
                    arg = ExpandMacro();

                string file = txtApp.Text;

                // Raise the OnLaunch event to allow subscribers to inspect or cancel the launch
                var ev = new LaunchEventArgs()
                {
                    FileName = file,
                    Arguments = arg,
                    Cancel = false
                };
                try
                {
                    OnLaunch?.Invoke(this, ev);
                }
                catch
                {
                    // Swallow exceptions from event handlers to avoid crashing the caller.
                }
                if (ev.Cancel)
                    return;

                if (!string.IsNullOrEmpty(file) && !string.IsNullOrEmpty(arg))
                    Process.Start(file, arg);
                else
                    Process.Start(!string.IsNullOrEmpty(file) ? file : arg);
            }
            catch (Exception ex)
            {
                if (!bNotShowError)
                {
                    MessageBox.Show(ex.Message,
                        Application.ProductName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        void LaunchApp()
        {
            LaunchApp(false);
        }
        void startOfShutdownThread()
        {
            Ambiesoft.AfterRunLib.FormMain formAfterrun = new AfterRunLib.FormMain(
                new Ambiesoft.AfterRunLib.UserInput(
                    true,
                    null,
                    30,
                    null));
            formAfterrun.OnLaunch += FormAfterrun_OnLaunch;
            formAfterrun.ShowDialog(null);
        }

        private void FormAfterrun_OnLaunch(object sender, AfterRunLib.FormMain.LaunchEventArgs e)
        {
            var ev = new LaunchEventArgs()
            {
                FileName = "Not yet implemented",
                Arguments = "Not yet implemented",
                Cancel = false,
            };
            try
            {
                OnLaunch?.Invoke(this, ev);
            }
            catch
            {
                // Swallow exceptions from event handlers to avoid crashing the caller.
            }
        }

        public void DoNotify()
        {
            if(bShowPlaySound_ && chkPlaySound.Checked)
            {
                PlayWav(true);
            }
            if(bShowOpenFolder_ && chkOpenFolder.Checked)
            {
                MessageBox.Show("Show Folder is not implemented",
                    Application.ProductName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            if(bShowLaunchApp_ && chkLaunchApp.Checked)
            {
                LaunchApp(true);
            }
            if (bShowShutdown_ && chkShutdown.Checked)
            {
                Thread thread = new Thread(startOfShutdownThread);
                thread.Start();
            }
        }

        private void OptionDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopWav();
        }
    }

    public class LaunchEventArgs : EventArgs
    {
        public string FileName { get; set; }
        public string Arguments { get; set; }
        /// <summary>
        /// If set to true by the event subscriber, the launch will be canceled.
        /// </summary>
        public bool Cancel { get; set; }
    }

}
