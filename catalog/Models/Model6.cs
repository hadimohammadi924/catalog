namespace catalog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model6 : DbContext
    {
        public Model6()
            : base("name=Model6")
        {
        }

        public virtual DbSet<customer_z> customer_z { get; set; }
        public virtual DbSet<goods_info> goods_info { get; set; }
        public virtual DbSet<login_point> login_point { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tbl_login> tbl_login { get; set; }
        public virtual DbSet<good_info> good_info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<goods_info>()
             .Property(e => e.code)
             .IsUnicode(false);

            modelBuilder.Entity<goods_info>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<goods_info>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<goods_info>()
                .Property(e => e.image_url)
                .IsUnicode(false);

            modelBuilder.Entity<goods_info>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<goods_info>()
                .Property(e => e.state)
                .IsUnicode(false);
        }
    }
}


