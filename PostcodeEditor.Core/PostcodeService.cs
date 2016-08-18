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
            return _postcodeDbContext.Postcodes;
        }
    }
}