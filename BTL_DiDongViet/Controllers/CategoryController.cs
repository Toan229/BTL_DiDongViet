﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTL_DiDongViet.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Category(Int32? CategoryID)
        {
            if(CategoryID == null)
            {
                
            }
            return View();
        }
        //GET: Details
        public ActionResult Products(int? id)
        {
            return View();
        }
    }
}