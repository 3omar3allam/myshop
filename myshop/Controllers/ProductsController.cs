using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.Common;
using MyShop.Core.Common.Models;
using MyShop.Core.Common.Models.Products;
using MyShop.Core.Entities;
using MyShop.Core.Interfaces;
using System.Net;

namespace MyShop.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("", Name = nameof(GetProducts))]
        [ProducesResponseType(typeof(IList<ProductDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts(int? categoryId, CancellationToken cancellationToken)
        {
            return Ok(await _productService.GetProductsAsync(categoryId, cancellationToken));
        }

        [HttpPost]
        [Route("", Name =nameof(CreateProduct))]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.AdminRoleName)]
        public async Task<IActionResult> CreateProduct(CreateOrUpdateProductRequest dto, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(dto);
            await _productService.CreateProductAsync(product, cancellationToken);
            return Ok(product.Id);
        }

        [HttpPut]
        [Route("", Name = nameof(UpdateProduct))]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.AdminRoleName)]
        public async Task<IActionResult> UpdateProduct(CreateOrUpdateProductRequest dto, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(dto);
            await _productService.UpdateProduct(product, cancellationToken);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}", Name = nameof(DeleteProduct))]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Constants.Roles.AdminRoleName)]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            await _productService.DeleteProduct(id, cancellationToken);
            return NoContent();
        }
    }
}
