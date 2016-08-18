using System.Collections.Generic;

namespace PostcodeEditor.SeparatedInterfaces
{
    public interface IPostcodeService
    {
        IEnumerable<IPostcode> Get();
    }
}