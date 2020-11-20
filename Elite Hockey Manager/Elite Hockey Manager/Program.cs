using System;
using System.Windows.Forms;

namespace Elite_Hockey_Manager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HomeForm form = new HomeForm();
            form.ShowDialog();
        }
    }
}