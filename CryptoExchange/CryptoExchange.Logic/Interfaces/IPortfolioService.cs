using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;

namespace CryptoExchange.Logic.Interfaces;
public interface IPortofolioService
{
    public decimal? GetPortofolioVAlueForCurrentCurrency(string currency);

    public Task<List<CurrencyValue>> GetAllPortfolio(int id);

}
