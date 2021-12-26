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
    public class FeedbackController : Controller
    {
        public DBDiDongViet db = new DBDiDongViet();
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Display()
        {
            var feedbacks = db.Feedback.Select(x => x);
            feedbacks = feedbacks.OrderBy(x => x.ID);
            return View(feedbacks);
        }

       // [HttpPost]
       // [ValidateAntiForgeryToken]

        /*    public ActionResult Create([Bind(Include = "ID,ProductID,UserID,FBContent,CreatedDate")] FeedbackModel model)
            {

                            var userName = db.Feedback.SingleOrDefault(x => x.Username == model.Username);        
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
                                if (!Char.IsDigit(c))
                                {
                                    throw new Exception("Số điện thoại nhập không đúng định dạng!");
                                    flag = false;
                                }
                            }
                            if (flag)
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









            } */
    }
}