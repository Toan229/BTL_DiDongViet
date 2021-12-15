namespace BTL_DiDongViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(10)]
        public string ProductID { get; set; }

        [StringLength(10)]
        public string UserID { get; set; }

        [StringLength(500)]
        public string FBContent { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
