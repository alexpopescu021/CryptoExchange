using CryptoExchange.Domain.Models;

namespace CryptoExchange.Domain.Dto
{
    public class TransactionGetDto : Entity
    {
        public string Username { get; set; } = string.Empty;
        public string SourceCurrencyCode { get; set; } = string.Empty;
        public string TargetCurrencyCode { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; } = new();
        // change from Price
        public decimal SourcePrice { get; set; }
        public decimal TargetPrice { get; set; }
        // computed column  1 target = x * source
        public decimal ConversionRate { get; set; }
    }
}
