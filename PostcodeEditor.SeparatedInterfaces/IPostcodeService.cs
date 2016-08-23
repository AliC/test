using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostcodeEditor.SeparatedInterfaces
{
    public interface IPostcodeService
    {
        IEnumerable<IPostcode> Get();

        void Update(IPostcode postcode);

        Task Save(IEnumerable<IPostcode> postcodes);
    }
}