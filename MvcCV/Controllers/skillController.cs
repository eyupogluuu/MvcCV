using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class skillController : Controller
    {
        skillRepository repo = new skillRepository();
        public ActionResult skillList()
        {
            var values = repo.List();// repositoryde yaptığımız listeleme işleminin çağırdık
            return View(values);
        }
        
        [HttpGet]
        public ActionResult skillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult skillAdd(skill s)
        {
            repo.Tadd(s);
            return RedirectToAction("skillList");
        }
        public ActionResult skillDelete(int id)
        {
            var values = repo.Find(x => x.skillID == id);
            repo.Tdelete(values);
            return RedirectToAction("skillList");
        }
        [HttpGet]
        public ActionResult skillUpdate(int id)
        {
            skill values = repo.Find(x => x.skillID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult skillUpdate(skill s)
        {
            var values = repo.Find(x => x.skillID == s.skillID);
            values.skillDescreption = s.skillDescreption;
            values.skillRating = s.skillRating;
            repo.Tupdate(values);
            return RedirectToAction("skillList");
        }
    }
}