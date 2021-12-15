using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTL_DiDongViet.Models
{
    public partial class DBDiDongViet : DbContext
    {
        public DBDiDongViet()
            : base("name=DBDiDongViet")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Admin>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.ProductID)
                .IsFixedLength();

            modelBuilder.Entity<Feedback>()
                .Property(e => e.UserID)
                .IsFixedLength();

            modelBuilder.Entity<News>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<News>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipPhone)
                .IsFixedLength();

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.ProductCategory1)
                .WithOptional(e => e.ProductCategory2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Sale)
                .HasPrecision(18, 0);
        }
    }
}
