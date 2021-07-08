using CustomerManagement.Domain.Models.Cutomers.Queries;
using CustomerManagement.Domain.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Models.Cutomers
{
    public interface ICustomerQuery
    {
        Task<CustomerQueryItem> GetCustomer(int id, CancellationToken cancellationToken);

        Task<ListQueryResponse<CustomerQueryItem>> GetCutomerList(CancellationToken cancellationToken);
    }
}
