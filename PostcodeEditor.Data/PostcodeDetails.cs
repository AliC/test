﻿using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.Data
{
    public class PostcodeDetails : IPostcode
    {
        public int Id { get; set; }
        public string Postcode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string County{ get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Region { get; set; }
    }
}

