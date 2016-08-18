using System.Collections.Generic;
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
            return View();
        }

        public ActionResult List()
        {
            IEnumerable<IPostcode> postcodes = _postcodeService.Get();

            return View(postcodes);
        }
    }
}