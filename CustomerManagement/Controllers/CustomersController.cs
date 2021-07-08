using AutoMapper;
using CustomerManagement.Application;
using CustomerManagement.Application.Customers;
using CustomerManagement.Domain.Models;
using CustomerManagement.Domain.Models.Cutomers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CustomersController(ICustomerRepository customerRepository, IMapper mapper, IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
            _mapper = mapper;
            
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        //{
        //    var customer = await _customerRepository.Get(id);
        //    if (customer == null)
        //        return NotFound();

        //    return Ok(customer);
        //}


        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(int id, CancellationToken cancellationToken)
        {
            var applicationQuery = new Application.Handlers.Customers.Queries.Detail.GetCustomerQuery() { CustomerId = id };
            var applicationResult = await _mediator.Send(applicationQuery, cancellationToken);

            var result = _mapper.Map<Models.BaseResponse>(applicationResult);

            //var customer = await _customerRepository.Get(id);
            //if (customer == null)
            //    return NotFound();

            return Ok(result);
        }

        //[MapToApiVersion("1.0")]
        //[Authorize(Policy = Policies.TenantUser)]
        //[HttpGet("{id:Guid}")]
        //[ValidateModel]
        //public async Task<IActionResult> GetAddOnGroupDetail([FromRoute] Guid tenantId, [FromRoute] Guid id, CancellationToken cancellationToken)
        //{
        //    var applicationQuery = new Application.Handlers.Products.AddOnGroups.Queries.Detail.DetailAddOnGroupQuery() { Id = id, TenantId = tenantId };
        //    var applicationResult = await _mediator.Send(applicationQuery, cancellationToken);

        //    BaseResponse result;
        //    if (applicationResult is Application.Handlers.Products.AddOnGroups.Queries.Detail.DetailAddOnGroupQueryResponse)
        //    {
        //        result = (BaseResponse)_mapper.Map(applicationResult, applicationResult.GetType(), typeof(Models.V1.V0.Products.AddOnGroups.Queries.Detail.DetailAddOnGroupQueryResponse));
        //    }
        //    else
        //    {
        //        result = (BaseResponse)_mapper.Map(applicationResult, applicationResult.GetType(), typeof(BaseResponse));
        //    }

        //    return ToActionResult(result);
        //}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(CancellationToken cancellationToken)
        {
            var applicationQuery = new Application.Handlers.Customers.Queries.List.GetAllCustomersQuery();
            var applicationResult = await _mediator.Send(applicationQuery, cancellationToken);

            var result = _mapper.Map<Models.BaseResponse>(applicationResult);

            return Ok(result);
        } 

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(Models.Customers.Commands.CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            //var customer = new Customer
            //{
            //    Name = createCustomerDto.Name,
            //    Phone = createCustomerDto.Phone,
            //    DateCreated = DateTime.Now
            //};

            var applicationCommand = _mapper.Map<Application.CreateCustomerCommand > (command);

            var applicationResult = await _mediator.Send(applicationCommand, cancellationToken);
            var result = _mapper.Map<Models.BaseResponse>(applicationResult);


            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            var applicationCommand = new Application.Handlers.Customers.Commands.DeleteCustomerCommand()
            {
                CustomerId = id
            };
            var applicationResult = await _mediator.Send(applicationCommand, cancellationToken);
            var result = _mapper.Map<Models.BaseResponse>(applicationResult);

            //await _customerRepository.Delete(id);
            return Ok(result);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateCustomer(int id, Models.Customers.Commands.UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var applicationCommand = _mapper.Map<Application.Customers.UpdateCustomerCommand>(command);
            applicationCommand.CustomerId = id;

            //Customer customer = new()
            //{
            //    CustomerId = id,
            //    Name = applicationCommand.Name,
            //    Phone = applicationCommand.Phone
            //};

            var applicationResult = await _mediator.Send(applicationCommand, cancellationToken);
            var result = _mapper.Map<Models.BaseResponse>(applicationResult);

            //await _customerRepository.Update(customer);
            return Ok(result);
        }
    }
}
