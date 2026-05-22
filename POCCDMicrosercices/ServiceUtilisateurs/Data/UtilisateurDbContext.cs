using Microsoft.EntityFrameworkCore;
using Poc.DeliveryContinuServiceUtilisateurs.Models;





namespace Poc.DeliveryContinuServiceUtilisateurs.Data
{
    public class UtilisateurDbContext:DbContext
    {
        public UtilisateurDbContext(DbContextOptions<UtilisateurDbContext> options)
            : base(options)
        {
        }
        public DbSet<Utilisateur> Utilisateurs => Set<Utilisateur>();
    }
}
