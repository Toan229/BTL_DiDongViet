using BTL_DiDongViet.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace BTL_DiDongViet.Controllers
{
    public class ProductsController : Controller
    {

        public DBDiDongViet db = new DBDiDongViet();

        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(long id)
        {
            var model = db.Products.SingleOrDefault(x => x.ID == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lst = db.Products.Where(x => x.ID != id).ToList();
            return View(model);
        }

    }
}