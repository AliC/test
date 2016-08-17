using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostcodeEditor.Data
{
    public class PostcodeDetails : IPostcode
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public object Latitude { get; set; }
        public object Longitude { get; set; }
        public object County{ get; set; }
        public object District { get; set; }
        public object Ward { get; set; }
        public object CountryRegion { get; set; }
    }
}

