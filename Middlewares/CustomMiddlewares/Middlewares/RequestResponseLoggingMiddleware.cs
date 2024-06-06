using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Log the request path
        _logger.LogInformation($"Request Path: {context.Request.Path}");

        // Call the next middleware in the pipeline
        await _next(context);

        // Log the response status code
        _logger.LogInformation($"Response Status Code: {context.Response.StatusCode}");
    }
}
