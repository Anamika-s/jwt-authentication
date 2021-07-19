using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDBAPI.Models;
using MongoDBAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDBAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository repo;
        public CustomerController(ICustomerRepository _repo)
        {
            repo = _repo;
        }
        // GET: api/<CustomerController>
        [Authorize(Roles = "admin")]
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return repo.GetCustomers();
        }

        // GET api/<CustomerController>/5
        [Authorize(Roles = "user")]
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return repo.GetCustomer(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            repo.AddCustomer(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            repo.UpdateCustomer(id, customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.DeleteCustomer(id);
        }
    }
}
