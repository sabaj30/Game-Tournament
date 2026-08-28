using GameTournamentApplication.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentWeb.ExceptionHandling
{
    public static class ErrorExtensions
    {
        public static IActionResult ToActionResult(this Error error)
        {
            return error.Code switch
            {
                ApplicationErrorCodes.NotFound =>
                    new NotFoundObjectResult(error),

                ApplicationErrorCodes.Validation =>
                    new BadRequestObjectResult(error),

                ApplicationErrorCodes.Conflict =>
                    new ConflictObjectResult(error),

                ApplicationErrorCodes.ServerError =>
                    new ObjectResult(error)
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    },

                _ =>
                    new BadRequestObjectResult(error)
            };
        }
    }
}
