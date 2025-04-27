using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace textile.Models;

public partial class NeondbContext : DbContext
{
    public NeondbContext()
    {
    }

    public NeondbContext(DbContextOptions<NeondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=ep-shy-surf-a4jqpir4-pooler.us-east-1.aws.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_MQ98dlbKxUAY");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Orderdate).HasColumnName("orderdate");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Quantitymeters)
                .HasPrecision(10, 2)
                .HasColumnName("quantitymeters");
            entity.Property(e => e.Totalprice)
                .HasPrecision(12, 2)
                .HasColumnName("totalprice");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("orders_productid_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Productid).HasName("products_pkey");

            entity.ToTable("products");

            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Materialtype)
                .HasMaxLength(50)
                .HasColumnName("materialtype");
            entity.Property(e => e.Pricepermeter)
                .HasPrecision(10, 2)
                .HasColumnName("pricepermeter");
            entity.Property(e => e.Productname)
                .HasMaxLength(100)
                .HasColumnName("productname");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.Supplierid)
                .HasConstraintName("products_supplierid_fkey");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Supplierid).HasName("suppliers_pkey");

            entity.ToTable("suppliers");

            entity.Property(e => e.Supplierid).HasColumnName("supplierid");
            entity.Property(e => e.Contactinfo)
                .HasMaxLength(150)
                .HasColumnName("contactinfo");
            entity.Property(e => e.Suppliername)
                .HasMaxLength(100)
                .HasColumnName("suppliername");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
