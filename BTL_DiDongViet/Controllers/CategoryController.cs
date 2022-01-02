using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_DiDongViet.Models;

namespace BTL_DiDongViet.Controllers
{
    public class CategoryController : Controller
    {
        DBDiDongViet db = new DBDiDongViet();
        // GET: Category
        public ActionResult Home(int? userID)
        {
            userID = 1;
            if(userID != null)
            {
                var user = db.User.Find(userID);
                ViewBag.User = user.Name;
            }
            else
            {
                ViewBag.User = "Đăng nhập";
            }
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Product = db.Products.ToList();
            viewModel.Category = db.ProductCategory.ToList();
            return View(viewModel);
        }

        public ActionResult Category(int? categoryID, string name = "default")
        {
            return View();
        }
    }
}