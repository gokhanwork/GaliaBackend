using Galia.Application.Common.Interfaces;
using Galia.Application.Wrapper;
using Galia.Shared.DTOs.Auditing;

namespace Galia.Application.Auditing;

public interface IAuditService : ITransientService
{
    Task<IResult<IEnumerable<AuditResponse>>> GetUserTrailsAsync(Guid userId);
}
