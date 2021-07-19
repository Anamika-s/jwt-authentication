using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBAPI.Models
{
    public class DataContext
    {
        MongoClient client;
        IMongoDatabase database;

        public DataContext(IConfiguration configuration)
        {
            client = new MongoClient(configuration.GetConnectionString("MongoDBConnection"));
            database = client.GetDatabase(configuration.GetSection("MongoDatabase").Value);
        }

        public IMongoCollection<Customer> Customers => database.GetCollection<Customer>("Customers");
    }
}
