using Galia.Application.Exceptions;
using System.Net;

namespace Galia.Application.Multitenancy;

public class InvalidTenantException : CustomException
{
    public InvalidTenantException(string message)
    : base(message, null, HttpStatusCode.BadRequest)
    {
    }
}
