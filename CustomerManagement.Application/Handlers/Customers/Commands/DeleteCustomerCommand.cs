using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers.Customers.Commands
{
    public class DeleteCustomerCommand : IRequest<BaseResponse>
    {
        public int CustomerId { get; set; }
    }
}
