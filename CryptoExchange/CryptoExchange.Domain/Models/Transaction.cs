namespace CryptoExchange.Domain.Models
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int SourceCurrencyId { get; set; }
        public int TargetCurrencyId { get; set; }
        public DateTime TransactionDate { get; set; }
        // change from Price
        public decimal SourcePrice { get; set; }
        public decimal TargetPrice { get; set; }
        // computed column  1 target = x * source
        public decimal ConversionRate { get; set; } = (decimal)0.15;
        public virtual Currency SourceCurrency { get; set; }
        public virtual Currency TargetCurrency { get; set; }
        public User User { get; set; }
    }
}
