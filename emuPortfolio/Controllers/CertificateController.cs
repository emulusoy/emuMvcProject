using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;
using emuPortfolio.Repositories;
namespace emuPortfolio.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate

        GenericRepository<TblCertificate> repo=new GenericRepository<TblCertificate>();
        public ActionResult Index()
        {
            var listCertificate = repo.List();
            return View(listCertificate);
        }
        [HttpGet]
        public ActionResult GetCertificate(int id) 
        {
            var getCertificate = repo.Find(x => x.CertificateID == id);
            ViewBag.bag = id;
            return View(getCertificate);
        }
        [HttpPost]
        public ActionResult GetCertificate(TblCertificate t)
        {
            var getCertificate = repo.Find(x => x.CertificateID == t.CertificateID);
            getCertificate.Description=t.Description;
            getCertificate.Date=t.Date;
            repo.TUpdate(getCertificate);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddNewCertificate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddNewCertificate(TblCertificate t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            var valueCertificate=repo.Find(x => x.CertificateID == id); 
            repo.TDelete(valueCertificate);
            return RedirectToAction("Index");
        }
    }
}