using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoExchange.Domain.Models
{
    public class Currency 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string CurrencyCode { get; set; } = string.Empty;
        public bool IsFiat { get; set; }

        public virtual ICollection<Transaction> SourceTransactions { get; set; }
        public virtual ICollection<Transaction> TargetTransactions { get; set; }
        public virtual ICollection<CurrencyValue> CurrencyValues { get; set; } = new List<CurrencyValue>();

    }
}
