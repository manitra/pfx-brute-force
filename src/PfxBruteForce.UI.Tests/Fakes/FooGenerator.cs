using System.Collections.Generic;
using System.Threading.Tasks;
using PfxBruteForce.UI.Generators;

namespace PfxBruteForce.UI.Tests.Fakes
{
    public class FooGenerator : CompositeGenerator
    {
        private bool firstTime = true;

        protected virtual string UniquePassword { get { return "foo"; } }

        public override CompositeGenerator Init(int minLength, int maxLength, string dictionaryUrl)
        {
            return this;
        }

        public override async Task<ICollection<string>> GetBucket(int size)
        {
            if (firstTime)
            {
                firstTime = false;
                return new[] { "apuo", UniquePassword, "sdpofispdfoi" };

            }
            else
                return new string[0];
        }
    }
}