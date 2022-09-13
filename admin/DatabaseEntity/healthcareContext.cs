using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace admin.DatabaseEntity
{
    public partial class healthcareContext : DbContext
    {
        public healthcareContext()
        {
        }

        public healthcareContext(DbContextOptions<healthcareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<Physician> Physicians { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRegistration> UserRegistrations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET673;Initial Catalog=healthcare;User ID=sa;Password=pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>(entity =>
            {
                entity.ToTable("claim");

                entity.Property(e => e.ClaimId).HasColumnName("claimId");

                entity.Property(e => e.ClaimAmmount).HasColumnName("claimAmmount");

                entity.Property(e => e.ClaimDate)
                    .HasColumnType("datetime")
                    .HasColumnName("claimDate");

                entity.Property(e => e.ClaimType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("claimType");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("remarks");

                entity.Property(e => e.UserId).HasColumnName("userId");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.Claims)
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__claim__userId__300424B4");
            });

            modelBuilder.Entity<Physician>(entity =>
            {
                entity.ToTable("physician");

                entity.Property(e => e.PhysicianId).HasColumnName("physicianId");

                entity.Property(e => e.PhysicianName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("physicianName");

                entity.Property(e => e.PhysicianState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("physicianState");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Physician)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("physician");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.UserName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__userRegi__CB9A1CFF6874C41D");

                entity.ToTable("userRegistration");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UserType)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("userType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
