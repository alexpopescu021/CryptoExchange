using AutoMapper;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Logic.Interfaces;
using CryptoExchange.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Transaction = CryptoExchange.Domain.Models.Transaction;

namespace CryptoExchange.Logic.Aggregates
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICryptoProvider _cryptoProvider;
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, ICryptoProvider cryptoProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cryptoProvider = cryptoProvider;
        }
        public async Task<TransactionGetDto> CreateTransaction(TransactionPostDto transactionDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionDto);

            // logic

            await _unitOfWork.Transactions.CreateAsync(transaction);

            await _unitOfWork.SaveChangesAsync();

            var transactionDb = await _unitOfWork.Transactions.GetAsync(transaction.Id);

            var result = _mapper.Map<TransactionGetDto>(transactionDb);

            return result;
        }

        public async Task<IEnumerable<TransactionGetDto>> GetAllTransactions()
        {
            var transactions = await _unitOfWork.Transactions.GetQuery()
                .Include(t => t.SourceCurrency)
                .Include(t => t.TargetCurrency)
                .Include(u => u.User)
                .ToListAsync();
            return _mapper.Map<IEnumerable<TransactionGetDto>>(transactions);
        }

        public async Task<Transaction> GetTransactionById(int transactionId)
        {
            return await _unitOfWork.Transactions.GetAsync(transactionId);
        }

        public async Task<bool> UpdateTransaction(Transaction transactionDetails)
        {
            _unitOfWork.Transactions.Update(transactionDetails);
            var updated = await _unitOfWork.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<double> Convert(string convertFromSymbol, string convertToSymbol, double amount)
        {
            var price = await _cryptoProvider.GetPrice(convertFromSymbol, convertToSymbol);

            price *= amount;
            var transactionFeeAmount = price * (double)(new Transaction().ConversionRate / 100);

            // Perform the conversion logic (replace this with your actual conversion logic)
            // For simplicity, let's assume it's a 1:1 conversion

            // If you have a specific conversion rate for each fiat currency, you can retrieve it here
            // Example: double conversionRate = fiatCurrency.ConversionRate;

            return Math.Round((price - transactionFeeAmount), 5);

        }
    }
}
