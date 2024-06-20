namespace CryptoExchange.Domain.Dto;
public class ExternalTransactionDto
{
    public int CurrencyId { get; set; }
    public string Iban { get; set; } = string.Empty;
    public string Card{ get; set; } = string.Empty;
    public decimal Amount { get; set; }
}

