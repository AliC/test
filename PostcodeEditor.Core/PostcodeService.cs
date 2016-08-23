using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task Save(IEnumerable<IPostcode> postcodes)
        {
            IEnumerable<Data.PostcodeDetails> postcodeDetails = Map(postcodes);

            _postcodeDbContext.Postcodes.RemoveRange(_postcodeDbContext.Postcodes);
            _postcodeDbContext.Postcodes.AddRange(postcodeDetails);

            await _postcodeDbContext.SaveChangesAsync();
        }

        private IEnumerable<Data.PostcodeDetails> Map(IEnumerable<IPostcode> postcodes)
        {
            foreach (Core.PostcodeDetails postcode in postcodes)
            {
                yield return Map(postcode);
            }
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

        //private Core.PostcodeDetails Map(IPostcode postcode)
        //{
        //    return new Core.PostcodeDetails
        //    {
        //        Id = postcode.Id,
        //        Postcode = postcode.Postcode,
        //        County = postcode.County,
        //        District = postcode.District,
        //        Latitude = postcode.Latitude,
        //        Longitude = postcode.Longitude,
        //        Region = postcode.Region,
        //        Ward = postcode.Ward
        //    };
        //}
    }
}