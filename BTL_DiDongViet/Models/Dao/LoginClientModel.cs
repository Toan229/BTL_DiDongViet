using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BTL_DiDongViet.Models.Dao
{
    public class LoginClientModel
    {
      //  [Required(ErrorMessage = "Hãy nhập tài khoản")]
        public string Username { set; get; }
     //   [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        public string Password { set; get; }
        // public bool RememberMe { set; get; }
    }
}