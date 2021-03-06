﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpeccomDB.Models
{
    public partial class speccomContext : DbContext
    {
        public virtual DbSet<Computer> Computer { get; set; }
        public virtual DbSet<ComputerUser> ComputerUser { get; set; }
        public virtual DbSet<DiskDrive> DiskDrive { get; set; }
        public virtual DbSet<GraphicCard> GraphicCard { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Memory> Memory { get; set; }
        public virtual DbSet<User> User { get; set; }

        public speccomContext(DbContextOptions<speccomContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer>(entity =>
            {
                entity.HasKey(e => e.Uuid);

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cpuname)
                    .HasColumnName("CPUName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ComputerUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Uuid });

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Uuid)
                    .HasColumnName("UUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ComputerUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComputerUser_User");

                entity.HasOne(d => d.Uu)
                    .WithMany(p => p.ComputerUser)
                    .HasForeignKey(d => d.Uuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComputerUser_Computer");
            });

            modelBuilder.Entity<DiskDrive>(entity =>
            {
                entity.Property(e => e.DiskDriveId).HasColumnName("DiskDriveID");

                entity.Property(e => e.Caption)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasColumnName("UUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Uu)
                    .WithMany(p => p.DiskDrive)
                    .HasForeignKey(d => d.Uuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DiskDrive_Computer");
            });

            modelBuilder.Entity<GraphicCard>(entity =>
            {
                entity.ToTable("Graphic Card");

                entity.Property(e => e.GraphicCardId).HasColumnName("GraphicCardID");

                entity.Property(e => e.AdapterRam).HasColumnName("AdapterRAM");

                entity.Property(e => e.Caption)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasColumnName("UUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Uu)
                    .WithMany(p => p.GraphicCard)
                    .HasForeignKey(d => d.Uuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Graphic Card_Computer");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Memory>(entity =>
            {
                entity.Property(e => e.MemoryId).HasColumnName("MemoryID");

                entity.Property(e => e.MemoryType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Uuid)
                    .IsRequired()
                    .HasColumnName("UUID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Uu)
                    .WithMany(p => p.Memory)
                    .HasForeignKey(d => d.Uuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Memory_Computer");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
