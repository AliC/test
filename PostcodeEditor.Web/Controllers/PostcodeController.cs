using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public ActionResult Index(int page = 1)
        {
            ViewBag.CurrentPage = page;

            IList<IPostcode> postcodes = _postcodeService.Get().ToList();
            ViewBag.TotalPostcodes = postcodes.Count;
            ViewBag.TotalPages = (int)Math.Ceiling(postcodes.Count / 5m);

            IEnumerable<IPostcode> pagedPostcodes = postcodes.Skip((page - 1) * 5).Take(5);

            if (Request.IsAjaxRequest())
            {
                return PartialView("list", pagedPostcodes);
            }

            return View(pagedPostcodes);
        }

        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                IEnumerable<IPostcode> postcodes = Parsers.CSVParser<Core.PostcodeDetails>(file.InputStream);

                await _postcodeService.Save(postcodes);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IPostcode postcodeToEdit = _postcodeService.Get().First(p => p.Id == id);

            return PartialView(postcodeToEdit);
        }

        [HttpPost]
        public ActionResult Edit(Core.PostcodeDetails postcodeDetails)
        {
            if (ModelState.IsValid)
            {
                _postcodeService.Update(postcodeDetails);

                return RedirectToAction("Index", new { page = 6 });
            }

            return PartialView(postcodeDetails);
        }

        private async Task<string> GetFileContents(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);

            return await reader.ReadToEndAsync();
        }

    }
}