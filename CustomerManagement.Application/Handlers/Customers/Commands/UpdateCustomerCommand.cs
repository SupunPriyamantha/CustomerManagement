using CustomerManagement.Application.Handlers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Customers
{
    public class UpdateCustomerCommand : IRequest<BaseResponse>
    {
        public int CustomerId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

    }
}
