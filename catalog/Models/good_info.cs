namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sa_pgtab.good_info")]
    public partial class good_info
    {
        [Key]
        [StringLength(100)]
        public string code { get; set; }

        [StringLength(100)]
        public string mn { get; set; }

        [StringLength(100)]
        public string p1 { get; set; }

        [StringLength(100)]
        public string p2 { get; set; }

        [StringLength(100)]
        public string x3 { get; set; }
    }
}
