using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.Data
{
    public class Parsers
    {
        private static int id;
        private static IList<IPostcode> _postcodes = new List<IPostcode>();

        public static IEnumerable<IPostcode> CSVParser<T>(string[] lines) where T : IPostcode
        {
            if (!_postcodes.Any())
            {
                PropertyInfo[] properties = typeof(IPostcode).GetProperties();
                List<string> headerRow = lines[0].Split(',').ToList();

                IDictionary<string, int> columns = GetColumns(properties, headerRow);

                foreach (string line in lines.Skip(1))
                {
                    string[] columnValues = line.Split(',');

                    _postcodes.Add((IPostcode)GetPostcode(typeof(T), properties, columns, columnValues));
                }
            }

            return _postcodes;
        }

        public static void Update<T>(IPostcode postcode)
        {
            IPostcode updateCandidate = _postcodes.First(p => p.Id == postcode.Id);

            foreach (PropertyInfo property in typeof(IPostcode).GetProperties().Where(p => p.Name != "Id"))
            {
                property.SetValue(updateCandidate, property.GetValue(postcode), null);
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
            
            foreach (PropertyInfo property in properties.Where(p => p.Name != "Id"))
            {
                property.SetValue(postcode, Convert.ChangeType(columnValues[columns[property.Name]], property.PropertyType), null);
            }

            PropertyInfo idProperty = properties.First(p => p.Name == "Id");
            idProperty.SetValue(postcode, Convert.ChangeType(NextId(), idProperty.PropertyType), null);

            return postcode;
        }

        private static int NextId()
        {
            return Interlocked.Increment(ref id);
        }
    }
}