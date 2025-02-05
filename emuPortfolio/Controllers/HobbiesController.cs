using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;
using emuPortfolio.Repositories;

namespace emuPortfolio.Controllers
{
    public class HobbiesController : Controller
    {
        // GET: Hobbies
        GenericRepository<TblHobbies> repo=new GenericRepository<TblHobbies>();
        [HttpGet]
        public ActionResult Index()
        {
            var listHobbies = repo.List();
            return View(listHobbies);
        }
        [HttpPost]
        public ActionResult Index(TblHobbies p)
        {
            var t = repo.Find(x => x.HobbiesID == 1);
            t.Description1 = p.Description1;
            t.Description2 = p.Description2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }


    }
}