using System.ComponentModel.DataAnnotations;

namespace Poc.DeliveryContinu.ServiceValidation.DTOs

{
    public class ValidationReadDto

    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le statut est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le statut ne doit pas dépasser 50 caractères.")]
        public string Statut { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Le commentaire ne doit pas dépasser 500 caractères.")]
        public string? Commentaire { get; set; }

        [Required(ErrorMessage = "La date de validation est obligatoire.")]
        public DateTime DateValidation { get; set; }
    }
}
