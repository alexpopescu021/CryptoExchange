using CryptoExchange.Logic;
using CryptoExchange.Logic.Aggregates;
using CryptoExchange.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// TODO: make it generic/ take profilers automatically
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(TransactionProfile)));

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();

builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();

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
app.UseCors(corsPolicyBuilder => corsPolicyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()); app.UseHttpsRedirection();
app.UseCors("ApiCorsPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
