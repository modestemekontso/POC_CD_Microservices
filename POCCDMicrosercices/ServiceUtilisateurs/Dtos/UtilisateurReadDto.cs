namespace Poc.DeliveryContinuServiceUtilisateurs.Dtos
{
    public class UtilisateurReadDto
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool Actif { get; set; }
    }
}
