using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class adminController : Controller
    {
        GenericRepository<login> repo = new GenericRepository<login>();
        DBCVYapimiEntities db = new DBCVYapimiEntities();
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(login lo)
        {
            var giris = db.login.FirstOrDefault(x => x.username == lo.username && x.password == lo.password);
            if (giris!=null)
            {
                FormsAuthentication.SetAuthCookie(giris.username, false);//beni hatırlama
                Session["Kullanici Adi"] = giris.username.ToString();
                return RedirectToAction("expList","experince");
            }
            else
            {
                return RedirectToAction("LogIn", "admin");
            }
           
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LogIn", "admin");
        }
        public ActionResult adminList()
        {
            var values = repo.List();
            return View(values);
        }
        public ActionResult adminDelete(int id)
        {
            var sil = repo.Find(x => x.loginID == id);
            repo.Tdelete(sil);
            return RedirectToAction("adminList");
        }
        [HttpGet]
        public ActionResult adminAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult adminAdd(login l)
        {
            repo.Tadd(l);
            return RedirectToAction("adminList");
        }
        [HttpGet]
        public ActionResult adminUpdate(int id)
        {
            var guncel = repo.Find(x => x.loginID == id);
            return View(guncel);
        }

        [HttpPost]
        public ActionResult adminUpdate(login l)
        {
            var guncel = repo.Find(x => x.loginID == l.loginID);
            guncel.username = l.username;
            guncel.password = l.password;
            repo.Tupdate(guncel);
            return RedirectToAction("adminList");
        }
    }


}