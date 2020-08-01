using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;

namespace TestAfterFinish
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                if (args[0] == "/lang")
                {
                    try
                    {
                        CultureInfo ci = new CultureInfo(args[1]);
                        System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                        System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message,
                            Application.ProductName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormTest());
        }
    }
}
