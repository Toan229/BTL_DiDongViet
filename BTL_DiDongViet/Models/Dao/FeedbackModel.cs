using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTL_DiDongViet.Models.Dao
{
    public class FeedbackModel
    {
        DBDiDongViet db = null;
        public FeedbackModel()
        {
            db = new DBDiDongViet();
        }
        public List<BTL_DiDongViet.ViewModel.Feedback> ListFeedback(int number, long productID)
        {
            var model = from a in db.Feedback
                        join b in db.Products on a.ProductID equals b.ID
                        join c in db.User on a.UserID equals c.ID

                        where a.ProductID == productID

                        select new ViewModel.Feedback() 
                        {
                            ProductID = (long)a.ProductID,
                            UserName = c.Name,
                            FBContent = a.FBContent,
                            CreatedDate = (DateTime)a.CreatedDate,
                        
                        };
            return model.Take(number).ToList();
        }

    }
}