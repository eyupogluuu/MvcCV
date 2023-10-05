using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class aboutController : Controller
    {
        aboutRepository repo = new aboutRepository();

        public ActionResult aboutList()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult aboutAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult aboutAdd(about a)
        {
            repo.Tadd(a);
            return RedirectToAction("aboutList");
        }
        public ActionResult abDelete(int id)
        {
            var sil = repo.Find(x => x.aboutID == id);
            repo.Tdelete(sil);
            return RedirectToAction("aboutList");
        }
        [HttpGet]
        public ActionResult abUpdate(int id)
        {
            var guncel = repo.Find(x => x.aboutID == id);
            return View(guncel);
        }

        [HttpPost]
        public ActionResult abUpdate(about a)
        {
            var guncel = repo.Find(x => x.aboutID == a.aboutID);
            guncel.name = a.name;
            guncel.surname = a.surname;
            guncel.adres = a.adres;
            guncel.mail = a.mail;
            guncel.descreption = a.descreption;
            guncel.imageUrl = a.imageUrl;
            repo.Tupdate(guncel);
            return RedirectToAction("aboutList");
        }

    }
}