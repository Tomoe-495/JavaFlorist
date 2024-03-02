using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JavaFlorist.Models;

namespace JavaFlorist.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private JavaFloristEntities _db = new JavaFloristEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Shop()
        {

            List<BOUQUET> _bouqs = _db.BOUQUETs.ToList();


            return View(_bouqs);
        }
    }
}