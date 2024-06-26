﻿using CryptoExchange.Domain.Dto;
using Transaction = CryptoExchange.Domain.Models.Transaction;

namespace CryptoExchange.Logic.Interfaces
{
    public interface ITransactionService
    {
        public Task<TransactionGetDto> CreateTransaction(TransactionPostDto transaction);

        Task<IEnumerable<TransactionGetDto>> GetAllTransactions();

        Task<Transaction> GetTransactionById(int transactionId);

        Task<bool> UpdateTransaction(Transaction transactionDetails);

        Task<decimal> Convert(ConversionDto value);

        Task<decimal> GetAmountFromTo(string from, string to, decimal value);
        Task<TransactionDto> CreateTransactionFromExternalAsync(ExternalTransactionDto externalTransactionDto);

    }
}
