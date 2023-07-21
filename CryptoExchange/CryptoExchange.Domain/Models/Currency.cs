namespace CryptoExchange.Domain.Models
{
    public class Currency : Entity
    {
        public string CurrencyCode { get; set; } = string.Empty;
        public bool IsFiat { get; set; }

        public virtual ICollection<Transaction> SourceTransactions { get; set; }
        public virtual ICollection<Transaction> TargetTransactions { get; set; }

    }
}
