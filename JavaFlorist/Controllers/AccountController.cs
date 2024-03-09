using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JavaFlorist.Models;
using System.Web.Security;

namespace JavaFlorist.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account

        private JavaFlEntities _db = new JavaFlEntities();
        private Encrypt _enc = new Encrypt();
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(CUSTOMER cust)
        {
            cust.PASSWORD = _enc.EnCrypt(cust.PASSWORD);
            var flag = _db.CUSTOMERs.Where(x => x.PASSWORD == cust.PASSWORD && x.FNAME == cust.FNAME);

            if (flag.Count()>0)
            {
                var user = flag.Single();
                FormsAuthentication.SetAuthCookie(user.FNAME, false);
                TempData["username"] = user.FNAME;
                TempData["id"] = user.CUSTID;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.errorMessage = "invalid credentials";
            }

            return View();
            
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register(CUSTOMER cust)
        {
            if(ModelState.IsValid)
            {
                cust.PASSWORD = _enc.EnCrypt(cust.PASSWORD);
                _db.CUSTOMERs.Add(cust);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View();
        }
    }
}
