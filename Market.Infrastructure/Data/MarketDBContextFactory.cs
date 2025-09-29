using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Infrastructure.Data
{
    public class MarketDBContextFactory : IDesignTimeDbContextFactory<MarketDBContext>
    {
        public MarketDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MarketDBContext>();


            //var connectionString = "Server=localhost;Port=3306;Database=marketdb;User=root;Password=test;CharSet=utf8mb4;";
            //var connectionString = "Server=market-mariadb;Port=3307;Database=marketdb;Uid=market_user;Password=test;SslMode=None;";
            var connectionString = "Server=127.0.0.1;Port=3307;Database=marketdb;Uid=root;Pwd=test;"; 

            // Auto-détection de la version MariaDB/MySQL pour .NET 8
            //optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            optionsBuilder.UseMySql(connectionString,
            new MariaDbServerVersion(new Version(12,0,2)));

            return new MarketDBContext(optionsBuilder.Options);
        }
    }
}
