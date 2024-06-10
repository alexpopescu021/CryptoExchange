namespace CryptoExchange.Domain.Models
{
    public class CurrencyValue : IEntity
    {
        public int Id { get; set; }

        public int PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; }

        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }

        public decimal Value { get; set; }
    }
}
