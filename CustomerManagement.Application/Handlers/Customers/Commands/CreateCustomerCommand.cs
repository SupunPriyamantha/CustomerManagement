using CustomerManagement.Application.Handlers;
using MediatR;
using System;

namespace CustomerManagement.Application
{
    public class CreateCustomerCommand: IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
