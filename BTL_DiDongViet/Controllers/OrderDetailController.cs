using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_DiDongViet.Models;
using BTL_DiDongViet.Common;

namespace BTL_DiDongViet.Controllers
{
    public class OrderDetailController : Controller
    {
        DBDiDongViet db = new DBDiDongViet();

        public CartViewModel layGioHang(int userID)
        {
                var order = db.Order.ToList().Find(o => o.UserID == userID);
           
                List<OrderDetail> orderDetail = db.OrderDetail.ToList().FindAll(o => o.OrderID == order.ID);
                List<Products> productList = new List<Products>();
                foreach (var item in orderDetail)
                {
                    var prod = db.Products.Find(item.ProductID);
                    productList.Add(prod);
                }
                CartViewModel viewModel = new CartViewModel();
                viewModel.order = orderDetail;
                viewModel.product = productList;
            return viewModel;
        }

        public ActionResult Cart()
        {
            if(Session[CommonConstants.CLIENT_SESSION] != null)
            {
                var user = (UserLogin)Session[CommonConstants.CLIENT_SESSION];
                CartViewModel viewModel =  layGioHang((int)user.UserID);
                return View(viewModel);
            }
            return RedirectToAction("LoginIndex", "Users");
        }
        public ActionResult XoaGiohang(int ProductID)
        {
            var order = db.Order.ToList().Find(o => o.UserID == 1);
            List<OrderDetail> orderDetail = db.OrderDetail.ToList().FindAll(o => o.OrderID == order.ID);
            if (orderDetail != null)
            {
                orderDetail.RemoveAll(n => n.ProductID == ProductID);
                return RedirectToAction("OrderDetail");
            }
            if (orderDetail.Count == 0)
            {
                return RedirectToAction("Index", "Product");
            }
            return RedirectToAction("Cart");
        }

        public ActionResult ChinhSuaSoLuong(int? productID, string act = "default")
        {
            if(Session[CommonConstants.CLIENT_SESSION] != null)
            {
                if(productID == null || act.Equals("default"))
                {
                    return RedirectToAction("Cart");
                }
                var user = (UserLogin)Session[CommonConstants.CLIENT_SESSION];
                var order = db.Order.ToList().Find(o => o.UserID == user.UserID);
                if (act.Equals("add"))
                {
                    db.OrderDetail.ToList().Find(o => o.OrderID == order.ID && o.ProductID == productID).Quantity++;
                }
                else
                {
                    db.OrderDetail.ToList().Find(o => o.OrderID == order.ID && o.ProductID == productID).Quantity--;
                }
                db.SaveChanges();
                return RedirectToAction("Cart");
            }

            return RedirectToAction("LoginIndex", "Users");
        }

        public ActionResult AddProductToCart(int? productID)
        {
            if (Session[CommonConstants.CLIENT_SESSION] != null && productID != null)
            {
                var user = (UserLogin)Session[CommonConstants.CLIENT_SESSION];
                var product = db.Products.ToList().Find(p => p.ID == productID);
                var order = db.Order.ToList().Find(o => o.UserID == user.UserID);
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.ProductID = product.ID;
                orderDetail.OrderID = order.ID;
                orderDetail.Quantity = 1;
                db.OrderDetail.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Detail", "Products", new { id = productID });
            }
            else
            {
                return RedirectToAction("LoginIndex", "Users");
            }
        }
    }
}