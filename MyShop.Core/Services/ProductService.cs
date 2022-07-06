using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyShop.Core.Common.Exceptions;
using MyShop.Core.Common.Models.Products;
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
    internal class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public ProductService(IMapper mapper, IRepository<Product> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IList<ProductDto>> GetProductsAsync(int? categoryId, CancellationToken cancellationToken)
        {
            var query = _repository.Table.Where(p => p.IsDeleted != true && (categoryId == null || p.CategoryId == categoryId))
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider);
            return await _repository.ToListAsync(query, cancellationToken);
        }

        public async Task CreateProductAsync(Product product, CancellationToken cancellationToken)
        {
            product.Id = 0;
            await _repository.InsertAsync(product, cancellationToken);
        }

        public async Task UpdateProduct(Product product, CancellationToken cancellationToken)
        {
            var query = _repository
                .Join(p => p.Discount)
                .Where(p => p.Id == product.Id);
            var existingProduct = await _repository.FirstOrDefaultAsync(query, cancellationToken);
            if (existingProduct is null)
            {
                throw new ApiException("Product not found", (int)HttpStatusCode.NotFound);
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Discount = product.Discount;
            await _repository.UpdateAsync(existingProduct, cancellationToken);
        }

        public async Task DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            var product = await _repository.FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
            if (product is null)
            {
                throw new ApiException("Product not found", (int)HttpStatusCode.NotFound);
            }
            await _repository.DeleteAsync(product, cancellationToken);
        }
    }
}
