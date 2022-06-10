using System;
using System.Windows.Forms;

namespace ATEN_Lottery
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ATEN_Lottery_2021());
            //Application.Run(new ATEN_Lottery_Mod());
        }
    }
}
