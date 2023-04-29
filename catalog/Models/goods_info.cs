namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class goods_info
    {
        public int id { get; set; }

        [StringLength(50)]
        public string code { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(150)]
        public string description { get; set; }

        [StringLength(100)]
        public string image_url { get; set; }

        [StringLength(100)]
        public string category { get; set; }

        [StringLength(100)]
        public string state { get; set; }
    }
}
