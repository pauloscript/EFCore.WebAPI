using System;
using EFCore.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EFCore.Repo
{
    public partial class heroContext : DbContext
    {
        public heroContext(DbContextOptions<heroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arma> Armas { get; set; }
        public virtual DbSet<Batalha> Batalhas { get; set; }
        public virtual DbSet<Heroi> Herois { get; set; }
        public virtual DbSet<HeroiBatalha> HeroiBatalhas { get; set; }
        public virtual DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Portuguese_Brazil.1252");

            modelBuilder.Entity<Arma>(entity =>
            {
                entity.HasIndex(e => e.HeroiId, "IX_Armas_HeroiId");

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.Armas)
                    .HasForeignKey(d => d.HeroiId);
            });

            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });

                entity.HasIndex(e => e.HeroiId, "IX_HeroiBatalhas_HeroiId");

                entity.HasOne(d => d.Batalha)
                    .WithMany(p => p.HeroiBatalhas)
                    .HasForeignKey(d => d.BatalhaId);

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.HeroiBatalhas)
                    .HasForeignKey(d => d.HeroiId);
            });

            modelBuilder.Entity<IdentidadeSecreta>(entity =>
            {
                entity.HasIndex(e => e.HeroiId, "IX_IdentidadeSecretas_HeroiId");

                entity.HasOne(d => d.Heroi)
                    .WithMany(p => p.IdentidadeSecreta)
                    .HasForeignKey(d => d.HeroiId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
