using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dotnet_test
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<A> As { get; set; } = null!;
        public virtual DbSet<B> Bs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=tcp:localhost,1433;user=SA;password=<YourStrong@Passw0rd>;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<A>(entity =>
            {
                entity.ToTable("A");

                entity.HasIndex(e => new { e.B1, e.B2 }, "A_b1_b2_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.B1).HasColumnName("b1");

                entity.Property(e => e.B2).HasColumnName("b2");

                entity.HasOne(d => d.B)
                    .WithOne(p => p.A)
                    .HasForeignKey<A>(d => new { d.B1, d.B2 })
                    .HasConstraintName("A_b1_b2_fkey");
            });

            modelBuilder.Entity<B>(entity =>
            {
                entity.HasKey(e => new { e.Id1, e.Id2 })
                    .HasName("B_pkey");

                entity.ToTable("B");

                entity.Property(e => e.Id1).HasColumnName("id1");

                entity.Property(e => e.Id2).HasColumnName("id2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
