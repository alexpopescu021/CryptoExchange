using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoExchange.Domain.Models
{
    public class ExternalTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int CurrencyId { get; set; }

        public string Iban { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public Currency Currency = new();

    }
}
