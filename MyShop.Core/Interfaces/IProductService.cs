using MyShop.Core.Common.Models.Products;
using MyShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Interfaces
{
    public interface IProductService
    {
        Task<IList<ProductDto>> GetProductsAsync(int? categoryId = null, CancellationToken cancellationToken = default);
        Task CreateProductAsync(Product product, CancellationToken cancellationToken);
        Task UpdateProduct(Product product, CancellationToken cancellationToken);
        Task DeleteProduct(int productId, CancellationToken cancellationToken);
    }
}
