namespace BTL_DiDongViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [Key]
        [Required(ErrorMessage = "Trường ID trống")]
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string NewContent { get; set; }

        [StringLength(10)]
        [Display(Name = "Ảnh")]
        public string Image { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }
    }
}
