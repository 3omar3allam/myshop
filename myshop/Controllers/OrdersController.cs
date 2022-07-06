using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.Common;
using MyShop.Core.Common.Models;
using MyShop.Core.Common.Models.Orders;
using MyShop.Core.Interfaces;
using MyShop.Web.Filters;
using System.Net;

namespace MyShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiAuthorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("", Name = nameof(CreateOrder))]
        [ProducesResponseType(typeof(CreateOrderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest dto, CancellationToken cancellationToken)
        {
            return Ok(await _orderService.CreateOrderAsync(dto, cancellationToken));
        }

        [HttpGet]
        [Route("complete_order/{id}", Name = nameof(AssociateCustomerIdToOrder))]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Conflict)]
        public async Task<IActionResult> AssociateCustomerIdToOrder(int id, CancellationToken cancellationToken)
        {
            await _orderService.AssociateCustomerToOrderAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
