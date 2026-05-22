using System.ComponentModel.DataAnnotations;

namespace Poc.DeliveryContinuServiceUtilisateurs.Dtos
{
    public class UtilisateurCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Nom { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = string.Empty;

        public bool Actif { get; set; } = true;


    }
}
