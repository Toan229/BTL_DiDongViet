using BTL_DiDongViet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace BTL_DiDongViet.Models.Dao
{
    public class ProductsDao
    {
        DBDiDongViet db = null;
        public ProductsDao()
        {
            db = new DBDiDongViet();
        }

        public IPagedList<BTL_DiDongViet.ViewModel.Products> GetSearchProducts(int pageNumber, int pageSize, string keyword)
        {
            var model = from a in db.Products
                        join b in db.ProductCategory
                        on a.CategoryID equals b.ID
                        where a.ProductName.Contains(keyword)
                        select new ViewModel.Products()
                        {
                            ID = a.ID,
                            ProductName = a.ProductName,
                            Price = a.Price,
                            Image = a.Image,
                            Url = b.MetaTitle + "/" + a.ID,
                            CategoryName = b.Name,
                            Description = a.Description,
                            
                        };
            model = model.OrderBy(x => x.ID);
            return model.ToPagedList(pageNumber, pageSize);
        }


    }
}