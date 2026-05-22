using Microsoft.EntityFrameworkCore;
using Poc.DeliveryContinu.ServiceDemandes.Models;

namespace Poc.DeliveryContinu.ServiceDemandes.Data

{
    public class DemandeDbContext : DbContext
    {
        public DemandeDbContext(DbContextOptions<DemandeDbContext> options)
            : base(options)
        {

        }
        public DbSet<Demande> Demandes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Demande>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titre)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.Description)
                    .HasMaxLength(1000);
                entity.Property(e => e.Statut)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.DateCreation)
                    .IsRequired();
                entity.ToTable("Demandes");
            });
        }
    }
}
