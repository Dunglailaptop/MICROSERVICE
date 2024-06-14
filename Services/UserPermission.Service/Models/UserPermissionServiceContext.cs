using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UserPermission.Service.Models;

public partial class UserPermissionServiceContext : DbContext
{
    public UserPermissionServiceContext()
    {
    }

    public UserPermissionServiceContext(DbContextOptions<UserPermissionServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PrismaMigration> PrismaMigrations { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=UserPermission_Service;Username=postgres;Password=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PrismaMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("_prisma_migrations_pkey");

            entity.ToTable("_prisma_migrations");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.AppliedStepsCount)
                .HasDefaultValue(0)
                .HasColumnName("applied_steps_count");
            entity.Property(e => e.Checksum)
                .HasMaxLength(64)
                .HasColumnName("checksum");
            entity.Property(e => e.FinishedAt).HasColumnName("finished_at");
            entity.Property(e => e.Logs).HasColumnName("logs");
            entity.Property(e => e.MigrationName)
                .HasMaxLength(255)
                .HasColumnName("migration_name");
            entity.Property(e => e.RolledBackAt).HasColumnName("rolled_back_at");
            entity.Property(e => e.StartedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("started_at");
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.HasKey(e => e.IdUserPermission).HasName("UserPermission_pkey");

            entity.ToTable("UserPermission");

            entity.Property(e => e.CodeUserPermission).HasMaxLength(50);
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.DateUpdate).HasColumnType("timestamp(3) without time zone");
            entity.Property(e => e.NameRole).HasMaxLength(50);
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
