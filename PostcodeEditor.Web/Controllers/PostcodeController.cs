﻿using System;
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

        public ActionResult Index(int page = 1)
        {
            ViewBag.CurrentPage = page;

            IEnumerable<IPostcode> postcodes = _postcodeService.Get().Skip((page - 1) * 5).Take(5);

            if (Request.IsAjaxRequest())
            {
                return PartialView("list", postcodes);
            }

            return View(postcodes);
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

                return RedirectToAction("Index");
            }

            return PartialView(postcodeDetails);
        }
    }
}