using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Models
{
    public class ListResponse<T> : BaseResponse
    {
        public IEnumerable<T> Items { get; set; }
    }
}
