using System;
using System.IO.Compression;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        private IList<char> options;
        private Thread worker;

        public MainForm()
        {
            InitializeComponent();

            options = new List<char>();
            for (char i = 'a'; i <= 'z'; i++)
                options.Add(i);
            //for (char i = 'A'; i <= 'Z'; i++)
            //    options.Add(i);
            //for (char i = '0'; i <= '9'; i++)
            //    options.Add(i);
        }

        private void go_Click(object sender, EventArgs e)
        {
            worker = new Thread(() =>
                {

                    long count = 0;
                    var start = DateTime.UtcNow;

                    Parallel.ForEach(
                        GetAll(),
                        new ParallelOptions { MaxDegreeOfParallelism = 8 },
                        password =>
                        {
                            if (count % 10 == 0)
                            {
                                Invoke(new Action(() =>
                                {
                                    toolStripStatusLabel1.Text = "Trying " + password;
                                    var elapsed = DateTime.UtcNow - start;
                                    toolStripStatusLabel2.Text = string.Format(
                                        "{0:n} tests per seconds since {1:t}",
                                        count / elapsed.TotalSeconds, elapsed
                                    );
                                }));
                                Application.DoEvents();
                            }

                            if (TryPassword(password))
                            {
                                BeginInvoke(new Action(() =>
                                {
                                    MessageBox.Show("Found : " + password);
                                    label2.Text = password;

                                }));
                            }

                            count++;
                        }
                    );
                });
            worker.Start();
        }

        private IEnumerable<string> GetAll()
        {
            return EnumerateDictionary(dictionaryUrl.Text)
                .Concat(
                    EnumerateOptions(options, (int)minChar.Value, (int)maxChar.Value)
                );
        }

        private IEnumerable<string> EnumerateDictionary(string url)
        {
            using (var reader = 
                new StreamReader(
                    new GZipStream(
                        WebRequest.Create(url)
                            .GetResponse()
                            .GetResponseStream(), 
                        CompressionMode.Decompress
                    )
                )
            )
            {
                string row;
                while((row = reader.ReadLine()) != null)
                {
                    yield return row;                    
                }
                
            }
        }

        private IEnumerable<string> EnumerateOptions(IList<char> options, int minLength, int maxLength)
        {
            var number = new List<int>(maxLength);
            for (int i = 0; i < minLength; i++)
                number.Add(0);

            while (number.Count <= maxLength)
            {
                yield return Stringify(number, options);

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
        }

        private string Stringify(IList<int> number, IList<char> options)
        {
            return string.Join("", number.Select(n => options[n]));
        }

        private bool TryPassword(string password)
        {
            try
            {
                var collection = new X509Certificate2Collection();
                collection.Import(certificatePath.Text, password, X509KeyStorageFlags.PersistKeySet);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
