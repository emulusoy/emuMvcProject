using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;
using emuPortfolio.Repositories;



namespace emuPortfolio.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills


        SkillsRepository repo = new SkillsRepository();

        public ActionResult Index()
        {
            var valuesSkills= repo.List();
            return View(valuesSkills);
        }
        [HttpGet]
        public ActionResult AddNewSkills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewSkills(TblSkills p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkills(int id)
        {
            TblSkills t = repo.Find(x => x.SkillsID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkills(int id) 
        {
            TblSkills t = repo.Find(x => x.SkillsID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateSkills(TblSkills p)
        {
            TblSkills t = repo.Find(x => x.SkillsID == p.SkillsID);
            t.Title = p.Title;
            t.Ratio = p.Ratio;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}