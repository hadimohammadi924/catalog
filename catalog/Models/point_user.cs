namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class point_user
    {
        [Key]
        public int id_user { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        [StringLength(500)]
        public string mantage { get; set; }

        [StringLength(500)]
        public string post { get; set; }

        [StringLength(500)]
        public string tell { get; set; }

        [StringLength(500)]
        public string password { get; set; }

        [StringLength(500)]
        public string picurl { get; set; }

        public string token { get; set; }

        [StringLength(500)]
        public string devicename { get; set; }

        [StringLength(500)]
        public string deviceid { get; set; }

        [StringLength(500)]
        public string lastupdate { get; set; }

        [StringLength(500)]
        public string xx1 { get; set; }

        [StringLength(500)]
        public string xx2 { get; set; }

        [StringLength(500)]
        public string xx3 { get; set; }

        [StringLength(500)]
        public string xx4 { get; set; }

        [StringLength(500)]
        public string xx5 { get; set; }
    }
}
