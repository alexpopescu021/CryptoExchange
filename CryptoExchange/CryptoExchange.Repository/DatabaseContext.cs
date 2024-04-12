using CryptoExchange.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoExchange.Repository
{
    public class DatabaseContext : DbContext
    {
        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Crypto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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

            modelBuilder.Entity<Transaction>()
                .Property(t => t.TransactionDate)
                .HasDefaultValueSql("getdate()");

            //modelBuilder.Entity<Transaction>()
            //    .Property(t => t.ConversionRate)
            //    .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaction>()
                .ToTable("Transactions");


            modelBuilder.Entity<User>()
                .HasData(
                    new User()
                    {
                        Id = 1,
                        Address = "test address",
                        EmailAddress = "email",
                        TelephoneNumber = "028172612",
                        Username = "username",
                        PasswordHash = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 },
                        PasswordSalt = new byte[] { 0x06, 0x07, 0x08, 0x09, 0x10 },
                        LastName = "LastName",
                        FirstName = "FirstName",
                    });
            modelBuilder.Entity<Currency>()
                .HasData(
                    new Currency()
                    {
                        Id = 1,
                        CurrencyCode = "EUR",
                        IsFiat = true
                    });
            modelBuilder.Entity<Currency>()
                .HasData(
                    new Currency()
                    {
                        Id = 2,
                        CurrencyCode = "USD",
                        IsFiat = true
                    });

            modelBuilder.Entity<Transaction>(t =>
            {
                t.HasData(new
                {
                    Id = 1,
                    UserId = 1,
                    SourceCurrencyId = 1,
                    TargetCurrencyId = 2,
                    ConversionRate = (decimal)3,
                    TransactionDate = DateTime.UtcNow,
                    SourcePrice = (decimal)100.00,
                    TargetPrice = (decimal)40.00,
                    //ConversionRate = (decimal)1.034
                });
            });

            modelBuilder.Entity<Portfolio>(t =>
            {
                t.HasData(new
                {
                    Id = 1,
                    UserId = 1,
                    CurrencyId = 1,
                    TransactionDate = DateTime.UtcNow,
                    Value = (decimal)123.00,
                    //ConversionRate = (decimal)1.034
                });
            });


        }

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<ExternalTransaction> ExternalTransactions { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<User?> Users { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }


    }
}
