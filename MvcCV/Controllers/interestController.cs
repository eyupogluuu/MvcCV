using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class interestController : Controller
    {
        interestRepository repo = new interestRepository();
        [HttpGet]
        public ActionResult interestList()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult interestAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult interestAdd(interest i)
        {
            repo.Tadd(i);
            return RedirectToAction("interestList");
        }
        public ActionResult interestDelete(int id)
        {
            var sil = repo.Find(x => x.interestID == id);
            repo.Tdelete(sil);
            return RedirectToAction("interestList");
        }
        [HttpGet]
        public ActionResult interestUpdate(int id)
        {
            var gun = repo.Find(x => x.interestID == id);
            return View(gun);
        }

        [HttpPost]
        public ActionResult interestUpdate(interest i)
        {
            var guncel = repo.Find(x => x.interestID == i.interestID);
            guncel.interesetDesc1 = i.interesetDesc1;
            guncel.interesetDesc2 = i.interesetDesc2;
            repo.Tupdate(guncel);
            return RedirectToAction("interestList");
        }
    }
}