using CustomerManagement.Application.Handlers.Customers.Queries.Detail;
using CustomerManagement.Domain.Models.Cutomers;
using CustomerManagement.Domain.Models.Cutomers.Queries;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CustomerManagement.Application.Tests.Unit.Handlers.Customers.Queries
{
    public class GetCustomerQueryHandlerTest
    {
        private readonly GetCustomerQueryHandler getCustomerQueryHandler;
        private readonly Mock<ICustomerQuery> _customerQuery;
        private readonly int id = 1;
        public GetCustomerQueryHandlerTest()
        {
            _customerQuery = new Mock<ICustomerQuery>();
            _customerQuery.Setup(p => p.GetCustomer(It.IsAny<int>(), default(CancellationToken)))
                .Returns(Task.FromResult(new CustomerQueryItem()));

            getCustomerQueryHandler = new GetCustomerQueryHandler(_customerQuery.Object);
        }

        [Fact]
        [Category("Application")]
        public async void Handle_GivenValidInput_ReturnsCreatedResponse()
        {
            var query = new GetCustomerQuery()
            {
                CustomerId = id

            };

            var result = await getCustomerQueryHandler.Handle(query, default);
            result.Should().BeOfType<GetCustomerQueryResponse>();
        }
    }
}
