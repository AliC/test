using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.MockData
{
    public class PostcodeService : IPostcodeService
    {
        public IEnumerable<IPostcode> Get()
        {
            string[] lines = File.ReadAllLines(@"C:\dev\PostcodeEditor\PostcodeEditor.MockData\SampleCSV\postcodes.csv");
            IEnumerable<IPostcode> postcodes = Parse(lines);

            return postcodes;
        }

        private IEnumerable<IPostcode> Parse(string[] lines)
        {
            string[] headerRow = lines[0].Split(',');
            IDictionary<string, int> index = new Dictionary<string, int>();

            for(int i = 0; i < headerRow.Length; i++)
            {
                if (headerRow[i] == "Postcode")
                {
                    index.Add("Postcode", i);
                }
                
                //Note ADC: no CountryRegion header in sample csv file, so using Region instead
                if (headerRow[i] == "Region")
                {
                    index.Add("Region", i);
                }
            }

            foreach (string line in lines.Skip(1))
            {
                string[] columns = line.Split(',');

                yield return new PostcodeDetails
                {
                    Postcode = columns[index["Postcode"]],
                    CountryRegion = columns[index["Region"]],
                };
            }
        }
    }
}