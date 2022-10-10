using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.AdvertisementApp.Common
{
    public class Response<T>:Response,IResponse<T>
    {
        public T Data { get; set; }
        public List<CustomValidationError> customValidationErrors  { get; set; }
        public Response(ResponseType type,string message):base(type,message)
        {

        }
        public Response(ResponseType type,T data):base(type)
        {
            Data = data;
        }
        public Response(T data,List<CustomValidationError> errors):base(ResponseType.ValidationError)
        {
            Data=data;
            customValidationErrors = errors;
        }
    }
}
