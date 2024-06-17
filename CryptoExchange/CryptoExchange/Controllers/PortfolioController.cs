using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
using CryptoExchange.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoExchange.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PortfolioController : ControllerBase
{
    private readonly IPortofolioService _portofolioService;
    public PortfolioController(IPortofolioService portofolioService)
    {
        _portofolioService = portofolioService;
    }

    [HttpGet("{id}")]
    public Task<List<CurrencyValue>> GetUserPortfolio(int id)
    {
        return _portofolioService.GetAllPortfolio(id);
    }
}
