﻿using AutoMapper;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
using CryptoExchange.Logic.Interfaces;
using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Logic.Aggregates
{
    public class PortofolioService : IPortofolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PortofolioService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public decimal? GetPortofolioVAlueForCurrentCurrency(string currency)
        {
            return _unitOfWork.Portfolio.GetCurrencyValueAsync(currency);
        }
    }
}
