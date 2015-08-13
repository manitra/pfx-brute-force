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
            controller = new MainController();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            model = controller.Init();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            //we just cancel the initial running request
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

        private async void go_Click(object sender, EventArgs e)
        {
            if (model.Running)
            {
                controller.Stop();
                uiRefreshTimer.Stop();
            }
            else
            {
                worker.RunWorkerAsync();
                uiRefreshTimer.Start();
            }
        }

        private void UpdateUI()
        {
            go.Text = model.Running ? "Stop" : "Go";
            currentCheckLabel.Text =
            current.Text = model.CurrentPassword;
            elapsedDurationLabel.Text = model.Elapsed.ToString("mm':'ss");
            checksPerSecondsLabel.Text = model.Speed.ToString("n");

            if (model.Found)
            {
                MessageBox.Show("Found : " + model.FoundPassword);
            }
        }

        private void uiRefreshTimer_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            controller.Start(
                new MainFormStartParameter
                {
                    DictionaryUrl = dictionaryUrl.Text,
                    MaxLength = (int)maxChar.Value,
                    MinLength = (int)maxChar.Value,
                    TargetPath = certificatePath.Text
                }
            );
        }
    }
}
