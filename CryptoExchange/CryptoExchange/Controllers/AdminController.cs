using CryptoExchange.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoExchange.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly ICryptoProvider _cryptoProvider;
    public AdminController(ICryptoProvider cryptoProvider)
    {
        _cryptoProvider = cryptoProvider;
    }

    [HttpGet]
    public async Task<string> GetAllFiat()
    {
        return await _cryptoProvider.GetFiatList();
    }

    [HttpPost]
    public async Task<string> AddSupportedFiat()
    {
        return await _cryptoProvider.GetCoinList();
    }

    [HttpPost]
    public async Task<string> AddSupportedCrypto()
    {
        return await _cryptoProvider.GetCoinList();
    }

}
