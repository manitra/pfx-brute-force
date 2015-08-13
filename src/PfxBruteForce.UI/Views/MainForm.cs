using System;
using System.IO.Compression;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PfxBruteForce.UI.Views
{
    public partial class MainForm : Form
    {
        private IList<char> options;
        private Thread worker;
        private bool running = false;

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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            
            //we just cancel the initial running request
            //set the cooperative running flag so that workers stop their job
            //schedule a real running in few moment
            if (running)
            {
                running = false;
                e.Cancel = true;
                Task.Factory.FromAsync(
                    Task.Delay(500),
                    r => BeginInvoke(new Action(Close))
                );
            }
        }

        private async void go_Click(object sender, EventArgs e)
        {
            running = !running;
            go.Text = running ? "Stop" : "Go";
            if (!running) return;

            var start = DateTime.UtcNow;
            long count = 0;
            var speedCalculationStartDate = start;
            var speedCalculationCount = 0;

            var cancelHandle = new CancellationTokenSource();
            var options = new ParallelOptions
                {
                    MaxDegreeOfParallelism = System.Environment.ProcessorCount,
                    CancellationToken = cancelHandle.Token
                };

            try
            {
                Parallel.ForEach(
                    GetAll(),
                    options,
                    password =>
                    {
                        if (count % 10 == 0)
                        {
                            if (running)
                                Invoke(new Action(() =>
                                    {
                                        var now = DateTime.UtcNow;
                                        currentCheckLabel.Text = password;
                                        current.Text = password;
                                        elapsedDurationLabel.Text = (now - start).ToString("mm':'ss");
                                        checksPerSecondsLabel.Text =
                                            (speedCalculationCount /
                                             (now - speedCalculationStartDate).TotalSeconds).ToString("n");
                                        speedCalculationStartDate = now;
                                        speedCalculationCount = 0;
                                    }));
                            Application.DoEvents();
                        }

                        if (TryPassword(password))
                        {
                            if (running)
                                BeginInvoke(new Action(() =>
                                    {
                                        MessageBox.Show("Found : " + password);
                                        current.Text = password;

                                    }));
                        }

                        count++;
                        speedCalculationCount++;

                        if (!running)
                        {
                            options.CancellationToken.ThrowIfCancellationRequested();
                        }
                    }
                    );
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                cancelHandle.Dispose();
            }
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
                while ((row = reader.ReadLine()) != null)
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
