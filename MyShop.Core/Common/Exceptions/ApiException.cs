using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Common.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(int statusCode) : base("Request failed.")
        {
            StatusCode = statusCode;
        }
        public ApiException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
    }
}
