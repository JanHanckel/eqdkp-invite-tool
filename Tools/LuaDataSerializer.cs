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
        private const int _IndentSize = 4;
        private static int _IndentLevel;

        public static string Convert(object obj)
        {
            _StringBuilder = new StringBuilder();
            
            _StringBuilder.AppendLine($"{obj.GetType().Name} = {{");
            _IndentLevel = 1;
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
                    _StringBuilder.AppendLine($"{GetIndent()}[\"{prop.Name}\"]= {ConvertProperty(propValue)},");
                }
                else if (prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var type = prop.GetValue(obj, null).GetType().GetGenericArguments().First().Name;
                    if (type != prop.Name)
                    {
                        _StringBuilder.AppendLine($"{GetIndent()}[\"{prop.Name}\"]= {{");
                        _IndentLevel++;
                    }

                    foreach (var item in (IEnumerable<object>)prop.GetValue(obj, null))
                    {
                        
                            _StringBuilder.AppendLine($"{GetIndent()}[\"{item.GetType().Name}\"] = {{");
                            _IndentLevel++;
                        
                        ConvertObject(item);
                        _IndentLevel--;
                        _StringBuilder.AppendLine($"{GetIndent()}}},");                        
                    }

                    if (type != prop.Name)
                    {
                        _IndentLevel--;
                        _StringBuilder.AppendLine($"{GetIndent()}}},");
                    }
                }
                else
                {
                    var propValue = prop.GetValue(obj);
                    _IndentLevel++;
                    _StringBuilder.AppendLine($"{GetIndent()}[\"{prop.Name}\"] = {{");
                    ConvertObject(propValue);
                    _StringBuilder.AppendLine($"{GetIndent()}}},");
                    _IndentLevel--;
                }
            }

        }

        private static string GetIndent()
        {
            return new string(' ', _IndentLevel * _IndentSize);
        }

        private static string ConvertProperty(object property)
        {
            if (property is bool)
                return ((bool)property) ? "1" : "0";

            if (property is DateTime)
                return $"\"{((DateTime)property).ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss")}\"";

            if (property is string)
                return $"\"{property}\"";

            return property?.ToString() ?? "\"\"";
        }
    }
}
