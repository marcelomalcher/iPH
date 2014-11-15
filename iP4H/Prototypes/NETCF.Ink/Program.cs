using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NETCF.Ink
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new CCXP.Capabilities.CP.Ink.InkFMain());
        }
    }
}