using Poc.DeliveryContinuServiceUtilisateurs.Dtos;

namespace Poc.DeliveryContinuServiceUtilisateurs.Services
{
    public interface IUtilisateurService
    {
        Task<IEnumerable<UtilisateurReadDto>> GetAllAsync();
        Task<UtilisateurReadDto?> GetByIdAsync(int id);
        Task<UtilisateurReadDto> CreateAsync(UtilisateurCreateDto dto);


    }
}
