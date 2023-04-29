namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VV")]
    public partial class VV
    {
        [Key]
        public int id_V { get; set; }

        [StringLength(500)]
        public string V_v { get; set; }

        [StringLength(500)]
        public string V_descrip { get; set; }

        [StringLength(500)]
        public string V_url { get; set; }

        [StringLength(500)]
        public string v_now { get; set; }

        [StringLength(500)]
        public string date { get; set; }

        [StringLength(500)]
        public string xx1 { get; set; }

        [StringLength(500)]
        public string xx2 { get; set; }
    }
}
