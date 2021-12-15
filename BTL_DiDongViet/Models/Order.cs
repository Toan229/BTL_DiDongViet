namespace BTL_DiDongViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [StringLength(10)]
        public string ID { get; set; }

        public long? UserID { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; }

        [StringLength(500)]
        public string ShipAddress { get; set; }

        [StringLength(10)]
        public string ShipPhone { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }
    }
}
