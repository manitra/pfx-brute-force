using System;
using PfxBruteForce.UI.Utils;

namespace PfxBruteForce.UI.Controllers.ViewModels
{
    public class MainFormViewModel : ModelBase
    {
        public string GoText { get { return Get<string>(); } set { Set(value); } }
        public bool Running { get { return Get<bool>(); } set { Set(value); } }
        public bool Found { get { return Get<bool>(); } set { Set(value); } }
        public string FoundPassword { get { return Get<string>(); } set { Set(value); } }
        public TimeSpan Elapsed { get { return Get<TimeSpan>(); } set { Set(value); } }
        public string CurrentPassword { get { return Get<string>(); } set { Set(value); } }
        public int Speed { get { return Get<int>(); } set { Set(value); } }
    }
}
