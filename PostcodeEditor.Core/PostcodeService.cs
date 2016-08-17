using System.Collections.Generic;
using System.Data.Entity;
using PostcodeEditor.Data;
using PostcodeEditor.Data.Repositories;
using PostcodeEditor.Web.Controllers;

namespace PostcodeEditor.Web
{
    public class PostcodeService : IPostcodeService
    {
        private PostcodeDbContext _postcodeDbContext;

        public PostcodeService()
        {
             _postcodeDbContext = new PostcodeDbContext();
        }
        public IEnumerable<Core.PostcodeDetails> Get()
        {
            return Map(_postcodeDbContext.Postcodes);
        }

        private IEnumerable<Core.PostcodeDetails> Map(DbSet<Data.PostcodeDetails> postcodes)
        {
            foreach(PostcodeDetails postcode in postcodes)
            {
                yield return new Core.PostcodeDetails
                {
                    Postcode = postcode.Postcode
                };
            }
        }
    }
}