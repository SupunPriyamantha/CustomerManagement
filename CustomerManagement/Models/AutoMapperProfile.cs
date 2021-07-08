using AutoMapper;
using CustomerManagement.Application.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Application.Handlers.BaseResponse, BaseResponse>()
                .Include<Application.Handlers.SuccessResponse, SuccessResponse>()
                .Include<Application.Handlers.CreatedResponse, CreatedResponse>()
                .Include<Application.Handlers.NotFoundResponse, NotFoundResponse>()
                .Include(typeof(Application.Handlers.ListResponse<>), typeof(ListResponse<>));

            CreateMap<Application.Handlers.SuccessResponse, SuccessResponse>();
            CreateMap<Application.Handlers.CreatedResponse, CreatedResponse>();
            CreateMap<Application.Handlers.NotFoundResponse, NotFoundResponse>();
            CreateMap(typeof(Application.Handlers.ListResponse<>), typeof(ListResponse<>));
        }
    }
    
}
