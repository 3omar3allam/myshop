using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyShop.Core.Common.Models.Products;
using MyShop.Core.Entities;
using MyShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IList<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken)
        {
            var query = _categoryRepository.Table
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider);
            return await _categoryRepository.ToListAsync(query, cancellationToken);
        }
    }
}
