using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MobileApplication.DbModels;

namespace MobileApplication.Infrastructure.Configuration;

public partial class MobilesDbContext : DbContext
{
    public MobilesDbContext()
    {
    }

    public MobilesDbContext(DbContextOptions<MobilesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MobileInfo> MobileInfos { get; set; }

    public virtual DbSet<MobileSpec> MobileSpecs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ISHAFATIMA\\ISHAFATIMA1907;Database=MobilesDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MobileInfo>(entity =>
        {
            entity.HasKey(e => e.MobileInfoId).HasName("PK__MobileIn__AFE0889AEA3240B7");

            entity.ToTable("MobileInfo");

            entity.Property(e => e.BrandName).HasMaxLength(100);
            entity.Property(e => e.ModelName).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<MobileSpec>(entity =>
        {
            entity.HasKey(e => e.MobileSpecsId).HasName("PK__MobileSp__72ED0D06C4E84F8F");

            entity.Property(e => e.Battery).HasMaxLength(100);
            entity.Property(e => e.Cameras).HasMaxLength(100);
            entity.Property(e => e.ChargingInfo).HasMaxLength(100);
            entity.Property(e => e.Cpu)
                .HasMaxLength(100)
                .HasColumnName("CPU");
            entity.Property(e => e.Ram)
                .HasMaxLength(50)
                .HasColumnName("RAM");
            entity.Property(e => e.Sensors).HasMaxLength(100);
            entity.Property(e => e.Storage).HasMaxLength(50);

            entity.HasOne(d => d.MobileInfo).WithMany(p => p.MobileSpecs)
                .HasForeignKey(d => d.MobileInfoId)
                .HasConstraintName("FK__MobileSpe__Mobil__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
