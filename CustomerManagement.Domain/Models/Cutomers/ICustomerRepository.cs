using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Models.Cutomers
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(int id);

        Task<IEnumerable<Customer>> GetAll();

        Task Add(Customer customer);

        Task Delete(int id);

        Task Update(Customer customer);
    }
}
