using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;

namespace PfxBruteForce.UI.Generators
{
    public class DictionaryReader : IPasswordGenerators, IDisposable
    {
        private string url;
        private StreamReader reader;

        public DictionaryReader Init(string url)
        {
            this.url = url;
            return this;
        }

        public async Task<ICollection<string>> GetBucket(int size)
        {
            if (reader == null)
            {
                var response = await WebRequest
                    .Create(url)
                    .GetResponseAsync();

                reader = new StreamReader(
                    new GZipStream(
                        response.GetResponseStream(),
                        CompressionMode.Decompress
                        )
                    );
            }

            var result = new List<string>();
            string row;
            while ((row = await reader.ReadLineAsync()) != null && result.Count < size)
            {
                result.Add(row);
            }

            if (result.Count == 0)
            {
                Dispose();
            }

            return result;
        }

        public void Dispose()
        {
            if (reader == null) return;

            reader.Dispose();
            reader = null;
        }
    }
}