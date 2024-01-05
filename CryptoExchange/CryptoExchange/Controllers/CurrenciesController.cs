using CryptoExchange.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoExchange.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrenciesController : ControllerBase
{
    private readonly ICryptoProvider _cryptoProvider;
    public CurrenciesController(ICryptoProvider cryptoProvider)
    {
        _cryptoProvider = cryptoProvider;
    }

    [HttpGet]
    public async Task<string> GetAllCrypto()
    {
        return await _cryptoProvider.GetCoinList();
    }

}
