using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;
using emuPortfolio.Repositories;

namespace emuPortfolio.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        GenericRepository<TblLogin> repo=new GenericRepository<TblLogin>();

        public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(TblLogin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmnin(int id)
        {
            TblLogin t = repo.Find(x => x.LoginID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            TblLogin t = repo.Find(x => x.LoginID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(TblLogin p)
        {
            TblLogin t = repo.Find(x => x.LoginID == p.LoginID);
            t.Username = p.Username;
            t.Password = p.Password;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}