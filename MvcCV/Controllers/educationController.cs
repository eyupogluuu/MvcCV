using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class educationController : Controller
    {
        educationRepository repo = new educationRepository();
        [Authorize]
        public ActionResult eduList()
        {
            var values = repo.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult eduAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult eduAdd(education ed)
        {
            if (!ModelState.IsValid)//doğrulama kontrolleri sağlanmadıysa (boş geçilen yanlış girilen alan varsa) gibi kaydetme yapma sayfayı geri döndür
            {
                return View();
            }
            repo.Tadd(ed);
            return RedirectToAction("eduList");
        }
        public ActionResult eduDelete(int id)
        {
            var values = repo.Find(x => x.educationID == id);
            repo.Tdelete(values);
            return RedirectToAction("eduList");
        }
        [HttpGet]
        public ActionResult eduUpdate(int id)
        {
            var values = repo.Find(x => x.educationID == id);
            return View(values);
        }

        [HttpPost]
        public ActionResult eduUpdate(education edu)
        {
            var values = repo.Find(x => x.educationID == edu.educationID);
            values.tittle = edu.tittle;
            values.subtittle = edu.subtittle;
            values.subtittle2 = edu.subtittle2;
            values.gradeavarage = edu.gradeavarage;
            values.date = edu.date;
            repo.Tupdate(values);
            return RedirectToAction("eduList") ;
        }

    }
}