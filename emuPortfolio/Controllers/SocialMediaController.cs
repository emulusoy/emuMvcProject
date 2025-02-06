using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;
using emuPortfolio.Repositories;

namespace emuPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<TblSocialMedia> repo= new GenericRepository<TblSocialMedia>();    
        public ActionResult Index()
        {
            var listSocialMedia = repo.List();
            return View(listSocialMedia);
        }
        [HttpGet]
        public ActionResult AddNewSocialMediaIcon()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewSocialMediaIcon(TblSocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMediaIcon(int id) 
        {
            var findId = repo.Find(x => x.SocialMediaID == id);
            return View(findId);
        }
        [HttpPost]
        public ActionResult UpdateSocialMediaIcon(TblSocialMedia p)
        {
            var value = repo.Find(x => x.SocialMediaID == p.SocialMediaID);
            value.Name = p.Name;
            value.Icon = p.Icon;
            value.Link = p.Link;
            repo.TUpdate(value);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMediaIcon(int id)
        {
            var findId = repo.Find(x => x.SocialMediaID == id);
            repo.TDelete(findId);
            return RedirectToAction("Index");
        }
    }
}