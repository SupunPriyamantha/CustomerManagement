using CustomerManagement.Domain.Models.Cutomers;
using CustomerManagement.Domain.Models.Cutomers.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers.Customers.Queries.Detail
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, BaseResponse>
    {
         private readonly ICustomerQuery _customerQuery;

        public GetCustomerQueryHandler(ICustomerQuery customerQuery)
        {
            _customerQuery = customerQuery;
        }
        //public GetCustomerQueryHandler()
        //{
        //    _customerQuery = customerQuery;
        //}


        public async Task<BaseResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            CustomerQueryItem customerQueryItem = await _customerQuery.GetCustomer(request.CustomerId, cancellationToken);

            return new GetCustomerQueryResponse(
                    customerQueryItem.CustomerId,
                    customerQueryItem.Name,
                    customerQueryItem.Phone,
                    customerQueryItem.DateCreated);
            //return new SuccessResponce();

                
        }
    }
}
