using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PostcodeEditor.Core;
using PostcodeEditor.Data;
using PostcodeEditor.SeparatedInterfaces;

namespace PostcodeEditor.Web.Controllers
{
    public class PostcodeController : Controller
    {
        private readonly IPostcodeService _postcodeService;

        public PostcodeController(IPostcodeService postcodeService)
        {
            _postcodeService = postcodeService;
        }

        public ActionResult Index()
        {
            IEnumerable<IPostcode> postcodes = _postcodeService.Get().Take(5);

            return View(postcodes);
        }

        public ActionResult List()
        {
            IEnumerable<IPostcode> postcodes = _postcodeService.Get().Skip(5).Take(5);

            return View(postcodes);
        }
    }
}