using Galia.Infrastructure.Identity.Models;
using Galia.Shared.DTOs.Identity;
using Mapster;

namespace Galia.Infrastructure.Mappings;

public class MapsterSettings
{
    public static void Configure()
    {
        // here we will define the type conversion / Custom-mapping
        // More details at https://github.com/MapsterMapper/Mapster/wiki/Custom-mapping
        TypeAdapterConfig<ApplicationRoleClaim, PermissionDto>.NewConfig().Map(dest => dest.Permission, src => src.ClaimValue);
    }
}
