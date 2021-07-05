using CustomerManagement.Domain.Models;
using CustomerManagement.Domain.Models.Cutomers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Data.Repositories
{
    public class CutomerRepository : ICustomerRepository
    {
        private readonly IAppDbContext _context;

        public CutomerRepository(IAppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var customerToDelete = await _context.Customers.FindAsync(id);
            if (customerToDelete == null)
                throw new NullReferenceException();

            _context.Customers.Remove(customerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task Update(Customer customer)
        {
            var customerToUpdate = await _context.Customers.FindAsync(customer.CustomerId);
            if (customerToUpdate == null)
                throw new NullReferenceException();

            customerToUpdate.Name = customer.Name;
            customerToUpdate.Phone = customer.Phone;
            await _context.SaveChangesAsync();
        }
    }
}
