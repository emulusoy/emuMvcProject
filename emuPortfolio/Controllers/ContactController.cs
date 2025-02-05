using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emuPortfolio.Models.Entity;
using emuPortfolio.Repositories;

namespace emuPortfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<TblContact> repo=new GenericRepository<TblContact>();
        public ActionResult Index()
        {
            var listContact = repo.List();
            return View(listContact);
        }
    }
}