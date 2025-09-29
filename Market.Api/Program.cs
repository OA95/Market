using Market.Application.Query;
using Market.Domain.Interfaces;
using Market.Domain.Repositories;
using Market.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MarketDBContext>(options =>
{
    string mariaDbConnectionString = builder.Configuration.GetConnectionString("MarketDbConnection");
    options.UseMySql(mariaDbConnectionString, ServerVersion.Create(Version.Parse("12.0.2"), ServerType.MariaDb), sql =>
    {
        sql.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), new List<int>());
    });

    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(GetAllProductQuery).Assembly);
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
