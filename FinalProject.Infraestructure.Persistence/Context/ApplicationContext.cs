using FinalProject.Core.Domain.Commons;
using FinalProject.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infraestructure.Persistence.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region TipoCaso
            modelBuilder.Entity<TipoCaso>().ToTable("TipoCaso");
            modelBuilder.Entity<TipoCaso>().HasKey(x => x.Id);
            modelBuilder.Entity<TipoCaso>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<TipoCaso>().Property(x => x.LastModifiedBy).IsRequired(false);
            modelBuilder.Entity<TipoCaso>().Property(x => x.CreatedBy).IsRequired(false);
            #endregion

            #region EstadoCaso
            modelBuilder.Entity<EstadoCaso>().ToTable("EstadoCaso");
            modelBuilder.Entity<EstadoCaso>().HasKey(x => x.Id);
            modelBuilder.Entity<EstadoCaso>().HasIndex(x => x.Nombre).IsUnique();
            modelBuilder.Entity<EstadoCaso>().Property(x => x.LastModifiedBy).IsRequired(false);
            modelBuilder.Entity<EstadoCaso>().Property(x => x.CreatedBy).IsRequired(false);
            #endregion

            #region Caso
            modelBuilder.Entity<Caso>().ToTable("Caso");
            modelBuilder.Entity<Caso>().HasKey(x => x.Id);
            modelBuilder.Entity<Caso>().Property(x => x.LastModifiedBy).IsRequired(false);
            modelBuilder.Entity<Caso>().Property(x => x.CreatedBy).IsRequired(false);

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
