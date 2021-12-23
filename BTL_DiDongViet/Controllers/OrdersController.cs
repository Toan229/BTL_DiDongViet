using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_DiDongViet.Models;

namespace BTL_DiDongViet.Controllers
{
    public class OrdersController : Controller
    {
        private DBDiDongViet db = new DBDiDongViet();

        // GET: Orders
        public ActionResult Index(/*int id*/)
        {
            /*var orders = db.Orders.Include(o => o.ID);
            return View(orders.ToList());*/
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
