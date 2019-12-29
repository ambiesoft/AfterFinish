using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Ambiesoft;

namespace Ambiesoft.AfterFinish
{
    public partial class OptionDialog : Form
    {
        static readonly string KEY_chkShowMessage = "chkShowMessage";
        static readonly string KEY_chkPlaySound = "chkPlaySound";
        static readonly string KEY_chkLaunchApp = "chkLaunchApp";
        static readonly string KEY_txtApp = "txtApp";
        static readonly string KEY_txtArg = "txtArg";
        public OptionDialog()
        {
            InitializeComponent();

            updateState();
        }

        private void updateState()
        {
            txtApp.Enabled = txtArg.Enabled = btnBrowseApp.Enabled = chkLaunchApp.Checked;
        }
        private void chkLaunchApp_CheckedChanged(object sender, EventArgs e)
        {
            updateState();
        }

        public bool LoadValues(string section, HashIni ini)
        {
            bool b;
            string s;
           
            if(Profile.GetBool(section, KEY_chkShowMessage, false, out b, ini))
                chkShowMessage.Checked = b;
            if(Profile.GetBool(section, KEY_chkPlaySound, false, out b, ini))
                chkPlaySound.Checked = b;
            if(Profile.GetBool(section, KEY_chkLaunchApp, false, out b, ini))
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
            ok &= Profile.WriteBool(section, KEY_chkShowMessage, chkShowMessage.Checked, ini);
            ok &= Profile.WriteBool(section, KEY_chkPlaySound, chkPlaySound.Checked, ini);
            ok &= Profile.WriteBool(section, KEY_chkLaunchApp, chkLaunchApp.Checked, ini);

            ok &= Profile.WriteString(section, KEY_txtApp, txtApp.Text, ini);
            ok &= Profile.WriteString(section, KEY_txtArg, txtArg.Text, ini);

            return ok;
        }

        private void btnBrowseApp_Click(object sender, EventArgs e)
        {

        }
    }
}
