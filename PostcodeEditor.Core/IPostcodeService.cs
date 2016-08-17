using System.Collections.Generic;

namespace PostcodeEditor.Web.Controllers
{
    public interface IPostcodeService
    {
        IEnumerable<Core.PostcodeDetails> Get();
    }
}