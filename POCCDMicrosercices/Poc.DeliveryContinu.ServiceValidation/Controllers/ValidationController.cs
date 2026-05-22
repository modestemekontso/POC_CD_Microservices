using Microsoft.AspNetCore.Mvc;

using Poc.DeliveryContinu.ServiceValidation.DTOs;
using Poc.DeliveryContinu.ServiceValidation.Service;
using Poc.DeliveryContinu.ServiceValidation.Services;
using Poc.DeliveryContinu.ServiceValidation.ServiceValidation;

namespace Poc.DeliveryContinu.ServiceValidation.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidationController : ControllerBase
    {
        private readonly IValidationService _validationService;
        public ValidationController(IValidationService validationService)
        {
            _validationService = validationService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValidationReadDto>>> GetAll()
        {
            var result = await _validationService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ValidationReadDto>> GetById(int id)
        {
            var result = await _validationService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ValidationReadDto>> Create(ValidationCreateDto dto)
        {
            var created = await _validationService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ValidationUpdateDto dto)
        {
            var updated = await _validationService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _validationService.DeleteAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
