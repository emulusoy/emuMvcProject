using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using emuPortfolio.Models.Entity;

namespace emuPortfolio.Controllers
{
    [AllowAnonymous] /*bu methot butun sayfanin gizli halde olmasini sagladik ama login sayfasi acik kalmali bunu sagliyor*/
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblLogin p)
        {
            emuPortfolioEntities db=new emuPortfolioEntities();
            var value = db.TblLogin.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Username, false);
                Session["UserName"] = value.Username.ToString();
                return RedirectToAction("Index", "About");
            }
            else {
                return RedirectToAction("Index", "Login");
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}