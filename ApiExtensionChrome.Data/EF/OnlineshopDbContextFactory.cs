using ApiExtensionChrome.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration.Json;
using System.IO;
using System.Text;

namespace ApiExtensionChrome.EF
{
    public class OnlineShopDbContextFactory : IDesignTimeDbContextFactory<OnlineShopContext>
    {
        public OnlineShopContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();

            var connectionString = configuration.GetConnectionString("OnlineShopNew");

            var optionsBuilder = new DbContextOptionsBuilder<OnlineShopContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new OnlineShopContext(optionsBuilder.Options);
        }
    }
}
