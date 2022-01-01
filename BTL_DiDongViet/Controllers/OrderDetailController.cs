using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_DiDongViet.Models;

namespace BTL_DiDongViet.Controllers
{
    public class OrderDetailController : Controller
    {
        DBDiDongViet db = new DBDiDongViet();
        //Lấy giỏ hàng
        /*public List<OrderDetail> Laygiohang()
        {
            List<OrderDetail> lstGiohang = Session["Giohang"] as List<OrderDetail>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<OrderDetail>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang ;
        }
        //Thêm hàng vào giỏ
        public ActionResult ThemGiohang( int ID, string strURL)
        {
            List<OrderDetail> lstGiohang = Laygiohang();
            OrderDetail sanpham = lstGiohang.Find(n => n.iProductID == ID);
            if (sanpham == null)
            {
                sanpham = new OrderDetail(ID);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<OrderDetail> lstGiohang = Session["Giohang"] as List<OrderDetail>;
            if (lstGiohang != null)
            {
                iTongSoLuong = lstGiohang.Sum(n => n.iSoluong);
            }
            return iTongSoLuong;
        }
        private decimal Tongtien()
        {
            decimal iTongtien = 0;
            List<OrderDetail> lstGiohang = Session["Giohang"] as List<OrderDetail>;
            if (lstGiohang != null)
            {
                iTongtien = lstGiohang.Sum(n => n.dThanhtien);
            }
            return iTongtien;
        }
        public ActionResult Giohang()
        {
            List<OrderDetail> lstGiohang = Laygiohang();
            if(lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Products");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = Tongtien();
            return View(lstGiohang);
        }
        public ActionResult XoaGiohang(int ProductID)
        {
            List<OrderDetail> lstGiohang = Laygiohang();
            OrderDetail sanpham = lstGiohang.SingleOrDefault(n => n.iProductID == ProductID);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.iProductID == ProductID);
                return RedirectToAction("OrderDetail");
            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Product");
            }
            return RedirectToAction("OrderDetail");
        }
        public ActionResult CapnhatGioang(int ProductID, FormCollection f)
        {
            List<OrderDetail> lstGiohang = Laygiohang();
            OrderDetail sanpham = lstGiohang.SingleOrDefault(n => n.iProductID == ProductID);
            if (sanpham != null)
            {
                sanpham.Quantity = int.Parse(f["txtSoluong"].ToString());

            }
            return RedirectToAction("OrderDetail");
        }*/
        // GET: OrderDetail
        //Trang cart.html

        public CartViewModel layGioHang(int userID)
        {
                var order = db.Order.ToList().Find(o => o.UserID == userID);
           
                List<OrderDetail> orderDetail = db.OrderDetail.ToList().FindAll(o => o.OrderID == order.ID);
                List<Products> productList = new List<Products>();
                foreach (var item in orderDetail)
                {
                    productList.Add(db.Products.Find(item.ProductID));
                }
                CartViewModel viewModel = new CartViewModel();
                viewModel.order = orderDetail;
                viewModel.product = productList;
            return viewModel;
        }

        public ActionResult Cart(int? userID)
        {
            userID = 1;
            if(userID != null)
            {
                Session["userID"] =  userID;
                CartViewModel viewModel =  layGioHang((int)Session["userID"]);
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
            if(Session["userID"] != null)
            {
                if(productID == null || act.Equals("default"))
                {
                    return RedirectToAction("Cart");
                }
                var order = db.Order.ToList().Find(o => o.UserID == (int)Session["userID"]);
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
    }
}