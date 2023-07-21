namespace CryptoExchange.Domain.Models
{
    public class Settings : Entity
    {
        public int WithdrawalCurrencyId { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal WithdrawalFee { get; set; }
        public virtual Currency Currency { get; set; } = new();
    }
}
