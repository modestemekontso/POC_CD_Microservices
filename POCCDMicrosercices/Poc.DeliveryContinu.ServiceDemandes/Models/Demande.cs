using System.ComponentModel.DataAnnotations;
namespace Poc.DeliveryContinu.ServiceDemandes.Models
{
    public class Demande
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Titre { get; set; } = string.Empty;
        [Required]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Statut { get; set; } = "En Attente";
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
    }
}
