using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Infrastructure.Providers
{
    public interface IDbConnectionProvider
    {
        IDbConnection GetConnection();
    }
}
