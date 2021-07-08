using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers
{
    public class ListResponse<T> : BaseResponse
        where T : new()
    {
        public IEnumerable<T> Items { get; set; }
    }
}
