using System.Collections.Generic;
using System.Threading.Tasks;

namespace PfxBruteForce.UI.Controllers
{
    public interface IPasswordGenerators
    {
        Task<ICollection<string>> GetBucket(int size);
    }
}