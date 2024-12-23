using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services
{
    public class GlobalExceptionHandler(IProblemDetailsService service) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var a = exception switch
            {
                ApplicationException => new ProblemDetails(),
                _ => new ProblemDetails()
                {
                    Status = 500,
                    Title = "Internal Error",
                    Type = exception.GetType().Name,
                    Instance = httpContext.Request.Method + " " + httpContext.Request.Path,


                }
            };
            await service.WriteAsync(new ProblemDetailsContext()
            {
                HttpContext = httpContext,
                ProblemDetails = a
            });
            return true;

        }
    }
}
