using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTournamentApplication.Common.Errors
{
    public class Error
    {
        public string Code { get; }
        public string Message { get; }

        private Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static Error NotFound(string message) =>
            new(ApplicationErrorCodes.NotFound, message);

        public static Error Validation(string message) =>
            new(ApplicationErrorCodes.Validation, message);

        public static Error Conflict(string message) =>
            new(ApplicationErrorCodes.Conflict, message);

        public static Error ServerError(string message) =>
            new(ApplicationErrorCodes.ServerError, message);
    }
}
