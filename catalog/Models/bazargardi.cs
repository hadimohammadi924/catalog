namespace catalog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bazargardi")]
    public partial class bazargardi
    {
        [Key]
        public int id_bazargardi { get; set; }

        [StringLength(50)]
        public string btypee { get; set; }

        [StringLength(50)]
        public string bname { get; set; }

        [StringLength(50)]
        public string bsarparast { get; set; }

        [StringLength(50)]
        public string btell { get; set; }

        [StringLength(50)]
        public string brel { get; set; }

        [StringLength(50)]
        public string bgrade { get; set; }

        [StringLength(50)]
        public string bcode { get; set; }

        [StringLength(50)]
        public string bvisitor { get; set; }

        [StringLength(50)]
        public string brannade { get; set; }

        [StringLength(50)]
        public string bsoper { get; set; }

        [StringLength(50)]
        public string brezayatv { get; set; }

        [StringLength(50)]
        public string brezayattoo { get; set; }

        public string bdarkhast { get; set; }

        public string btoosiye { get; set; }

        public string bnazar { get; set; }

        [StringLength(50)]
        public string bsh1 { get; set; }

        [StringLength(50)]
        public string bsh2 { get; set; }

        [StringLength(50)]
        public string bsh3 { get; set; }

        [StringLength(50)]
        public string bkh1 { get; set; }

        [StringLength(50)]
        public string bkh2 { get; set; }

        [StringLength(50)]
        public string bkh3 { get; set; }

        [StringLength(50)]
        public string bshs1 { get; set; }

        [StringLength(50)]
        public string bshs2 { get; set; }

        [StringLength(50)]
        public string bshs3 { get; set; }

        [StringLength(50)]
        public string bk1 { get; set; }

        [StringLength(50)]
        public string bk2 { get; set; }

        [StringLength(50)]
        public string bk3 { get; set; }

        [StringLength(50)]
        public string bshd1 { get; set; }

        [StringLength(50)]
        public string bshd2 { get; set; }

        [StringLength(50)]
        public string bshd3 { get; set; }

        [StringLength(50)]
        public string bma1 { get; set; }

        [StringLength(50)]
        public string bma2 { get; set; }

        [StringLength(50)]
        public string bma3 { get; set; }

        [StringLength(50)]
        public string bp1 { get; set; }

        [StringLength(50)]
        public string bp2 { get; set; }

        [StringLength(50)]
        public string bp3 { get; set; }

        [StringLength(50)]
        public string bdb1 { get; set; }

        [StringLength(50)]
        public string bdb2 { get; set; }

        [StringLength(50)]
        public string bdb3 { get; set; }

        [StringLength(50)]
        public string bdn1 { get; set; }

        [StringLength(50)]
        public string bdn2 { get; set; }

        [StringLength(50)]
        public string bdn3 { get; set; }

        [StringLength(50)]
        public string bab1 { get; set; }

        [StringLength(50)]
        public string bab2 { get; set; }

        [StringLength(50)]
        public string bab3 { get; set; }

        public string bx1 { get; set; }

        public string bx2 { get; set; }

        public string baddress { get; set; }

        [StringLength(50)]
        public string btime { get; set; }

        [StringLength(50)]
        public string bdate { get; set; }

        [StringLength(50)]
        public string byakhurl { get; set; }

        [StringLength(50)]
        public string bun { get; set; }
    }
}
