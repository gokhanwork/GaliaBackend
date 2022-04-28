using Microsoft.AspNetCore.Authorization;

namespace Galia.Infrastructure.Identity.Permissions;

public class MustHavePermission : AuthorizeAttribute
{
    public MustHavePermission(string permission)
    {
        Policy = permission;
    }
}
