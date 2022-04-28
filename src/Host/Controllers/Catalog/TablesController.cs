using Galia.Application.Catalog.Interfaces;
using Galia.Domain.Constants;
using Galia.Infrastructure.Identity.Permissions;
using Galia.Shared.DTOs.Catalog.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Galia.Host.Controllers.Catalog;
public class TablesController : BaseController
{
    private readonly ITableService _tableService;

    public TablesController(ITableService tableService)
    {
        _tableService = tableService;
    }

    [HttpPost]
    [MustHavePermission(PermissionConstants.Tables.Register)]
    public async Task<IActionResult> CreateAsync(CreateTableRequest request)
    {
        return Ok(await _tableService.CreateTableAsync(request));
    }

    [HttpGet]
    [MustHavePermission(PermissionConstants.Tables.View)]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _tableService.GetAllTableAsync());
    }
}
