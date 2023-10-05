using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class contactController : Controller
    {
        contactRepository repo = new contactRepository();
        public ActionResult messageList()
        {
            var values = repo.List();
            return View(values);
        }
    }
}