using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using Municipality_App.Forms.Main;
using Municipality_App.Services;

namespace Municipality_App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize MaterialSkin globally
            MaterialSkinManager.Instance.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.Instance.ColorScheme = new ColorScheme(
                Primary.Blue600,
                Primary.Blue700,
                Primary.Blue500,
                Accent.Blue400,
                TextShade.WHITE
            );

            GamificationService.Initialize();
            Application.Run(new FormMain());
        }
    }
}
