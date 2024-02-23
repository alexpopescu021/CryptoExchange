namespace CryptoExchange.Logic.Interfaces;
public interface ICryptoProvider
{
    public Task<List<string>> GetCoinList();

    public Task<double> GetPrice(string convertFromSymbol, string convertToSymbol);

    public Task<Dictionary<string, string>> GetFiatList();
}
