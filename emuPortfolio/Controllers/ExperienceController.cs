using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;
using emuPortfolio.Repositories;

namespace emuPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo=new ExperienceRepository();
        public ActionResult Index()
        {
            var valuesExperience = repo.List();
            return View(valuesExperience);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            TblExperience t = repo.Find(x => x.ExperienceID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetExperience(int id) 
        {
            TblExperience t = repo.Find(x => x.ExperienceID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetExperience(TblExperience p)
        {
            TblExperience t = repo.Find(x => x.ExperienceID == p.ExperienceID);
            t.Title = p.Title;
            t.Subtitle = p.Subtitle;    
            t.Description = p.Description;  
            t.Date = p.Date;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}