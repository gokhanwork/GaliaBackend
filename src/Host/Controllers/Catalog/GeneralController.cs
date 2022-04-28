using Galia.Application.Catalog.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galia.Host.Controllers.Catalog;
public class GeneralController : BaseController
{
    private readonly IGeneralService _generalService;

    public GeneralController(IGeneralService generalService)
    {
        _generalService = generalService;
    }

    [HttpGet("units")]
    public async Task<IActionResult> GetUnitsAll()
    {
        return Ok(await _generalService.GetAllUnitsAsync());
    }
}
