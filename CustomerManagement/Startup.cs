using Autofac;
using CustomerManagement.Application;
using CustomerManagement.Application.Customers;
using CustomerManagement.Application.Handlers;
using CustomerManagement.Application.Handlers.Customers.Queries.Detail;
using CustomerManagement.AutofacModules;
using CustomerManagement.Data;
using CustomerManagement.Data.Querying.Providers;
using CustomerManagement.Data.Repositories;
using CustomerManagement.Domain.Infrastructure.Providers;
using CustomerManagement.Domain.Models.Cutomers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CustomerManagement
{
    public class Startup
    {
        //private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //_env = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddEnvironmentService(_env);
            ConfigureDbContextServices(services);

            //services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            //services.AddScoped<ICustomerRepository, CutomerRepository>();

            services.AddMediatR(typeof(BaseResponse).GetTypeInfo().Assembly);


            //services.AddMediatR(typeof(CreateCustomerCommand).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(UpdateCustomerCommand).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(GetCustomerQuery).GetTypeInfo().Assembly);

            services.AddControllers();

            services.AddAutoMapper(
               options =>
               {
                   options.AllowNullCollections = true;
               },
                Assembly.GetAssembly(typeof(Startup)),
                Assembly.GetAssembly(typeof(Application.Handlers.BaseResponse)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerManagement", Version = "v1" });
            });
        }

        //public void ConfigureContainer(ContainerBuilder builder)
        //{

        //    builder.RegisterModule<MediatorModule>();
        //}
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<PersistenceModule>();
            builder.RegisterType<DbConnectionProvider>().As<IDbConnectionProvider>().InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerManagement v1"));
            }

            //app.UseSerilogEnrichmentLogging();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDbContextServices(IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options =>
            //{
            //    string connection = Configuration.GetConnectionString("DefaultConnection");
            //    options.UseNpgsql(
            //        connection,
            //        npgsqlOptionsAction: sqlOptions =>
            //        {
            //            sqlOptions.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name);
            //        });
            //});
            services.AddDbContext<AppDbContext>(
               options => options.UseNpgsql(
                   Configuration.GetConnectionString("DefaultConnection"),
                   npgsqlOptionsAction: sqlOptions =>
                   {
                       sqlOptions.MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name);
                   }));
        }
    }
}
