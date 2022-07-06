using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Common.Models.Orders
{
    public class CreateOrderResponse
    {
        public int OrderId { get; set; }
        public bool RegistrationNeeded { get; set; }
    }
}
