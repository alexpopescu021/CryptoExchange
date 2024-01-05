using CryptoExchange.Domain.Dto;
using Transaction = CryptoExchange.Domain.Models.Transaction;

namespace CryptoExchange.Logic.Interfaces
{
    public interface ITransactionService
    {
        public Task<TransactionGetDto> CreateTransaction(TransactionPostDto transaction);

        Task<IEnumerable<TransactionGetDto>> GetAllTransactions();

        Task<Transaction> GetTransactionById(int transactionId);

        Task<bool> UpdateTransaction(Transaction transactionDetails);

        Task<double> Convert(string convertFromSymbol, string convertToSymbol, double amount);

    }
}
