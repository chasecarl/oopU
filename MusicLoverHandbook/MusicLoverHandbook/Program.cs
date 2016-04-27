using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicLoverHandbook
{
    static class Program
    {
        /// <summary>
        /// Справочник меломана. База групп и исполнителей; база песен; база дисков
        /// с перечнем песен (в виде ссылок). Выбор всех песен заданной группы; всех дисков,
        /// где встречается заданная песня.
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
