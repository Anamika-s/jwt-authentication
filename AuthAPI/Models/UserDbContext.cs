using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthAPI.Models
{
    public class UserDbContext
    {
        MongoClient client;
        IMongoDatabase database;

        public UserDbContext(IConfiguration configuration)
        {
            client = new MongoClient(configuration.GetConnectionString("MongoDBConnection"));
            database = client.GetDatabase(configuration.GetSection("MongoDatabase").Value);
        }

        public IMongoCollection<User> Users => database.GetCollection<User>("Users");
    }
}
