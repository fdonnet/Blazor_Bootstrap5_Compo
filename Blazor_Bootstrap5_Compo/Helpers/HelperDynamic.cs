using System.Reflection;

namespace Blazor_Bootstrap5_Compo.Helpers
{
    public static class HelperDynamic<TItem>
    {
        public static string GetPropertyValue(TItem item, string propertyName)
        {
            var prop = GetProperty(propertyName);
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return prop?.GetValue(item) == null ? "" : prop.GetValue(item).ToString();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8603 // Possible null reference return.
        }

        public static void SetPropertyValue(TItem item, string propertyName, string value)
        {
            var prop = GetProperty(propertyName);
            prop?.SetValue(item, value);
        }

        public static bool GetPropertyBoolValue(TItem item, string propertyName)
        {
            var prop = GetProperty(propertyName);
#pragma warning disable CS8605 // Unboxing a possibly null value.
            return (bool)(prop?.GetValue(item) == null ? false : prop.GetValue(item));
#pragma warning restore CS8605 // Unboxing a possibly null value.
        }
        public static void SetPropertyBoolValue(TItem item, string propertyName, bool value)
        {
            var prop = GetProperty(propertyName);
            prop?.SetValue(item, value);
        }

        private static PropertyInfo? GetProperty(string propertyName)
        {
            var type = typeof(TItem);
            return type.GetProperty(propertyName);
        }

    }
}
