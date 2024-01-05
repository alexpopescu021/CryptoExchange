namespace CryptoExchange.Logic.Interfaces;
public interface ICryptoProvider
{
    public Task<string> GetCoinList();

    public Task<double> GetPrice(string convertFromSymbol, string convertToSymbol);

    public Task<string> GetFiatList();
}
