using MyShop.Core.Common.Models.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest dto, CancellationToken cancellationToken);

        Task AssociateCustomerToOrderAsync(int orderId, CancellationToken cancellationToken);
    }
}
