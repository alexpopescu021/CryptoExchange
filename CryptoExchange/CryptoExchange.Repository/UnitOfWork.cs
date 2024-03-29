﻿using CryptoExchange.Repository.Interfaces;

namespace CryptoExchange.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public ITransactionRepository Transactions { get; }
        public ICurrencyRepository Currencies { get; }
        public IUserRepository Users { get; }
        public UnitOfWork(DatabaseContext dbContext,
            ITransactionRepository transactionRepository, IUserRepository users, ICurrencyRepository currencies)
        {
            _context = dbContext;
            Transactions = transactionRepository;
            Users = users;
            Currencies = currencies;
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
