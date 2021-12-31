using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_DiDongViet.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        //GET: Details
        public ActionResult Products(int? id)
        {
            return View();
        }
        /*public ActionResult ThemGiohang()
        {
            RedirectToAction("Cart");
            
        }*/
    }
}