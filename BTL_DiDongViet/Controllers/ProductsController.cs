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
using System.Data;
using System.Data.Entity;
using System.Net;
using PagedList;



namespace BTL_DiDongViet.Controllers
{
    public class ProductsController : Controller
    {

        public DBDiDongViet db = new DBDiDongViet();

        // GET: Products
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

        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurentSort = sortOrder;
            ViewBag.XepTheoTen = string.IsNullOrEmpty(sortOrder) ? "ten_desc" : "";
            ViewBag.XepTheoGia = sortOrder == "gia" ? "gia_desc" : "gia";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var products = db.Products.Include(p => p.ProductCategory);
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(u => u.ProductName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ten_desc":
                    products = products.OrderByDescending(s => s.ProductName);
                    break;
                case "gia":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "gia_desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.ProductName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(products.ToPagedList(pageNumber, pageSize));
        }

        // GET: Products1/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.ProductCategory, "ID", "Name");
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,CategoryID,Storage,Price,Color,Sale,Quantity,Image,Description,Sets,Insurance,NumberOfPurchases")] Products products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    products.Image = "";
                    var f = Request.Files["ImageFile"];
                    if(f != null && f.ContentLength > 0){
                        string filename = System.IO.Path.GetFileName(f.FileName);
                        string uploadPath = Server.MapPath("~/assets/img/ProductsImage" + filename);
                        f.SaveAs(uploadPath);
                        products.Image = filename;
                    }
                    db.Products.Add(products);
                    db.SaveChanges();
                }
                ViewBag.Err = null;
                ViewBag.CategoryID = new SelectList(db.ProductCategory, "ID", "Name", products.CategoryID);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Err = "Lỗi" + e.Message;
                return View(products);
            }
        }

        // GET: Products1/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.ProductCategory, "ID", "Name", products.CategoryID);
            return View(products);
        }

        // POST: Products1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,CategoryID,Storage,Price,Color,Sale,Quantity,Image,Description,Sets,Insurance,NumberOfPurchases")] Products products)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    products.Image = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string filename = System.IO.Path.GetFileName(f.FileName);
                        string uploadPath = Server.MapPath("~/assets/img/ProductsImage" + filename);
                        f.SaveAs(uploadPath);
                        products.Image = filename;
                    }
                    db.Entry(products).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryID = new SelectList(db.ProductCategory, "ID", "Name", products.CategoryID);
                return View("Index");
            }catch(Exception e)
            {
                ViewBag.Err1 = "Lỗi" + e.Message;
                return View(products);
            }

        }

        // GET: Products1/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
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
