using CryptoExchange.Domain.Dto;
using CryptoExchange.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoExchange.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly ICryptoProvider _cryptoProvider;
    private readonly ICurrencyService _currencyService;
    public AdminController(ICryptoProvider cryptoProvider, ICurrencyService currencyService)
    {
        _cryptoProvider = cryptoProvider;
        _currencyService = currencyService;
    }

    [HttpGet("getfiat")]
    public async Task<Dictionary<string, string>> GetAllFiat()
    {
        return await _cryptoProvider.GetFiatList();
    }

    [HttpGet("getcrypto")]
    public async Task<List<string>> GetAllCrypto()
    {
        return await _cryptoProvider.GetCoinList();
    }

    [HttpPost("addcurr")]
    public async Task<bool> AddSupportedFiat([FromBody] SupportedCurrenciesGetDto currencies)
    {
        return await _currencyService.AddSupportedCurrency(currencies);
    }

}
