using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PostcodeEditor.Data;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.MockData
{
    public class PostcodeService : IPostcodeService
    {
        public IEnumerable<IPostcode> Get()
        {
            string[] lines = File.ReadAllLines(Path.GetPathRoot(AppDomain.CurrentDomain.BaseDirectory) + @"\dev\PostcodeEditor\PostcodeEditor.MockData\SampleCSV\postcodes.csv");

            return Parsers.CSVParser<PostcodeDetails>(lines);
        }

        public void Update(IPostcode postcode)
        {
            Parsers.Update<PostcodeDetails>(postcode);
        }
    }
}