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
    [Authorize]
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
            int userId = (int)TempData["id"];
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

        public ActionResult PlaceOrder(int id, int MesId)
        {
            var carts = _db.CARTs.Where(x => x.CARTID == id).Join(
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
                ).Single();

            CartItems _cr = new CartItems { CARTID = carts.CARTID, IMG = carts.IMG, NAME = carts.NAME, PRICE = carts.PRICE, QUANTITY = carts.QUANTITY };

            //int userId = (int)TempData["id"];
            int userId = 1;

            ViewBag.user = _db.CUSTOMERs.Find(userId);
            ViewBag.mesId = MesId;
            ViewBag.price = _cr.QUANTITY * _cr.PRICE;

            return View(_cr);
        }

        [HttpPost]
        public ActionResult Order(ORDER ord, int id, int MesId)
        {
            int userId = (int)TempData["id"];
            var user = _db.CUSTOMERs.Find(userId);
            var cart = _db.CARTs.Find(id);
            var bouq = _db.BOUQUETs.Find(cart.BOUQUETID);

            ord.CUSTID = userId;
            ord.OCCASIONID = MesId;
            ord.ORDERNAME = bouq.NAME;
            ord.ORDERADDRESS = ord.ORDERADDRESS == null ? user.ADDRESS : ord.ORDERADDRESS;
            ord.ORDERPHONE = ord.ORDERPHONE == null ? user.PNO : ord.ORDERPHONE;
            ord.QUANTITY = cart.QUANTITY;
            ord.TOTALPRICE = cart.QUANTITY * bouq.PRICE;

            _db.ORDERs.Add(ord);
            _db.CARTs.Remove(cart);
            _db.SaveChanges();

            return RedirectToAction("Cart");
        }

        public ActionResult OrderList()
        {
            var orders = _db.ORDERs.ToList();

            TimeSpan ninePM = new TimeSpan(21, 0, 0); // represents 9 PM;

            foreach(var item in orders)
            {
                if(item.ORDERDATE.TimeOfDay > ninePM)
                {
                    item.ORDERDATE.AddDays(1);
                    item.ORDERDATE = new DateTime(item.ORDERDATE.Year, item.ORDERDATE.Month, item.ORDERDATE.Day, 13, 0, 0);
                }
                else
                {
                    item.ORDERDATE = item.ORDERDATE.AddHours(5.0);
                }
            }

            return View(orders);
        }
    }
}