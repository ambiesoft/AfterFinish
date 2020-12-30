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

namespace TestAfterFinish
{
    public partial class FormTest : Form
    {
        Ambiesoft.AfterFinish.OptionDialog afterFinisiDlg_ = new Ambiesoft.AfterFinish.OptionDialog(true, true, true, true);
        public FormTest()
        {
            InitializeComponent();
        }

        string IniPath
        {
            get
            {
                return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),
                    Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".ini");
            }
        }

        bool LoadAfterFinish()
        {
            HashIni ini = Profile.ReadAll(IniPath);
            if (!afterFinisiDlg_.LoadValues("AfterFinish", ini))
            {
                MessageBox.Show("error");
                return false;
            }
            return true;
        }
        bool SaveAfterFinish()
        {
            HashIni ini = Profile.ReadAll(IniPath);
            if (!afterFinisiDlg_.SaveValues("AfterFinish", ini))
            {
                MessageBox.Show("error");
                return false;
            }
            if (!Profile.WriteAll(ini, IniPath))
            {
                MessageBox.Show("error");
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e) 
        {
            if (!LoadAfterFinish())
                return;

            if (DialogResult.OK != afterFinisiDlg_.ShowDialog())
            {
                txtDescription.Text = "Canceled";
                return;
            }

            txtDescription.Text = afterFinisiDlg_.ToDescription();

            SaveAfterFinish();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            if (!LoadAfterFinish())
                return;
            afterFinisiDlg_.DoNotify();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            if(!LoadAfterFinish())
            {
                Close();
                return;
            }
            txtDescription.Text = afterFinisiDlg_.ToDescription();
        }
    }
}
