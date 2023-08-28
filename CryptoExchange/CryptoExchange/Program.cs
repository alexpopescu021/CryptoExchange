using CryptoExchange.Logic.Aggregates;
using CryptoExchange.Logic.Interfaces;
using CryptoExchange.Repository;
using CryptoExchange.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// TODO: make it generic/ take profilers automatically
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()?.CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<DatabaseContext>();
    context?.Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
