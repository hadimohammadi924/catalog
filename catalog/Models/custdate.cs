namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("custdate")]
    public partial class custdate
    {
        [Key]
        public int data_id { get; set; }

        [StringLength(50)]
        public string pdcode { get; set; }

        [StringLength(500)]
        public string pdname { get; set; }

        public string pddata { get; set; }

        [StringLength(50)]
        public string pddate { get; set; }

        public string pdx1 { get; set; }

        public string pdx2 { get; set; }

        public string pdx3 { get; set; }

        public string pdx4 { get; set; }

        public string pdx5 { get; set; }

        public string pdx6 { get; set; }
    }
}
