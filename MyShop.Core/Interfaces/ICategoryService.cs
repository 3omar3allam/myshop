using MyShop.Core.Common.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<IList<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken);
    }
}
