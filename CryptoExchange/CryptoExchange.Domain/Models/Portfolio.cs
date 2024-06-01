namespace CryptoExchange.Domain.Models
{
    public class Portfolio : Entity
    {
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Value { get; set; }
        public Currency Currency { get; set; } = new();
        public User User { get; set; } = new();

        public ICollection<CurrencyValue> CurrencyValues { get; set; } = new List<CurrencyValue>();
    }
}
