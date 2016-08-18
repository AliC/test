using System.Collections.Generic;
using PostcodeEditor.Data.Repositories;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.MockData
{
    public class PostcodeService : IPostcodeService
    {
        public IEnumerable<IPostcode> Get()
        {
            return null;
        }

        
    }
}