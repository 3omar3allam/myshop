using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace MyShop.Web.Filters
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        public ApiAuthorizeAttribute() : base()
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }

        public ApiAuthorizeAttribute(string policy) : base(policy)
        {
            AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme;
        }
    }
}
