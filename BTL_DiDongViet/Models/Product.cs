namespace BTL_DiDongViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(250)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string Storage { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public decimal? Sale { get; set; }

        public long? Quantity { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Sets { get; set; }

        [StringLength(250)]
        public string Insurance { get; set; }
    }
}
