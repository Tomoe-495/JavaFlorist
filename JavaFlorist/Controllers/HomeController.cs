using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using JavaFlorist.Models;
using Newtonsoft.Json.Linq;

namespace JavaFlorist.Controllers
{
    //[Authorize]
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

        public ActionResult AddCart(int bouqId, int quant)
        {
            int userId = (int)TempData["id"];
            var flag = _db.CARTs.Where(x =>x.CUSTID== userId && x.BOUQUETID==bouqId);

            if (flag.Count()>0)
            {
                CART _cr = flag.Single();
                _cr.QUANTITY ++;
                _db.SaveChanges();
            }
            else
            {
                var cart = new CART() { CUSTID = userId, BOUQUETID = bouqId, QUANTITY = quant };
                _db.CARTs.Add(cart);
                _db.SaveChanges();

            }


            return RedirectToAction("Shop", "Home");
        }

        public ActionResult Cart()
        {
            //int userId = (int)TempData["id"];
            int userId = 2;
            var carts = _db.CARTs.Where(x => x.CUSTID == userId).Join(
                    _db.BOUQUETs,
                    cart => cart.BOUQUETID,
                    bouq => bouq.BOUQUETID,
                    (cart, bouq) => new
                    {
                        CARTID = cart.CARTID,
                        NAME = bouq.NAME,
                        PRICE = bouq.PRICE,
                        IMG = bouq.IMG,
                        QUANTITY = cart.QUANTITY
                    }
                ).ToList();


            List<CartItems> Carts = new List<CartItems>();

            foreach(var item in carts)
            {
                Carts.Add(
                        new CartItems { CARTID = item.CARTID, NAME = item.NAME, IMG = item.IMG, PRICE = item.PRICE, QUANTITY = item.QUANTITY}
                    );
            }

            var _messages = _db.OCCASIONs.ToList();
            ViewBag.messages = _messages;
             return View(Carts);
        }

        public ActionResult DeleteCart(int id)
        {
            CART _cr = _db.CARTs.Find(id);
            _db.CARTs.Remove(_cr);
            _db.SaveChanges();
            return RedirectToAction("Cart");
        }
    }
}