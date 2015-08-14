using PfxBruteForce.UI.Tests.Controllers;

namespace PfxBruteForce.UI.Tests.Fakes
{
    public class BarGenerator : FooGenerator
    {
        protected override string UniquePassword
        {
            get { return "bar"; }
        }
    }
}