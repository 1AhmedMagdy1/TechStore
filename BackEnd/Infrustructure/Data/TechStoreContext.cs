#nullable disable
using System;
using System.Collections.Generic;
using System.Reflection;
using Core.Models;
using Core.Models.Order;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrustructure.Data
{
    public partial class TechStoreContext : IdentityDbContext<AppUser>
    {
        public TechStoreContext(DbContextOptions<TechStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoty> Categoties { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsPhoto> ProductsPhotos { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<DeliveryMethods> DeliveryMethods { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoty>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Categoty__3214EC0774BC2E0D");

                entity.ToTable("Categoty");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.CreatedDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                // Category 1 -> * Products
                entity.HasMany(e => e.Products)
                      .WithOne(p => p.Category)
                      .HasForeignKey(p => p.CategoryId)
                      .HasConstraintName("FK_Product_Category")
                      .OnDelete(DeleteBehavior.SetNull); // CategoryId is nullable, set to null if category deleted
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Product__3214EC077A56D618");

                entity.ToTable("Product");

                entity.Property(e => e.KeyFeatures)
                    .HasMaxLength(3383)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductDetails)
                    .HasMaxLength(2894)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.Stars).HasColumnType("numeric(3, 1)");

                // Product -> ProductsPhotos relationship is configured below
            });

            modelBuilder.Entity<ProductsPhoto>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Products__3214EC070346FD8E");

                entity.Property(e => e.ImageURL)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                // Product 1 -> * ProductsPhoto
                entity.HasOne(d => d.Product)
                      .WithMany(p => p.ProductsPhotos)
                      .HasForeignKey(d => d.ProductId)
                      .HasConstraintName("FK_ProductsPhotos_Product")
                      .OnDelete(DeleteBehavior.Cascade); // delete photos when product deleted
            });

            OnModelCreatingPartial(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
