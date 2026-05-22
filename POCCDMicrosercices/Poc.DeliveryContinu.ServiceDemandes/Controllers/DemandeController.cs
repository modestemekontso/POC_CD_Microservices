using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Poc.DeliveryContinu.ServiceDemandes.Data;
using Poc.DeliveryContinu.ServiceDemandes.Models;

[ApiController]
[Route("api/[controller]")]
public class DemandesController : ControllerBase
    {
    private readonly DemandeDbContext _context;
     
    public DemandesController(DemandeDbContext context )
    {
        _context = context;
        
    }

    // GET: api/demandes

    [HttpGet]
    public async Task<IActionResult> GetDemandes()
    {
        var demandes = await _context.Demandes.ToListAsync();
        return Ok(demandes);
    }
    // GET: api/demandes/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDemande(int id)
    {
        var demande = await _context.Demandes.FindAsync(id);
        if (demande == null)
            return NotFound();
        return Ok(demande);
    }
    // POST: api/demandes

    [HttpPost]
    public async Task<IActionResult> CreateDemande([FromBody] Demande demande)
    {
        demande.DateCreation = DateTime.UtcNow;
        _context.Demandes.Add(demande);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDemande), new { id = demande.Id }, demande);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDemande(int id, Demande demande)
    {
        if (id != demande.Id)
        {
            return BadRequest("L'identifiant de l'URL ne correspond pas à celui du body.");
        }

        var demandeExistante = await _context.Demandes.FindAsync(id);

        if (demandeExistante == null)
        {
            return NotFound();
        }
        demandeExistante.Titre = demande.Titre;
        demandeExistante.Description = demande.Description;
        demandeExistante.Statut = demande.Statut;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDemande(int id)
    {
        var demande = await _context.Demandes.FindAsync(id);
        if (demande == null)
        {
            return NotFound();
        }
        _context.Demandes.Remove(demande);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
 

