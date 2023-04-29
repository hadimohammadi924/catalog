namespace catalog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model7 : DbContext
    {
        public Model7()
            : base("name=Model7")
        {
        }

        public virtual DbSet<bazargardi> bazargardi { get; set; }
        public virtual DbSet<customer_z> customer_z { get; set; }
        public virtual DbSet<goods_info> goods_info { get; set; }
        public virtual DbSet<login_point> login_point { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_login> tbl_login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
