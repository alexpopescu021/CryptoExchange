using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoExchange.Domain.Models
{
    public class Portfolio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Value { get; set; }
        public Currency Currency { get; set; } = new();
        public User User { get; set; } = new();

        public ICollection<CurrencyValue> CurrencyValues { get; set; } = new List<CurrencyValue>();
    }
}
