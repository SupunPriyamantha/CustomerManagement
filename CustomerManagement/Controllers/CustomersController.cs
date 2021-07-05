using CustomerManagement.Application;
using CustomerManagement.Application.Customers;
using CustomerManagement.Domain.Models;
using CustomerManagement.Domain.Models.Cutomers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepository.Get(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }
           
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return Ok(customers);
        } 

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            //var customer = new Customer
            //{
            //    Name = createCustomerDto.Name,
            //    Phone = createCustomerDto.Phone,
            //    DateCreated = DateTime.Now
            //};

            Customer customer = new()
            {
                Name = createCustomerDto.Name,
                Phone = createCustomerDto.Phone,
                DateCreated = DateTime.Now
            };

            await _customerRepository.Add(customer);
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _customerRepository.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateCustomer(int id, UpdateCustomerDto updateCustomerDto)
        {
            Customer customer = new()
            {
                CustomerId = id,
                Name = updateCustomerDto.Name,
                Phone = updateCustomerDto.Phone
            };

            await _customerRepository.Update(customer);
            return Ok();
        }
    }
}
