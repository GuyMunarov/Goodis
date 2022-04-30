using System.Net;

namespace Goodis.Helpers.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                if(error is ApplicationException)
                    await response.WriteAsync(error.Message);
                else
                    await response.WriteAsync("System Error");
            }
        }
    }
}