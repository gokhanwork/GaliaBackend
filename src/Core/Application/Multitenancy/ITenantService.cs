using Galia.Application.Common.Interfaces;
using Galia.Shared.DTOs.Multitenancy;

namespace Galia.Application.Multitenancy;

public interface ITenantService : IScopedService
{
    public string GetDatabaseProvider();

    public string GetConnectionString();

    public TenantDto GetCurrentTenant();

    public void SetCurrentTenant(string tenant);
}
