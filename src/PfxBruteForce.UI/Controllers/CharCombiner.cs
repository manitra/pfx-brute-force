using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PfxBruteForce.UI.Controllers
{
    public class CharCombiner : IPasswordGenerators
    {
        private IList<char> options;
        private int maxLength;
        private IList<int> number;

        public CharCombiner Init(int minLength, int maxLength)
        {
            options = new List<char>();
            for (char i = 'a'; i <= 'z'; i++)
                this.maxLength = maxLength;

            number = new List<int>(maxLength);
            for (int i = 0; i < minLength; i++)
                number.Add(0);

            return this;
        }

        public async Task<ICollection<string>> GetBucket(int size)
        {
            await Task.Yield();

            var result = new List<string>(size);
            while (number.Count <= maxLength && result.Count < size)
            {
                result.Add(Stringify(number, options));

                bool overflowed = true;
                for (int numberPart = number.Count - 1; numberPart >= 0 && overflowed; numberPart--)
                {
                    number[numberPart]++;
                    if (number[numberPart] >= options.Count)
                    {
                        number[numberPart] = number[numberPart] % options.Count;
                    }
                    else
                    {
                        overflowed = false;
                    }
                }
                if (overflowed)
                    number.Insert(0, 0);
            }

            return result;
        }

        private string Stringify(IEnumerable<int> number, IList<char> options)
        {
            return string.Join("", number.Select(n => options[n]));
        }
    }
}