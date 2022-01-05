using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_DiDongViet.Models
{
    public class CartViewModel
    {

        public CartViewModel()
        {
            product = new List<Products>();
            order = new List<OrderDetail>();
        }

        public List<Products> product { get; set; }
        public List<OrderDetail> order { get; set; }
    }
}