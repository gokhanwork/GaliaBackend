using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Shared.DTOs.Identity;

namespace Galia.Application.Abstractions.Services.Identity;

public interface ITokenService : ITransientService
{
    Task<IResult<TokenResponse>> GetTokenAsync(TokenRequest request, string ipAddress);

    Task<IResult<TokenResponse>> RefreshTokenAsync(RefreshTokenRequest request, string ipAddress);
}
