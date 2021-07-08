using AutoMapper.Configuration;
using CustomerManagement.Domain.Infrastructure.Providers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CustomerManagement.Data.Querying.Providers
{
    public class DbConnectionProvider : IDbConnectionProvider
    {
        private string _connectionString;

        
        public DbConnectionProvider(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(ConnectionStrings.DefaultConnectionString);
            
            /* _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString*/
            ;
        }
        //public IConfiguration Configuration { get; }

        public IDbConnection GetConnection()
        {
            return new Npgsql.NpgsqlConnection(_connectionString);
        }
    }
}
