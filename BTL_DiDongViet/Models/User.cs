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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được bỏ trống userame")]
        public string Username { get; set; }

        [StringLength(32)]
        [Required(ErrorMessage = "Không được bỏ trống password")]
        public string Password { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Không được bỏ trống tên")]
        public string Name { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        public bool Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(250)]
        public string ModifiedBy { get; set; }
    }
}
