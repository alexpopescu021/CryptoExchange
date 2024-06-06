using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoExchange.Domain.Models
{
    public class Settings : IEntity
    {
        public int Id { get; set; }

        public int WithdrawalCurrencyId { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal WithdrawalFee { get; set; }
        public virtual Currency Currency { get; set; } = new();
    }
}
