using MyShop.Core.Common.Models;
using MyShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Interfaces
{
    public interface IAuthService
    {
        Task<LoginSuccessResponse> LoginAsync(string username, string password, CancellationToken cancellationToken);
        Task<LoginSuccessResponse> RegisterCustomerAsync(ApplicationUser customer, string password, CancellationToken cancellationToken);
    }
}
