namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vy")]
    public partial class vy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_vy { get; set; }

        [StringLength(500)]
        public string c_code { get; set; }

        [StringLength(500)]
        public string userv { get; set; }

        [StringLength(500)]
        public string url { get; set; }

        [StringLength(500)]
        public string date { get; set; }

        [StringLength(500)]
        public string time { get; set; }

        [StringLength(500)]
        public string x1 { get; set; }

        [StringLength(500)]
        public string x2 { get; set; }

        [StringLength(500)]
        public string x3 { get; set; }
    }
}
