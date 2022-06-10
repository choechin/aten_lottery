using System;
using System.Windows.Forms;

namespace ATEN_Lottery_Manager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Login login = new Login();
            login.ShowDialog();
            if (login.DialogResult == DialogResult.OK)
            {
                login.Dispose();
                Application.Run(new ATEN_Lottery_Manager());
            }
            else if (login.DialogResult == DialogResult.Cancel)
            {
                login.Dispose();
                return;
            }
        }
    }
}
