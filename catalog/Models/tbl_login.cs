namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_login
    {
        public int id { get; set; }

        [StringLength(500)]
        public string name { get; set; }

        [StringLength(500)]
        public string family { get; set; }

        [StringLength(500)]
        public string user_name { get; set; }

        [StringLength(500)]
        public string password { get; set; }
    }
}
