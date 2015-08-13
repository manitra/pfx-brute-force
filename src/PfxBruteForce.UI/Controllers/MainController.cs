using System;
using System.Text;
using System.Threading.Tasks;
using PfxBruteForce.UI.Controllers.ViewModels;

namespace PfxBruteForce.UI.Controllers
{
    public class MainController
    {
        int bucketSize = 100;

        private MainFormViewModel model;
        private CompositeGenerator generator;
        private PasswordTester tester;
        private SpeedCalculator speedCalc;

        public MainFormViewModel Init()
        {
            generator = new CompositeGenerator();
            tester = new PasswordTester();
            speedCalc = new SpeedCalculator();

            return model = new MainFormViewModel
                {
                    CurrentPassword = "",
                    Elapsed = TimeSpan.Zero,
                    Running = false,
                    Found = false,
                    FoundPassword = "",
                    Speed = 0,
                };
        }

        public async Task Start(MainFormStartParameter parameters)
        {
            if (model.Running) return;

            model.Running = true;
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
            } while (model.Running);
        }

        public void Stop()
        {
            model.Running = false;
        }
    }
}
