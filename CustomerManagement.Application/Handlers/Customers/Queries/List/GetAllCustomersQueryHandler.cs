using CustomerManagement.Domain.Models.Cutomers;
using CustomerManagement.Domain.Models.Cutomers.Queries;
using CustomerManagement.Domain.Models.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers.Customers.Queries.List
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, BaseResponse>
    {
        private readonly ICustomerQuery _customerQuery;

        public GetAllCustomersQueryHandler(ICustomerQuery customerQuery)
        {
            _customerQuery = customerQuery;
        }

        public async Task<BaseResponse> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            ListQueryResponse<CustomerQueryItem> customerQueryItemList = await _customerQuery.GetCutomerList(cancellationToken);

            return new GetAllCustomersQueryResponse
            {
                Items = customerQueryItemList.Items
            };
        }
    }
}
