using Microsoft.AspNetCore.Mvc;

namespace Galia.Host.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseController : ControllerBase
{
}
