using CryptoExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoExchange.Repository
{
    public class DatabaseContext : DbContext
    {
        private const string ConnectionString = "Server=localhost; Integrated Security=SSPI; Database=Crypto; TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(ConnectionString);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasMany(e => e.SourceTransactions)
                .WithOne(e => e.SourceCurrency)
                .HasForeignKey(e => e.SourceCurrencyId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Currency>()
                .HasMany(e => e.TargetTransactions)
                .WithOne(e => e.TargetCurrency)
                .HasForeignKey(e => e.TargetCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(e => e.User)
                .WithMany(e => e.Transactions)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<ExternalTransaction> ExternalTransactions { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }


    }
}
