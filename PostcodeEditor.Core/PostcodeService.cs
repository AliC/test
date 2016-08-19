using System.Collections.Generic;
using System.Data.Entity;
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

        private Core.PostcodeDetails Map(Data.PostcodeDetails postcode)
        {
            return new PostcodeDetails
            {
                Postcode = postcode.Postcode,
                CountryRegion = postcode.CountryRegion
            };
        }
    }
}