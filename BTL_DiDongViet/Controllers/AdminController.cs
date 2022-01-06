using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTL_DiDongViet.Models.Dao;
using BTL_DiDongViet.Models;
using BTL_DiDongViet.Common;

namespace BTL_DiDongViet.Controllers
{
    public class AdminController : Controller
    {
        DBDiDongViet db = new DBDiDongViet();
        // GET: Admin
        public ActionResult Login(LoginClientModel model)
        {
            if(model != null)
            {
                Admin admin = db.Admin.ToList().Find(admin1 => admin1.Username == model.Username);
                if(admin != null)
                {
                    Session[CommonConstants.ADMIN_SESSION] = admin;
                    return RedirectToAction("List", "Users");
                }
                else
                {
                    ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu";
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
    }
}