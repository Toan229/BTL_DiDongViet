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
        public long ID { get; set; }

        public long? ProductID { get; set; }

        public long? UserID { get; set; }

        [StringLength(500)]
        public string FBContent { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual Products Products { get; set; }

        public virtual User User { get; set; }
    }
}
