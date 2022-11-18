using AnkaraPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AnkaraPortfolio.Controllers
{
    public class EmployeeLoginController : Controller
    {
        DbAnkaraPortfolioEntities db = new DbAnkaraPortfolioEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TblEmployee p)
        {
            var values = db.TblEmployee.FirstOrDefault(x => x.EmployeeMail == p.EmployeeMail && x.EmployeePassword == p.EmployeePassword);
            // x(database) p=  username input

            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.EmployeeMail, false);
                Session["EmployeeMail"] = values.EmployeeMail;
                return RedirectToAction("Inbox", "Message");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

    }
}