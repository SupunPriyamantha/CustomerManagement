using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Models.Customers.Commands
{
    public class CreateCustomerCommand
    {
        public string Name { get; set; }
        public string Phone { get; set; }

    }
}
