using Catalog.Api.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

namespace Catalog.Api.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {  
            var client = new MongoClient(configuration.GetValue<String>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<String>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<String>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
