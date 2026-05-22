using Microsoft.EntityFrameworkCore;
using Poc.DeliveryContinu.ServiceValidation.Data;
using Poc.DeliveryContinu.ServiceValidation.Services;
using Poc.DeliveryContinu.ServiceValidation.Models;
using Poc.DeliveryContinu.ServiceValidation.ServiceValidation;

namespace Poc.DeliveryContinu.ServiceValidation.Tests
{
    [TestClass]
    public sealed class ValidationServiceTests
    {
        private ValidationDbContext _context = null!;
        private ValidationService _service = null!;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ValidationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ValidationDbContext(options);
            _service = new ValidationService(_context);
        }
        [TestMethod]
        public async Task GetAllAsync_Returns_Empty_List_When_No_Data()
        {
            var result = await _service.GetAllAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public async Task GetAllAsync_Returns_All_Validations()
        {
            _context.Validations.AddRange(
            new Validation
            {
                Statut = "Valide",
                Commentaire = "Validation 1",
                DateValidation = DateTime.UtcNow
            },
            new Validation
            {
                Statut = "Rejetée",
                Commentaire = "Validation 2",
                DateValidation = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            var result = await _service.GetAllAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task GetByIdAsync_Returns_Validation_When_Id_Exists()
        {
            var entity = new Validation
            {
                Statut = "Valide",
                Commentaire = "Test",
                DateValidation = DateTime.UtcNow
            };
            _context.Validations.Add(entity);
            await _context.SaveChangesAsync();
            var result = await _service.GetByIdAsync(entity.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(entity.Id, result.Id);
            Assert.AreEqual("Valide", result.Statut);
            Assert.AreEqual("Test", result.Commentaire);
        }

        [TestMethod]
        public async Task GetByIdAsync_Returns_Null_When_Id_Does_Not_Exist()
        {
            var result = await _service.GetByIdAsync(999);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task CreateAsync_Creates_Validation_And_Returns_Dto()
        {
            var dto = new ValidationCreateDto
            {
                Statut = "Valide",
                Commentaire = "Création test"
            };

            var result = await _service.CreateAsync(dto);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, _context.Validations.Count());
            Assert.AreEqual("Valide", result.Statut);
            Assert.AreEqual("Création test", result.Commentaire);

            var entity = await _context.Validations.FirstAsync();
            Assert.AreEqual("Valide", entity.Statut);
            Assert.AreEqual("Création test", entity.Commentaire);
        }
    }
}

