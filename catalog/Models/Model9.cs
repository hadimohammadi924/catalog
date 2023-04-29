namespace catalog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model9 : DbContext
    {
        public Model9()
            : base("name=Model9")
        {
        }

        public virtual DbSet<bazargardi> bazargardi { get; set; }
        public virtual DbSet<custdate> custdate { get; set; }
        public virtual DbSet<customer_z> customer_z { get; set; }
        public virtual DbSet<goods_info> goods_info { get; set; }
        public virtual DbSet<login_point> login_point { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_login> tbl_login { get; set; }
        public virtual DbSet<tiket> tiket { get; set; }
        public virtual DbSet<VV> VV { get; set; }
        public virtual DbSet<vy> vy { get; set; }
        public virtual DbSet<update> update { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
