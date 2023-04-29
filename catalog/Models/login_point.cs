namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class login_point
    {
        public int id { get; set; }

        [StringLength(150)]
        public string username { get; set; }

        [StringLength(150)]
        public string password { get; set; }

        public int? post { get; set; }
    }
}
