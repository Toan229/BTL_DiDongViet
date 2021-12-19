﻿using BTL_DiDongViet.Models;
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


namespace BTL_DiDongViet.Controllers
{
    public class UsersController : Controller
    {
        private DBDiDongViet db = new DBDiDongViet();

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

        public ActionResult Register()
        {
            return View();
        }



        // POST: Users/Create
        // Để bảo vệ khỏi overposting attacks, phải chỉ định các thuộc tính cụ thể 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create2([Bind(Include = "Username,Password,Name,Address,Email,Phone")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Status =  false;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = user.ID.ToString();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
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
