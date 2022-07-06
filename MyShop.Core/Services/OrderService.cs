using MyShop.Core.Common.Exceptions;
using MyShop.Core.Common.Models.Orders;
using MyShop.Core.Entities;
using MyShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Services
{
    internal class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Discount> _discountRepository;
        private readonly ICurrentUser _currentUser;

        public OrderService(
            ICurrentUser currentUser,
            IRepository<Order> prderRepsitory,
            IRepository<Discount> discountRepository,
            IRepository<Product> productRepository)
        {
            _currentUser = currentUser;
            _orderRepository = prderRepsitory;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
        }

        public async Task AssociateCustomerToOrderAsync(int orderId, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FirstOrDefaultAsync(o => o.Id == orderId, cancellationToken);
            if (order is null)
            {
                throw new ApiException("Order not found", (int)HttpStatusCode.NotFound);
            }
            if (order.CustomerId is not null)
            {
                throw new ApiException("Order is already assigned to a customer", (int)HttpStatusCode.Conflict);
            }
            var customerId = _currentUser.IsAuthenticated ? _currentUser.UserId : null;
            if (customerId is null)
            {
                throw new ApiException((int)HttpStatusCode.Unauthorized);
            }
            order.CustomerId = customerId;
            await _orderRepository.UpdateAsync(order, cancellationToken);
        }

        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest dto, CancellationToken cancellationToken)
        {
            var customerId = _currentUser.IsAuthenticated ? _currentUser.UserId : null;

            var product = await _productRepository.FirstOrDefaultAsync(p => p.Id == dto.ProductId, cancellationToken);
            if (product is null)
            {
                throw new ApiException("Product not found", (int)HttpStatusCode.NotFound);
            }
            var discount = await _discountRepository.FirstOrDefaultAsync(p => p.ProductId == dto.ProductId && p.Quantity <= dto.Quantity, cancellationToken);
            var totalPrice = product.Price * dto.Quantity;
            if (discount is not null)
            {
                totalPrice *= (1 - discount.Percentage);
            }
            var order = new Order
            {
                CustomerId = customerId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                Price = totalPrice,
            };

            await _orderRepository.InsertAsync(order, cancellationToken);
            return new CreateOrderResponse
            {
                OrderId = order.Id,
                RegistrationNeeded = customerId == null,
            };
        }
    }
}
