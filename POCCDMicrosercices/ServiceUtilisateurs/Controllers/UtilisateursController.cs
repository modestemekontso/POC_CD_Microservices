using Microsoft.AspNetCore.Mvc;
using Poc.DeliveryContinuServiceUtilisateurs.Dtos;
using Poc.DeliveryContinuServiceUtilisateurs.Services;

namespace Poc.DeliveryContinuServiceUtilisateurs.Controllers
{
          [ApiController]
        [Route("api/[controller]")]
        public class UtilisateursController : ControllerBase
        {
            private readonly IUtilisateurService _utilisateurService;

            public UtilisateursController(IUtilisateurService utilisateurService)
            {
                _utilisateurService = utilisateurService;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<UtilisateurReadDto>>> GetAll()
            {
                var utilisateurs = await _utilisateurService.GetAllAsync();
                return Ok(utilisateurs);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<UtilisateurReadDto>> GetById(int id)
            {
                var utilisateur = await _utilisateurService.GetByIdAsync(id);

                if (utilisateur == null)
                    return NotFound();

                return Ok(utilisateur);
            }

            [HttpPost]
            public async Task<ActionResult<UtilisateurReadDto>> Create(UtilisateurCreateDto dto)
            {
                var created = await _utilisateurService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
        }
   }

