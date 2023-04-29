namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tiket")]
    public partial class tiket
    {
        [Key]
        public int id_tiket { get; set; }

        [StringLength(50)]
        public string tdate { get; set; }

        [StringLength(50)]
        public string ttime { get; set; }

        [StringLength(500)]
        public string tcategori { get; set; }

        [StringLength(500)]
        public string ttitle { get; set; }

        public string tdescription { get; set; }

        [StringLength(50)]
        public string tbgcode { get; set; }

        [StringLength(500)]
        public string bgname { get; set; }

        [StringLength(50)]
        public string btell { get; set; }

        [StringLength(500)]
        public string tvisitor { get; set; }

        [StringLength(500)]
        public string tresponse { get; set; }

        [StringLength(50)]
        public string trdate { get; set; }

        [StringLength(50)]
        public string trtime { get; set; }

        [StringLength(50)]
        public string truser { get; set; }

        [StringLength(50)]
        public string tstatus { get; set; }

        [StringLength(500)]
        public string x1 { get; set; }

        [StringLength(500)]
        public string x2 { get; set; }

        [StringLength(500)]
        public string x3 { get; set; }

        [StringLength(500)]
        public string x4 { get; set; }
    }
}
