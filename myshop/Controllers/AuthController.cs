using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.Common.Exceptions;
using MyShop.Core.Common.Models;
using MyShop.Core.Entities;
using MyShop.Core.Interfaces;
using MyShop.Web.Models;
using System.Net;

namespace MyShop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("", Name = nameof(Login))]
        [ProducesResponseType(typeof(LoginSuccessResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login(LoginVM model, CancellationToken cancellationToken)
        {
            var response = await _authService.LoginAsync(model.UserName, model.Password, cancellationToken);
            if (response is null) throw new ApiException("Login failed", (int)HttpStatusCode.Unauthorized);
            AddSecureCookie("X-Access-Token", response.Token, response.ExpiresAt);
            return Ok(response);
        }

        [HttpPost]
        [Route("register", Name = nameof(RegisterCustomer))]
        [ProducesResponseType(typeof(LoginSuccessResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerVM model, CancellationToken cancellationToken)
        {
            var customer = _mapper.Map<ApplicationUser>(model);
            var response = await _authService.RegisterCustomerAsync(customer, model.Password, cancellationToken);
            if (response is null) throw new ApiException("Registration failed", (int)HttpStatusCode.Unauthorized);
            AddSecureCookie("X-Access-Token", response.Token, response.ExpiresAt);
            return Ok(response);
        }

        private void AddSecureCookie(string key, string value, DateTimeOffset? expires = null)
        {
            Response.Cookies.Append(key, value, new CookieOptions
            {
                HttpOnly = true,
                Expires = expires,
                SameSite = SameSiteMode.None,
                Secure = true,
            });
        }
    }
}
