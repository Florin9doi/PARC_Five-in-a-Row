using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;


// 2do: verifica dace serverul e online !!! (linia 32+)
namespace Client
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new step1_con());
        }
    }
}
