using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Shared.DTOs.Identity;

namespace Galia.Application.Abstractions.Services.Identity;

public interface IRoleClaimsService : ITransientService
{
    public Task<bool> HasPermissionAsync(string userId, string permission);

    Task<Result<List<RoleClaimResponse>>> GetAllAsync();

    Task<int> GetCountAsync();

    Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

    Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

    Task<Result<string>> SaveAsync(RoleClaimRequest request);

    Task<Result<string>> DeleteAsync(int id);
}
