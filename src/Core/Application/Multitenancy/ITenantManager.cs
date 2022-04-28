using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Shared.DTOs.Multitenancy;

namespace Galia.Application.Multitenancy;

public interface ITenantManager : ITransientService
{
    public Task<Result<TenantDto>> GetByKeyAsync(string key);

    public Task<Result<List<TenantDto>>> GetAllAsync();

    public Task<Result<object>> CreateTenantAsync(CreateTenantRequest request);

    Task<Result<object>> UpgradeSubscriptionAsync(UpgradeSubscriptionRequest request);

    Task<Result<object>> DeactivateTenantAsync(string tenant);

    Task<Result<object>> ActivateTenantAsync(string tenant);
}
