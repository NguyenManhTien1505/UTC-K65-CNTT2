using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nmt_231230923_de02.Models;

public partial class NguyenManhTien231230923De02Context : DbContext
{
    public NguyenManhTien231230923De02Context()
    {
    }

    public NguyenManhTien231230923De02Context(DbContextOptions<NguyenManhTien231230923De02Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NmtCatalog> NmtCatalogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-CC95T4S7\\SQLEXPRESS;Database=NguyenManhTien_231230923_de02;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NmtCatalog>(entity =>
        {
            entity.HasKey(e => e.NmtId).HasName("PK__NmtCatal__C8150A2096FAADBD");

            entity.ToTable("NmtCatalog");

            entity.Property(e => e.NmtId).HasColumnName("nmtId");
            entity.Property(e => e.NmtCateActive).HasColumnName("nmtCateActive");
            entity.Property(e => e.NmtCateName)
                .HasMaxLength(100)
                .HasColumnName("nmtCateName");
            entity.Property(e => e.NmtCatePrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("nmtCatePrice");
            entity.Property(e => e.NmtCateQty).HasColumnName("nmtCateQty");
            entity.Property(e => e.NmtPicture)
                .HasMaxLength(255)
                .HasColumnName("nmtPicture");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
