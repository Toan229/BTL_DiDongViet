namespace BTL_DiDongViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
            Orders = new HashSet<Order>();
        }

        public long ID { get; set; }
        [Required(ErrorMessage = "Tài khoản trống")]
        [StringLength(50)]
        [Display(Name = "Tài khoản")]
   
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu trống")]
        [StringLength(32)]
        [Display(Name = "Mật khẩu")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Họ tên trống")]
        [StringLength(50)]
        [Display(Name = "Họ tên")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Địa chỉ trống")]
        [StringLength(250)]
        [Display(Name = "Địa chỉ")]

        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Số điện thoại trống")]
        [StringLength(10)]
        [Display(Name = "Số điện thoại")]

        public string Phone { get; set; }
        [Display(Name = "Tình trạng")]

        public bool Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(250)]
        public string ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }


    }
}
