using MyShop.Core.Interfaces;

namespace MyShop.Web.Middlewares
{
    internal class SaveCurrentUserMiddleware
    {
        public RequestDelegate _next;

        public SaveCurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            if (context.User is not null)
            {
                var currentUser = context.RequestServices.GetRequiredService<ICurrentUser>();
                currentUser?.Authenticate(context.User);
            }

            return _next(context);
        }
    }
}
