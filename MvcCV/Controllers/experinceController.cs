using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Repositories;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    public class experinceController : Controller
    {
        experinceRepository rep = new experinceRepository();
        public ActionResult expList()
        {
            var values = rep.List();
            return View(values);
        }

        [HttpGet]
        public ActionResult expAdd()
        {
           return View();
        }

        [HttpPost]
        public ActionResult expAdd(experince e)
        {
            rep.Tadd(e);
            return RedirectToAction("expList");
        }

        public ActionResult expDelete(int id)
        {
            experince e = rep.Find(x => x.expID == id);
            rep.Tdelete(e);
            return RedirectToAction("expList");
        }
        [HttpGet]
        public ActionResult experinceUpdate(int id)
        {
            experince e = rep.Find(x => x.expID == id);
            return View(e);
        }

        [HttpPost]
        public ActionResult experinceUpdate(experince p)
        {
            experince e = rep.Find(x => x.expID == p.expID);
            e.company = p.company;
            e.tittle = p.tittle;    
            e.subtittle = p.subtittle;    
            e.date = p.date;
            rep.Tupdate(e);
            return RedirectToAction("expList") ;
        }
    }
}