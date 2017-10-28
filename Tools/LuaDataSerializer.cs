using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class LuaDataSerializer
    {
        private static StringBuilder _StringBuilder;

        public static string Convert(object obj)
        {
            _StringBuilder = new StringBuilder();
            
            _StringBuilder.AppendLine($"[\"{obj.GetType().Name}\"] = {{");
            ConvertObject(obj);
            _StringBuilder.AppendLine("}");

            return _StringBuilder.ToString();
        }

        private static void ConvertObject(object obj)
        {
            if (obj == null)
                return;

            Type myType = obj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime))
                {
                    var propValue = prop.GetValue(obj);
                    _StringBuilder.AppendLine($"[\"{prop.Name}\"]= {ConvertProperty(propValue)},");
                }
                else if (prop.PropertyType.GetInterfaces().Contains(typeof(IEnumerable<>)))
                {
                    _StringBuilder.AppendLine($"[\"{prop.Name}\"]= {{");

                    foreach (var item in (IEnumerable<object>)prop.GetValue(obj, null))
                    {
                        Convert(item);
                    }

                    _StringBuilder.AppendLine("},");
                }
                else
                {
                    var propValue = prop.GetValue(obj);
                    _StringBuilder.AppendLine($"[\"{prop.Name}\"] = {{");
                    ConvertObject(propValue);
                    _StringBuilder.AppendLine("},");
                }
            }
            
        }

        private static string ConvertProperty(object property)
        {
            if (property is bool)
                return ((bool)property) ? "1" : "0";

            if (property is DateTime)
                return ((DateTime)property).ToString("dd.MM.yyyy HH:mm:ss");

            if (property is string)
                return $"\"{property}\"";

            return property?.ToString() ?? "\"\"";
        }
    }
}
