namespace BTL_DiDongViet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        public bool Type { get; set; }

        public bool Status { get; set; }
    }
}
