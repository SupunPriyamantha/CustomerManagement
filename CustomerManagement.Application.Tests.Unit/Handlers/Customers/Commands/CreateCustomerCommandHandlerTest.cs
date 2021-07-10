using CustomerManagement.Application.Handlers;
using CustomerManagement.Application.Handlers.Customers.Commands;
using CustomerManagement.Domain.Models;
using CustomerManagement.Domain.Models.Cutomers;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.Application.Tests.Unit.Handlers.Customers.Commands
{
    public class CreateCustomerCommandHandlerTest
    {
        private readonly CreateCustomerCommandHandler createCustomerCommandHandler;
        private readonly Mock<ICustomerRepository> _customerRepository;
        
        public CreateCustomerCommandHandlerTest()
        {
            Customer customer = new Customer();

            _customerRepository = new Mock<ICustomerRepository>();
            _customerRepository.Setup(s => s.Add(
                customer
                ))
                .Returns(Task.FromResult(1));

            createCustomerCommandHandler = new CreateCustomerCommandHandler(_customerRepository.Object);
        }

        [Fact]
        [Category("Application")]
        public async void Handle_GivenValidInput_ReturnsCreatedResponse()
        {
            var command = new CreateCustomerCommand()
            {
                Name = "Supun",
                Phone = "0775896325"
                
            };

            var result = await createCustomerCommandHandler.Handle(command, default);
            result.Should().BeOfType<CreatedResponse>();
        }
    }
}
