using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_DiDongViet.Models;

namespace BTL_DiDongViet.Models
{
    public class Giohang
    {
        DBDiDongViet db = new DBDiDongViet();
        public int iProductID { get; set; }
        public string sProductName { get; set; }
        public string sColor { get; set; }
        public decimal dPrice { get; set; }
        public string sImage { get; set; }
        public int iSoluong { get; set; }
        public decimal dThanhtien
        {
            get { return iSoluong * dPrice; }
        }
        public Giohang(int ProductID)
        {
            iProductID = ProductID;
            Product sanpham = db.Products.Single(n => n.ID == iProductID);
            sProductName = sanpham.ProductName;
            sColor = sanpham.Color;
            dPrice = sanpham.Price;
            sImage = sanpham.Image;
            iSoluong = 1;
        }
    }
}