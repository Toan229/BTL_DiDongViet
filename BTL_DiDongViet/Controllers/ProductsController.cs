using BTL_DiDongViet.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using BTL_DiDongViet.Models.Dao;


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
        public ActionResult Detail(long? id)
        {
            if(id == null)
            {
                return RedirectToAction("Home", "Category");
            }
            else
            {
                long id2 = (long)id;
                var model = db.Products.SingleOrDefault(x => x.ID == id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                FeedbackModel Feedback = new FeedbackModel();
                ViewBag.ListFB = Feedback.ListFeedback(11,id2);
                ViewBag.Lst = db.Products.Where(x => x.ID != id).ToList();
                return View(model);
            }

        }

    }
}