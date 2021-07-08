using CustomerManagement.Domain.Models;
using CustomerManagement.Domain.Models.Cutomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers.Customers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<BaseResponse> Handle(CreateCustomerCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            
            Customer customer = new()
            {
                Name = command.Name,
                Phone = command.Phone,
                DateCreated = DateTime.Now
            };

            await _customerRepository.Add(customer);
            return new CreatedResponse(customer.CustomerId);
        }

    }
}
