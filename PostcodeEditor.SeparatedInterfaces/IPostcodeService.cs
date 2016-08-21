using System.Collections.Generic;

namespace PostcodeEditor.SeparatedInterfaces
{
    public interface IPostcodeService
    {
        IEnumerable<IPostcode> Get();

        void Update(IPostcode postcode);
    }
}