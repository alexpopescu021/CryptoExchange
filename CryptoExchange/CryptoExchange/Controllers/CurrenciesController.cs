using CryptoExchange.Domain.Dto;
using CryptoExchange.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoExchange.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrenciesController : ControllerBase
{
    private readonly ICurrencyService _currencyService;
    public CurrenciesController(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    [HttpGet("crypto")]
    public async Task<CurrencyPostDto[]> GetAllSuportedCrypto()
    {
        return await _currencyService.GetSupportedCrypto();
    }

    [HttpGet("fiat")]
    public async Task<CurrencyPostDto[]> GetAllSuportedFiat()
    {
        return await _currencyService.GetSupportedFiat();
    }
}
