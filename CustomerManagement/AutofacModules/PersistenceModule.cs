using Autofac;
using CustomerManagement.Data.Querying.Queries.Customers;
using CustomerManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.AutofacModules
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            
            builder.RegisterAssemblyTypes(typeof(CutomerRepository).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(CustomerQuery).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
