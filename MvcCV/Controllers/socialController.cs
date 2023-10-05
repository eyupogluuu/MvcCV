using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;
namespace MvcCV.Controllers
{
    public class socialController : Controller
    {
        GenericRepository<social> repo = new GenericRepository<social>();
        public ActionResult socialList()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult socialAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult socialAdd(social s)
        {
            repo.Tadd(s);
            return RedirectToAction("socialList");
        }
        [HttpGet]
        public ActionResult socialUpdate(int id)
        {
            var guncel = repo.Find(x => x.meidaID == id);
            return View(guncel);
        }
        [HttpPost]
        public ActionResult socialUpdate(social s)
        {
            var guncel = repo.Find(x => x.meidaID == s.meidaID);
            guncel.mediaStatus = true;//güncelleme yaptığımda kendiliğinden listede gözüksün
            guncel.mediaName = s.mediaName;
            guncel.mediaLink = s.mediaLink;
            guncel.mediaIcon = s.mediaIcon;
            repo.Tupdate(guncel);
            return RedirectToAction("socialList");
        }
        public ActionResult socialDelete(int id)
        {
            var sil = repo.Find(x => x.meidaID == id);
            sil.mediaStatus = false;//durumunu false yap listede gösterme
            repo.Tupdate(sil);
            return RedirectToAction("socialList");
        }
    }
}