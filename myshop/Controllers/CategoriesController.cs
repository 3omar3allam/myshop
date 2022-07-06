using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.Common.Models.Products;
using MyShop.Core.Interfaces;
using System.Net;

namespace MyShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("", Name = nameof(GetCategories))]
        [ProducesResponseType(typeof(IList<CategoryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.GetCategoriesAsync(cancellationToken));
        }
    }
}
