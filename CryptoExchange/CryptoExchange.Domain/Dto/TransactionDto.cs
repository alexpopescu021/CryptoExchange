namespace CryptoExchange.Domain.Dto;
public class TransactionDto
{
    public int UserId { get; set; }
    public int SourceCurrencyId { get; set; }
    public int TargetCurrencyId { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal SourcePrice { get; set; }
    public decimal TargetPrice { get; set; }
    public decimal ConversionRate { get; set; }
}

