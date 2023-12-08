using FinalProject.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infraestructure.Persistence.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region TipoCaso
            modelBuilder.Entity<TipoCaso>().ToTable("TipoCaso");
            modelBuilder.Entity<TipoCaso>().HasKey(x => x.Id);
            modelBuilder.Entity<TipoCaso>().HasIndex(x => x.Nombre).IsUnique();
            #endregion

            #region EstadoCaso
            modelBuilder.Entity<EstadoCaso>().ToTable("EstadoCaso");
            modelBuilder.Entity<EstadoCaso>().HasKey(x => x.Id);
            modelBuilder.Entity<EstadoCaso>().HasIndex(x => x.Nombre).IsUnique();
            #endregion
            
            #region Caso
            modelBuilder.Entity<Caso>().ToTable("Caso");
            modelBuilder.Entity<Caso>().HasKey(x => x.Id);

            modelBuilder.Entity<Caso>()
                .HasOne(x => x.TipoCaso)
                .WithMany(x => x.Casos)
                .HasForeignKey(x => x.IdTipoCaso)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Caso>()
                .HasOne(x => x.EstadoCaso)
                .WithMany(x => x.Casos)
                .HasForeignKey(x => x.IdEstadoCaso)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion
        }

        public DbSet<Caso> Casos { get; set; }
        public DbSet<TipoCaso> TipoCasos { get; set; }
        public DbSet<EstadoCaso> EstadoCasos { get; set; }
    }
}
