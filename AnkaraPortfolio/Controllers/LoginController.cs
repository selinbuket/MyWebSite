using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AnkaraPortfolio.Models;

namespace AnkaraPortfolio.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login


        DbAnkaraPortfolioEntities db = new DbAnkaraPortfolioEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TblAdmin p)
        {
            var values = db.TblAdmin.FirstOrDefault(x => x.Username == p.Username && x.Password == p.Password);
            // x(database) p=  username input

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["username"] = values.Username;
                return RedirectToAction("SkillList", "Skill");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}