namespace CryptoExchange.Domain.Dto
{
    public class TransactionGetDto
    {
        public string Username { get; set; } = string.Empty;
        public string SourceCurrencyCode { get; set; } = string.Empty;
        public string TargetCurrencyCode { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        // change from Price
        public decimal SourcePrice { get; set; }
        public decimal TargetPrice { get; set; }
        // computed column  1 target = x * source
        public decimal ConversionRate { get; set; }
    }
}
