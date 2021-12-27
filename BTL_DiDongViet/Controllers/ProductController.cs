using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_DiDongViet.Models.Dao;
using BTL_DiDongViet.Models;
namespace BTL_DiDongViet.Controllers
{
    
    public class ProductController : Controller
    {
        DBDiDongViet db = new DBDiDongViet();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        //GET: Details
        public ActionResult Detail(long? id)
        {
           // if (id != null)
            //{
                var product = db.Products.ToList().Find(t => t.ID == (long) id);
                //ViewBag.RelatedProducts = new ProductDao().ListRelatedProducts((int)id);
                return View(product);
            /*}
            else
            {
                return RedirectToAction("index");
            }*/
        }
        public ActionResult Feedback()
        {
            return View();
        }
    }
}