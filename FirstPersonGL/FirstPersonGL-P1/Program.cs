using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirstPersonGL
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (MainWindow mw = new MainWindow())
            {
                mw.Run();
            }
        }
    }
}