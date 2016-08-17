using System.Collections.Generic;
using System.Web.Mvc;
using PostcodeEditor.Core;

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
            IEnumerable<PostcodeDetails> postcodes = _postcodeService.Get();

            return View(postcodes);
        }
    }
}