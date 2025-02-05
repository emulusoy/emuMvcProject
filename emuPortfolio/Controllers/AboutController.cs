using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;
using emuPortfolio.Repositories;

namespace emuPortfolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();
        [HttpGet]
        public ActionResult Index()
        {
            var listAbout = repo.List();
            return View(listAbout);
        }
        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            var t = repo.Find(x => x.AboutID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Adress = p.Adress;
            t.Description = p.Description;
            t.Mail = p.Mail;
            t.Phone = p.Phone;
            t.Picture=p.Picture;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}