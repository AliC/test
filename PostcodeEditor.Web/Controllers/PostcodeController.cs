using System;
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
            IEnumerable<IPostcode> postcodes = _postcodeService.Get().Skip(((int)DateTime.Now.Ticks % 300) / 5).Take(5);
            if (Request.IsAjaxRequest())
            {
                return PartialView("list", postcodes);
            }

            return View(postcodes);
        }

    }
}