using Vegan.api.Exceptions.constraints;
using System.Net;

namespace Vegan.api.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) :
        base
            (
                ErrorCode.BAD_REQUEST,
                message,
                HttpStatusCode.NotFound,
                StatusCodes.Status404NotFound,
                null,
                DateTimeOffset.UtcNow,
                null
            )
        { }
    }
}
