using AutoMapper;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Logic.Interfaces;
using CryptoExchange.Repository.Interfaces;
using Transaction = CryptoExchange.Domain.Models.Transaction;

namespace CryptoExchange.Logic.Aggregates
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
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
            var transactions = await _unitOfWork.Transactions.GetAllAsync();
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

    }
}
