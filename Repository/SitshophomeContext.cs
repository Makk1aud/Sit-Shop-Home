using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public partial class SitshophomeContext : DbContext
{
    public SitshophomeContext()
    {
    }

    public SitshophomeContext(DbContextOptions<SitshophomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productcategory> Productcategories { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=sitshophome;Username=postgres;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("customer_pkey");

            entity.ToTable("customer");

            entity.HasIndex(e => e.CustomerEmail, "customer_customer_email_key").IsUnique();

            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("customer_id");
            entity.Property(e => e.CustomerBirth).HasColumnName("customer_birth");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(50)
                .HasColumnName("customer_email");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(30)
                .HasColumnName("customer_name");
            entity.Property(e => e.CustomerPassword)
                .HasMaxLength(20)
                .HasColumnName("customer_password");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(13)
                .HasColumnName("customer_phone");
            entity.Property(e => e.CustomerSurname)
                .HasMaxLength(30)
                .HasColumnName("customer_surname");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");

            entity.HasOne(d => d.Gender).WithMany(p => p.Customers)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_customer_gender_id");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("gender_pkey");

            entity.ToTable("gender");

            entity.Property(e => e.GenderId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("gender_id");
            entity.Property(e => e.GenderTitle)
                .HasMaxLength(15)
                .HasColumnName("gender_title");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.ProductId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("product_id");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(300)
                .HasColumnName("product_description");
            entity.Property(e => e.ProductDisplay)
                .IsRequired()
                .HasDefaultValueSql("true")
                .HasColumnName("product_display");
            entity.Property(e => e.ProductImage)
                .HasMaxLength(100)
                .HasColumnName("product_image");
            entity.Property(e => e.ProductPrice).HasColumnName("product_price");
            entity.Property(e => e.ProductTitle)
                .HasMaxLength(100)
                .HasColumnName("product_title");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product_productcategory_id");
        });

        modelBuilder.Entity<Productcategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("productcategory_pkey");

            entity.ToTable("productcategory");

            entity.Property(e => e.ProductCategoryId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("product_category_id");
            entity.Property(e => e.CategoryTitle)
                .HasMaxLength(100)
                .HasColumnName("category_title");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("purchase_pkey");

            entity.ToTable("purchase");

            entity.Property(e => e.PurchaseId)
                .HasDefaultValueSql("uuid_generate_v4()")
                .HasColumnName("purchase_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.PurchaseCard)
                .HasMaxLength(16)
                .HasColumnName("purchase_card");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("purchase_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_customer_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_purchase_product_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
