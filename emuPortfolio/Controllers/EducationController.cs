using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;
using emuPortfolio.Repositories;

namespace emuPortfolio.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        GenericRepository<TblEducation> repo=new GenericRepository<TblEducation>(){ };
        public ActionResult Index()
        {
            var valuesEducation=repo.List();
            return View(valuesEducation);
        }
        [HttpGet]
        public ActionResult AddNewEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewEducation(TblEducation p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var deleteValue = repo.Find(x=>x.EducationID==id);
            repo.TDelete(deleteValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var t = repo.Find(x => x.EducationID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation p)
        {
            var t = repo.Find(x => x.EducationID == p.EducationID);
            t.Title = p.Title;
            t.Subtitle1 = p.Subtitle1;
            t.Subtitle2 = p.Subtitle2;  
            t.Date = p.Date;
            t.GANO = p.GANO;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}