using System.Collections.Generic;
using System.Data.Entity;
using PostcodeEditor.Core;
using PostcodeEditor.Data;
using PostcodeEditor.Data.Repositories;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.Web
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
            return Map(_postcodeDbContext.Postcodes);
        }

        private IEnumerable<Core.PostcodeDetails> Map(IEnumerable<Data.PostcodeDetails> postcodes)
        {
            foreach(Data.PostcodeDetails postcode in postcodes)
            {
                yield return new Core.PostcodeDetails
                {
                    Postcode = postcode.Postcode
                };
            }
        }
    }
}