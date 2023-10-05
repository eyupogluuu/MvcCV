using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DBCVYapimiEntities c = new DBCVYapimiEntities();
        public ActionResult Index()
        {
            var values = c.about.ToList();
            return PartialView(values);
        }

        public PartialViewResult socialList()
        {
            var values = c.social.Where(x=>x.mediaStatus==true).ToList();
            return PartialView(values);
        }
        public PartialViewResult experinceList()
        {
            var values = c.experince.ToList();
            return PartialView(values);
        }
        public PartialViewResult educationList()
        {
            var values = c.education.ToList();
            return PartialView(values);
        }
        public PartialViewResult skillList()
        {
            var values = c.skill.ToList();
            return PartialView(values);
        }

        public PartialViewResult interestList()
        {
            var values = c.interest.ToList();
            return PartialView(values);
        }
        public PartialViewResult certificateList()
        {
            var values = c.certificate.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult contact()
        {
            
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult contact(contact con)
        {
            con.date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.contact.Add(con);
            c.SaveChanges();
            return PartialView();
        }
    }
}