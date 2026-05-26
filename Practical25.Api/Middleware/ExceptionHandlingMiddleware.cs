using System.Net;
using Practical25.Application.Exceptions;

namespace Practical25.Api.Middleware;

public sealed class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context).ConfigureAwait(false);
        }
        // Handle FluentValidation exceptions and return a structured error response.
        catch (ValidationException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new
            {
                Title = "Validation failed",
                Status = context.Response.StatusCode,
                Errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
            }).ConfigureAwait(false);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsJsonAsync(new
            {
                Title = "Resource not found",
                Status = context.Response.StatusCode,
                Detail = ex.Message
            }).ConfigureAwait(false);
        }
        catch (Exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(new
            {
                Title = "An unexpected error occurred",
                Status = context.Response.StatusCode
            }).ConfigureAwait(false);
        }
    }
}
