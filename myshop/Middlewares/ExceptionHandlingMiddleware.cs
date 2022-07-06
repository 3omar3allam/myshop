using MyShop.Core.Common.Exceptions;
using MyShop.Core.Common.Models;
using System.Net;
using System.Text.Json;

namespace MyShop.Web.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        public RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var result = new ErrorResponse
            {
                Message = exception.Message
            };
            context.Response.ContentType = "application/json";
            var code = (int)HttpStatusCode.InternalServerError;
            switch (exception)
            {
                case ApiException apiException:
                    code = apiException.StatusCode;
                    break;
                case ValidationException validationException:
                    code = (int)HttpStatusCode.BadRequest;
                    result.ValidationErrors = validationException.Errors;
                    break;
                default:
                    break;
            }
            context.Response.StatusCode = code;

            var sResult = JsonSerializer.Serialize(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });

            return context.Response.WriteAsync(sResult);
        }
    }
}
