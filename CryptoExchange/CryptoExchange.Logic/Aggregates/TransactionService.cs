using AutoMapper;
using CryptoExchange.Domain.Dto;
using CryptoExchange.Domain.Models;
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
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICurrencyValueRepository _currencyValueRepository;
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, ICryptoProvider cryptoProvider, ICurrencyValueRepository currencyValueRepository, ICurrencyRepository currencyRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cryptoProvider = cryptoProvider;
            _currencyValueRepository = currencyValueRepository;
            _currencyRepository = currencyRepository;
        }
        public async Task<TransactionGetDto> CreateTransaction(TransactionPostDto transactionDto)
        {

            var sourceCurrency = await _unitOfWork.Currencies.GetByCodeAsync(transactionDto.SourceCurrencyCode);
            var targetCurrency = await _unitOfWork.Currencies.GetByCodeAsync(transactionDto.TargetCurrencyCode);

            var transaction = _mapper.Map<Transaction>(transactionDto);

            transaction.SourceCurrencyId = sourceCurrency!.Id;
            transaction.TargetCurrencyId = targetCurrency!.Id;
            transaction.UserId = 1;
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

        public async Task<decimal> Convert(ConversionDto value)
        {
            // Retrieve the current values for the source and target currencies
            var sourceCurrencyValue = _currencyValueRepository
                .GetByCurrencyCodeAndPortfolioIdAsync(value.SourceCurrencyCode, 1);

            // Attempt to retrieve the target currency value
            var targetCurrencyValue = _currencyValueRepository
                .GetByCurrencyCodeAndPortfolioIdAsync(value.TargetCurrencyCode, 1);

            if (sourceCurrencyValue == null)
            {
                throw new Exception("Source currency not found");
            }

            if (targetCurrencyValue == null)
            {
                var currency = await _currencyRepository.GetByCodeAsync(value.TargetCurrencyCode);
                // If target currency value is not found, insert a new record
                targetCurrencyValue = new CurrencyValue
                {
                    PortfolioId = 1, // Adjust as needed
                    CurrencyId = currency.Id, // You need to implement this method to get currency ID
                    Value = value.TargetValue // Set initial value
                };

                await _unitOfWork.CurrencyValues.CreateAsync(targetCurrencyValue);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                // Update the target currency value
                targetCurrencyValue.Value += value.TargetValue;
            }

            // Update the source currency value
            sourceCurrencyValue.Value -= value.SourceValue;
            // _unitOfWork.CurrencyValues.Update(sourceCurrencyValue);

            //await _unitOfWork.SaveChangesAsync();

            // Create a transaction from the ConversionDto values
            var transactionDto = new TransactionPostDto
            {
                SourceCurrencyCode = value.SourceCurrencyCode,
                TargetCurrencyCode = value.TargetCurrencyCode,
                TransactionDate = DateTime.UtcNow, // You may adjust the transaction date as needed
                SourcePrice = value.SourceValue,
                TargetPrice = value.TargetValue
            };

            await CreateTransaction(transactionDto);

            return targetCurrencyValue.Value;
        }


        public async Task<decimal> GetAmountFromTo(string from, string to, decimal value)
        {
            return await _cryptoProvider.GetConversionAmountFromTo(from, to, value);
        }
    }
}
