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
                entity.ToTable("demandes", "public");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.Titre)
                      .HasColumnName("titre")
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Description)
                      .HasColumnName("description");

                entity.Property(e => e.DateCreation)
                      .HasColumnName("date_creation");

                entity.Property(e => e.Statut)
                      .HasColumnName("statut")
                      .IsRequired()
                      .HasMaxLength(50);
            });
        }
    }
}
