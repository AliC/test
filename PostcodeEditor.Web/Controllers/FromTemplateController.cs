using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostcodeEditor.Web.Controllers
{
    public class FromTemplateController : Controller
    {
        // GET: FromTemplate
        public ActionResult Index()
        {
            return View();
        }

        // GET: FromTemplate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FromTemplate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FromTemplate/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FromTemplate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FromTemplate/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FromTemplate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FromTemplate/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
