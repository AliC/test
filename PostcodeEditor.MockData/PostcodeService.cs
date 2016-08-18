using System.Collections.Generic;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.MockData
{
    public class PostcodeService : IPostcodeService
    {
        public IEnumerable<IPostcode> Get()
        {
            yield return new PostcodeDetails
            {
                Postcode = "QV1 1IJ",
                CountryRegion = "From Mock Data"
            };
    }


}
}