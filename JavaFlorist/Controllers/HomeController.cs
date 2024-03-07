using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using JavaFlorist.Models;

namespace JavaFlorist.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private JavaFlEntities _db = new JavaFlEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop()
        {

            List<BOUQUET> _bouqs = _db.BOUQUETs.ToList();


            return View(_bouqs);
        }

        public ActionResult Product(int id)
        {
            BOUQUET _boug = _db.BOUQUETs.Find(id);
            return View(_boug);
        }
    }
}