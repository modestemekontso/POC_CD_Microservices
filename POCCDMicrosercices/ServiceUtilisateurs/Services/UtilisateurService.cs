using Microsoft.EntityFrameworkCore;
using Poc.DeliveryContinuServiceUtilisateurs.Data;
using Poc.DeliveryContinuServiceUtilisateurs.Dtos;
using Poc.DeliveryContinuServiceUtilisateurs.Models;

namespace Poc.DeliveryContinuServiceUtilisateurs.Services
{
    public class UtilisateurService:IUtilisateurService
    {
        private readonly UtilisateurDbContext _context;
        public UtilisateurService(UtilisateurDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UtilisateurReadDto>> GetAllAsync()
        {
            return await _context.Utilisateurs
            .Select(u => new UtilisateurReadDto
            {
                Id = u.Id,
                Nom = u.Nom,
                Email = u.Email,
                Role = u.Role,
                Actif = u.Actif
            })
            .ToListAsync();
        }
        public async Task<UtilisateurReadDto?> GetByIdAsync(int id)
        {
            return await _context.Utilisateurs
            .Where(u => u.Id == id)
            .Select(u => new UtilisateurReadDto
            {
                Id = u.Id,
                Nom = u.Nom,
                Email = u.Email,
                Role = u.Role,
                Actif = u.Actif
            })
            .FirstOrDefaultAsync();
        }
        public async Task<UtilisateurReadDto> CreateAsync(UtilisateurCreateDto dto)
        {
            var utilisateur = new Utilisateur
            {
                Nom = dto.Nom,
                Email = dto.Email,
                Role = dto.Role,
                Actif = dto.Actif
            };

            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();

            return new UtilisateurReadDto
            {
                Id = utilisateur.Id,
                Nom = utilisateur.Nom,
                Email = utilisateur.Email,
                Role = utilisateur.Role,
                Actif = utilisateur.Actif
            };
        }
    }
}
