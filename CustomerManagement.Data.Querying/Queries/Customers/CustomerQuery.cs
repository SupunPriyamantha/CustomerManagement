using CustomerManagement.Domain.Infrastructure.Providers;
using CustomerManagement.Domain.Models.Cutomers;
using CustomerManagement.Domain.Models.Cutomers.Queries;
using CustomerManagement.Domain.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Data.Querying.Queries.Customers
{
    public class CustomerQuery : BaseQuery, ICustomerQuery
    {
        

        public CustomerQuery(IDbConnectionProvider dbConnectionProvider ): base(dbConnectionProvider)
        {
           
        }

        public async Task<CustomerQueryItem> GetCustomer(int id, CancellationToken cancellationToken)
        {
            return await QueryFirstOrDefaultAsync<CustomerQueryItem>(
                $@"
                SELECT 
                     ""CustomerId"", 
                    ""Name"", 
                    ""Phone"",
                    ""DateCreated""
                FROM 
                    ""Customers"" 
                WHERE 
                    ""CustomerId"" = @id"
                , new { id },
                cancellationToken);
        }


        public async Task<ListQueryResponse<CustomerQueryItem>> GetCutomerList(CancellationToken cancellationToken)
        {

            List<dynamic> customers = await QueryAsync<dynamic>(
               $@"
                SELECT 
                    ""CustomerId"", 
                    ""Name"", 
                    ""Phone"",
                    ""DateCreated""
                FROM 
                    ""Customers"""
               , new object()
               , cancellationToken);

            return new ListQueryResponse<CustomerQueryItem>()
            {
                Items = customers.Select(customer => new CustomerQueryItem(customer.CustomerId, customer.Name, customer.Phone, customer.DateCreated)).ToList()
            };

        }

        //public async Task<IEnumerable<CustomerQueryItem>> GetCutomerList(CancellationToken cancellationToken)
        //{

        //     return await QueryAsync<CustomerQueryItem>(
        //        $@"
        //        SELECT 
        //            ""CustomerId"", 
        //            ""Name"", 
        //            ""Phone"",
        //            ""DateCreated""
        //        FROM 
        //            ""Customers"""
        //        , new object()
        //        ,cancellationToken);

        //}
    }
}
