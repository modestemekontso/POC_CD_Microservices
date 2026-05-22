using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poc.DeliveryContinu.ServiceDemandes.Data;
using Poc.DeliveryContinu.ServiceDemandes.Models;

namespace Poc.DeliveryContinu.ServiceDemandes.Tests
{
    [TestClass]
    public class DemandesServiceTests
    {
        private DemandeDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<DemandeDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new DemandeDbContext(options);
        }
        [TestMethod]
        public async Task GetDemandes_Retourne_La_Liste_Des_Demandes()
        {
            // Arrange
            using var context = GetDbContext();
            context.Demandes.Add(new Demande
            {
                Titre = "Demande 1",
                Description = "Description 1",
                Statut = "En attente",
                DateCreation = DateTime.UtcNow
            });
            context.Demandes.Add(new Demande
            {
                Titre = "Demande 2",
                Description = "Description 2",
                Statut = "Approuvée",
                DateCreation = DateTime.UtcNow
            });
            await context.SaveChangesAsync();
            var controller = new DemandesController(context);

            // Act
            var result = await controller.GetDemandes();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var demandes = okResult.Value as List<Demande>;

            Assert.IsNotNull(demandes);
            Assert.AreEqual(2, demandes.Count);
        }
        [TestMethod]
        public async Task CreateDemande_Ajoute_Une_Demande()

        {
            // Arrange
            using var context = GetDbContext();
            var controller = new DemandesController(context);
            var nouvelleDemande = new Demande
            {
                Titre = "Nouvelle demande",
                Description = "Description test",
                Statut = "En attente"
            };

            // Act
            var result = await controller.CreateDemande(nouvelleDemande);

            // Assert
            var createdAtResult = result as CreatedAtActionResult;
            Assert.IsNotNull(createdAtResult);
            var demandeCreee = createdAtResult.Value as Demande;

            Assert.IsNotNull(demandeCreee);
            Assert.AreEqual("Nouvelle demande", demandeCreee.Titre);
            Assert.AreEqual(1, context.Demandes.Count());
        }
        [TestMethod]
        public async Task GetDemande_Retourne_NotFound_Si_Absente()
        {
            // Arrange
            using var context = GetDbContext();
            var controller = new DemandesController(context);

            // Act
            var result = await controller.GetDemande(999);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
