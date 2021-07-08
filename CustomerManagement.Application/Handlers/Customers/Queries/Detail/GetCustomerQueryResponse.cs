using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers.Customers.Queries.Detail
{
    public class GetCustomerQueryResponse : BaseResponse
    {
        public GetCustomerQueryResponse(
            int id,
            string name,
            string phone,
            DateTime dateCreated)
        {
            CustomerId = id;
            Name = name;
            Phone = phone;
            DateCreated = dateCreated;
        }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
