using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendApi.Models
{
    public partial class Int_shopContext : DbContext
    {
        public Int_shopContext()
        {
        }

        public Int_shopContext(DbContextOptions<Int_shopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Delivery> Deliveries { get; set; } = null!;
        public virtual DbSet<Good> Goods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ShopCart> ShopCarts { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Category__A9FAE80A4C6EFDDC");

                entity.ToTable("Category");

                entity.Property(e => e.CId)
                    .ValueGeneratedNever()
                    .HasColumnName("C_id");

                entity.Property(e => e.CDescr)
                    .HasMaxLength(500)
                    .HasColumnName("C_descr");

                entity.Property(e => e.CName)
                    .HasMaxLength(50)
                    .HasColumnName("C_name");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.HasKey(e => e.DId)
                    .HasName("PK__Delivery__D95F582BDF81E88F");

                entity.ToTable("Delivery");

                entity.Property(e => e.DId)
                    .ValueGeneratedNever()
                    .HasColumnName("d_id");

                entity.Property(e => e.DStatus)
                    .HasMaxLength(50)
                    .HasColumnName("d_status");

                entity.Property(e => e.DUserId).HasColumnName("d_user_id");

                entity.HasOne(d => d.DUser)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.DUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Delivery__d_user__2F10007B");
            });

            modelBuilder.Entity<Good>(entity =>
            {
                entity.HasKey(e => new { e.GProdId, e.GDelivId })
                    .HasName("PK__Goods__BCE8FF34BCD5330D");

                entity.Property(e => e.GProdId).HasColumnName("g_prod_id");

                entity.Property(e => e.GDelivId).HasColumnName("g_deliv_id");

                entity.Property(e => e.GMethod).HasColumnName("g_method");

                entity.HasOne(d => d.GDeliv)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.GDelivId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Goods__g_deliv_i__32E0915F");

                entity.HasOne(d => d.GProd)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.GProdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Goods__g_method__31EC6D26");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PId)
                    .HasName("PK__Product__82E06B91967E9F64");

                entity.ToTable("Product");

                entity.Property(e => e.PId)
                    .ValueGeneratedNever()
                    .HasColumnName("p_id");

                entity.Property(e => e.PAvail).HasColumnName("p_avail");

                entity.Property(e => e.PCategId).HasColumnName("P_categ_id");

                entity.Property(e => e.PName)
                    .HasMaxLength(50)
                    .HasColumnName("p_name");

                entity.HasOne(d => d.PCateg)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.PCategId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__P_categ__286302EC");
            });

            modelBuilder.Entity<ShopCart>(entity =>
            {
                entity.HasKey(e => new { e.SUserId, e.SProductId })
                    .HasName("PK__Shop_car__F9E2B77615B90556");

                entity.ToTable("Shop_cart");

                entity.Property(e => e.SUserId).HasColumnName("S_user_id");

                entity.Property(e => e.SProductId).HasColumnName("S_product_id");

                entity.Property(e => e.SAmountOfProd).HasColumnName("S_amount_of_prod");

                entity.HasOne(d => d.SProduct)
                    .WithMany(p => p.ShopCarts)
                    .HasForeignKey(d => d.SProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shop_cart__S_pro__2C3393D0");

                entity.HasOne(d => d.SUser)
                    .WithMany(p => p.ShopCarts)
                    .HasForeignKey(d => d.SUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shop_cart__S_amo__2B3F6F97");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK___User__5A39651347B16235");

                entity.ToTable("_User");

                entity.Property(e => e.UId).HasColumnName("U_id");

                entity.Property(e => e.ULogin)
                    .HasMaxLength(50)
                    .HasColumnName("U_login");

                entity.Property(e => e.UPassword)
                    .HasMaxLength(50)
                    .HasColumnName("U_password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
