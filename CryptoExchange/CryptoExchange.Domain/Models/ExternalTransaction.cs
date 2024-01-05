namespace CryptoExchange.Domain.Models
{
    public class ExternalTransaction : Entity
    {
        public int CurrencyId { get; set; }

        public string Iban { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public Currency Currency = new();

    }
}
