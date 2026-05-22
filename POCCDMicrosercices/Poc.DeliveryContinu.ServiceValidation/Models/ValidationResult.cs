namespace Poc.DeliveryContinu.ServiceValidation.Models
{
    public class ValidationResult
    {
        public bool EstValide { get; set; }

        public List<string> Erreurs { get; set; } = new();
    }
}
