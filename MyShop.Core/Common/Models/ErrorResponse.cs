using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Common.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
