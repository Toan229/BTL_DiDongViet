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

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<News> News { get; set; }

        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<User> User { get; set; }

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

            modelBuilder.Entity<News>()
                .Property(e => e.Image)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipPhone)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetail)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.ProductCategory1)
                .WithOptional(e => e.ProductCategory2)
                .HasForeignKey(e => e.ParentID);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Products>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Products>()
                .Property(e => e.Sale)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Feedback)
                .WithOptional(e => e.Products)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Products>()
                .HasMany(e => e.OrderDetail)
                .WithRequired(e => e.Products)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Feedback)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();
        }

        public System.Data.Entity.DbSet<BTL_DiDongViet.Models.Dao.RegisterModel> RegisterModels { get; set; }
    }
}
