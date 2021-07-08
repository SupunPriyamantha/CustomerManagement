using Autofac;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomerManagement.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<Application.Events.DomainEventHandlers.MediatorDomainEventDispatcher>().As<IDomainEventDispatcher>().InstancePerLifetimeScope();
            //builder.RegisterType<Application.Events.DirectEventHandlers.MediatorDirectEventHandler>().As<IDirectEventDispatcher>().InstancePerLifetimeScope();
            //builder.RegisterType<Application.Events.IntegrationEventHandlers.MediatorIntegrationEventDispatcher>().As<IIntegrationEventDispatcher>().InstancePerLifetimeScope();

            // Mediator itself
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            // Register all application commands and query handlers

            builder.RegisterAssemblyTypes(typeof(Application.Handlers.BaseResponse).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
        }
    }
}
