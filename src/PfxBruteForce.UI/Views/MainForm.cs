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
using PfxBruteForce.UI.Controllers;
using PfxBruteForce.UI.Controllers.ViewModels;

namespace PfxBruteForce.UI.Views
{
    public partial class MainForm : Form
    {
        private MainController controller;
        private MainFormViewModel model;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(MainController controller)
            : this()
        {
            this.controller = controller;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            model = controller.Init();
            model.PropertyChanged += model_PropertyChanged;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            //we just cancel the initial close request
            //set the cooperative running flag so that workers stop their job
            //schedule a real running in few moment
            if (model.Running)
            {
                controller.Stop();
                e.Cancel = true;
                Task.Factory.FromAsync(
                    Task.Delay(500),
                    r => BeginInvoke(new Action(Close))
                );
            }
        }

        private void go_Click(object sender, EventArgs e)
        {
            if (model.Running)
            {
                controller.Stop();
            }
            else
            {
                worker.RunWorkerAsync();
            }
        }

        private async void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            await controller.Start(
                new MainFormStartParameter
                {
                    DictionaryUrl = dictionaryUrl.Text,
                    MaxLength = (int)maxChar.Value,
                    MinLength = (int)maxChar.Value,
                    TargetPath = certificatePath.Text
                }
            );
        }

        private void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {

                go.Text = model.GoText;
                statusLabel.Text = model.StatusText;
                current.Text = model.CurrentPassword;
                elapsedDurationLabel.Text = model.Elapsed.ToString("mm':'ss");
                checksPerSecondsLabel.Text = model.Speed.ToString("n0");

                if (model.Found)
                {
                    MessageBox.Show("Found : " + model.FoundPassword);
                }
            }));
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            openFile.InitialDirectory = Path.GetDirectoryName(Path.GetFullPath(certificatePath.Text));
            openFile.FileName = Path.GetFileName(certificatePath.Text);
            if (openFile.ShowDialog() == DialogResult.OK)
                certificatePath.Text = openFile.FileName;
        }
    }
}
