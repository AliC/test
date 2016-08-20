using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.MockData
{
    internal class Parsers
    {
        internal static IEnumerable<TInterface> CSVParser<TInterface, T>(string[] lines) where T : TInterface
        {
            PropertyInfo[] properties = typeof(TInterface).GetProperties();
            List<string> headerRow = lines[0].Split(',').ToList();

            IDictionary<string, int> columns = GetColumns(properties, headerRow);

            foreach (string line in lines.Skip(1))
            {
                string[] columnValues = line.Split(',');

                yield return (TInterface)GetPostcode(typeof(T), properties, columns, columnValues);
            }
        }

        private static IDictionary<string, int> GetColumns(PropertyInfo[] properties, List<string> columnNames)
        {
            IDictionary<string, int> columns = new Dictionary<string, int>();

            for (int i = 0; i < properties.Length; i++)
            {
                int index = columnNames.IndexOf(properties[i].Name);
                if (index > -1)
                {
                    columns.Add(columnNames.First(c => c == properties[i].Name), index);
                }
            }

            return columns;
        }

        private static object GetPostcode(Type type, PropertyInfo[] properties, IDictionary<string, int> columns, string[] columnValues)
        {
            object postcode = Activator.CreateInstance(type);

            foreach (PropertyInfo property in properties)
            {
                property.SetValue(postcode, Convert.ChangeType(columnValues[columns[property.Name]], property.PropertyType), null);
            }

            return postcode;
        }
    }
}