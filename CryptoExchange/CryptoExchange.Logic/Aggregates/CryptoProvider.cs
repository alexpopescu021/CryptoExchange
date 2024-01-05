using CryptoExchange.Logic.Interfaces;
using Newtonsoft.Json;

namespace CryptoExchange.Logic.Aggregates;
public class CryptoProvider : ICryptoProvider
{
    public async Task<string> GetCoinList()
    {
        var client = new HttpClient();
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://min-api.cryptocompare.com/data/blockchain/list")
        };

        httpRequestMessage.Headers.TryAddWithoutValidation("Authorization",
            "Apikey 3ac770516d8474766b6fa6e4db64c96c291d68f6016fc58e57e9277c7de126f8");

        var response = await client.SendAsync(httpRequestMessage);

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<double> GetPrice(string convertFromSymbol, string convertToSymbol)
    {
        var client = new HttpClient();
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri =
                new Uri(
                    $"https://min-api.cryptocompare.com/data/price?fsym={convertFromSymbol}&tsyms={convertToSymbol}")
        };

        httpRequestMessage.Headers.TryAddWithoutValidation("Authorization",
            "Apikey 3ac770516d8474766b6fa6e4db64c96c291d68f6016fc58e57e9277c7de126f8");

        var response = await client.SendAsync(httpRequestMessage);

        // Read the response content as a string
        var content = await response.Content.ReadAsStringAsync();


        // Deserialize the JSON and extract the numeric value
        var result = JsonConvert.DeserializeObject<Dictionary<string, double>>(content);

        return result.Values.First();
    }

    public async Task<string> GetFiatList()
    {
        var client = new HttpClient();
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://api.currencylayer.com/list?access_key=79bb00227550668266d760885e6b0784")
        };

        var response = await client.SendAsync(httpRequestMessage);

        return await response.Content.ReadAsStringAsync();
    }
}
