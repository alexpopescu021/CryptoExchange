namespace CryptoExchange.Domain.Models
{
    public class Transaction : Entity
    {
        public int UserId { get; set; }
        public int SourceCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public DateTime TransactionDate { get; set; } = new();
        // change from Price
        public decimal SourcePrice { get; set; }
        public decimal TargetPrice { get; set; }
        // computed column  1 target = x * source
        public decimal ConversionRate { get; set; } = (decimal)0.15;
        public virtual Currency SourceCurrency { get; set; } = new();
        public virtual Currency TargetCurrency { get; set; } = new();
        public User User { get; set; } = new();
    }
}
