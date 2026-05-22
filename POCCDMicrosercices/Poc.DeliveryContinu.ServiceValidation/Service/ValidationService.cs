using Microsoft.EntityFrameworkCore;
using Poc.DeliveryContinu.ServiceValidation.Data;
using Poc.DeliveryContinu.ServiceValidation.DTOs;
using Poc.DeliveryContinu.ServiceValidation.Models;
using Poc.DeliveryContinu.ServiceValidation.Service;
using Poc.DeliveryContinu.ServiceValidation.ServiceValidation;

namespace Poc.DeliveryContinu.ServiceValidation.Services

{
    public class ValidationService : IValidationService
    {
        private readonly ValidationDbContext _context;
        public ValidationService(ValidationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ValidationReadDto>> GetAllAsync()
        {
            return await _context.Validations
                .Select(v => new ValidationReadDto
                {
                    Id = v.Id,
                    Statut = v.Statut,
                    Commentaire = v.Commentaire,
                    DateValidation = v.DateValidation
                })
                .ToListAsync();
        }

        public async Task<ValidationReadDto?> GetByIdAsync(int id)
        {
            return await _context.Validations
                .Where(v => v.Id == id)
                .Select(v => new ValidationReadDto
                {
                    Id = v.Id,
                    Statut = v.Statut,
                    Commentaire = v.Commentaire,
                    DateValidation = v.DateValidation
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ValidationReadDto> CreateAsync(ValidationCreateDto dto)
        {
            var validation = new Validation
            {
                Statut = dto.Statut,
                Commentaire = dto.Commentaire,
                DateValidation = dto.DateValidation
            };
            _context.Validations.Add(validation);
            await _context.SaveChangesAsync();
            return new ValidationReadDto
            {
                Id = validation.Id,
                Statut = validation.Statut,
                Commentaire = validation.Commentaire,
                DateValidation = validation.DateValidation
            };
        }
        public async Task<bool> UpdateAsync(int id, ValidationUpdateDto dto)
        {
            var validation = await _context.Validations.FindAsync(id);
            if (validation == null)
                return false;
            validation.Statut = dto.Statut;
            validation.Commentaire = dto.Commentaire;
            validation.DateValidation = dto.DateValidation;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var validation = await _context.Validations.FindAsync(id);
            if (validation == null)
                return false;
            _context.Validations.Remove(validation);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
