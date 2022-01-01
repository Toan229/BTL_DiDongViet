using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BTL_DiDongViet.Models;
using PagedList;

namespace BTL_DiDongViet.Models.Dao
{
    public class NewsDao
    {
        DBDiDongViet db = null;
        public NewsDao()
        {
            db = new DBDiDongViet();
        }
    }
}