using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minesweeper.UserInterctionLayer.Forms;

namespace Minesweeper
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        //[STAThread]

        static void Main(string[] args)
        {
            Conector.GetSqlConection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormContext(new UsersForm()));
        }
    }
}
