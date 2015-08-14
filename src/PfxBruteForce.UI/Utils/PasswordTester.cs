using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PfxBruteForce.UI.Utils
{
    public class PasswordTester
    {
        private byte[] target;

        public virtual void Init(string targetPath)
        {
            target = File.ReadAllBytes(targetPath);
        }

        public virtual async Task<string> Test(ICollection<string> passwords)
        {
            foreach (var password in passwords)
            {
                try
                {
                    await Task.Yield();
                    new X509Certificate2(target, password);
                    return password;
                }
                catch (CryptographicException)
                {
                }
            }

            return null;
        }
    }
}