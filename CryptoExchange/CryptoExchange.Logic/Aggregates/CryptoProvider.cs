using CryptoExchange.Domain.Dto;
using CryptoExchange.Logic.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CryptoExchange.Logic.Aggregates;
public class CryptoProvider : ICryptoProvider
{
    public async Task<List<string>> GetCoinList()
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

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(responseContent);

            var symbols = new List<string>();

            // Iterate through the properties of the 'Data' object and extract the 'symbol' property
            foreach (var item in jsonObject["Data"])
            {
                var symbol = item.First["symbol"].ToString();
                // Split the symbol by colon (:) and take the second part
                var trimmedSymbol = symbol.Contains(':') ? symbol.Split(':')[1] : symbol;
                symbols.Add(trimmedSymbol);
            }

            return symbols;
        }
        else
        {
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
        }
    }

    public async Task<decimal> GetPrice(string convertFromSymbol, string convertToSymbol)
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
        var result = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(content);

        return result.Values.First();
    }

    public async Task<Dictionary<string, string>> GetFiatList()
    {
        var client = new HttpClient();
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("http://api.currencylayer.com/list?access_key=79bb00227550668266d760885e6b0784")
        };

        var response = await client.SendAsync(httpRequestMessage);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<CurrencyGetListDto>(responseContent);
            if (responseObject != null) return responseObject.Currencies;
        }

        throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
    }

    public async Task<decimal> GetConversionAmountFromTo(string from, string to, decimal fromValue)
    {
        var client = new HttpClient();
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://min-api.cryptocompare.com/data/price?fsym={from.ToUpper()}&tsyms={to.ToUpper()}")
        };
        httpRequestMessage.Headers.TryAddWithoutValidation("Authorization",
            "Apikey 3ac770516d8474766b6fa6e4db64c96c291d68f6016fc58e57e9277c7de126f8");
        var response = await client.SendAsync(httpRequestMessage);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(responseContent);

            // Check if the response contains the desired currency rate
            if (responseObject != null && responseObject.ContainsKey(to.ToUpper()))
            {
                // Get the conversion rate
                var conversionRate = responseObject[to.ToUpper()];
                // Calculate and return the converted amount
                var test = Math.Round(fromValue * conversionRate, 8);
                return Math.Round(fromValue * conversionRate, 8);
            }
        }
        throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
    }

    public class ConversionRateDto
    {
        public Dictionary<string, decimal> Quotes { get; set; }
    }
}
