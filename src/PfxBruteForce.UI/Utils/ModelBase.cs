using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PfxBruteForce.UI.Utils
{
    /// <summary>
    /// Most convenient way to have classe with property change notif without any boiler plate
    /// </summary>
    public class ModelBase : INotifyPropertyChanged
    {
        private Dictionary<string, object> fields;

        public ModelBase()
        {
            fields = new Dictionary<string, object>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual T Get<T>([CallerMemberName] string propertyName = "Property")
        {
            return GetOrDefault<T>(propertyName);
        }

        protected bool Set<T>(T value, [CallerMemberName] string propertyName =  "Property")
        {
            var current = GetOrDefault<T>(propertyName);
            if (EqualityComparer<T>.Default.Equals(current, value)) return false;
            fields[propertyName] = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private T GetOrDefault<T>(string propertyName)
        {
            object result;
            fields.TryGetValue(propertyName, out result);
            if (result == null) result = default(T);
            return (T) result;
        }
    }
}
