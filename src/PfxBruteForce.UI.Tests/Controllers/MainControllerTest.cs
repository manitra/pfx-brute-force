using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PfxBruteForce.UI.Controllers;

namespace PfxBruteForce.UI.Tests.Controllers
{
    [TestFixture]
    public class MainControllerTest
    {
        [Test]
        public void Constructing_DoesNotThrow()
        {
            var target = new MainController();
        }

        [Test]
        public void Init_IsNotRunningByDefault()
        {
            var target = new MainController();

            var data = target.Init();

            Assert.IsFalse(data.Running);
        }

        [Test]
        public async void Start_FindTotoPassword()
        {
            var target = new MainController();

            //target.Start(parameters);

            // to test this, i have to
            // - give a real certificate file path
            // - give a real url to an online gzipped compressed text file
            // - i need internet connection to access that file
            // - it will take ages for the method to actually find the password
            Assert.Inconclusive();
        }
    }
}
