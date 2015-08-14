using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PfxBruteForce.UI.Controllers.ViewModels;
using PfxBruteForce.UI.Generators;
using PfxBruteForce.UI.Utils;

namespace PfxBruteForce.UI.Controllers
{
    public class MainController
    {
        int bucketSize = 10;

        private MainFormViewModel model;
        private CompositeGenerator generator;
        private PasswordTester tester;
        private SpeedCalculator speedCalc;

        public MainController(CompositeGenerator generator, PasswordTester tester, SpeedCalculator speedCalc)
        {
            this.generator = generator;
            this.tester = tester;
            this.speedCalc = speedCalc;
        }

        public MainFormViewModel Init()
        {
            return model = new MainFormViewModel
                {
                    CurrentPassword = "",
                    Elapsed = TimeSpan.Zero,
                    Running = false,
                    GoText = "Go",
                    Found = false,
                    FoundPassword = "",
                    Speed = 0,
                };
        }

        public async Task Start(MainFormStartParameter parameters)
        {
            if (model.Running) return;

            model.Running = true;
            model.GoText = "Stop";
            model.StatusText = "Running ..";
            model.Found = false;
            model.FoundPassword = "";
            model.Elapsed = TimeSpan.Zero;
            model.Speed = 0;

            generator.Init(parameters.MinLength, parameters.MaxLength, parameters.DictionaryUrl);
            tester.Init(parameters.TargetPath);
            speedCalc.Init();
            do
            {
                var passwords = await generator.GetBucket(bucketSize);
                if (passwords.Count == 0)
                    break;

                var result = await tester.Test(passwords);

                //found password
                if (result != null)
                {
                    model.Running = false;
                    model.Found = true;
                    model.FoundPassword = result;
                }

                //password list exhausted
                if (passwords.Count == 0)
                {
                    model.Running = false;
                    model.Found = false;
                    model.FoundPassword = "";
                }

                speedCalc.Push(passwords.Count);

                model.Speed = speedCalc.Speed;
                model.Elapsed = speedCalc.Elapsed;
                model.CurrentPassword = passwords.FirstOrDefault();
            } while (model.Running);
        }

        public void Stop()
        {
            model.Running = false;
            model.GoText = "Go";
            model.StatusText = "Stopped";
        }
    }
}
