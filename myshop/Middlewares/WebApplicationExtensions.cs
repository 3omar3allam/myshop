namespace MyShop.Web.Middlewares
{
    internal static class WebApplicationExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this WebApplication app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseCurrentUser(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SaveCurrentUserMiddleware>();
        }
    }
}
