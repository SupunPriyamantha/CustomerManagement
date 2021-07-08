using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers
{
    public class CreatedResponse : BaseResponse
    {
        public CreatedResponse()
        {
            Id = 0;
        }

        public CreatedResponse(int createdId)
        {
            Id = createdId;
        }

        public int Id { get; private set; }
    }
}
