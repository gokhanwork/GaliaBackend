using System.Net;

namespace Galia.Application.Exceptions;

public class EntityNotFoundException : CustomException
{
    public EntityNotFoundException(string message)
    : base(message, null, HttpStatusCode.NotFound)
    {
    }
}
