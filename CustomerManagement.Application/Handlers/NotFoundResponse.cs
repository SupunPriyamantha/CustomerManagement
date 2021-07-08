using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Handlers
{
    public class NotFoundResponse :BaseResponse
    {
        public NotFoundResponse(string message)
        {
            Message = message;
        }

        public NotFoundResponse()
        {
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }

    public class NotFoundResponse<T> : BaseResponse
    where T : class
    {
        public NotFoundResponse()
        {
            Message = $"{typeof(T).Name} not found";
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
