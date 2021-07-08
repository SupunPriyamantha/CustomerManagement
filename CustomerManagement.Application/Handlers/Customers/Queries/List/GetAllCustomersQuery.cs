using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers.Customers.Queries.List
{
    public class GetAllCustomersQuery : IRequest<BaseResponse>
    {
        public int CustomerId { get; set; }
    }
}
