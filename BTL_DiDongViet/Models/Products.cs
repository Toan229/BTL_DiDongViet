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

        public long ID { get; set; }

        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }

        public long? CategoryID { get; set; }

        [StringLength(50)]
        public string Storage { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Color { get; set; }

        public decimal? Sale { get; set; }

        public long Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Sets { get; set; }

        [StringLength(250)]
        public string Insurance { get; set; }

        public long? NumberOfPurchases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedback { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}
