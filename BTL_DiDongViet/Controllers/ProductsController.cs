using BTL_DiDongViet.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using BTL_DiDongViet.Models.Dao;
using BTL_DiDongViet.Common;


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

        public ActionResult AddFeedback(string id, string feedback)
        {
            var user = (UserLogin)Session[CommonConstants.CLIENT_SESSION];
            if (user != null || id == null || feedback != null)
            {
                DateTime dateTime = DateTime.Now;
                Feedback feedback1 = new Feedback();
                feedback1.ProductID = int.Parse(id);
                feedback1.UserID = user.UserID;
                feedback1.FBContent = feedback;
                feedback1.CreatedDate = dateTime;
                db.Feedback.Add(feedback1);
                db.SaveChanges();
                return RedirectToAction("Detail", "Products", new { id = id });
            }
            else
            {
                return RedirectToAction("Home", "Category");
            }

        }

    }
}