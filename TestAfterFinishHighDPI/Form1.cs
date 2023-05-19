using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAfterFinishHighDPI
{
    public partial class Form1 : Form
    {
        Ambiesoft.AfterFinish.OptionDialog _option = new Ambiesoft.AfterFinish.OptionDialog(true, true, true, true);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            _option.SetArgMacro("Before", "aaa.mp4");
            _option.SetArgMacro("After", "aaa.mkv");
            _option.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = _option.ExpandMacro();
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            _option.DoNotify();
        }
    }
}
