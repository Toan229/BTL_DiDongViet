using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_DiDongViet.Models;
using BTL_DiDongViet.Common;

namespace BTL_DiDongViet.Controllers
{
    public class OrdersController : Controller
    {
        private DBDiDongViet db = new DBDiDongViet();

        // GET: Orders
    
        public ActionResult CartCommit()
        {
            if(Session[CommonConstants.CLIENT_SESSION] != null)
            {
                var user = (UserLogin)Session[CommonConstants.CLIENT_SESSION];
                var order = db.Order.ToList().Find(o => o.UserID ==  user.UserID);
                List<OrderDetail> orderDetail = db.OrderDetail.ToList().FindAll(o => o.OrderID == order.ID);
                double total = 0, sale = 0;
                foreach (var item in orderDetail)
                {
                    var prod = db.Products.Find(item.ProductID);
                    var total1 = prod.Price * item.Quantity;
                    sale += double.Parse((total1*prod.Sale/100).ToString());
                    total  += double.Parse(total1.ToString());
                }
                ViewBag.Total = string.Format("{0:0,0}", total);
                ViewBag.Sale = string.Format("{0:0,0}", sale);
                ViewBag.Final = string.Format("{0:0,0}", total - sale);
                return View(order);
            }
            else
            {
                return RedirectToAction("LoginIndex", "Users");
            }
        }


        public ActionResult Commit(string name, string address, string email, string phone, string note)
        {
            if(Session[CommonConstants.CLIENT_SESSION] != null)
            {
                var user = (UserLogin)Session[CommonConstants.CLIENT_SESSION];
            }
            return RedirectToAction("Home", "Category");
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
