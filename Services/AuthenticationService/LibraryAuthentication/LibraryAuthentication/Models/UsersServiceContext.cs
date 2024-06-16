﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LibraryAuthentication.Models;

public partial class UsersServiceContext : DbContext
{
    public UsersServiceContext()
    {
    }

    public UsersServiceContext(DbContextOptions<UsersServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detailuser> Detailusers { get; set; }

    public virtual DbSet<PrismaMigration> PrismaMigrations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userpermission> Userpermissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=users_service;user id=root;password=2792001dung", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Detailuser>(entity =>
        {
            entity.HasKey(e => e.IdDetailUsers).HasName("PRIMARY");

            entity
                .ToTable("detailusers")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CodeDetailUsers).HasMaxLength(50);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime(3)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<PrismaMigration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("_prisma_migrations")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .HasColumnName("id");
            entity.Property(e => e.AppliedStepsCount).HasColumnName("applied_steps_count");
            entity.Property(e => e.Checksum)
                .HasMaxLength(64)
                .HasColumnName("checksum");
            entity.Property(e => e.FinishedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("finished_at");
            entity.Property(e => e.Logs)
                .HasColumnType("text")
                .HasColumnName("logs");
            entity.Property(e => e.MigrationName)
                .HasMaxLength(255)
                .HasColumnName("migration_name");
            entity.Property(e => e.RolledBackAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("rolled_back_at");
            entity.Property(e => e.StartedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("started_at");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity
                .ToTable("role")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.CodeRole).HasMaxLength(50);
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime(3)");
            entity.Property(e => e.NameRole).HasMaxLength(150);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUsers).HasName("PRIMARY");

            entity
                .ToTable("users")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.CodeUsers).HasMaxLength(50);
            entity.Property(e => e.DateCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)");
            entity.Property(e => e.DateUpdate).HasColumnType("datetime(3)");
            entity.Property(e => e.Password).HasMaxLength(150);
            entity.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Username).HasMaxLength(150);
        });

        modelBuilder.Entity<Userpermission>(entity =>
        {
            entity.HasKey(e => e.IdUserPermssions).HasName("PRIMARY");

            entity
                .ToTable("userpermissions")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.CodeUserPermssions).HasMaxLength(50);
            entity.Property(e => e.IsCreate)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.IsDelete)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.IsEdit)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.IsRead)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.NameUserPermissions).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
