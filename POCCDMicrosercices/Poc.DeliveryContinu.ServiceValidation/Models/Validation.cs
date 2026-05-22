namespace Poc.DeliveryContinu.ServiceValidation.Models
{
    public class Validation
    {
        public int Id { get; set; }
        public int DemandeId { get; set; }
        public string Commentaire { get; set; } = string.Empty;
        public DateTime DateValidation { get; set; } = DateTime.Now;
        public string Statut { get; set; } = string.Empty;
    }
}
