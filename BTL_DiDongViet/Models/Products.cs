namespace BTL_DiDongViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            Feedback = new HashSet<Feedback>();
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Display(Name = "Mã sản phẩm")]
        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên sản phấm")]

        public string ProductName { get; set; }

        public long? CategoryID { get; set; }

        [StringLength(50)]
        [Display(Name = "Số lượng còn")]

        public string Storage { get; set; }


        [Column(TypeName = "money")]
        [Display(Name = "Giá sản phẩm")]

        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }
        [Display(Name = "Giảm giá")]

        public decimal? Sale { get; set; }
        [Display(Name = "Số lượng")]

        public long Quantity { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ảnh sản phẩm")]

        public string Image { get; set; }

        [StringLength(250)]
        [Display(Name = "Mô tả")]

        public string Description { get; set; }

        [StringLength(250)]
        [Display(Name = "Bộ phụ kiện")]

        public string Sets { get; set; }

        [StringLength(250)]
        [Display(Name = "Bảo hành")]

        public string Insurance { get; set; }
        [Display(Name = "Đã bán")]

        public long? NumberOfPurchases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedback { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
