using GameTournamentApplication.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;

namespace GameTournamentWeb.ExceptionHandling
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(
            ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(
                exception,
                "Unhandled exception occurred");

            var error = Error.ServerError(
                "خطایی در سرور رخ داده است.");

            httpContext.Response.StatusCode =
                StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(
                error,
                cancellationToken);

            return true;
        }
    }
}
