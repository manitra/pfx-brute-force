using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PfxBruteForce.UI.Controllers;
using PfxBruteForce.UI.Generators;
using PfxBruteForce.UI.Utils;
using PfxBruteForce.UI.Views;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var generator = new CompositeGenerator();
            var tester = new PasswordTester();
            var speedCalc = new SpeedCalculator();

            var controller = new MainController(generator, tester, speedCalc);
            var form = new MainForm(controller);

            Application.Run(form);
        }
    }
}
