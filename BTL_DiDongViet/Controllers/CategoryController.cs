using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_DiDongViet.Models;
using PagedList;

namespace BTL_DiDongViet.Controllers
{
    public class CategoryController : Controller
    {
        DBDiDongViet db = new DBDiDongViet();
        // GET: Category
        public ActionResult Home(int? userID)
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Product = db.Products.ToList();
            viewModel.Category = db.ProductCategory.ToList();
            return View(viewModel);
        }

        public ActionResult Category(int? categoryID, int? page, string name = "default")
        {
            HomeViewModel viewModel = new HomeViewModel();
            if (categoryID != null)
            {
                var product = db.Products.ToList().FindAll(p => p.CategoryID == categoryID);
                var categoty = db.ProductCategory.Find(categoryID);
                viewModel.Product = product;
                viewModel.Category.Add(categoty);
            }
            else
            {
                if(name.Equals("default"))
                {
                    return View("Home");
                }
                else
                {            
                    var categoty = db.ProductCategory.FirstOrDefault(c => c.Name == name);
                    var product = db.Products.ToList().FindAll(p => p.CategoryID == categoty.ID);
                    viewModel.Product = product;
                    viewModel.Category.Add(categoty);
                }
            }
            return View(viewModel);
        }
    }
}