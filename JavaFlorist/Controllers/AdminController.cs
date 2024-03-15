using JavaFlorist.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JavaFlorist.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private JavaFloristEntities _db = new JavaFloristEntities();
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Flowers()
        {
            var bouqs = _db.BOUQUETs.ToList();

            return View(bouqs);
        }

        public ActionResult Edit(int id)
        {
            var _bouq = _db.BOUQUETs.Find(id);

            return View(_bouq);
        }
        [HttpPost]
        public ActionResult Update(BOUQUET _bouq)
        {
            var _bou = _db.BOUQUETs.Find(_bouq.BOUQUETID);
            _bou.NAME = _bouq.NAME;
            _bou.PRICE = _bouq.PRICE;
            _bouq.DESCRIPTION = _bouq.DESCRIPTION;
            _db.SaveChanges();
            return RedirectToAction("Flowers");
        }

        public ActionResult Delete(int id)
        {
            var _bouq = _db.BOUQUETs.Find(id);
            _db.BOUQUETs.Remove(_bouq);
            _db.SaveChanges();

            return RedirectToAction("Flowers", "Admin");
        }

        public ActionResult Insert()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Insert(BOUQUET _bouq)
        {
            if (ModelState.IsValid)
            {
                string originalName = Path.GetFileName(_bouq.iqg.FileName);
                string path = Path.Combine(Server.MapPath("../uploads/"), originalName);
                _bouq.iqg.SaveAs(path);

                _bouq.IMG = "../uploads/" + originalName;
                _db.BOUQUETs.Add(_bouq);
                _db.SaveChanges();
                return RedirectToAction("Flowers");
            }

            return View();
        }

    }
}