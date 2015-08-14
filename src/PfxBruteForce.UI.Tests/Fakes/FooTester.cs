using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PfxBruteForce.UI.Utils;

namespace PfxBruteForce.UI.Tests.Fakes
{
    public class FooTester : PasswordTester
    {
        public override void Init(string targetPath)
        {
        }

        public override async Task<string> Test(ICollection<string> passwords)
        {
            return passwords.FirstOrDefault(p => p == "foo");
        }
    }
}