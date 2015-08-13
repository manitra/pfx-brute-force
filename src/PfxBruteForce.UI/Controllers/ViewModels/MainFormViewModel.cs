using System;

namespace PfxBruteForce.UI.Controllers.ViewModels
{
    public class MainFormViewModel
    {
        public bool Running { get; set; }
        public bool Found { get; set; }
        public string FoundPassword { get; set; }
        public TimeSpan Elapsed { get; set; }
        public string CurrentPassword { get; set; }
        public int Speed { get; set; }
    }
}
