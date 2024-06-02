using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoExchange.Domain.Models
{
    public class CurrencyValue
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; } = new();

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; } = new();

        public decimal Value { get; set; }
    }
}
