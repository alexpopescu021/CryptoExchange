namespace CryptoExchange.Logic.Interfaces;
public interface ICryptoProvider
{
    public Task<List<string>> GetCoinList();

    public Task<decimal> GetPrice(string convertFromSymbol, string convertToSymbol);

    public Task<Dictionary<string, string>> GetFiatList();
    public Task<decimal> GetConversionAmountFromTo(string from, string to, decimal fromValue);

}
