using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _10170405_王浩丞_摄影测量.UI;

namespace _10170405_王浩丞_摄影测量
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
                 
            Application.Run(new Form1());

            
           
        }
    }
}
