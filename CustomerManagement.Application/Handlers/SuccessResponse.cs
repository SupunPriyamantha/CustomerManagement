using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers
{
    public class SuccessResponse :BaseResponse
    {
        public SuccessResponse()
        {

        }

        public SuccessResponse(string message)
        {
            Message = message;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
