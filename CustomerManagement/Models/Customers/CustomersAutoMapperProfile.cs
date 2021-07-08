using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Models.Customers
{
    public class CustomersAutoMapperProfile : Profile
    {
        public CustomersAutoMapperProfile()
        {
            CreateMap<Commands.CreateCustomerCommand, Application.CreateCustomerCommand>();
            CreateMap<Commands.UpdateCustomerCommand, Application.Customers.UpdateCustomerCommand>()
                .ForMember(dest => dest.CustomerId, opts => opts.Ignore());

            CreateMap<Application.Handlers.Customers.Queries.Detail.GetCustomerQueryResponse, Queries.Detail.GetCustomerQueryResponse>()
                .IncludeBase<Application.Handlers.BaseResponse, BaseResponse>();
            
            CreateMap<Application.Handlers.Customers.Queries.List.GetAllCustomersQueryResponse, Queries.List.GetAllCustomersQueryResponse>()
                .IncludeBase<Application.Handlers.BaseResponse, BaseResponse>();
            CreateMap<Domain.Models.Cutomers.Queries.CustomerQueryItem, Queries.List.GetAllCustomersModel>();

        }
    }
}
