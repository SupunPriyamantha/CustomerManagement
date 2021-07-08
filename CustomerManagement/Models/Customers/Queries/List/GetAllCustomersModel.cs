using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Models.Customers.Queries.List
{
    public class GetAllCustomersModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
