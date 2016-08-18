using PostcodeEditor.Data;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.Core
{
    public class PostcodeDetails : IPostcode
    {
        public string Postcode { get; set; }
        public object Latitude { get; set; }
        public object Longitude { get; set; }
        public object County { get; set; }
        public object District { get; set; }
        public object Ward { get; set; }
        public object CountryRegion { get; set; }
    }
}
