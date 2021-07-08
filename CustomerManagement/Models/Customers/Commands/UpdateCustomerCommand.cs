using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Models.Customers.Commands
{
    public class UpdateCustomerCommand
    {
        //public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
    }
}
