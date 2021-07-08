using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers.Customers.Queries.Detail
{
    public class GetCustomerModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
