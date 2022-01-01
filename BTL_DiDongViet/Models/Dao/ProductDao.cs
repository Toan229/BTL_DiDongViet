using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_DiDongViet.Models.Dao
{
    public class ProductDao
    {
        DBDiDongViet db = null;
        public ProductDao()
        {
            db = new DBDiDongViet();
        }
        public Products ViewDetial(long id)
        {
            return db.Products.Find(id);
        }
        public List<Products> ListRelatedProducts(long ID)
        {
            var product = db.Products.Find(ID);
            return db.Products.Where(x => x.ID != ID && x.CategoryID == product.CategoryID).ToList();
        }
    }
}