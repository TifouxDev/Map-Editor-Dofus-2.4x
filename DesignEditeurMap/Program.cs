using DesignEditeurMap.View;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace DesignEditeurMap
{
    static class Program
    {

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
  

            try
            {
                if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\data\init.conf"))
                    Application.Run(new LoadingForm());
                else
                    Application.Run(new NewUI());
            }
            catch(Exception e)
            {
       
            }
          

        }

    }
}
