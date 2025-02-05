using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;

namespace emuPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        emuPortfolioEntities data=new emuPortfolioEntities();   
        public ActionResult Index()
        {
            var valuesAbout = data.TblAbout.ToList();
            return View(valuesAbout);
        }
        public PartialViewResult Experience()
        {
            var valuesExperience=data.TblExperience.ToList();
            return PartialView(valuesExperience);
        }
        public PartialViewResult Education()
        {
            var valuesEducation = data.TblEducation.ToList();
            return PartialView(valuesEducation);
        }
        public PartialViewResult Skills()
        {
            var valuesSkills = data.TblSkills.ToList();
            return PartialView(valuesSkills);
        }
        public PartialViewResult Hobbies()
        {
            var valuesHobbies = data.TblHobbies.ToList();
            return PartialView(valuesHobbies);
        }
        public PartialViewResult Certificate()
        {
            var valuesCertificate = data.TblCertificate.ToList();
            return PartialView(valuesCertificate);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            
            return PartialView();
        }
        [HttpPost]//mesaj gondermek icin yaptik!
        public PartialViewResult Contact(TblContact c)
        {
            c.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            data.TblContact.Add(c);
            data.SaveChanges();

            return PartialView();
        }

        public PartialViewResult SocialMedia()
        {
            var valuesSocialMedia = data.TblSocialMedia.ToList();
            return PartialView(valuesSocialMedia);
        }
    }
}