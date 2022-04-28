using System.Net;

namespace Galia.Application.Exceptions;

public class EntityAlreadyExistsException : CustomException
{
    public EntityAlreadyExistsException(string message)
    : base(message, null, HttpStatusCode.BadRequest)
    {
    }
}