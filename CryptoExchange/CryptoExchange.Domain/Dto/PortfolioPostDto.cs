namespace CryptoExchange.Domain.Dto;
public class PortfolioPostDto
{
    public List<Dictionary<CurrencyGetDto, decimal>> Currencies { get; set; }

}
