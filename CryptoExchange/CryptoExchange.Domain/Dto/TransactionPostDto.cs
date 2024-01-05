using CryptoExchange.Domain.Models;

namespace CryptoExchange.Domain.Dto
{
    public class TransactionPostDto : Entity
    {
        public string SourceCurrencyCode { get; set; } = string.Empty;
        public string TargetCurrencyCode { get; set; } = string.Empty;

    }
}
