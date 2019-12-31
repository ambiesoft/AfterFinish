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

        private void button1_Click(object sender, EventArgs e)
        {
            using (Ambiesoft.AfterFinish.OptionDialog dlg = new Ambiesoft.AfterFinish.OptionDialog())
            {
                HashIni ini = Profile.ReadAll(IniPath);
                if (!dlg.LoadValues("AfterFinish", ini))
                {
                    MessageBox.Show("error");
                    return;
                }
                if (DialogResult.OK != dlg.ShowDialog())
                {
                    textBox1.Text = "Canceled";
                    return;
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("{0} => {1}", "chkPlaySound", dlg.chkPlaySound.Checked));

                textBox1.Text = sb.ToString();

                if (!dlg.SaveValues("AfterFinish", ini))
                {
                    MessageBox.Show("error");
                    return;
                }
                if (!Profile.WriteAll(ini, IniPath))
                {
                    MessageBox.Show("error");
                    return;
                }
            }
        }
    }
}
