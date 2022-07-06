using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyShop.Core.Common;
using MyShop.Core.Common.Exceptions;
using MyShop.Core.Common.Models;
using MyShop.Core.Entities;
using MyShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Persistence.Services
{
    internal class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HttpContext _httpContext;
        private readonly ICurrentUser _currentUser;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            ICurrentUser currentUser,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _httpContext = httpContextAccessor.HttpContext;
            _currentUser = currentUser;
            _configuration = configuration;
        }

        public async Task<LoginSuccessResponse> LoginAsync(string username, string password, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user is null)
            {
                throw new ApiException("Invalid username or password", (int)HttpStatusCode.Unauthorized);
            }
            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if (result != PasswordVerificationResult.Success)
            {
                throw new ApiException("Invalid username or password", (int)HttpStatusCode.Unauthorized);
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null || roles.Count == 0)
            {
                throw new ApiException("Your account is locked, please contact support team", (int)HttpStatusCode.Unauthorized);
            }
            return GenerateTokenResponse(user, roles);
        }

        public async Task<LoginSuccessResponse> RegisterCustomerAsync(ApplicationUser customer, string password, CancellationToken cancellationToken)
        {
            var result = await _userManager.CreateAsync(customer, password);
            if (!result.Succeeded)
            {
                throw new ApiException("Failed to create customer", (int)HttpStatusCode.BadRequest);
            }
            await _userManager.AddToRoleAsync(customer, Constants.Roles.CustomerRoleName);
            return GenerateTokenResponse(customer, new[] { Constants.Roles.CustomerRoleName });
        }

        private LoginSuccessResponse GenerateTokenResponse(ApplicationUser user, IList<string> roles)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.DisplayName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            foreach (var item in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, item));
            }

            var jwtSettings = _configuration.GetSection("JwtSettings");

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));

            var expiresAt = DateTime.UtcNow.Add(TimeSpan.Parse(jwtSettings["Lifetime"]));

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                expires: expiresAt,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return new LoginSuccessResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expiresAt,
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.DisplayName,
                Roles = roles,
            };
        }
    }
}
