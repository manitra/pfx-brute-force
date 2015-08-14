using System.Collections.Generic;
using System.Threading.Tasks;

namespace PfxBruteForce.UI.Generators
{
    public interface IPasswordGenerators
    {
        Task<ICollection<string>> GetBucket(int size);
    }
}