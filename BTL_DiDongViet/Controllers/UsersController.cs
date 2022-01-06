using BTL_DiDongViet.Models;
using BTL_DiDongViet.Models.Dao;
using BTL_DiDongViet.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace BTL_DiDongViet.Controllers
{
    public class UsersController : Controller
    {
        public DBDiDongViet db = new DBDiDongViet();

        // GET: Users/Create
        // GET: Users1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Password,Name,Address,Email,Phone,Status,CreatedDate,CreateBy,ModifiedDate,ModifiedBy")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(user);
        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Password,Name,Address,Email,Phone,Status,CreatedDate,CreateBy,ModifiedDate,ModifiedBy")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(user);
        }

        // GET: Users1/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult List(string sortOrder, string searchString, string currentFilter,int? page)
        {
            ViewBag.CurentSort = sortOrder;
            ViewBag.XepTheoNgayTao = string.IsNullOrEmpty(sortOrder) ? "ngay_tao_desc" : "";
            ViewBag.XepTheoNgay = sortOrder == "ngay" ? "ngay_desc" : "ngay";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var users = db.User.Select(user => user);
            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Username.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "ngay_tao_desc":
                    users = users.OrderByDescending(s => s.CreatedDate);
                    break;
                case "ngay":
                    users = users.OrderBy(s => s.ModifiedDate);
                    break;
                case "ngay_desc":
                    users = users.OrderByDescending(s => s.ModifiedDate);
                    break;
                default:
                    users = users.OrderBy(s => s.CreatedDate);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult LoginIndex()
        {
            return View();
        }

        public ActionResult Login(LoginClientModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                // var result = dao.Login(model.Username, Encryptor.MD5Hash(model.Password));
                var result = dao.Login(model.Username, model.Password);

                if (result == 1)
                {
                    var user = dao.GetByID(model.Username);
                    var userSession = new UserLogin();
                    userSession.Username = user.Username;
                    userSession.UserID = user.ID;
                    userSession.Name = user.Name;
                    userSession.Phone = user.Phone;
                    userSession.Address = user.Address;
                    userSession.Email = user.Email;
                    Session.Add(CommonConstants.CLIENT_SESSION, userSession);
                    return RedirectToAction("Home", "Category");
                }
                else
                if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản này không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản này đang bị khóa.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai mật khẩu");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập sai.");
                }
            }


            return View("LoginIndex");

        }



        public ActionResult RegisterIndex()
        {
            return View();
        }

        public ActionResult Search(string keyword, int? page)
        {
            ProductsDao productsDao = new ProductsDao();
            var products = db.Products.Where(p => p.ProductName.Contains(keyword));
            products = products.OrderBy(p => p.ID);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            ViewBag.Count = products.Count();
            if (products.Count() < 10)
            {
                ViewBag.Start = pageNumber * 10 - 9;
                ViewBag.End = products.Count();
                return View(productsDao.GetSearchProducts(pageNumber, pageSize, keyword));
            }
            ViewBag.Start = pageNumber * 10 - 9;
            if (pageNumber * 10 > products.Count())
            {
                ViewBag.End = products.Count();
            }
            else
            {
                ViewBag.End = pageNumber * 10;
            }
            return View(productsDao.GetSearchProducts(pageNumber, pageSize, keyword));
        }


        public ActionResult Register([Bind(Include = "ID,Username,Password,Name,Address,Email,Phone,Status,CreatedDate,CreateBy,ModifliedDate,ModifliedBy")] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userName = db.User.SingleOrDefault(x => x.Username == model.Username);
                    if (userName != null)
                    {
                        //ModelState.AddModelError("", "Tài khoản đã tồn tại!");
                        throw new Exception("Tài khoản đã tồn tại!");
                    }
                    else
                    {
                        var user = new User();
                        Random rnd = new Random();
                        //BigInteger num = rnd.Next(1000);

                        user.Username = model.Username;
                        if (model.Password.Length < 6)
                        {
                            throw new Exception("Mật khẩu chưa đủ 6 kí tự!");
                        }
                        else
                        {
                            user.Password = model.Password;
                        }
                        bool flag = true;
                        foreach (char c in model.Phone)
                        {
                            if (!Char.IsDigit(c)) {
                                flag = false;
                                throw new Exception("Số điện thoại nhập không đúng định dạng!");
                            }
                        }
                        if(flag)
                        {
                            user.Phone = model.Phone;
                        }
                        user.Name = model.Name;
                        user.Address = model.Address;
                        user.Email = model.Email;       
                        user.CreatedDate = DateTime.Now;
                        user.CreateBy = model.Name;
                        user.ModifiedDate = DateTime.Now;
                        user.ModifiedBy = model.Name;
                        user.Status = true;
                        db.User.Add(user);
                        db.SaveChanges();
                        model = new RegisterModel();
                        return View("RegisterSuccess");

                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View("RegisterIndex");

                }
            }


            return View("RegisterIndex");

        }
        public ActionResult Logout()
        {
            Session[CommonConstants.CLIENT_SESSION] = null;
            return RedirectToAction("LoginIndex");
        }

    }
}
