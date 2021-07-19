using MongoDBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDBAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext context;

        public CustomerRepository(DataContext _context)
        {
            context = _context;
        }
        public void AddCustomer(Customer customer)
        {
            context.Customers.InsertOne(customer);
        }

        public void DeleteCustomer(int id)
        {
            context.Customers.DeleteOne(c => c.Id == id);
        }

        public Customer GetCustomer(int id)
        {
            return context.Customers.Find(c => c.Id == id).FirstOrDefault();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return context.Customers.Find(c => c.Email == email).FirstOrDefault();
        }

        public List<Customer> GetCustomers()
        {
            return context.Customers.Find(c => true).ToList();
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            var filter = Builders<Customer>.Filter.Where(c => c.Id == id);
            var update = Builders<Customer>.Update.Set(c => c.Name, customer.Name)
                .Set(c => c.Email, customer.Email)
                .Set(c => c.City, customer.City)
                .Set(c => c.Age, customer.Age);
            context.Customers.UpdateOne(filter, update);
        }
    }
}
