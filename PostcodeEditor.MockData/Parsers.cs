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
            IDictionary<string, int> headerRowIndex = new Dictionary<string, int>();

            string[] headerRow = lines[0].Split(',');
            PropertyInfo[] typeProperties = typeof(T).GetProperties();

            for (int i = 0; i < headerRow.Length; i++)
            {

                if (typeProperties.Any(p => p.Name == headerRow[i]))
                {
                    headerRowIndex.Add(typeProperties.First(p => p.Name == headerRow[i]).Name, i);
                }
            }

            foreach (string line in lines.Skip(1))
            {
                string[] columns = line.Split(',');

                TInterface postcode = (TInterface)Activator.CreateInstance(typeof(T));

                foreach (PropertyInfo property in typeProperties)
                {
                    property.SetValue(postcode, Convert.ChangeType(columns[headerRowIndex[property.Name]], property.PropertyType), null);
                }

                yield return postcode;
            }
        }
   }
}