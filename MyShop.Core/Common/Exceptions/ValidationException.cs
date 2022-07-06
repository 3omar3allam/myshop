using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
            Errors = new();
        }

        public ValidationException() : base("Bad request.")
        {
            Errors = new();
        }

        public Dictionary<string, string[]> Errors { get; set; }
    }
}
