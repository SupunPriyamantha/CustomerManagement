using CustomerManagement.Domain.Models.Cutomers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers.Customers.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, BaseResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _customerRepository.Delete(command.CustomerId);
            
            return new SuccessResponse(command.CustomerId.ToString());
        }
    }
}
