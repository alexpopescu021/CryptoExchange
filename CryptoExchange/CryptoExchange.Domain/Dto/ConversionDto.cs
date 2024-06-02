using CryptoExchange.Domain.Models;

namespace CryptoExchange.Domain.Dto
{
    public class ConversionDto
    {
        public string SourceCurrencyCode { get; set; } = string.Empty;
        public string TargetCurrencyCode { get; set; } = string.Empty;

        public decimal SourceValue { get; set; }
        public decimal TargetValue { get; set; }
        public decimal ConversionFee { get; set; }
    }
}
