using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_DiDongViet.ViewModel
{
    public class Feedback
    {
   
        public long ID { get; set; }


        public long ProductID { get; set; }
       

        public string UserName { get; set; }
     

        public string FBContent { get; set; }
      
        public DateTime CreatedDate { get; set; }

    }
}