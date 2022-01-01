using BTL_DiDongViet.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

//Phần controller tin tức của trang web
namespace BTL_DiDongViet.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public DBDiDongViet db = new DBDiDongViet();
        public ActionResult News()
        {
            return View(db.News.ToList());
        }
        public ActionResult Display(int? page)
        {
            var news = db.News.Select(x => x);
            news = news.OrderBy(x => x.ID);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(news.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Detail(long id)
        {
            var model = db.News.SingleOrDefault(x => x.ID == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lst = db.News.Where(x => x.ID != id).ToList();
            return View(model);
        }

        public ActionResult Policy()
        {
            return View();
        }
        public ActionResult Gioithieu()
        {
            return View();
        }
        public ActionResult Lienhe()
        {
            return View();
        }
    }
}