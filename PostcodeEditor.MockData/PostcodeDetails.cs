using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.MockData
{
    internal class PostcodeDetails : IPostcode
    {
        public string Postcode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string County { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string CountryRegion { get; set; }

    }
}