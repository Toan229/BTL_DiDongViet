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
using System.Diagnostics;
using System.Numerics;

namespace BTL_DiDongViet.Controllers
{
    public class UsersController : Controller
    {
        public DBDiDongViet db = new DBDiDongViet();

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
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
                    return RedirectToRoute("home");
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





        // POST: Users/Create
        // Để bảo vệ khỏi overposting attacks, phải chỉ định các thuộc tính cụ thể 
        [HttpPost]
        [ValidateAntiForgeryToken]
        /*
        public ActionResult Create2([Bind(Include = "Username,Password,Name,Address,Email,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Status = false;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = user.ID.ToString();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        */
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
            return RedirectToRoute("home");
        }



        /*
                // GET: Users
                public ActionResult Index()
                {
                    return View(db.Users.ToList());
                }

                // GET: Users/Details/5
                public ActionResult Details(long? id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    User user = db.Users.Find(id);
                    if (user == null)
                    {
                        return HttpNotFound();
                    }
                    return View(user);
                }

                // GET: Users/Edit/5
                public ActionResult Edit(long? id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    User user = db.Users.Find(id);
                    if (user == null)
                    {
                        return HttpNotFound();
                    }
                    return View(user);
                }

                // POST: Users/Edit/5
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
                        return RedirectToAction("Index");
                    }
                    return View(user);
                }

                // GET: Users/Delete/5
                public ActionResult Delete(long? id)
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    User user = db.Users.Find(id);
                    if (user == null)
                    {
                        return HttpNotFound();
                    }
                    return View(user);
                }

                // POST: Users/Delete/5
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public ActionResult DeleteConfirmed(long id)
                {
                    User user = db.Users.Find(id);
                    db.Users.Remove(user);
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
                }*/
    }
}
