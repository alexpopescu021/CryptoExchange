﻿using CryptoExchange.Domain.Models;

namespace CryptoExchange.Repository.Interfaces
{
    public interface IPortfolioRepository : IGenericRepository<Portfolio>
    {
        public decimal? GetCurrencyValueAsync(string currency);

    }
}
