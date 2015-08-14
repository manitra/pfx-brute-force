using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PfxBruteForce.UI.Generators
{
    public class CompositeGenerator : IPasswordGenerators
    {
        private ICollection<IPasswordGenerators> children;

        public virtual CompositeGenerator Init(int minLength, int maxLength, string dictionaryUrl)
        {
            this.children = new List<IPasswordGenerators>()
                {
                    new DictionaryReader().Init(dictionaryUrl),
                    new CharCombiner().Init(minLength, maxLength),
                };

            return this;
        }

        public virtual async Task<ICollection<string>> GetBucket(int size)
        {
            var child = children.FirstOrDefault();
            if (child == null)
                return await Task.FromResult<ICollection<string>>(new string[0]);

            var result = await child.GetBucket(size);
            if (result.Count == 0)
                children.Remove(child);

            return result;
        }
    }
}