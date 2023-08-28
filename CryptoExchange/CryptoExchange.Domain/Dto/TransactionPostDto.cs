using CryptoExchange.Domain.Models;

namespace CryptoExchange.Domain.Dto
{
    public class TransactionPostDto : Entity
    {
        public int SourceCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public decimal SourcePrice { get; set; }

    }
}
