using Galia.Application.Abstractions.Services.Identity;
using Galia.Application.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Galia.Host.Controllers.Identity;

[ApiController]
[Route("api/audit-logs")]
public class AuditLogsController : ControllerBase
{
    private readonly ICurrentUser _user;
    private readonly IAuditService _auditService;

    public AuditLogsController(IAuditService auditService, ICurrentUser user)
    {
        _auditService = auditService;
        _user = user;
    }

    [HttpGet]
    public async Task<IActionResult> GetMyLogsAsync()
    {
        return Ok(await _auditService.GetUserTrailsAsync(_user.GetUserId()));
    }
}
