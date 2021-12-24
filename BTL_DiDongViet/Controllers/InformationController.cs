using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


//Hiển thị thông tin liên hệ, chính sách khách hàng
namespace BTL_DiDongViet.Controllers
{
    public class InformationController : Controller
    {
        // GET: Information
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Policy()
        {
            return View();
        }

        public ActionResult Gioithieu()
        {
            return View();
        }
    }
}