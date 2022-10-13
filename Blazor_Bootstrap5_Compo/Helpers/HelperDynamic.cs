using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Bootstrap5_Compo.Helpers
{
    public static class HelperDynamic<TItem>
    {
        public static string GetPropertyValue(TItem item, string propertyName)
        {
            var prop = GetProperty(propertyName);
            return prop?.GetValue(item) == null ? "" : prop.GetValue(item).ToString();
        }

        public static void SetPropertyValue(TItem item, string propertyName, string value)
        {
            var prop = GetProperty(propertyName);
            prop.SetValue(item, value);
        }

        public static bool GetPropertyBoolValue(TItem item, string propertyName)
        {
            var prop = GetProperty(propertyName);
            return (bool)(prop?.GetValue(item) == null ? false : prop.GetValue(item));
        }
        public static void SetPropertyBoolValue(TItem item, string propertyName, bool value)
        {
            var prop = GetProperty(propertyName);
            prop.SetValue(item, value);
        }

        private static PropertyInfo? GetProperty(string propertyName)
        {
            var type = typeof(TItem);
            return type.GetProperty(propertyName);
        }

    }
}
