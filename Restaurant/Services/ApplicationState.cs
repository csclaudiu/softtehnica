using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public static class ApplicationState
    {
        private static Dictionary<string, object> _values =
                   new Dictionary<string, object>();

        public static void SetValue(string key, object value)
        {
            _values.Add(key, value);
        }

        public static T GetValue<T>(string key)
        {
            return (T)_values[key];
        }
    }
}
