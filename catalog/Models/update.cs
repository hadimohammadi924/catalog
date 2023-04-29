namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("update")]
    public partial class update
    {
        [Key]
        public int id_user { get; set; }

        [StringLength(500)]
        public string username_l { get; set; }

        [StringLength(500)]
        public string last_update { get; set; }

        [StringLength(500)]
        public string xx1 { get; set; }

        [StringLength(500)]
        public string xx2 { get; set; }
    }
}
