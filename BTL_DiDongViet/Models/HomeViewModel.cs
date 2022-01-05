using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_DiDongViet.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Product = new List<Products>();
            Category = new List<ProductCategory>();
        }
        public List<Products> Product { get; set; }
        public List<ProductCategory> Category { get; set; }
    }
}