using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Common
{
    public class Response: IResponse
    {
        public Response(ResponseType type)
        {
            ResponseType = type;
        }
        public Response(ResponseType type,string message)
        {
            ResponseType = type;
            Message = message;
        }

        public string Message { get; set; }
        public ResponseType ResponseType { get; set; }
    }
    public enum ResponseType
    {
        Success,
        NotFound,
        ValidationError,
        Error
    }
}
