using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Models.Cutomers.Queries
{
    public class CustomerQueryItem
    {
        public CustomerQueryItem(
                int customerId,
                string name,
                string phone,
                DateTime dateCreated

            )
        {
            CustomerId = customerId;
            Name = name;
            Phone = phone;
            DateCreated = dateCreated;
        }
        public CustomerQueryItem()
        {

        }

        public int CustomerId { get; }
        public string Name { get;  }
        public string Phone { get;  }
        public DateTime DateCreated { get; }
    }
}
