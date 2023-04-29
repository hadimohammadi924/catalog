namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customer_z
    {
        public int id { get; set; }

        [StringLength(150)]
        public string type { get; set; }

        [StringLength(150)]
        public string cust { get; set; }

        [StringLength(150)]
        public string power { get; set; }

        [StringLength(150)]
        public string name { get; set; }

        [StringLength(150)]
        public string tell1 { get; set; }

        [StringLength(150)]
        public string mobile { get; set; }

        [StringLength(150)]
        public string address { get; set; }

        [StringLength(150)]
        public string typeRel { get; set; }

        [StringLength(150)]
        public string pgcode { get; set; }

        [StringLength(150)]
        public string picURL { get; set; }

        [StringLength(150)]
        public string x1 { get; set; }

        [StringLength(150)]
        public string x2 { get; set; }

        [StringLength(150)]
        public string date { get; set; }

        [StringLength(150)]
        public string time { get; set; }

        [StringLength(150)]
        public string un { get; set; }
    }
}
