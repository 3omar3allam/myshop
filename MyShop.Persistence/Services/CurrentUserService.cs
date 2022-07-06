using Microsoft.AspNetCore.Http;
using MyShop.Core.Common;
using MyShop.Core.Interfaces;
using System.Security.Claims;
using System.Security.Principal;

namespace MyShop.Persistence.Services
{
    internal class CurrentUserService : ICurrentUser
    {
        public bool IsAuthenticated { get; private set; }
        public string? UserId { get; private set; }
        public string? Username { get; private set; }
        public string? Email { get; private set; }
        public string? DisplayName { get; private set; }
        public List<string> Roles { get; private set; }
        public bool IsAdmin => IsAuthenticated && Roles.Contains(Constants.Roles.AdminRoleName);

        public void Authenticate(ClaimsPrincipal user)
        {
            if (user?.Identity?.IsAuthenticated == true)
            {
                UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
                Email = user.FindFirstValue(ClaimTypes.Email);
                Username = user.FindFirstValue(ClaimTypes.Name);
                DisplayName = user.FindFirstValue(ClaimTypes.GivenName);
                Roles = user.FindAll(ClaimTypes.Role)
                    .Select(p => p.Value)
                    .ToList();
                if (UserId != null)
                {
                    IsAuthenticated = true;
                }
            }
            else
            {
                Roles = new List<string>(0);
            }
        }
    }
}
