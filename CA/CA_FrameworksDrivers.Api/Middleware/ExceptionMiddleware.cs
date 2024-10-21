using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace CA_FrameworksDrivers.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {

                await HandleException(context, ex);
            }
        }

        private static async Task HandleException(HttpContext context, ValidationException exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var result =  JsonSerializer.Serialize(new
            {
                error = exception.Message,
                detail = exception.InnerException?.ToString()
            });

            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await response.WriteAsync(result);
        }
    }
}
