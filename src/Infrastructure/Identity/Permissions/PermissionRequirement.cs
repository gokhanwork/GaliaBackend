using Microsoft.AspNetCore.Authorization;

namespace Galia.Infrastructure.Identity.Permissions;

internal class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; private set; }

    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}
