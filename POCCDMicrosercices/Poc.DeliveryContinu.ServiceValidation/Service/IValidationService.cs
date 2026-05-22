using Poc.DeliveryContinu.ServiceValidation.DTOs;
using Poc.DeliveryContinu.ServiceValidation.ServiceValidation;

namespace Poc.DeliveryContinu.ServiceValidation.Service
{
    public interface IValidationService
    {
        Task<IEnumerable<ValidationReadDto>> GetAllAsync();
        Task<ValidationReadDto?> GetByIdAsync(int id);
        Task<ValidationReadDto> CreateAsync(ValidationCreateDto dto);
        Task<bool> UpdateAsync(int id, ValidationUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
