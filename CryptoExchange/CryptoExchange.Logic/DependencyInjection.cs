using CryptoExchange.Logic.Aggregates;
using CryptoExchange.Logic.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoExchange.Logic;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICurrencyService, CurrencyService>();
        services.AddScoped<ICryptoProvider, CryptoProvider>();
        services.AddScoped<IPortofolioService, PortofolioService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHelper, PasswordHelper>();
        return services;
    }
}
