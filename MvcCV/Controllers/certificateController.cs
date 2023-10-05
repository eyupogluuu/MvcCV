using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class certificateController : Controller
    {
        certificateRepository repo = new certificateRepository();
        public ActionResult certificateList()
        {
            var values = repo.List();
            return View(values) ;
        }

        [HttpGet]
        public ActionResult certificateAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult certificateAdd(certificate cer)
        {
            repo.Tadd(cer);
            return RedirectToAction("certificateList");
        }
        public ActionResult cerDelete(int id)
        {
            var values = repo.Find(x => x.certificateID == id);
            repo.Tdelete(values);
            return RedirectToAction("certificateList");
        }

        [HttpGet]
        public ActionResult cerUpdate(int id)
        {
            var values = repo.Find(x => x.certificateID == id);
            ViewBag.d = id;
            return View(values);
        }
        [HttpPost]
        public ActionResult cerUpdate(certificate cer)
        {
            var values = repo.Find(x => x.certificateID == cer.certificateID);
            values.date = cer.date;
            values.descreption = cer.descreption;
            repo.Tupdate(values);
            return RedirectToAction("certificateList");
        }
    }
}