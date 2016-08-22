using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PostcodeEditor.Core;
using PostcodeEditor.Data;
using PostcodeEditor.Data.Repositories;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.Core
{
    public class PostcodeService : IPostcodeService
    {
        private PostcodeDbContext _postcodeDbContext;

        public PostcodeService()
        {
             _postcodeDbContext = new PostcodeDbContext();
        }

        public IEnumerable<IPostcode> Get()
        {
            foreach(Data.PostcodeDetails postcode in _postcodeDbContext.Postcodes)
            {
                yield return Map(postcode);
            }
        }

        public void Update(IPostcode postcode)
        {
            Data.PostcodeDetails postcodeDetails = Map(postcode);
            _postcodeDbContext.Postcodes.Attach(postcodeDetails);
            _postcodeDbContext.Entry(postcodeDetails).State = EntityState.Modified;

            _postcodeDbContext.SaveChanges();
        }

        private Data.PostcodeDetails Map(IPostcode postcode)
        {
            return new Data.PostcodeDetails
            {
                Id = postcode.Id,
                Postcode = postcode.Postcode,
                County = postcode.County,
                District = postcode.District,
                Latitude = postcode.Latitude,
                Longitude = postcode.Longitude,
                Region = postcode.Region,
                Ward = postcode.Ward
            };
        }

        private Core.PostcodeDetails Map(Data.PostcodeDetails postcode)
        {
            return new PostcodeDetails
            {
                Id = postcode.Id,
                Postcode = postcode.Postcode,
                County = postcode.County,
                District = postcode.District,
                Latitude = postcode.Latitude,
                Longitude = postcode.Longitude,
                Region = postcode.Region,
                Ward = postcode.Ward
            };
        }
    }
}