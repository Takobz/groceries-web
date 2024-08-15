using System.Net;
using Groceries.Core.Domain.DomainExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

namespace Groceries.Core.Application.Extensions
{
    public static class ApiGlobalExceptionHandler
    {
        public static void UseApiGlobalExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(c =>
            {
                c.Run(async context =>
                {
                    var exception = context.Features.GetRequiredFeature<IExceptionHandlerFeature>().Error;
                    if (exception is DomainValidationException)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsJsonAsync(new ProblemDetailsDTO(
                            "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                            "Bad Request",
                            400,
                            exception.Message));
                    }

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsJsonAsync(new ProblemDetailsDTO(
                        "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                        "Internal Server Error",
                        (int)HttpStatusCode.InternalServerError,
                        exception.Message));
                });
            });
        }
    }
}