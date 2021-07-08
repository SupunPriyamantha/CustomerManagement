using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Models.Queries
{
    public class ListQueryResponse<T>
    {
        public ListQueryResponse()
        {
            Items = new List<T>();
        }

        public ListQueryResponse(List<T> items, int count)
        {
            Items = items;
            Count = count;
        }

        public List<T> Items { get; set; }

        public int Count { get; set; }
    }
}
