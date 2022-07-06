using System;
using System.Security.Claims;

namespace MyShop.Core.Interfaces
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        string? UserId { get; }
        string? Username { get; }
        string? Email { get; }
        string? DisplayName { get; }
        List<string> Roles { get; }
        bool IsAdmin { get; }

        void Authenticate(ClaimsPrincipal principal);
    }
}
