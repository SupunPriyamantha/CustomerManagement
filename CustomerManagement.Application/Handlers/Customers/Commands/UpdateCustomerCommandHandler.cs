using CustomerManagement.Application.Handlers;
using CustomerManagement.Domain.Models;
using CustomerManagement.Domain.Models.Cutomers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, BaseResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            Customer customer = new()
            {
                CustomerId = command.CustomerId,
                Name = command.Name,
                Phone = command.Phone
            };

            await _customerRepository.Update(customer);
            
            return new SuccessResponse(customer.Name);

            //return new SuccessResponce();
        }
    }
}
