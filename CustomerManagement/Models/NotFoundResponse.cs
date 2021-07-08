using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Models
{
    public class NotFoundResponse : BaseResponse
    {
        public NotFoundResponse()
        {
        }

        public NotFoundResponse(string message)
        {
            Message = message;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }

    public class NotFoundResponse<T> : BaseResponse
    where T : class
    {
        public NotFoundResponse()
        {
            Message = $"{nameof(T)} not found";
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
