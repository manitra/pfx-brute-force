using System;
using System.Text;
using Moq;
using NUnit.Framework;
using PfxBruteForce.UI.Controllers;
using PfxBruteForce.UI.Controllers.ViewModels;
using PfxBruteForce.UI.Generators;
using PfxBruteForce.UI.Tests.Fakes;
using PfxBruteForce.UI.Utils;

namespace PfxBruteForce.UI.Tests.Controllers
{
    [TestFixture]
    public class MainControllerTest
    {
        [Test]
        public void Constructing_DoesNotThrow()
        {
            var target = new MainController(
                Mock.Of<CompositeGenerator>(),
                Mock.Of<PasswordTester>(),
                Mock.Of<SpeedCalculator>()
            );
        }

        [Test]
        public void Init_IsNotRunningByDefault()
        {
            var target = new MainController(
                Mock.Of<CompositeGenerator>(),
                Mock.Of<PasswordTester>(),
                Mock.Of<SpeedCalculator>()
            );

            var data = target.Init();

            Assert.IsFalse(data.Running);
        }

        [Test]
        public async void Start_FooListWithFooTester_Succeeds()
        {
            var target = new MainController(
                new FooGenerator(),
                new FooTester(),
                Mock.Of<SpeedCalculator>()
            );
            var data = target.Init();

            await target.Start(new MainFormStartParameter());

            Assert.IsTrue(data.Found);
            Assert.AreEqual("foo", data.FoundPassword);
        }

        [Test]
        public async void Start_BarListWithFooTester_Fails()
        {
            var target = new MainController(
                new BarGenerator(),
                new FooTester(),
                Mock.Of<SpeedCalculator>()
            );
            var data = target.Init();

            await target.Start(new MainFormStartParameter());

            Assert.IsFalse(data.Found);
            Assert.IsEmpty(data.FoundPassword);
        }

    }
}